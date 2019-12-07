using System;
using System.Net;
using System.Net.Sockets;

namespace S2Library.Network
{
    public delegate void SocketEventHandler(SocketWrapper sock);
    public delegate void SocketResultHandler(SocketWrapper sock, SocketResultCode result);
    public delegate void SocketErrorHandler(SocketWrapper sock, SocketResultCode result, SocketResultCode nativeError);
    public delegate void SocketReceiveHandler(SocketWrapper sock, byte[] data, int size);

    public enum SocketResultCode
    {
        OK,
        GeneralFailure,
        SocketError,
        SocketNotAvailableAnymore,
        AlreadyInitialized,
        CantCreateSocket,
        NotInitialized,
        AlreadyConnected,
        CantResolveHostname,
        CantConnect,
        BindFailed,
        ListenFailed,
        CantStartListener,
        NotSupportedOnOS,
        AcceptFailed,
        UnconnectedAccept,
        NotConnected,
        CantStartReceive,
        ReceiveFailed,
        IsListeningSocket,
        CantStartSend,
        SendFailed,

        WSAERRORCODES,

        WSAEINTR,
        WSAEACCES,
        WSAEFAULT,
        WSAEINVAL,
        WSAEMFILE,
        WSAEWOULDBLOCK,
        WSAEINPROGRESS,
        WSAEALREADY,
        WSAENOTSOCK,
        WSAEDESTADDRREQ,
        WSAEMSGSIZE,
        WSAEPROTOTYPE,
        WSAENOPROTOOPT,
        WSAEPROTONOSUPPORT,
        WSAESOCKTNOSUPPORT,
        WSAEOPNOTSUPP,
        WSAEPFNOSUPPORT,
        WSAEAFNOSUPPORT,
        WSAEADDRINUSE,
        WSAEADDRNOTAVAIL,
        WSAENETDOWN,
        WSAENETUNREACH,
        WSAENETRESET,
        WSAECONNABORTED,
        WSAECONNRESET,
        WSAENOBUFS,
        WSAEISCONN,
        WSAENOTCONN,
        WSAESHUTDOWN,
        WSAETIMEDOUT,
        WSAECONNREFUSED,
        WSAEHOSTDOWN,
        WSAEHOSTUNREACH,
        WSAEPROCLIM,
        WSASYSNOTREADY,
        WSAVERNOTSUPPORTED,
        WSANOTINITIALISED,
        WSAEDISCON,
        WSATYPE_NOT_FOUND,
        WSAHOST_NOT_FOUND,
        WSATRY_AGAIN,
        WSANO_RECOVERY,
        WSANO_DATA,
    }

    public class SocketWrapper
    {
        private static uint _idGenerator = 0;

        private readonly uint _id;
        private volatile Socket _socket;

        private bool _isListening;
        private bool _isIncoming;

        private byte[] _receiveBuffer;
        private SocketResultCode _lastSocketError;

        public readonly IPAddress NoAddress = new IPAddress(0);

        public event SocketEventHandler Connected;
        public event SocketResultHandler ConnectFailed;
        public event SocketResultHandler ConnectionError;
        public event SocketErrorHandler SocketError;
        public event SocketEventHandler Disconnected;
        public event SocketReceiveHandler Received;

        public uint Id => _id;

        public bool IsIncoming => _isIncoming;
        public bool IsOutgoing => !_isIncoming;

        public SocketResultCode LastSocketError => _lastSocketError;

        public IPEndPoint LocalAddress => _socket == null || !_socket.Connected ? null : _socket.LocalEndPoint as IPEndPoint;
        public IPEndPoint RemoteAddress => _socket == null || !_socket.Connected ? null : _socket.RemoteEndPoint as IPEndPoint;

        public SocketWrapper() : this(null)
        {
        }

        public SocketWrapper(Socket socket)
        {
            _id = ++_idGenerator;
            _socket = socket;
            _receiveBuffer = null;
            _isListening = false;
            _isIncoming = false;
        }

