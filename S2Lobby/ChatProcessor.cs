using System.IO;
using S2Library.Protocol;

namespace S2Lobby
{
    public class ChatProcessor : ServerProcessor
    {
        private readonly byte[] _initial1 = Crypto.BytesFromHexString("620000000000370000000200000053430600000053797374656d0e00000053797374656d206368616e6e656c0500000041646d696e0000000000010000000000000100000000000000");
        private readonly byte[] _initial2 = Crypto.BytesFromHexString("62000000000030000000020000005343050000004c6f6262790d0000004c6f626279204368616e6e656c000000000000000000010000000000000200000000000000");

        public ChatProcessor(Program program, uint connection) : base(program, connection)
        {
        }

        protected override void HandleInitialReply(MemoryStream replyStream)
        {
            BinaryWriter writer = new BinaryWriter(replyStream);
            writer.Write(_initial1);
            SendReply(MessageContainer.Types.ApplicationMessage, replyStream);
            writer.Write(_initial2);
            SendReply(MessageContainer.Types.ApplicationMessage, replyStream);
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
            StatusWithId resultPayload = Payloads.CreatePayload<StatusWithId>();
            resultPayload.Errorcode = 0;
            resultPayload.Errormsg = null;
            resultPayload.Id = 0;
            resultPayload.TicketId = payload.TicketId;
            SendReply(writer, resultPayload);
        }

        private void ChatHandleCreateChannel(CreateChannel chatPayload, PayloadWriter writer)
        {
            UnknownData data = ReadUnknownData(chatPayload.Data);

            Program.LogDebug($" --- Chat Create Channel Data ---");
            data.Serialize(Logger);
        }

        private UnknownData ReadUnknownData(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryReader reader = new BinaryReader(stream);

            Serializer dataReader = new PayloadReader(reader);

            UnknownData unknownData = new UnknownData();
            unknownData.Serialize(dataReader);

            reader.Close();
            stream.Close();

            return unknownData;
        }
    }
}
