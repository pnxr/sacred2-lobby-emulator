using System.IO;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

using S2Library.Protocol;

namespace S2Lobby
{
    public class ChatProcessor : ServerProcessor
    {
        private static readonly ConcurrentDictionary<uint, ConcurrentBag<uint>> _channelConnections = new ConcurrentDictionary<uint, ConcurrentBag<uint>>();
        private static readonly ConcurrentDictionary<uint, Channel> _channels = new ConcurrentDictionary<uint, Channel>();

        public ChatProcessor(Program program, uint connection) : base(program, connection)
        {
        }

        public override void Close()
        {
            base.Close();
            if (Account == null)
            {
                return;
            }

            KeyValuePair<uint, ConcurrentBag<uint>>[] channels = _channelConnections.ToArray();
            foreach(KeyValuePair<uint, ConcurrentBag<uint>> channel in channels)
            {
                uint channelId = channel.Key;
                uint[] connections = channel.Value.ToArray();

                foreach(uint connection in connections)
                {
                    if (connection != Connection)
                    {
                        continue;
                    }

                    ChatDisconnected disconnected = Payloads.CreatePayload<ChatDisconnected>();
                    disconnected.PermId = Account.Id;
                    disconnected.CellId = channelId;

                    SendAsChatReply(MessageContainer.ConnectionServer, disconnected, channelId);
                }
            }
        }

        protected override void HandleInitialReply()
        {
            List<Channel> channels = Program.Channels.GetAll(Database.Connection);

            foreach (Channel channel in channels)
            {
                _channels[channel.Id] = channel;
            }

            List<uint> ids = _channels.Keys.ToList();
            ids.Sort();

            foreach (uint id in ids)
            {
                Channel channel = _channels[id];

                ChannelData channelData = new ChannelData()
                {
                    Name = channel.Name,
                    Subject = channel.Subject,
                    Creator = channel.Creator,
                    Password = channel.Password,
                    Protected = channel.Protected,
                    Persistent = channel.Persistent,
                    Autodelete = channel.AutoDelete,
                    Hidden = channel.Hidden,
                    CreatorPid = channel.CreatorId,
                };

                ChannelInfo payload = ChatPayloads.CreateChatPayload<ChannelInfo>();
                payload.Data = WriteChannelData(channelData);
                payload.CellId = channel.Id;
                payload.TicketId = 0;
                SendChat(payload);
            }
        }

        private void SendChat(ChatPayloadPrefix payload)
        {
            ChatPayloads.ChatTypes chatPayloadType = (ChatPayloads.ChatTypes)payload.Id;

            Program.LogDebug($" --- Chat Payload sending: {chatPayloadType} ---");
            payload.Serialize(Logger);

            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            PayloadWriter payloadWriter = new PayloadWriter(writer);
            payload.Serialize(payloadWriter);
            SendReply(MessageContainer.Types.ApplicationMessage, stream);

            writer.Close();
            stream.Close();
        }

        protected sealed override bool HandlePayloadType(Payloads.Types payloadType, PayloadPrefix payload, PayloadWriter writer)
        {
            if (base.HandlePayloadType(payloadType, payload, writer))
            {
                return true;
            }

            switch (payloadType)
            {
                case Payloads.Types.LoginChat:
                    HandleLoginChat((LoginChat)payload, writer);
                    return true;
                case Payloads.Types.VerifyChatLogin:
                    HandleVerifyChatLogin((VerifyChatLogin)payload, writer);
                    return true;
                case Payloads.Types.JoinChatChannel:
                    HandleJoinChatChannel((JoinChatChannel)payload, writer);
                    return true;
                default:
                    return false;
            }
        }

        protected sealed override void HandleChatPayloadType(ChatPayloads.ChatTypes chatPayloadType, ChatPayloadPrefix chatPayload, PayloadWriter writer)
        {
            Program.LogDebug($" --- Chat Payload received: {chatPayloadType} ---");
            chatPayload.Serialize(Logger);

            switch (chatPayloadType)
            {
                case ChatPayloads.ChatTypes.CreateChannel:
                    ChatHandleCreateChannel((CreateChannel)chatPayload, writer);
                    break;
                case ChatPayloads.ChatTypes.ChatMessage:
                    ChatHandleChatMessage((ChatMessage)chatPayload, writer);
                    break;
                default:
                    return;
            }
        }

        private void HandleLoginChat(LoginChat payload, PayloadWriter writer)
        {
            LoginChatReply resultPayload = Payloads.CreatePayload<LoginChatReply>();
            resultPayload.Nonce = Crypto.CreateNonce();
            resultPayload.TicketId = payload.TicketId;
            SendReply(writer, resultPayload);
        }

        private void HandleVerifyChatLogin(VerifyChatLogin payload, PayloadWriter writer)
        {
            Account = Program.Accounts.Get(Database.Connection, payload.PermId);
            if (Account == null || Account.Id != payload.PermId)
            {
                StatusWithId resultPayload1 = Payloads.CreatePayload<StatusWithId>();
                resultPayload1.Errorcode = 1;
                resultPayload1.Errormsg = "Account not found";
                resultPayload1.Id = 0;
                resultPayload1.TicketId = payload.TicketId;
                SendReply(writer, resultPayload1);
                return;
            }

            StatusWithId resultPayload2 = Payloads.CreatePayload<StatusWithId>();
            resultPayload2.Errorcode = 0;
            resultPayload2.Errormsg = null;
            resultPayload2.Id = 0;
            resultPayload2.TicketId = payload.TicketId;
            SendReply(writer, resultPayload2);
        }

