using System.Drawing;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlTempoField : XP50BaseControl
    {
        const int min = 20;
        const int max = 250;

        protected XP50TwoBytes data;

        // ByteValue
        public virtual byte[] ValueBuffer
        {
            get { return data.ByteArray; }
            set { data.ByteArray = value; }
        }

        // Value
        public int Value
        {
            get { return data.Value; }
            set
            {
                data.Value = ValidateValue(value);
                XP_CalculateBounds();
                this.Invalidate();
                EnableEditor = true;
            }
        }

        // Constructor
        public CtlTempoField()
        {
            InitializeComponent();

            caption = "Tempo:";
            data.Value = 120;

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

        public override void XP_BeginEdit()
        {
            tbEnter.Text = data.ToString();
            base.XP_BeginEdit();
        }

        //------------------------------------------------------  Drawing  --------------------------------------------------------------
        public override void XP_Drawing(Graphics gr)
        {
            base.XP_Drawing(gr);
            gr.DrawString(data.Value.ToString(), Font, new SolidBrush(ForeColor), rect, sf);
        }
    }
}
