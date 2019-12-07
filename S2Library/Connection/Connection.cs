using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using S2Library.Network;

namespace S2Library.Connection
{
    public class Connection
    {
        private readonly ConnectionManager _manager;
        private SocketWrapper _socket;
        private Thread _connectionThread;
        private volatile ConnectionState _state;

        private volatile Queue<byte[]> _receiveQueue;
        private readonly MemoryStream _sendStream;

        private readonly ConnectionEventArgs _connectionEvent;
        private readonly ConnectionResultArgs _connectionLostArgs;
        private readonly ConnectionReceiveArgs _receiveArgs;

        public event ConnectionEventHandler Disconnected;
        public event ConnectionResultHandler ConnectionLost;
        public event ConnectionReceiveHandler Received;
        public event ConnectionEventHandler ThreadTick;

        public uint Id => _socket?.Id ?? 0;
        public ConnectionManager Manager => _manager;

        public bool IsIncomingConnection => _socket?.IsIncoming ?? false;
        public bool IsConnected => _state == ConnectionState.Connected;

        public byte[] RemoteIpHash => Socket?.RemoteAddress?.Address.GetAddressBytes();

        internal SocketWrapper Socket => _socket;

        public object CustomData
        {
            get; set;
        }

        public ConnectionState State
        {
            get
            {
                return _state;
            }
            internal set
            {
                _state = value;
            }
        }

        internal Connection(ConnectionManager mgr) : this(mgr, new SocketWrapper())
        {
            _state = ConnectionState.NotConnected;
        }

        internal Connection(ConnectionManager mgr, SocketWrapper sock)
        {
            _manager = mgr;
            _socket = sock;
            _state = ConnectionState.Connected;

            _receiveQueue = new Queue<byte[]>();

            _socket.ConnectionError += SocketErrorHandler;
            _socket.SocketError += SocketNativeErrorHandler;
            _socket.Disconnected += SocketDisconnectHandler;
            _socket.Received += ReceiveDataHandler;

            _sendStream = new MemoryStream();

            _connectionEvent = new ConnectionEventArgs(this);
            _connectionLostArgs = new ConnectionResultArgs(this, ConnectionResult.Unknown);
            _receiveArgs = new ConnectionReceiveArgs(this, null);

            CustomData = null;

            var threadStart = new ThreadStart(ConnectionThread);
            _connectionThread = new Thread(threadStart, 512 * 1024);
        }

        private void ConnectionThread()
        {
            while (_state != ConnectionState.Terminating)
            {
                ProcessConnection();
                OnThreadTick();
                Thread.Sleep(10);
            }

            OnDisconnected();

            _socket.Remove();
            _socket.Received -= ReceiveDataHandler;
            _socket.Disconnected -= SocketDisconnectHandler;
            _socket.SocketError -= SocketNativeErrorHandler;
            _socket.ConnectionError -= SocketErrorHandler;

            _receiveQueue.Clear();
            _manager.RemoveConnection(this);
            _state = ConnectionState.Terminated;
        }

        internal void StartConnectionProcessing()
        {
            _connectionThread.Start();
        }

        internal void Shutdown()
        {
            _socket?.Remove();

            var count = 2;
            if (_connectionThread != null)
            {
                _state = ConnectionState.Terminating;
                while (count-- > 0 && _state == ConnectionState.Terminating)
                {
                    Thread.Sleep(10);
                }

                if (_state != ConnectionState.Terminated)
                {
                    _connectionThread.Abort();
                    _connectionThread = null;
                    _state = ConnectionState.Terminated;
                }
            }

            _manager.RemoveConnection(this);
            _socket = null;
        }

        public ConnectionResult Send(byte[] message)
        {
            if (_state != ConnectionState.Connected)
            {
                return ConnectionResult.NotConnected;
            }

            lock (_sendStream)
            {
                _sendStream.Write(message, 0, message.Length);
            }
            return ConnectionResult.OK;
        }

        public void SendToAll(byte[] message)
        {
            _manager.SendToAllExcept(message, 0);
        }

        public void SendToAllExcept(byte[] message, uint exceptId)
        {
            _manager.SendToAllExcept(message, exceptId);
        }

        public void Disconnect()
        {
            _socket?.Disconnect();
        }

        private void ReceiveDataHandler(SocketWrapper sock, byte[] data, int size)
        {
            var msg = new byte[size];
            Array.Copy(data, msg, size);
            lock (_receiveQueue)
            {
                _receiveQueue.Enqueue(msg);
            }
        }