        private void HandleJoinChatChannel(JoinChatChannel payload, PayloadWriter writer)
        {
            ConcurrentBag<uint> connections;
            if (!_channelConnections.TryGetValue(payload.CellId, out connections)) {
                connections = new ConcurrentBag<uint>();
                _channelConnections[payload.CellId] = connections;
            }

            connections.Add(Connection);
            Program.LogDebug($" # User {Connection} joins channel {payload.CellId}");

            ChannelJoined joined = ChatPayloads.CreateChatPayload<ChannelJoined>();
            joined.CellId = payload.CellId;
            joined.TicketId = payload.TicketId;
            joined.Option = 0;

            SendChat(joined);

            StatusReply reply = ChatPayloads.CreateChatPayload<StatusReply>();
            reply.CellId = payload.CellId;
            reply.TicketId = payload.TicketId;
            reply.ResultId = 0;

            SendChat(reply);

            ChatUserInfo userInfo = Payloads.CreatePayload<ChatUserInfo>();
            userInfo.PermId = Account.Id;
            userInfo.CellId = payload.CellId;
            userInfo.Nick = Account.PlayerName;

            SendAsChatReply(MessageContainer.ConnectionServer, userInfo, payload.CellId);

            uint[] cellConnections = connections.ToArray();
            foreach (uint connection in cellConnections)
            {
                if (connection == Connection)
                {
                    continue;
                }

                ChatProcessor processor = Program.GetChatProcessor(connection);
                if (processor == null)
                {
                    continue;
                }

                ChatUserInfo info = Payloads.CreatePayload<ChatUserInfo>();
                info.PermId = processor.Account.Id;
                info.CellId = payload.CellId;
                info.Nick = processor.Account.PlayerName;

                SendChatReplyTo(this, info, payload.CellId);
            }
        }

        private void SendAsChatReply(uint from, PayloadPrefix payload, uint cellId)
        {
            ConcurrentBag<uint> connections;
            if (!_channelConnections.TryGetValue(cellId, out connections))
            {
                return;
            }

            MemoryStream stream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(stream);
            PayloadWriter payloadWriter = new PayloadWriter(binaryWriter);

            payload.Serialize(payloadWriter, false);
            byte[] data = stream.ToArray();

            binaryWriter.Close();
            stream.Close();

            ChatReply chatReply = ChatPayloads.CreateChatPayload<ChatReply>();
            chatReply.MessageId = payload.Type2;
            chatReply.Data = data;
            chatReply.CellId = cellId;
            chatReply.FromId = from;
            chatReply.Ispropset = true;

            uint[] cellConnections = connections.ToArray();
            foreach (uint connection in cellConnections)
            {
                ChatProcessor processor = Program.GetChatProcessor(connection);
                if (processor != null)
                {
                    processor.SendChat(chatReply);
                }
            }
        }

        private void SendChatReplyTo(ChatProcessor to, PayloadPrefix payload, uint cellId)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(stream);
            PayloadWriter payloadWriter = new PayloadWriter(binaryWriter);

            payload.Serialize(payloadWriter, false);
            byte[] data = stream.ToArray();

            binaryWriter.Close();
            stream.Close();

            ChatReply chatReply = ChatPayloads.CreateChatPayload<ChatReply>();
            chatReply.MessageId = payload.Type2;
            chatReply.Data = data;
            chatReply.CellId = cellId;
            chatReply.FromId = MessageContainer.ConnectionServer;
            chatReply.Ispropset = true;

            to.SendChat(chatReply);
        }

        private void ChatHandleCreateChannel(CreateChannel chatPayload, PayloadWriter writer)
        {
            ChannelData data = ReadChannelData(chatPayload.Data);

            Program.LogDebug($" --- Chat Create Channel Data ---");
            data.Serialize(Logger);

            StatusReply reply = ChatPayloads.CreateChatPayload<StatusReply>();
            reply.CellId = 3;
            reply.TicketId = chatPayload.TicketId;
            reply.ResultId = 0;

            SendChat(reply);
        }

        private void ChatHandleChatMessage(ChatMessage chatPayload, PayloadWriter w)
        {
            if (chatPayload.MessageId != (ushort)Payloads.Types.ChatPayload)
            {
                Program.Log($" !!! Received chat message of invalid type {(Payloads.Types)chatPayload.MessageId}");
                return;
            }

            MemoryStream stream = new MemoryStream(chatPayload.Data);
            BinaryReader reader = new BinaryReader(stream);
            PayloadReader payloadReader = new PayloadReader(reader);

            ChatPayload chat = Payloads.CreatePayload<ChatPayload>();
            chat.Serialize(payloadReader, false);

            reader.Close();
            stream.Close();

            Program.LogDebug($" + Chat Payload +");
            chat.Serialize(Logger);

            ChatPayload resultPayload = Payloads.CreatePayload<ChatPayload>();
            resultPayload.Mode = chat.Mode;
            resultPayload.Txt = chat.Txt;
            resultPayload.TicketId = chat.TicketId;
            resultPayload.FromId = chat.FromId;

            SendAsChatReply(Account.Id, resultPayload, chatPayload.CellId);
        }

        private ChannelData ReadChannelData(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryReader reader = new BinaryReader(stream);

            Serializer dataReader = new PayloadReader(reader);

            ChannelData channelData = new ChannelData();
            channelData.Serialize(dataReader);

            reader.Close();
            stream.Close();

            return channelData;
        }

        private byte[] WriteChannelData(ChannelData data)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            Serializer dataWriter = new PayloadWriter(writer);
            data.Serialize(dataWriter);

            byte[] result = stream.ToArray();

            writer.Close();
            stream.Close();

            return result;
        }
    }
}
