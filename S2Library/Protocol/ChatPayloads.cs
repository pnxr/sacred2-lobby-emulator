using System;
using System.Collections.Generic;

namespace S2Library.Protocol
{
    public class ChatPayloads
    {
        public enum ChatTypes : ushort
        {
            UnknownType00 = 0,
            UnknownType01 = 1,
            UnknownType02 = 2,
            UnknownType03 = 3,
            UnknownType04 = 4,
            UnknownType05 = 5,
            CreateChannel = 7, // UnknownType07
            UnknownType08 = 8,
            UnknownType09 = 9,
            UnknownType10 = 10,
            UnknownType11 = 11,
        }

        private static readonly Dictionary<Type, ChatTypes> ChatPayloadTypes = new Dictionary<Type, ChatTypes>();
        private static readonly Dictionary<ChatTypes, Type> ChatPayloadFromType = new Dictionary<ChatTypes, Type>();

        static ChatPayloads()
        {
            ChatPayloadTypes.Add(typeof(ChatPayload0), ChatTypes.UnknownType00);
            ChatPayloadTypes.Add(typeof(ChatPayload1), ChatTypes.UnknownType01);
            ChatPayloadTypes.Add(typeof(ChatPayload2), ChatTypes.UnknownType02);
            ChatPayloadTypes.Add(typeof(ChatPayload3), ChatTypes.UnknownType03);
            ChatPayloadTypes.Add(typeof(ChatPayload4), ChatTypes.UnknownType04);
            ChatPayloadTypes.Add(typeof(ChatPayload5), ChatTypes.UnknownType05);
            ChatPayloadTypes.Add(typeof(CreateChannel), ChatTypes.CreateChannel); // ChatPayload7
            ChatPayloadTypes.Add(typeof(ChatPayload8), ChatTypes.UnknownType08);
            ChatPayloadTypes.Add(typeof(ChatPayload9), ChatTypes.UnknownType09);
            ChatPayloadTypes.Add(typeof(ChatPayload10), ChatTypes.UnknownType10);
            ChatPayloadTypes.Add(typeof(ChatPayload11), ChatTypes.UnknownType11);

            foreach (KeyValuePair<Type, ChatTypes> payloadType in ChatPayloadTypes)
            {
                ChatPayloadFromType.Add(payloadType.Value, payloadType.Key);
            }
        }

        public static T CreateChatPayload<T>() where T : ChatPayloadPrefix, new()
        {
            T payload = new T();

            payload.Magic = ChatPayloadPrefix.PayloadMagic;

            ChatTypes payloadChatTypes;
            if (ChatPayloadTypes.TryGetValue(typeof(T), out payloadChatTypes))
            {
                payload.Type = 0;
            }

            return payload;
        }

        public static ChatPayloadPrefix CreateChatPayload(ChatTypes chatTypes)
        {
            Type classType;
            if (ChatPayloadFromType.TryGetValue(chatTypes, out classType))
            {
                ChatPayloadPrefix result = (ChatPayloadPrefix) Activator.CreateInstance(classType);
                result.Magic = ChatPayloadPrefix.PayloadMagic;
                result.Type = 0;
                return result;
            }

            return null;
        }
    }

    public class ChatPayloadPrefix
    {
        public ushort Magic;
        public ushort Type;

        public const ushort PayloadMagic = 0x0062;

        public virtual void Serialize(Serializer serializer)
        {
            serializer.Serialize(nameof(Magic), ref Magic);
            serializer.Serialize(nameof(Type), ref Type);
        }
    }

    public class ChatPayload0 : ChatPayloadPrefix
    {
        public ushort Id;
        public byte[] Data;
        public uint CellId;
        public uint TicketId;

        public ChatPayload0()
        {
            Id = (ushort) ChatPayloads.ChatTypes.UnknownType00;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

    public class ChatPayload1 : ChatPayloadPrefix
    {
        public ushort Id;
        public uint CellId;
        public uint TicketId;
        public ushort Option;

        public ChatPayload1()
        {
            Id = (ushort)ChatPayloads.ChatTypes.UnknownType01;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(Option), ref Option);
        }
    }

    public class ChatPayload2 : ChatPayloadPrefix
    {
        public ushort Id;
        public ushort ModuleId;
        public ushort MessageId;
        public uint Except;
        public byte[] Data;
        public uint CellId;
        public bool Self;
        public bool Ispropset;

