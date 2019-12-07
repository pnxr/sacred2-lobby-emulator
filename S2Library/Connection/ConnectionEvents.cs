namespace S2Library.Connection
{
    public delegate void ConnectionEventHandler(ConnectionEventArgs args);
    public delegate void ConnectionResultHandler(ConnectionResultArgs args);
    public delegate void ConnectionReceiveHandler(ConnectionReceiveArgs args);

    public class ConnectionEventArgs
    {
        public Connection Conn
        {
            get;
        }

        internal ConnectionEventArgs(Connection conn)
        {
            Conn = conn;
        }
    }

    public class ConnectionResultArgs : ConnectionEventArgs
    {
        public ConnectionResult Result
        {
            get; internal set;
        }

        internal ConnectionResultArgs(Connection conn, ConnectionResult result)
          : base(conn)
        {
            Result = result;
        }
    }

    public class ConnectionReceiveArgs : ConnectionEventArgs
    {
        public byte[] Data
        {
            get; internal set;
        }

        internal ConnectionReceiveArgs(Connection conn, byte[] data)
          : base(conn)
        {
            Data = data;
        }
    }
}
