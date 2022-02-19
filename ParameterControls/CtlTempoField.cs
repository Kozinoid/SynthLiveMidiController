using System;
using System.Drawing;
using System.Windows.Forms;

namespace SynthLiveMidiController
{
    public partial class CtlTempoField : CtlByteField
    {
        protected byte[] valBuffer = new byte[2];
        // ByteValue
        public virtual byte[] ValueBuffer
        {
            get { return valBuffer; }
            set { valBuffer = value; }
        }

        // Constructor
        public CtlTempoField()
        {
            InitializeComponent();

            min = 20;
            max = 250;
            _value = 120;
            caption = "Tempo:";
        }

        // byte _value -> byte[2] valBuffer
        public void ByteToBuffer()
        {
            valBuffer[1] = (byte)(_value & 0x0F);
            valBuffer[0] = (byte)((_value & 0xF0) >> 4);
        }

        // byte[2] valBuffer -> byte _value
        public  void BufferToByte()
        {
            Value = (valBuffer[0] << 4) + valBuffer[1];
        }
    }
}
