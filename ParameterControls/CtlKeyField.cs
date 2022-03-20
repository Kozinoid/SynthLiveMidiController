using System.Drawing;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlKeyField : XP50BaseControl
    {
        const int min = 0;
        const int max = 127;
        const int initValue = 60;

        // Fields
        protected XP50Key data;

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
        public CtlKeyField()
        {
            InitializeComponent();

            caption = "Key:";
            data.Value = initValue;
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

        public override void XP_EndEdit(object sender, KeyEventArgs e)
        {
            try
            {
                Value = int.Parse(tbEnter.Text);
            }
            catch
            {
                base.XP_EndEdit(sender, e);
            }
        }

        public override void XP_BeginEdit()
        {
            tbEnter.Text = data.Value.ToString();
            base.XP_BeginEdit();
        }

        //------------------------------------------------------  Drawing  --------------------------------------------------------------
        public override void XP_Drawing(Graphics gr)
        {
            base.XP_Drawing(gr);
            gr.DrawString(data.ToString(), Font, new SolidBrush(ForeColor), rect, sf);
        }
    }
}