        public SocketResultCode Init()
        {
            _lastSocketError = SocketResultCode.OK;
            if (null != _socket)
            {
                return SocketResultCode.AlreadyInitialized;
            }

            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
            }
            catch (SocketException e)
            {
                _lastSocketError = SocketTools.NativeToSocketError(e.NativeErrorCode);
                return SocketResultCode.CantCreateSocket;
            }
            return SocketResultCode.OK;
        }

        public void Remove()
        {
            Disconnect();
        }

        public SocketResultCode Connect(string address, int port)
        {
            Socket sock;
            _lastSocketError = SocketResultCode.OK;

            lock (this)
            {
                if (null == _socket)
                {
                    return SocketResultCode.NotInitialized;
                }
                sock = _socket;
            }

            if (sock.Connected)
            {
                return SocketResultCode.AlreadyConnected;
            }

            var addr = GetIpForHostname(address);
            if (addr == NoAddress)
            {
                return SocketResultCode.CantResolveHostname;
            }

            var endpt = new IPEndPoint(addr, port);

            try
            {
                sock.BeginConnect(endpt, OnConnectCallback, sock);
            }
            catch (ObjectDisposedException)
            {
                return SocketResultCode.SocketNotAvailableAnymore;
            }
            catch (SocketException e)
            {
                _lastSocketError = SocketTools.NativeToSocketError(e.NativeErrorCode);
                return SocketResultCode.CantConnect;
            }
            catch (InvalidOperationException)
            {
                return SocketResultCode.CantConnect;
            }
            return SocketResultCode.OK;
        }

        private void OnConnectCallback(IAsyncResult ar)
        {
            var sock = (Socket)ar.AsyncState;

            try
            {
                sock.EndConnect(ar);
            }
            catch (ObjectDisposedException)
            {
                OnConnectFailed(SocketResultCode.SocketNotAvailableAnymore);
                return;
            }
            catch (SocketException e)
            {
                OnConnectFailed(SocketTools.NativeToSocketError(e.NativeErrorCode));
                return;
            }

            if (!sock.Connected)
            {
                OnConnectFailed(SocketResultCode.CantConnect);
                return;
            }

            OnConnected();

            var res = StartReceive();
            if (res == SocketResultCode.OK)
            {
                return;
            }

            OnSocketError(res, _lastSocketError);
            Disconnect();
        }

        public void Disconnect()
        {
            Disconnect(false);
        }

        private void Disconnect(bool forceCallback)
        {
            _lastSocketError = SocketResultCode.OK;

            bool wasConnected;
            lock (this)
            {
                if (null == _socket)
                {
                    return;
                }

                wasConnected = _socket.Connected;

                try
                {
                    _socket.Shutdown(SocketShutdown.Both);
                }
                catch (ObjectDisposedException)
                {
                    // EMPTY
                }
                catch (SocketException e)
                {
                    _lastSocketError = SocketTools.NativeToSocketError(e.NativeErrorCode);
                }

                _socket.Close();
                _socket = null;
                System.Threading.Thread.Yield();
            }

            if (wasConnected || forceCallback)
            {
                OnDisconnected();
            }
        }

        public SocketResultCode StartListen(string address, int port)
        {
            _lastSocketError = SocketResultCode.OK;

            Socket sock;
            lock (this)
            {
                if (null == _socket)
                {
                    return SocketResultCode.NotInitialized;
                }

                sock = _socket;
            }

            IPAddress addr;
            addr = address == null ? IPAddress.Any : GetIpForHostname(address);
            if (addr == NoAddress)
            {
                return SocketResultCode.CantResolveHostname;
            }

            var endPoint = new IPEndPoint(addr, port);
            try
            {
                sock.ExclusiveAddressUse = true;
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, false);
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
                sock.Bind(endPoint);
            }
            catch (ObjectDisposedException)
            {
                return SocketResultCode.SocketNotAvailableAnymore;
            }
            catch (SocketException e)
            {
                _lastSocketError = SocketTools.NativeToSocketError(e.NativeErrorCode);
                return SocketResultCode.BindFailed;
            }

