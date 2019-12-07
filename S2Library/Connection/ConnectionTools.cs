using System;
using S2Library.Network;

namespace S2Library.Connection
{
    internal enum ManagerMode
    {
        NotDefined,
        Client,
        Server,
    }

    public enum ConnectionState : uint
    {
        NotConnected,
        Connecting,
        Connected,
        Disconnecting,
        Disconnected,
        Terminating,
        Terminated,

        Broken,
        Reconnecting,
    }

    public enum ConnectionResult
    {
        Unknown,
        OK,

        CantSend,
        CantConnect,
        NotConnected,
        AlreadyConnected,
        AlreadyInitialized,
        CantResolveHostname,
        CantStartListeningSocket,

        Timeout,
        AddressInUse,
        InvalidArguments,
        SocketIsShutdown,
        ConnectionRefused,
        ConnectionAborted,
        ConnectionResetByPeer,
    }

    public enum ConnectionEvent
    {
        None,
        Connected,
        ConnectFailed,
        Disconnected,
        ConnectionLost,
    }

    internal static class Converter
    {
        public static ConnectionResult SockResToConnRes(SocketResultCode res)
        {
            switch (res)
            {
                case SocketResultCode.CantResolveHostname:
                    return ConnectionResult.CantResolveHostname;
                case SocketResultCode.NotConnected:
                    return ConnectionResult.NotConnected;
                case SocketResultCode.CantStartSend:
                    return ConnectionResult.CantSend;

                case SocketResultCode.WSAECONNREFUSED:
                    return ConnectionResult.ConnectionRefused;
                case SocketResultCode.WSAEADDRINUSE:
                    return ConnectionResult.AddressInUse;
                case SocketResultCode.WSAECONNRESET:
                    return ConnectionResult.ConnectionResetByPeer;
                case SocketResultCode.WSAETIMEDOUT:
                    return ConnectionResult.Timeout;
                case SocketResultCode.WSAESHUTDOWN:
                    return ConnectionResult.SocketIsShutdown;
                case SocketResultCode.WSAECONNABORTED:
                    return ConnectionResult.ConnectionAborted;
                case SocketResultCode.WSAEINVAL:
                    return ConnectionResult.InvalidArguments;
            }
            Console.WriteLine("Unresolved error code: {0}", res);
            return ConnectionResult.Unknown;
        }
    }
}
