using System.IO;
using System.Text;
using S2Library.Protocol;

namespace S2Lobby
{
    public class ServerProcessor : NetworkProcessor
    {
        protected readonly Serializer Logger;

        protected readonly Database Database;
        protected Account Account;

        private byte[] _sharedSecret;

        public ServerProcessor(Program program, uint connection) : base(program, connection)
        {
            Logger = new PayloadLogger(program.LogDebug);
            Database = new Database(program);
        }

        public override void Close()
        {
            Database.Dispose();
        }

        protected bool SendToLobbyConnection(uint connection, PayloadPrefix message)
        {
            NetworkProcessor processor = Program.GetLobbyProcessor(connection);
            if (processor == null)
            {
                return false;
            }

            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            PayloadWriter payloadWriter = new PayloadWriter(writer);

            message.Serialize(payloadWriter);

            Program.LogDebug($" --- Payload sending to {connection}: {(Payloads.Types)message.Type2} ---");
            message.Serialize(Logger);

            processor.SendReply(MessageContainer.Types.ApplicationMessage, stream);

            writer.Close();
            stream.Close();

            return false;
        }

        protected sealed override void HandleMessage(BinaryReader reader, BinaryWriter writer)
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            PayloadReader payloadReader = new PayloadReader(reader);
            PayloadWriter payloadWriter = new PayloadWriter(writer);

            PayloadPrefix prefix = new PayloadPrefix();
            prefix.Serialize(payloadReader);


            if (prefix.Magic == PayloadPrefix.PayloadMagic)
            {
                if (prefix.Type1 != prefix.Type2)
                {
                    Program.Log($" Corrupt payload type, first is {prefix.Type1:X04} but second is {prefix.Type2:X04}");
                }

                Payloads.Types payloadType = (Payloads.Types)prefix.Type2;
                PayloadPrefix payload = Payloads.CreatePayload(payloadType);

                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                payload.Serialize(payloadReader);

                HandlePayloadType(payloadType, payload, payloadWriter);
            }
            else if (prefix.Magic == ChatPayloadPrefix.PayloadMagic)
            {
                if (prefix.Type1 != 0)
                {
                    Program.Log($" Corrupt payload chatTypes, is {prefix.Type1:X04} but expected 0");
                }

                ChatPayloads.ChatTypes chatPayloadType = (ChatPayloads.ChatTypes)prefix.Type2;
                ChatPayloadPrefix chatPayload = ChatPayloads.CreateChatPayload(chatPayloadType);

                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                chatPayload.Serialize(payloadReader);

                HandleChatPayloadType(chatPayloadType, chatPayload, payloadWriter);
            }
            else
            {
                Program.Log($" Incorrect payload magic, is {prefix.Magic:X04} but should be {PayloadPrefix.PayloadMagic:X04}");
            }

        }

        protected virtual bool HandlePayloadType(Payloads.Types payloadType, PayloadPrefix payload, PayloadWriter writer)
        {
            Program.LogDebug($" --- Payload received: {payloadType} ---");
            payload.Serialize(Logger);

            switch (payloadType)
            {
                case Payloads.Types.VersionCheck:
                    HandleVersionCheck((VersionCheck)payload, writer);
                    return true;
                case Payloads.Types.Login:
                    HandleLogin((Login)payload, writer);
                    return true;
                case Payloads.Types.RegisterUser:
                    HandleRegisterUser((RegisterUser)payload, writer);
                    return true;
                case Payloads.Types.LoginUser:
                    HandleLoginUser((LoginUser)payload, writer);
                    return true;
                case Payloads.Types.LoginServer:
                    HandleLoginServer((LoginServer)payload, writer);
                    return true;
                default:
                    return false;
            }
        }

        protected virtual void HandleChatPayloadType(ChatPayloads.ChatTypes chatPayloadType, ChatPayloadPrefix chatPayload, PayloadWriter payloadWriter)
        {
            Program.LogDebug(" Unknown chat payload message received");
            chatPayload.Serialize(Logger);
        }

        protected void SendReply(PayloadWriter writer, PayloadPrefix payload)
        {
            payload.Serialize(writer);
            SendReply(MessageContainer.Types.ApplicationMessage, writer.BaseStream);

            Program.LogDebug($" --- Payload sending: {(Payloads.Types)payload.Type2} ---");
            payload.Serialize(Logger);
        }

