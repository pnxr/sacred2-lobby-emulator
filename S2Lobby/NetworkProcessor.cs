using System;
using System.Collections.Concurrent;
using System.IO;

using S2Library.Protocol;

namespace S2Lobby
{
    public class NetworkProcessor
    {
        private enum State
        {
            Prefix,
            Payload
        }

        protected readonly Program Program;
        protected readonly uint Connection;

        private MemoryStream _receiver = new MemoryStream();
        private readonly MemoryStream _sender = new MemoryStream();

        private readonly object _sync = new object();

        private State _state;
        protected readonly MessageContainer Message = new MessageContainer();

        public NetworkProcessor(Program program, uint connection)
        {
            Program = program;
            Connection = connection;
            _state = State.Prefix;
        }

        public virtual void Close()
        {
        }

        public void Receive(byte[] data)
        {
            _receiver.Seek(0, SeekOrigin.End);
            _receiver.Write(data, 0, data.Length);

            bool handled = true;
            while (handled)
            {
                handled = false;

                switch (_state)
                {
                    case State.Prefix:
                        {
                            if (_receiver.Length >= MessageContainer.PrefixSize)
                            {
                                _receiver.Seek(0, SeekOrigin.Begin);
                                BinaryReader reader = new BinaryReader(_receiver);

                                Message.Magic = reader.ReadUInt32();
                                Message.From = reader.ReadUInt32();
                                Message.To = reader.ReadUInt32();
                                Message.Type = (MessageContainer.Types)reader.ReadInt32();
                                Message.Unknown1 = reader.ReadInt32();
                                Message.PayloadSize = reader.ReadInt32();
                                Message.PayloadChecksum = reader.ReadUInt32();

                                MemoryStream newReceiver = new MemoryStream();
                                if (_receiver.Length > MessageContainer.PrefixSize)
                                {
                                    _receiver.CopyTo(newReceiver);
                                }

                                _receiver = newReceiver;
                                _state = State.Payload;
                                handled = true;
                            }
                        }
                        break;
                    case State.Payload:
                        {
                            if (_receiver.Length >= Message.PayloadSize)
                            {
                                _receiver.Seek(0, SeekOrigin.Begin);
                                Message.Payload = new byte[Message.PayloadSize];
                                _receiver.Read(Message.Payload, 0, Message.PayloadSize);

                                MemoryStream newReceiver = new MemoryStream();
                                if (_receiver.Length > Message.PayloadSize)
                                {
                                    _receiver.CopyTo(newReceiver);
                                }

                                _receiver = newReceiver;
                                _state = State.Prefix;

                                HandlePacket();
                                handled = true;
                            }
                        }
                        break;
                }
            }
        }

        public void Process(ConcurrentQueue<byte[]> outgoingQueue)
        {
            lock (_sync)
            {
                if (_sender.Length < 1)
                {
                    return;
                }

                byte[] data = _sender.ToArray();
                _sender.SetLength(0);
                outgoingQueue.Enqueue(data);
            }
        }

        private void AddToSendBuffer(Action<BinaryWriter> writeAction)
        {
            lock (_sync)
            {
                _sender.Seek(0, SeekOrigin.End);
                BinaryWriter writer = new BinaryWriter(_sender);
                writeAction.Invoke(writer);
            }
        }

        private void HandlePacket()
        {
            if (Message.Magic != MessageContainer.MagicNumber)
            {
                Program.Log($" Incorrect packet magic, is {Message.Magic:X08} but should be {MessageContainer.MagicNumber:X08}");
            }
            if (Message.To != MessageContainer.ConnectionServer)
            {
                Program.Log($" Incorrect receiver id, is {Message.To:X08} but should be {MessageContainer.ConnectionServer:X08}");
            }

            uint crc32 = Crc32.Calculate(Message.Payload);
            if (crc32 != Message.PayloadChecksum)
            {
                Program.Log($" Incorrect checksum, is {Message.PayloadChecksum:X08} but should be {crc32:X08}");
            }

            Program.LogDebug(" === Packet received ===");
            Program.LogDebug($"  {nameof(Message.Magic)}: {Message.Magic:X08}");
            Program.LogDebug($"  {nameof(Message.From)}: {Message.From:X08}");
            Program.LogDebug($"  {nameof(Message.To)}: {Message.To:X08}");
            Program.LogDebug($"  {nameof(Message.Type)}: {Message.Type}");
            Program.LogDebug($"  {nameof(Message.Unknown1)}: {Message.Unknown1:X08}");
            Program.LogDebug($"  {nameof(Message.PayloadSize)}: {Message.PayloadSize}");
            Program.LogDebug($"  {nameof(Message.PayloadChecksum)}: {Message.PayloadChecksum:X08}");
            Program.LogDebug($"  {nameof(Message.Payload)}: {Serializer.DumpBytes(Message.Payload)}");

            HandlePayload();
        }

