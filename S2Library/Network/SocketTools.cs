namespace S2Library.Network
{
    public static class SocketTools
    {
        public static SocketResultCode NativeToSocketError(int error)
        {
            switch (error)
            {
                case 10004:
                    return SocketResultCode.WSAEINTR;
                case 10013:
                    return SocketResultCode.WSAEACCES;
                case 10014:
                    return SocketResultCode.WSAEFAULT;
                case 10022:
                    return SocketResultCode.WSAEINVAL;
                case 10024:
                    return SocketResultCode.WSAEMFILE;
                case 10035:
                    return SocketResultCode.WSAEWOULDBLOCK;
                case 10036:
                    return SocketResultCode.WSAEINPROGRESS;
                case 10037:
                    return SocketResultCode.WSAEALREADY;
                case 10038:
                    return SocketResultCode.WSAENOTSOCK;
                case 10039:
                    return SocketResultCode.WSAEDESTADDRREQ;
                case 10040:
                    return SocketResultCode.WSAEMSGSIZE;
                case 10041:
                    return SocketResultCode.WSAEPROTOTYPE;
                case 10042:
                    return SocketResultCode.WSAENOPROTOOPT;
                case 10043:
                    return SocketResultCode.WSAEPROTONOSUPPORT;
                case 10044:
                    return SocketResultCode.WSAESOCKTNOSUPPORT;
                case 10045:
                    return SocketResultCode.WSAEOPNOTSUPP;
                case 10046:
                    return SocketResultCode.WSAEPFNOSUPPORT;
                case 10047:
                    return SocketResultCode.WSAEAFNOSUPPORT;
                case 10048:
                    return SocketResultCode.WSAEADDRINUSE;
                case 10049:
                    return SocketResultCode.WSAEADDRNOTAVAIL;
                case 10050:
                    return SocketResultCode.WSAENETDOWN;
                case 10051:
                    return SocketResultCode.WSAENETUNREACH;
                case 10052:
                    return SocketResultCode.WSAENETRESET;
                case 10053:
                    return SocketResultCode.WSAECONNABORTED;
                case 10054:
                    return SocketResultCode.WSAECONNRESET;
                case 10055:
                    return SocketResultCode.WSAENOBUFS;
                case 10056:
                    return SocketResultCode.WSAEISCONN;
                case 10057:
                    return SocketResultCode.WSAENOTCONN;
                case 10058:
                    return SocketResultCode.WSAESHUTDOWN;
                case 10060:
                    return SocketResultCode.WSAETIMEDOUT;
                case 10061:
                    return SocketResultCode.WSAECONNREFUSED;
                case 10064:
                    return SocketResultCode.WSAEHOSTDOWN;
                case 10065:
                    return SocketResultCode.WSAEHOSTUNREACH;
                case 10067:
                    return SocketResultCode.WSAEPROCLIM;
                case 10091:
                    return SocketResultCode.WSASYSNOTREADY;
                case 10092:
                    return SocketResultCode.WSAVERNOTSUPPORTED;
                case 10093:
                    return SocketResultCode.WSANOTINITIALISED;
                case 10101:
                    return SocketResultCode.WSAEDISCON;
                case 10109:
                    return SocketResultCode.WSATYPE_NOT_FOUND;
                case 11001:
                    return SocketResultCode.WSAHOST_NOT_FOUND;
                case 11002:
                    return SocketResultCode.WSATRY_AGAIN;
                case 11003:
                    return SocketResultCode.WSANO_RECOVERY;
                case 11004:
                    return SocketResultCode.WSANO_DATA;
            }
            return SocketResultCode.GeneralFailure;
        }
    }
}