        private void HandleVersionCheck(VersionCheck payload, PayloadWriter writer)
        {
            StatusMsg resultPayload = Payloads.CreatePayload<StatusMsg>();
            resultPayload.Errorcode = 0;
            resultPayload.Errormsg = null;
            resultPayload.TicketId = payload.TicketId;
            SendReply(writer, resultPayload);
        }

        private void HandleLogin(Login payload, PayloadWriter writer)
        {
            byte[] loginKey = payload.Key;

            _sharedSecret = Crypto.CreateSecretKey();
            byte[] result = Crypto.HandleKey(loginKey, _sharedSecret);

            LoginReply resultPayload = Payloads.CreatePayload<LoginReply>();
            resultPayload.Cipher = result;
            resultPayload.TicketId = payload.TicketId;
            SendReply(writer, resultPayload);
        }

        private void HandleRegisterUser(RegisterUser payload, PayloadWriter writer)
        {
            byte[] loginCipher = payload.Cipher;

            byte[] result = Crypto.HandleUser(loginCipher, _sharedSecret);
            Program.LogDebug($" User: {Serializer.DumpBytes(result)}");

            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);

            bool invalid = false;

            byte[] nameBytes = null;
            int nameLength = reader.ReadByte();
            if (nameLength < 32)
            {
                nameBytes = reader.ReadBytes(nameLength);
            }
            else
            {
                invalid = true;
            }

            byte[] passwordBytes = null;
            if (!invalid)
            {
                int passwordLength = reader.ReadByte();
                if (nameLength < 32)
                {
                    passwordBytes = reader.ReadBytes(passwordLength);
                }
                else
                {
                    invalid = true;
                }
            }

            byte[] cdKey = null;
            if (!invalid)
            {
                int keysLength = reader.ReadByte();
                int keyPool = reader.ReadByte();
                int keyLength = reader.ReadByte();
                if (keysLength != 1 || keyPool != 1 || keyLength != 16)
                {
                    invalid = true;
                }
                else
                {
                    cdKey = reader.ReadBytes(keyLength);
                }
            }

            if (invalid)
            {
                StatusMsg resultPayload1 = Payloads.CreatePayload<StatusMsg>();
                resultPayload1.Errorcode = 3;
                resultPayload1.Errormsg = "Encryption failure";
                resultPayload1.TicketId = payload.TicketId;
                SendReply(writer, resultPayload1);
                return;
            }

            string name = Encoding.ASCII.GetString(nameBytes);
            byte[] password = Crypto.HashPassword(passwordBytes);

            uint id = Program.Accounts.Create(Database.Connection, name, password, cdKey);
            if (id == 0)
            {
                StatusMsg resultPayload1 = Payloads.CreatePayload<StatusMsg>();
                resultPayload1.Errorcode = 1;
                resultPayload1.Errormsg = "Username already in use";
                resultPayload1.TicketId = payload.TicketId;
                SendReply(writer, resultPayload1);
                return;
            }

            Account = Program.Accounts.Get(Database.Connection, name);
            if (Account == null)
            {
                StatusMsg resultPayload1 = Payloads.CreatePayload<StatusMsg>();
                resultPayload1.Errorcode = 1;
                resultPayload1.Errormsg = "Account not created";
                resultPayload1.TicketId = payload.TicketId;
                SendReply(writer, resultPayload1);
                return;
            }

            byte[] secret = Crypto.HandleSessionKey(Crypto.CreateSecretKey(), _sharedSecret);

            LoginReplyCipher resultPayload2 = Payloads.CreatePayload<LoginReplyCipher>();
            resultPayload2.PermId = Account.Id;
            resultPayload2.Cipher = secret;
            resultPayload2.TicketId = payload.TicketId;
            SendReply(writer, resultPayload2);

