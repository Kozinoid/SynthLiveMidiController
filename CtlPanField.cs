using System;
using System.Drawing;

namespace SynthLiveMidiController
{
    public partial class CtlPanField : CtlByteField
    {
        string stringValue;

        // Constructor
        public CtlPanField()
        {
            InitializeComponent();
            _value = 0;
            caption = "Pan:";
            min = -63;
            max = 63;
        }

        // ByteValue
        public override byte ByteValue 
        {
            get { return (byte)(_value + 63); }
            set 
            { 
                int res = ValidateValue(value - 63);
                _value = res;
            }
        }

        // Overridable Drawing Fuction
        public override void Drawing(Graphics gr)
        {
            if (_value < 0) stringValue = string.Format("L{0}", Math.Abs(_value));
            else if (_value > 0) stringValue = string.Format("R{0}", _value);
            else stringValue = "C";

            gr.DrawString(caption, Font, new SolidBrush(ForeColor), this.ClientRectangle, sf);
            gr.DrawString(stringValue, Font, new SolidBrush(ForeColor), rect, sf);
        }
    }
}