        private void SocketErrorHandler(SocketWrapper sock, SocketResultCode result)
        {
            SocketNativeErrorHandler(sock, result, SocketResultCode.GeneralFailure);
        }

        private void SocketNativeErrorHandler(SocketWrapper sock, SocketResultCode result, SocketResultCode nativeError)
        {
            lock (_receiveQueue)
            {
                _receiveQueue.Enqueue(null);

                var resultInt = (int)result;
                var resultBytes = BitConverter.GetBytes(resultInt);
                _receiveQueue.Enqueue(resultBytes);

                resultInt = (int)nativeError;
                resultBytes = BitConverter.GetBytes(resultInt);
                _receiveQueue.Enqueue(resultBytes);
            }
        }

        private void SocketDisconnectHandler(SocketWrapper sock)
        {
            _state = ConnectionState.Disconnecting;
            lock (_receiveQueue)
            {
                _receiveQueue.Enqueue(null);
                _receiveQueue.Enqueue(new byte[0]);
            }
        }

        private void ProcessConnection()
        {
            var processReceive = true;
            var processSend = true;
            var processCount = 100;

            while (processCount-- > 0 && (processReceive || processSend))
            {
                processReceive = ProcessReceiving();
                processSend = ProcessSending();
            }
        }

        private bool ProcessReceiving()
        {
            if (_receiveQueue.Count == 0)
            {
                return false;
            }

            byte[] packet;
            lock (_receiveQueue)
            {
                packet = _receiveQueue.Dequeue();
            }

            if (packet == null)
            {
                return HandleReceiveError();
            }
            return ProcessReceivedPacket(packet) == SocketResultCode.OK;
        }

        private bool ProcessSending()
        {
            byte[] packet;

            lock (_sendStream)
            {
                if (_state != ConnectionState.Connected || _sendStream.Length == 0)
                {
                    return false;
                }

                packet = _sendStream.ToArray();
                _sendStream.SetLength(0);
                _sendStream.Position = 0;
            }

            var res = _socket.SendData(packet);
            if (res == SocketResultCode.OK)
            {
                return true;
            }

            SocketErrorHandler(_socket, res);
            return false;
        }

        private SocketResultCode ProcessReceivedPacket(byte[] packet)
        {
            OnReceived(packet);
            return SocketResultCode.OK;
        }

        private bool HandleReceiveError()
        {
            if (_receiveQueue.Count < 1)
            {
                return true;
            }

            var errorCode = SocketResultCode.GeneralFailure;
            var nativeError = SocketResultCode.GeneralFailure;

            lock (_receiveQueue)
            {
                var errorBytes = _receiveQueue.Dequeue();
                if (errorBytes != null)
                {
                    if (errorBytes.Length == 0)
                    {
                        _state = ConnectionState.Disconnected;
                        _state = ConnectionState.Terminating;
                        return false;
                    }

                    if (errorBytes.Length == 4)
                    {
                        errorCode = (SocketResultCode)BitConverter.ToInt32(errorBytes, 0);
                    }
                }

                if (_receiveQueue.Count >= 1)
                {
                    errorBytes = _receiveQueue.Dequeue();
                    if (errorBytes != null && errorBytes.Length == 4)
                    {
                        nativeError = (SocketResultCode)BitConverter.ToInt32(errorBytes, 0);
                    }
                }
            }

            ConnectionResult res = Converter.SockResToConnRes(nativeError != SocketResultCode.GeneralFailure ? nativeError : errorCode);
            if (res == ConnectionResult.SocketIsShutdown)
            {
                return false;
            }

            if (_state == ConnectionState.Connected ||
              _state == ConnectionState.Disconnecting ||
              _state == ConnectionState.Terminating)
            {
                OnConnectionLost(res);
            }
            return true;
        }

        protected void OnDisconnected()
        {
            Disconnected?.Invoke(_connectionEvent);
        }

        protected void OnConnectionLost(ConnectionResult reason)
        {
            _connectionLostArgs.Result = reason;
            ConnectionLost?.Invoke(_connectionLostArgs);
        }

        protected void OnReceived(byte[] data)
        {
            _receiveArgs.Data = data;
            Received?.Invoke(_receiveArgs);
        }

        protected void OnThreadTick()
        {
            ThreadTick?.Invoke(_connectionEvent);
        }
    }
}
