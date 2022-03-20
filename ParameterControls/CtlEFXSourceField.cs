using System;
using System.Drawing;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlEFXSourceField : XP50BaseControl
    {
        // Fields
        protected XP50EFXEnum<EFXSource> data;
        private const int min = 0;
        private readonly int max;
        private ContextMenuStrip menu;

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

        public CtlEFXSourceField()
        {
            InitializeComponent();

            caption = "EFX:";
            max = data.Count - 1;
            menu = new ContextMenuStrip();
            foreach(string name in data.Names)
            {
                menu.Items.Add(name);
            }
            menu.ItemClicked += Menu_ItemClicked;
            EnableContext = true;

            XP_CalculateBounds();
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            data.SetName(e.ClickedItem.Text);
            XP_CalculateBounds();
            this.Invalidate();
        }

        // Validate
        private int ValidateValue(int val)
        {
            int res = val;
            if (val < min) res = min;
            if (val > max) res = max;
            return res;
        }

        // ---------------------------------------------------  CONTEXT  ----------------------------------------------------------------
        public override void XP_RightClick(object sender, MouseEventArgs e)
        {
            menu.Show(this, e.X, e.Y);
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

        //------------------------------------------------------  Drawing  --------------------------------------------------------------
        public override void XP_Drawing(Graphics gr)
        {
            base.XP_Drawing(gr);
            gr.DrawString(data.ToString(), Font, new SolidBrush(ForeColor), rect, sf);
        }
    }
}
