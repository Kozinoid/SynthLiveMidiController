using SynthLiveMidiController.InstrumentList.Roland.XP50;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlFastCommandListField : XP50BaseControl
    {
        protected XP50LimitedByte data = new XP50LimitedByte(1, RolandXP50CommandSet.FastCommandCount, 1);
        protected List<string> namesList = new List<string>();

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
        public CtlFastCommandListField()
        {
            InitializeComponent();

            caption = "Song Command:";
            Init();

            EnableEditor = true;

            XP_CalculateBounds();
        }

        // Init
        public void Init()
        {
            for (int i = data.Min; i <= data.Max; i++)
            {
                namesList.Add("");
            }
            for (int i = data.Min; i <= data.Max; i++)
            {
                SetString(i, string.Format("Command {0}", i));
            }
        }

        // Set String
        public void SetString(int key, string value)
        {
            namesList[key - data.Offset] = value;
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

        public override void XP_EndEdit(object sender, KeyEventArgs e)
        {
            SetString(Value, tbEnter.Text);
            base.XP_EndEdit(sender, e);
        }

        public override void XP_BeginEdit()
        {
            tbEnter.Text = namesList[data.Value - data.Offset];
            base.XP_BeginEdit();
        }

        //------------------------------------------------------  Drawing  --------------------------------------------------------------
        public override void XP_Drawing(Graphics gr)
        {
            base.XP_Drawing(gr);
            gr.DrawString(namesList[data.Value - data.Offset], Font, new SolidBrush(ForeColor), rect, sf);
        }
    }
}
