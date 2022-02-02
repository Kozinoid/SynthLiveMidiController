using System.Text;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SynthLiveMidiController.File
{
    public class MultiDataFileStream
    {
        // FileStreaem
        private readonly FileStream fs;

        //----------------------  INT conversion union  -------------------------
        [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
        struct IntUnion
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            public int i;

            [System.Runtime.InteropServices.FieldOffset(0)]
            public byte b1;

            [System.Runtime.InteropServices.FieldOffset(1)]
            public byte b2;

            [System.Runtime.InteropServices.FieldOffset(2)]
            public byte b3;

            [System.Runtime.InteropServices.FieldOffset(3)]
            public byte b4;
        }

        //----------------------  UINT conversion union  ------------------------
        [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
        struct UINTUnion
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            public uint i;

            [System.Runtime.InteropServices.FieldOffset(0)]
            public byte b1;

            [System.Runtime.InteropServices.FieldOffset(1)]
            public byte b2;

            [System.Runtime.InteropServices.FieldOffset(2)]
            public byte b3;

            [System.Runtime.InteropServices.FieldOffset(3)]
            public byte b4;
        }

        //**************************  Constructor  ******************************
        public MultiDataFileStream(string FileName, FileMode mode, FileAccess access)
        {
            fs = new FileStream(FileName, mode, access);
        }

        //*************************  Close  *************************************
        public void Close()
        {
            fs.Close();
        }

        //************************  Skip bytes  *********************************
        public void Skip(int count)
        {
            fs.Seek(count + 4, SeekOrigin.Current);
        }

        //************************  Write byte array  ***************************
        public void WriteByteArray(byte[] buf)
        {
            WriteInt(buf.Length);
            fs.Write(buf, 0, buf.Length);
        }

        //************************  Read byte array  ****************************
        public byte[] ReadByteArray()
        {
            int len = ReadInt();
            byte[] buf = new byte[len];
            fs.Read(buf, 0, len);
            return buf;
        }

        //**************************  Write byte  *******************************
        public void WriteByte(byte bt)
        {
            fs.WriteByte(bt);
        }

        //**************************  Read byte  ********************************
        public byte ReadByte()
        {
            return (byte)fs.ReadByte();
        }

        //*******************  Write null-terminated text  **********************
        public void WriteText(string str)
        {
            int length = str.Length;
            byte[] buf = new byte[length];
            buf = Encoding.Default.GetBytes(str);

            fs.Write(buf, 0, length);
        }

        //***********************  Read long text  ******************************
        public string ReadLirics()
        {
            string str = "";

            int length = ReadInt();
            byte[] buf = new byte[length];
            fs.Read(buf, 0, length);
            str = Encoding.Default.GetString(buf);

            return str;
        }

        //*************************  Write long text  ***************************
        public void WriteLirics(string str)
        {
            int length = str.Length;
            byte[] buf = new byte[length];
            buf = Encoding.Default.GetBytes(str);
            WriteInt(length);
            fs.Write(buf, 0, length);
        }

        //**************************  Write string  *****************************
        public void WriteString(string str)
        {
            int length = str.Length;
            byte[] buf = new byte[length];
            buf = Encoding.Default.GetBytes(str);
            fs.WriteByte((byte)length);
            fs.Write(buf, 0, length);
        }

        //************************  Read string  ********************************
        public string ReadString()
        {
            string str = "";

            int length = fs.ReadByte();
            byte[] buf = new byte[length];
            fs.Read(buf, 0, length);
            str = Encoding.Default.GetString(buf);

            return str;
        }

        //****************************  Write int  ******************************
        public void WriteInt(int num)
        {
            IntUnion un = new IntUnion
            {
                i = num
            };
            fs.WriteByte(un.b1);
            fs.WriteByte(un.b2);
            fs.WriteByte(un.b3);
            fs.WriteByte(un.b4);
        }

        //**************************  Read int  *********************************
        public int ReadInt()
        {
            IntUnion un = new IntUnion
            {
                b1 = (byte)fs.ReadByte(),
                b2 = (byte)fs.ReadByte(),
                b3 = (byte)fs.ReadByte(),
                b4 = (byte)fs.ReadByte()
            };
            return un.i;
        }

        //***************************  Write uint  ******************************
        public void WriteUInt(uint num)
        {
            UINTUnion un = new UINTUnion
            {
                i = num
            };
            fs.WriteByte(un.b1);
            fs.WriteByte(un.b2);
            fs.WriteByte(un.b3);
            fs.WriteByte(un.b4);
        }

        //***************************  Read uint  *******************************
        public uint ReadUInt()
        {
            UINTUnion un = new UINTUnion
            {
                b1 = (byte)fs.ReadByte(),
                b2 = (byte)fs.ReadByte(),
                b3 = (byte)fs.ReadByte(),
                b4 = (byte)fs.ReadByte()
            };
            return un.i;
        }

        //*************************  Write chunk  *******************************
        public void WriteChunk(string chunk)
        {
            string str;
            if (chunk.Length > 4)
            {
                str = chunk.Substring(0, 4);
            }
            else if (chunk.Length < 4)
            {
                str = chunk.PadRight(4, ' ');
            }
            else str = chunk;

            int length = str.Length;
            byte[] buf = new byte[length];
            buf = Encoding.Default.GetBytes(str);
            fs.Write(buf, 0, length);
        }

        //****************************  Read chunk  *****************************
        public string ReadChunk()
        {
            string chunk = "";

            int length = 4;
            byte[] buf = new byte[length];
            fs.Read(buf, 0, length);
            chunk = Encoding.Default.GetString(buf);

            return chunk;
        }

        //**************************  Write bool  *******************************
        public void WriteBool(bool fl)
        {
            if (fl) fs.WriteByte(1);
            else fs.WriteByte(0);
        }

        //**************************  Read bool  ********************************
        public bool ReadBool()
        {
            bool res = false;
            if (fs.ReadByte() != 0) res = true;
            return res;
        }

        //************************  Write Color  ********************************
        public void WriteColor(Color color)
        {
            WriteInt((int)color.R);
            WriteInt((int)color.G);
            WriteInt((int)color.B);
        }

        //***************************  Read Color *******************************
        public Color ReadColor()
        {
            int r = ReadInt();
            int g = ReadInt();
            int b = ReadInt();
            Color res = Color.FromArgb(r, g, b);
            return res;
        }
    }
}
