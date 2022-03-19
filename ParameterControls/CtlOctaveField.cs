using System.Drawing;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlOctaveField : XP50BaseControl
    {
        protected XP50LimitedByte data;

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
        public CtlOctaveField()
        {
            InitializeComponent();

            data = new XP50LimitedByte(-3, 3, -3);
            caption = "Oct:";
            EnableEditor = true;

            XP_CalculateBounds();
        }


        // Validate
        private int ValidateValue(int val)
        {
            int res = val;
            if (val < data.Min) res = data.Min;
            if (val > data.Max) res = data.Max;
            return res;
        }

        // ---------------------------------------------------  Value change  -----------------------------------------------------------
        public override bool XP_IncValue()
        {
            if (Value < data.Max)
            {
                Value++;
                return true;
            }
            else return false;
        }

        public override bool XP_DecValue()
        {
            if (Value > data.Min)
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