            try
            {
                sock.Listen(16);
            }
            catch (ObjectDisposedException)
            {
                return SocketResultCode.SocketNotAvailableAnymore;
            }
            catch (SocketException e)
            {
                _lastSocketError = SocketTools.NativeToSocketError(e.NativeErrorCode);
                return SocketResultCode.ListenFailed;
            }

            _isListening = true;
            return StartAccept(sock);
        }

        private SocketResultCode StartAccept(Socket socket)
        {
            try
            {
                socket.BeginAccept(OnAcceptCallback, socket);
            }
            catch (ObjectDisposedException)
            {
                return SocketResultCode.SocketNotAvailableAnymore;
            }
            catch (SocketException e)
            {
                return SocketTools.NativeToSocketError(e.NativeErrorCode);
            }
            catch (InvalidOperationException)
            {
                return SocketResultCode.CantStartListener;
            }
            catch (NotSupportedException)
            {
                return SocketResultCode.NotSupportedOnOS;
            }
            return SocketResultCode.OK;
        }

        private void OnAcceptCallback(IAsyncResult ar)
        {
            var sock = (Socket)ar.AsyncState;

            Socket newSocket;
            try
            {
                newSocket = sock.EndAccept(ar);
            }
            catch (ObjectDisposedException)
            {
                OnConnectionError(SocketResultCode.SocketNotAvailableAnymore);
                Disconnect(true);
                return;
            }
            catch (SocketException)
            {
                OnConnectionError(SocketResultCode.AcceptFailed);
                Disconnect(true);
                return;
            }

            SocketResultCode res;
            if (!newSocket.Connected)
            {
                OnConnectionError(SocketResultCode.UnconnectedAccept);

                res = StartAccept(sock);
                if (res != SocketResultCode.OK)
                {
                    OnConnectionError(res);
                    Disconnect(true);
                }
                return;
            }

            var wrapper = new SocketWrapper(newSocket);
            wrapper._isIncoming = true;

            OnConnected(wrapper);
            wrapper.StartReceive();

            res = StartAccept(sock);
            if (res != SocketResultCode.OK)
            {
                OnConnectionError(res);
                Disconnect(true);
            }
        }

        public void EndListen()
        {
            Disconnect();
        }

        public SocketResultCode StartReceive()
        {
            _lastSocketError = SocketResultCode.OK;

            Socket sock;
            lock (this)
            {
                if (null == _socket)
                {
                    return SocketResultCode.NotInitialized;
                }
                sock = _socket;
            }

            if (!sock.Connected)
            {
                return SocketResultCode.NotConnected;
            }

            if (_isListening)
            {
                return SocketResultCode.IsListeningSocket;
            }

            if (null == _receiveBuffer)
            {
                _receiveBuffer = new byte[sock.ReceiveBufferSize];
            }

            try
            {
                sock.BeginReceive(_receiveBuffer, 0, _receiveBuffer.Length, SocketFlags.None, OnReceivedCallback, sock);
            }
            catch (ObjectDisposedException)
            {
                return SocketResultCode.SocketNotAvailableAnymore;
            }
            catch (SocketException e)
            {
                _lastSocketError = SocketTools.NativeToSocketError(e.NativeErrorCode);
                return SocketResultCode.CantStartReceive;
            }
            return SocketResultCode.OK;
        }

        private void OnReceivedCallback(IAsyncResult ar)
        {
            var sock = (Socket)ar.AsyncState;

            int readBytes;
            try
            {
                readBytes = sock.EndReceive(ar);
            }
            catch (ObjectDisposedException)
            {
                OnConnectionError(SocketResultCode.SocketNotAvailableAnymore);
                Disconnect(true);
                return;
            }
            catch (SocketException e)
            {
                OnSocketError(SocketResultCode.ReceiveFailed, SocketTools.NativeToSocketError(e.NativeErrorCode));
                Disconnect(true);
                return;
            }

            if (readBytes <= 0)
            {
                Disconnect(true);
                return;
            }
            OnReceived(_receiveBuffer, readBytes);

            try
            {
                sock.BeginReceive(_receiveBuffer, 0, _receiveBuffer.Length, SocketFlags.None, OnReceivedCallback, sock);
            }
            catch (ObjectDisposedException)
            {
                OnConnectionError(SocketResultCode.SocketNotAvailableAnymore);
                Disconnect(true);
            }
            catch (SocketException e)
            {
                OnSocketError(SocketResultCode.CantStartReceive, SocketTools.NativeToSocketError(e.NativeErrorCode));
                Disconnect(true);
            }
        }

        public SocketResultCode SendData(byte[] buffer)
        {
            _lastSocketError = SocketResultCode.OK;

            Socket sock;
            lock (this)
            {
                if (null == _socket)
                {
                    return SocketResultCode.NotInitialized;
                }

                sock = _socket;
            }

            if (!sock.Connected)
            {
                return SocketResultCode.NotConnected;
            }
            if (_isListening)
            {
                return SocketResultCode.IsListeningSocket;
            }

            try
            {
                sock.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, OnSentCallback, sock);
            }
            catch (ObjectDisposedException)
            {
                return SocketResultCode.SocketNotAvailableAnymore;
            }
            catch (SocketException e)
            {
                _lastSocketError = SocketTools.NativeToSocketError(e.NativeErrorCode);
                return SocketResultCode.CantStartSend;
            }
            return SocketResultCode.OK;
        }

        private void OnSentCallback(IAsyncResult ar)
        {
            var sock = (Socket)ar.AsyncState;
            if (!sock.Connected)
            {
                Disconnect(true);
                return;
            }

            int sentBytes;
            try
            {
                sentBytes = sock.EndSend(ar);
            }
            catch (ObjectDisposedException)
            {
                OnConnectionError(SocketResultCode.SocketNotAvailableAnymore);
                Disconnect(true);
            }
            catch (SocketException e)
            {
                OnSocketError(SocketResultCode.SendFailed, SocketTools.NativeToSocketError(e.NativeErrorCode));
                Disconnect(true);
            }
        }

        public IPAddress GetIpForHostname(string hostname)
        {
            var addr = NoAddress;

            if (hostname == "0.0.0.0")
            {
                return IPAddress.Any;
            }
            if (hostname == "::0")
            {
                return IPAddress.IPv6Any;
            }

            IPHostEntry hostEntry;
            try
            {
                hostEntry = Dns.GetHostEntry(hostname);
            }
            catch (SocketException)
            {
                return addr;
            }
            catch (ArgumentOutOfRangeException)
            {
                return addr;
            }
            catch (ArgumentException)
            {
                return addr;
            }

            if (hostEntry.AddressList.Length > 0)
            {
                foreach (IPAddress address in hostEntry.AddressList)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        addr = address;
                    }
                }

                /*
                foreach (IPAddress address in hostEntry.AddressList)
                {
                    if (address.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        addr = address;
                    }
                }
                */
            }
            return addr;
        }

        public string[] GetLocalIpAddresses()
        {
            IPHostEntry hostEntry;
            try
            {
                hostEntry = Dns.GetHostEntry(string.Empty);
            }
            catch (SocketException)
            {
                return null;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }

            string[] addresses = new string[hostEntry.AddressList.Length];
            for (int i = 0; i < addresses.Length; ++i)
            {
                addresses[i] = hostEntry.AddressList[i].ToString();
            }
            return addresses;
        }

        protected void OnConnected()
        {
            OnConnected(this);
        }

        protected void OnConnected(SocketWrapper sock)
        {
            Connected?.Invoke(sock);
        }

        protected void OnConnectFailed(SocketResultCode result)
        {
            ConnectFailed?.Invoke(this, result);
        }

        protected void OnConnectionError(SocketResultCode result)
        {
            ConnectionError?.Invoke(this, result);
        }

        protected void OnSocketError(SocketResultCode result, SocketResultCode nativeError)
        {
            SocketError?.Invoke(this, result, nativeError);
        }

        protected void OnDisconnected()
        {
            Disconnected?.Invoke(this);
        }

        protected void OnReceived(byte[] data, int size)
        {
            Received?.Invoke(this, data, size);
        }
    }
}