            Program.Log($"Account created for {name}");
        }

        private void HandleLoginUser(LoginUser payload, PayloadWriter writer)
        {
            byte[] loginCipher = payload.Cipher;

            byte[] result = Crypto.HandleUser(loginCipher, _sharedSecret);
            Program.LogDebug($" User: {Serializer.DumpBytes(result)}");

            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);

            bool invalid = false;

            byte[] nameBytes = null;
            int nameLength = reader.ReadByte();
            if (nameLength < 32)
            {
                nameBytes = reader.ReadBytes(nameLength);
            }
            else
            {
                invalid = true;
            }

            byte[] passwordBytes = null;
            if (!invalid)
            {
                int passwordLength = reader.ReadByte();
                if (nameLength < 32)
                {
                    passwordBytes = reader.ReadBytes(passwordLength);
                }
                else
                {
                    invalid = true;
                }
            }

            if (invalid)
            {
                StatusMsg resultPayload1 = Payloads.CreatePayload<StatusMsg>();
                resultPayload1.Errorcode = 3;
                resultPayload1.Errormsg = "Encryption failure";
                resultPayload1.TicketId = payload.TicketId;
                SendReply(writer, resultPayload1);
                return;
            }

            string name = Encoding.ASCII.GetString(nameBytes);
            byte[] password = Crypto.HashPassword(passwordBytes);

            Account = Program.Accounts.Get(Database.Connection, name);
            if (Account == null)
            {
                StatusMsg resultPayload1 = Payloads.CreatePayload<StatusMsg>();
                resultPayload1.Errorcode = 1;
                resultPayload1.Errormsg = "Account not found";
                resultPayload1.TicketId = payload.TicketId;
                SendReply(writer, resultPayload1);
                return;
            }

            if (!Serializer.CompareArrays(password, Account.Password))
            {
                StatusMsg resultPayload1 = Payloads.CreatePayload<StatusMsg>();
                resultPayload1.Errorcode = 1;
                resultPayload1.Errormsg = "Wrong password";
                resultPayload1.TicketId = payload.TicketId;
                SendReply(writer, resultPayload1);
                return;
            }

            byte[] secret = Crypto.HandleSessionKey(Crypto.CreateSecretKey(), _sharedSecret);

            LoginReplyCipher resultPayload = Payloads.CreatePayload<LoginReplyCipher>();
            resultPayload.PermId = Account.Id;
            resultPayload.Cipher = secret;
            resultPayload.TicketId = payload.TicketId;
            SendReply(writer, resultPayload);

            Program.Log($"User {name} logged in");
        }

        private void HandleLoginServer(LoginServer payload, PayloadWriter writer)
        {
            byte[] loginCipher = payload.Cipher;

            byte[] result = Crypto.HandleUser(loginCipher, _sharedSecret);
            Program.LogDebug($" User: {Serializer.DumpBytes(result)}");

            MemoryStream stream = new MemoryStream(result);
            BinaryReader reader = new BinaryReader(stream);

            bool invalid = false;

            byte[] nameBytes = null;
            int nameLength = reader.ReadByte();
            if (nameLength < 32)
            {
                nameBytes = reader.ReadBytes(nameLength);
            }
            else
            {
                invalid = true;
            }

            byte[] passwordBytes = null;
            if (!invalid)
            {
                int passwordLength = reader.ReadByte();
                if (nameLength < 32)
                {
                    passwordBytes = reader.ReadBytes(passwordLength);
                }
                else
                {
                    invalid = true;
                }
            }

            if (invalid)
            {
                StatusMsg resultPayload1 = Payloads.CreatePayload<StatusMsg>();
                resultPayload1.Errorcode = 3;
                resultPayload1.Errormsg = "Encryption failure";
                resultPayload1.TicketId = payload.TicketId;
                SendReply(writer, resultPayload1);
                return;
            }

            string name = Encoding.ASCII.GetString(nameBytes);
            byte[] password = Crypto.HashPassword(passwordBytes);

            Account = Program.Accounts.Get(Database.Connection, name);
            if (Account == null)
            {
                StatusMsg resultPayload1 = Payloads.CreatePayload<StatusMsg>();
                resultPayload1.Errorcode = 1;
                resultPayload1.Errormsg = "Account not found";
                resultPayload1.TicketId = payload.TicketId;
                SendReply(writer, resultPayload1);
                return;
            }

            if (!Serializer.CompareArrays(password, Account.Password))
            {
                StatusMsg resultPayload1 = Payloads.CreatePayload<StatusMsg>();
                resultPayload1.Errorcode = 1;
                resultPayload1.Errormsg = "Wrong password";
                resultPayload1.TicketId = payload.TicketId;
                SendReply(writer, resultPayload1);
                return;
            }

            byte[] secret = Crypto.HandleSessionKey(Crypto.CreateSecretKey(), _sharedSecret);

            LoginReplyCipher resultPayload = Payloads.CreatePayload<LoginReplyCipher>();
            resultPayload.PermId = Account.Id;
            resultPayload.Cipher = secret;
            resultPayload.TicketId = payload.TicketId;
            SendReply(writer, resultPayload);

            Program.Log($"Server logged in for user {name}");
        }
    }
}
