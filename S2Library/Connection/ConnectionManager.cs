using System.Collections.Generic;
using S2Library.Network;

namespace S2Library.Connection
{
    public class ConnectionManager
    {
        private readonly Dictionary<uint, Connection> _connections;
        private ManagerMode _mode;

        private string _serverAddress;
        private uint _serverPort;
        private SocketWrapper _listenSocket;

        public event ConnectionEventHandler Connected;
        public event ConnectionResultHandler ConnectFailed;

        public bool IsInitialized => _mode != ManagerMode.NotDefined;
        public bool IsClient => _mode == ManagerMode.Client;
        public bool IsServer => _mode == ManagerMode.Server;

        public string ServerBindAddress => _serverAddress;
        public uint ServerListenPort => _serverPort;

        public Connection[] AllConnections
        {
            get
            {
                lock (_connections)
                {
                    var conns = new Connection[_connections.Count];
                    _connections.Values.CopyTo(conns, 0);
                    return conns;
                }
            }
        }

        public ConnectionManager()
        {
            _connections = new Dictionary<uint, Connection>();
            _mode = ManagerMode.NotDefined;
            _listenSocket = null;
        }

        public ConnectionResult InitClient()
        {
            if (_mode != ManagerMode.NotDefined)
            {
                return ConnectionResult.AlreadyInitialized;
            }
            _mode = ManagerMode.Client;
            return ConnectionResult.OK;
        }

        public ConnectionResult InitServer(string bindAddress, uint listenPort)
        {
            if (_mode != ManagerMode.NotDefined)
            {
                return ConnectionResult.AlreadyInitialized;
            }

            _listenSocket = new SocketWrapper();
            var res = _listenSocket.Init();
            if (res != SocketResultCode.OK)
            {
                _listenSocket = null;
                return Converter.SockResToConnRes(res);
            }

            _mode = ManagerMode.Server;
            _listenSocket.Connected += OnListenSocketConnected;
            _listenSocket.ConnectionError += OnListenSocketConnectionError;

            res = _listenSocket.StartListen(bindAddress, (int)listenPort);
            if (res != SocketResultCode.OK)
            {
                if (res == SocketResultCode.BindFailed || res == SocketResultCode.ListenFailed)
                {
                    res = _listenSocket.LastSocketError;
                }
                _listenSocket.Remove();
                _listenSocket = null;
                return Converter.SockResToConnRes(res);
            }

            _serverAddress = bindAddress;
            _serverPort = listenPort;
            return ConnectionResult.OK;
        }

        public void Shutdown()
        {
            if (_mode == ManagerMode.NotDefined)
            {
                return;
            }
            _mode = ManagerMode.NotDefined;
            _listenSocket?.Remove();

            var conns = AllConnections;
            foreach (var conn in conns)
            {
                conn.Shutdown();
            }
        }

        public ConnectionResult Connect(string address, uint port, out Connection conn)
        {
            conn = null;
            if (_mode == ManagerMode.NotDefined)
            {
                return ConnectionResult.CantConnect;
            }

            var connection = CreateConnection(null);
            conn = connection;
            connection.Socket.Connected += OnNewSocketConnected;
            connection.Socket.ConnectFailed += OnNewSocketConnectFailed;
            connection.State = ConnectionState.Connecting;

            var res = connection.Socket.Init();
            if (res != SocketResultCode.OK)
            {
                RemoveConnection(connection);
                conn = null;
                return Converter.SockResToConnRes(res);
            }

            res = connection.Socket.Connect(address, (int)port);
            if (res == SocketResultCode.OK)
            {
                return ConnectionResult.OK;
            }

            connection.Shutdown();
            conn = null;
            return Converter.SockResToConnRes(res);
        }

        public void DisconnectAll()
        {
            lock (_connections)
            {
                foreach (var conn in _connections.Values)
                {
                    conn.Disconnect();
                }
                _connections.Clear();
            }
        }

        private Connection GetConnection(SocketWrapper sock)
        {
            return GetConnection(sock.Id);
        }

        public Connection GetConnection(uint id)
        {
            Connection conn;
            lock (_connections)
            {
                _connections.TryGetValue(id, out conn);
            }
            return conn;
        }

        protected void OnConnected(Connection conn)
        {
            ConnectionEventArgs args = new ConnectionEventArgs(conn);
            Connected?.Invoke(args);
        }

        protected void OnConnectFailed(Connection conn, ConnectionResult result)
        {
            ConnectionResultArgs args = new ConnectionResultArgs(conn, result);
            ConnectFailed?.Invoke(args);
        }

        private void OnListenSocketConnected(SocketWrapper sock)
        {
            Connection conn = CreateConnection(sock);
            conn.State = ConnectionState.Connected;
            OnConnected(conn);
            conn.StartConnectionProcessing();
        }

        private void OnListenSocketConnectionError(SocketWrapper sock, SocketResultCode result)
        {
            //OnConnectFailed( null, ConnectionResult.CantStartListeningSocket );
        }

        private void OnNewSocketConnected(SocketWrapper sock)
        {
            var conn = GetConnection(sock);
            sock.Connected -= OnNewSocketConnected;
            sock.ConnectFailed -= OnNewSocketConnectFailed;
            conn.State = ConnectionState.Connected;
            OnConnected(conn);
            conn.StartConnectionProcessing();
        }

        private void OnNewSocketConnectFailed(SocketWrapper sock, SocketResultCode result)
        {
            var conn = GetConnection(sock);
            sock.Connected -= OnNewSocketConnected;
            sock.ConnectFailed -= OnNewSocketConnectFailed;
            OnConnectFailed(conn, Converter.SockResToConnRes(result));
            conn.Shutdown();
        }

        internal void SendToAllExcept(byte[] message, uint except)
        {
            var conns = AllConnections;
            if (except == 0)
            {
                foreach (var conn in conns)
                {
                    if (conn.IsIncomingConnection)
                    {
                        conn.Send(message);
                    }
                }
            }
            else
            {
                foreach (var conn in conns)
                {
                    if (conn.IsIncomingConnection && conn.Id != except)
                    {
                        conn.Send(message);
                    }
                }
            }
        }

        private Connection CreateConnection(SocketWrapper sock)
        {
            var conn = sock == null ? new Connection(this) : new Connection(this, sock);
            lock (_connections)
            {
                _connections.Add(conn.Id, conn);
            }
            return conn;
        }

        internal void RemoveConnection(Connection conn)
        {
            if (conn == null)
            {
                return;
            }
            lock (_connections)
            {
                _connections.Remove(conn.Id);
            }
        }
    }
}
