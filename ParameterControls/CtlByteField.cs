using System.Drawing;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlByteField : XP50BaseControl
    {
        const int min = 0;
        const int max = 127;

        // Fields
        protected XP50Byte data;

        // Value
        public int Value
        {
            get { return data.Value; }
            set
            {
                data.Value = ValidateValue(value);
                XP_CalculateBounds();
                this.Invalidate();
            }
        }

        // ByteValue
        public virtual byte ByteValue
        {
            get { return (byte)data.Value; }
            set { Value = value; }
        }

        // Constructor
        public CtlByteField()
        {
            InitializeComponent();

            data.Value = max;
            caption = "Vol: ";
            EnableEditor = true;

            XP_CalculateBounds();
        }

        // Validate
        private int ValidateValue(int val)
        {
            int res = val;
            if (val < min) res = min;
            if (val > max) res = max;
            return res;
        }

        // ---------------------------------------------------  Value change  -----------------------------------------------------------
        public override bool XP_IncValue()
        {
            if (Value < max)
            {
                Value++;
                return true;
            }
            else return false;
        }

        public override bool XP_DecValue()
        {
            if (Value > min)
            {
                Value--;
                return true;
            }
            else return false;
        }

        public override void XP_EndEdit()
        {
            Value = int.Parse(tbEnter.Text);
            base.XP_EndEdit();
        }

        //------------------------------------------------------  Drawing  --------------------------------------------------------------
        public override void XP_Drawing(Graphics gr)
        {
            base.XP_Drawing(gr);
            gr.DrawString(data.Value.ToString(), Font, new SolidBrush(ForeColor), rect, sf);
        }
    }
}
