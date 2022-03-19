using System;
using System.Drawing;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlHoldBoolField : XP50BaseControl
    {
        // Fields
        protected XP50EFXEnum<RecieveHold1Switch> data;

        // Checked
        public bool Checked
        {
            get { return (data.Data == RecieveHold1Switch.ON) ? true : false; }
            set
            {
                if (value) data.Data = RecieveHold1Switch.ON;
                else data.Data = RecieveHold1Switch.OFF;
                this.Invalidate();
            }
        }

        // Constructor
        public CtlHoldBoolField()
        {
            InitializeComponent();

            data.Data = RecieveHold1Switch.OFF;
            caption = "Hold: ";
            EnableContext = true;

            XP_CalculateBounds();
        }

        // ---------------------------------------------------  Value change  -----------------------------------------------------------
        public override bool XP_IncValue()
        {
            if (!Checked)
            {
                //Console.WriteLine("Change: inc");
                data.Data = RecieveHold1Switch.ON;
                return true;
            }
            else return false;
        }

        public override bool XP_DecValue()
        {
            if (Checked)
            {
                //Console.WriteLine("Change: dec");
                data.Data = RecieveHold1Switch.OFF;
                return true;
            }
            else return false;
        }

        public override void XP_RightClick(object sender, MouseEventArgs e)
        {
            Checked = !Checked;
            CallBackCall();
        }

        //------------------------------------------------------  Drawing  --------------------------------------------------------------
        public override void XP_Drawing(Graphics gr)
        {
            base.XP_Drawing(gr);
            gr.DrawString(data.Data.ToString(), Font, new SolidBrush(ForeColor), rect, sf);
        }
    }
}
