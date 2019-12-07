namespace S2Library.Protocol
{
    public class MessageContainer
    {
        public enum Types : int
        {
            ApplicationMessage = 2,
            HandshakeConnect = 3,
            HandShakeConnected = 5,
            Ping = 11,
        }

        public uint Magic { get; set; }
        public uint From { get; set; }
        public uint To { get; set; }
        public Types Type { get; set; }
        public int Unknown1 { get; set; }
        public int PayloadSize { get; set; }
        public uint PayloadChecksum { get; set; }
        public byte[] Payload { get; set; }

        public const uint ConnectionUnknown = 0xEFFFFFEE;
        public const uint ConnectionServer = 0xEFFFFFCC;
        public const int PrefixSize = 0x1C;
        public const uint MagicNumber = 0xDABAFBEF;
    }
}