        private void HandlePayload()
        {
            if (Message.Type == MessageContainer.Types.HandshakeConnect)
            {
                if (Message.Payload.Length != HandshakeMessage.MessageSize)
                {
                    Program.Log($" Incorrect handshake connect message size, is {Message.Payload.Length} but should be {HandshakeMessage.MessageSize}");
                }
                if (Message.From != MessageContainer.ConnectionUnknown)
                {
                    Program.Log($" Incorrect sender id, is {Message.From:X08} but should be {MessageContainer.ConnectionUnknown:X08}");
                }

                MemoryStream readStream = new MemoryStream(Message.Payload);
                BinaryReader reader = new BinaryReader(readStream);

                HandshakeMessage handshake = new HandshakeMessage();
                handshake.Magic = reader.ReadUInt32();
                handshake.ConnectionId = reader.ReadUInt32();
                handshake.Username = reader.ReadBytes(HandshakeMessage.UsernameSize);
                handshake.Password = reader.ReadBytes(HandshakeMessage.PasswordSize);
                handshake.Unknown1 = reader.ReadInt32();

                if (handshake.Magic != HandshakeMessage.MagicNumber)
                {
                    Program.Log($" Incorrect handshake magic, is {handshake.Magic:X08} but should be {HandshakeMessage.MagicNumber:X08}");
                }

                handshake.Magic = HandshakeMessage.MagicNumber;
                handshake.ConnectionId = Connection;
                handshake.Password = HandshakeMessage.ReplyPassword;

                MemoryStream writeStream = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(writeStream);

                writer.Write(handshake.Magic);
                writer.Write(handshake.ConnectionId);
                writer.Write(handshake.Username);
                writer.Write(handshake.Password);
                writer.Write(handshake.Unknown1);

                SendReply(MessageContainer.Types.HandShakeConnected, writeStream);

                writer.Close();
                writeStream.Close();

                HandleInitialReply();
            }
            else if (Message.Type == MessageContainer.Types.ApplicationMessage)
            {
                MemoryStream readStream = new MemoryStream(Message.Payload);
                BinaryReader reader = new BinaryReader(readStream);

                MemoryStream writeStream = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(writeStream);

                HandleMessage(reader, writer);

                writer.Close();
                writeStream.Close();

                reader.Close();
                readStream.Close();
            }
            else if (Message.Type == MessageContainer.Types.Ping)
            {
                Program.LogDebug($" PING");
            }
            else
            {
                Program.Log($" Unknown prefix message type: {Message.Type}");
            }
        }

        protected virtual void HandleInitialReply()
        {
        }

        protected virtual void HandleMessage(BinaryReader reader, BinaryWriter writer)
        {
            Program.Log(" Unknown payload message received");
        }

        public void SendReply(MessageContainer.Types replyType, MemoryStream replyStream)
        {
            MemoryStream writeStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(writeStream);

            MessageContainer replyMessage = new MessageContainer();
            replyMessage.Magic = MessageContainer.MagicNumber;
            replyMessage.From = MessageContainer.ConnectionServer;
            replyMessage.To = Connection;
            replyMessage.Type = replyType;
            replyMessage.Unknown1 = 0;
            replyMessage.PayloadSize = (int)replyStream.Length;
            replyMessage.Payload = replyStream.ToArray();
            replyStream.SetLength(0);
            replyMessage.PayloadChecksum = Crc32.Calculate(replyMessage.Payload);

            writer.Write(replyMessage.Magic);
            writer.Write(replyMessage.From);
            writer.Write(replyMessage.To);
            writer.Write((int)replyMessage.Type);
            writer.Write(replyMessage.Unknown1);
            writer.Write(replyMessage.PayloadSize);
            writer.Write(replyMessage.PayloadChecksum);
            writer.Write(replyMessage.Payload);

            Program.LogDebug(" === Packet sending ===");
            Program.LogDebug($"  {nameof(replyMessage.Magic)}: {replyMessage.Magic:X08}");
            Program.LogDebug($"  {nameof(replyMessage.From)}: {replyMessage.From:X08}");
            Program.LogDebug($"  {nameof(replyMessage.To)}: {replyMessage.To:X08}");
            Program.LogDebug($"  {nameof(replyMessage.Type)}: {replyMessage.Type}");
            Program.LogDebug($"  {nameof(replyMessage.Unknown1)}: {replyMessage.Unknown1:X08}");
            Program.LogDebug($"  {nameof(replyMessage.PayloadSize)}: {replyMessage.PayloadSize}");
            Program.LogDebug($"  {nameof(replyMessage.PayloadChecksum)}: {replyMessage.PayloadChecksum:X08}");
            Program.LogDebug($"  {nameof(replyMessage.Payload)}: {Serializer.DumpBytes(replyMessage.Payload)}");

            byte[] replyBytes = writeStream.ToArray();

            writer.Close();
            writeStream.Close();

            AddToSendBuffer(buffer => { buffer.Write(replyBytes); });
        }

        private class HandshakeMessage
        {
            public uint Magic { get; set; }
            public uint ConnectionId { get; set; }
            public byte[] Username { get; set; }
            public byte[] Password { get; set; }
            public int Unknown1 { get; set; }

            public const int UsernameSize = 0x20;
            public const int PasswordSize = 0x08;
            public const int MessageSize = 0x34;
            public const uint MagicNumber = 0xDABAFBEF;

            public static readonly byte[] ReplyPassword = { 0x2D, 0, 0, 0, 0, 0, 0, 0 };
        }
    }
}
