using System;
using System.IO;
using System.Text;

namespace S2Library.Protocol
{
    public abstract class Serializer
    {
        public abstract void Serialize(string name, ref string data);
        public abstract void Serialize(string name, ref byte[] data);
        public abstract void Serialize(string name, ref bool data);
        public abstract void Serialize(string name, ref byte data);
        public abstract void Serialize(string name, ref sbyte data);
        public abstract void Serialize(string name, ref ushort data);
        public abstract void Serialize(string name, ref short data);
        public abstract void Serialize(string name, ref uint data);
        public abstract void Serialize(string name, ref int data);

        public static string DumpBytes(byte[] data)
        {
#if DEBUG
            StringBuilder sb = new StringBuilder();
            sb.Append("0x");
            foreach (var b in data)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(" ");
            }
            sb.Append("| ");
            foreach (var b in data)
            {
                if (b >= 32)
                {
                    sb.Append(Convert.ToChar(b));
                }
                else
                {
                    sb.Append("°");
                }
            }
            return sb.ToString();
#else
            return string.Empty;
#endif
        }

        public static bool CompareArrays(byte[] array1, byte[] array2)
        {
            if (array1 == null || array2 == null || array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class PayloadReader : Serializer
    {
        private readonly BinaryReader _reader;

        public MemoryStream BaseStream { get { return _reader.BaseStream as MemoryStream; } }

        public PayloadReader(BinaryReader reader)
        {
            _reader = reader;
        }

        public override void Serialize(string name, ref string data)
        {
            int length = _reader.ReadInt32();
            if (length > 0)
            {
                byte[] textBytes = _reader.ReadBytes(length);
                data = Encoding.ASCII.GetString(textBytes);
            }
            else
            {
                data = null;
            }
        }

        public override void Serialize(string name, ref byte[] data)
        {
            int length = _reader.ReadInt32();
            if (length > 0)
            {
                data = _reader.ReadBytes(length);
            }
            else
            {
                data = null;
            }
        }

        public override void Serialize(string name, ref bool data)
        {
            data = _reader.ReadByte() != 0;
        }

        public override void Serialize(string name, ref byte data)
        {
            data = _reader.ReadByte();
        }

        public override void Serialize(string name, ref sbyte data)
        {
            data = _reader.ReadSByte();
        }

        public override void Serialize(string name, ref ushort data)
        {
            data = _reader.ReadUInt16();
        }

        public override void Serialize(string name, ref short data)
        {
            data = _reader.ReadInt16();
        }

        public override void Serialize(string name, ref uint data)
        {
            data = _reader.ReadUInt32();
        }

        public override void Serialize(string name, ref int data)
        {
            data = _reader.ReadInt32();
        }
    }

    public class PayloadWriter : Serializer
    {
        private readonly BinaryWriter _writer;

        public MemoryStream BaseStream { get { return _writer.BaseStream as MemoryStream; } }

        public PayloadWriter(BinaryWriter writer)
        {
            _writer = writer;
        }

        public override void Serialize(string name, ref string data)
        {
            if (data == null)
            {
                int length = 0;
                _writer.Write(length);
            }
            else
            {
                byte[] bytes = Encoding.ASCII.GetBytes(data);
                int length = bytes.Length;
                _writer.Write(length);
                _writer.Write(bytes);
            }
        }

        public override void Serialize(string name, ref byte[] data)
        {
            if (data == null)
            {
                int length = 0;
                _writer.Write(length);
            }
            else
            {
                int length = data.Length;
                _writer.Write(length);
                _writer.Write(data);
            }
        }

        public override void Serialize(string name, ref bool data)
        {
            byte flag = (byte)(data ? 1 : 0);
            _writer.Write(flag);
        }

        public override void Serialize(string name, ref byte data)
        {
            _writer.Write(data);
        }

        public override void Serialize(string name, ref sbyte data)
        {
            _writer.Write(data);
        }

        public override void Serialize(string name, ref ushort data)
        {
            _writer.Write(data);
        }

        public override void Serialize(string name, ref short data)
        {
            _writer.Write(data);
        }

        public override void Serialize(string name, ref uint data)
        {
            _writer.Write(data);
        }

        public override void Serialize(string name, ref int data)
        {
            _writer.Write(data);
        }
    }

    public class PayloadLogger : Serializer
    {
        private readonly Action<string> _logger;

        public PayloadLogger(Action<string> logger)
        {
            _logger = logger;
        }

        public override void Serialize(string name, ref string data)
        {
            if (data == null)
            {
                _logger($"  {name} (0): NULL");
            }
            else
            {
                _logger($"  {name} ({data.Length}): '{data}'");
            }
        }

        public override void Serialize(string name, ref byte[] data)
        {
            if (data == null)
            {
                _logger($"  {name} (0): NULL");
            }
            else
            {
                _logger($"  {name} ({data.Length}): {DumpBytes(data)}");
            }
        }

        public override void Serialize(string name, ref bool data)
        {
            string text = data ? "true" : "false";
            _logger($"  {name}: {text}");
        }

        public override void Serialize(string name, ref byte data)
        {
            _logger($"  {name}: {data:X02} ({data})");
        }

        public override void Serialize(string name, ref sbyte data)
        {
            _logger($"  {name}: {data:X02} ({data})");
        }

        public override void Serialize(string name, ref ushort data)
        {
            _logger($"  {name}: {data:X04} ({data})");
        }

        public override void Serialize(string name, ref short data)
        {
            _logger($"  {name}: {data:X04} ({data})");
        }

        public override void Serialize(string name, ref uint data)
        {
            _logger($"  {name}: {data:X08} ({data})");
        }

        public override void Serialize(string name, ref int data)
        {
            _logger($"  {name}: {data:X08} ({data})");
        }
    }
}