        public ChatPayload2()
        {
            Id = (ushort)ChatPayloads.ChatTypes.UnknownType02;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(ModuleId), ref ModuleId);
            serializer.Serialize(nameof(MessageId), ref MessageId);
            serializer.Serialize(nameof(Except), ref Except);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(Self), ref Self);
            serializer.Serialize(nameof(Ispropset), ref Ispropset);
        }
    }

    public class ChatPayload3 : ChatPayloadPrefix
    {
        public ushort Id;
        public ushort MessageId;
        public byte[] Data;
        public uint CellId;
        public uint FromId;
        public bool Ispropset;

        public ChatPayload3()
        {
            Id = (ushort)ChatPayloads.ChatTypes.UnknownType03;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(MessageId), ref MessageId);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(FromId), ref FromId);
            serializer.Serialize(nameof(Ispropset), ref Ispropset);
        }
    }

    public class ChatPayload4 : ChatPayloadPrefix
    {
        public ushort Id;
        public uint CellId;
        public uint TicketId;
        public ushort Option;

        public ChatPayload4()
        {
            Id = (ushort)ChatPayloads.ChatTypes.UnknownType04;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(Option), ref Option);
        }
    }

    public class ChatPayload5 : ChatPayloadPrefix
    {
        public ushort Id;
        public uint CellId;
        public uint TicketId;
        public ushort Option;

        public ChatPayload5()
        {
            Id = (ushort)ChatPayloads.ChatTypes.UnknownType05;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(Option), ref Option);
        }
    }

    public class CreateChannel : ChatPayloadPrefix // ChatPayload7
    {
        public ushort Id;
        public byte[] Data;
        public uint TicketId;

        public CreateChannel()
        {
            Id = (ushort)ChatPayloads.ChatTypes.CreateChannel;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(Data), ref Data);
            serializer.Serialize(nameof(TicketId), ref TicketId);
        }
    }

    public class ChatPayload8 : ChatPayloadPrefix
    {
        public ushort Id;
        public uint CellId;
        public uint TicketId;
        public ushort Option;

        public ChatPayload8()
        {
            Id = (ushort)ChatPayloads.ChatTypes.UnknownType08;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(Option), ref Option);
        }
    }

    public class ChatPayload9 : ChatPayloadPrefix
    {
        public ushort Id;
        public uint CellId;
        public uint TicketId;
        public ushort Option;

        public ChatPayload9()
        {
            Id = (ushort)ChatPayloads.ChatTypes.UnknownType09;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(Option), ref Option);
        }
    }

    public class ChatPayload10 : ChatPayloadPrefix
    {
        public ushort Id;
        public uint CellId;
        public uint TicketId;
        public ushort Option;

        public ChatPayload10()
        {
            Id = (ushort)ChatPayloads.ChatTypes.UnknownType10;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(Option), ref Option);
        }
    }

    public class ChatPayload11 : ChatPayloadPrefix
    {
        public ushort Id;
        public uint CellId;
        public uint TicketId;
        public ushort ResultId;

        public ChatPayload11()
        {
            Id = (ushort)ChatPayloads.ChatTypes.UnknownType11;
        }

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(nameof(Id), ref Id);
            serializer.Serialize(nameof(CellId), ref CellId);
            serializer.Serialize(nameof(TicketId), ref TicketId);
            serializer.Serialize(nameof(ResultId), ref ResultId);
        }
    }

    public class UnknownData
    {
        public string Publish;
        public string Name;
        public string Subject;
        public string Creator;
        public string Password;
        public bool Protected;
        public bool Persistent;
        public bool Autodelete;
        public bool Hidden;
        public uint CreatorPid;

        public UnknownData()
        {
            Publish = "SC";
        }

        public void Serialize(Serializer serializer)
        {
            serializer.Serialize(nameof(Publish), ref Publish);
            serializer.Serialize(nameof(Name), ref Name);
            serializer.Serialize(nameof(Subject), ref Subject);
            serializer.Serialize(nameof(Creator), ref Creator);
            serializer.Serialize(nameof(Password), ref Password);
            serializer.Serialize(nameof(Protected), ref Protected);
            serializer.Serialize(nameof(Persistent), ref Persistent);
            serializer.Serialize(nameof(Autodelete), ref Autodelete);
            serializer.Serialize(nameof(Hidden), ref Hidden);
            serializer.Serialize(nameof(CreatorPid), ref CreatorPid);
        }
    }
}
