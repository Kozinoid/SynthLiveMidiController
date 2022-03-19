using System;
using System.Drawing;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlLocalBoolField : XP50BaseControl
    {
        // Fields 
        private XP50EFXEnum<LocalSwitch> data;

        // Checked
        public bool Checked
        {
            get { return (data.Data == LocalSwitch.ON) ? true : false; }
            set
            {
                if (value) data.Data = LocalSwitch.ON;
                else data.Data = LocalSwitch.OFF;
                this.Invalidate();
            }
        }

        // Constructor
        public CtlLocalBoolField()
        {
            InitializeComponent();

            data.Data = LocalSwitch.OFF;
            caption = "Local: ";
            EnableContext = true;

            XP_CalculateBounds();
        }

        // ---------------------------------------------------  Value change  -----------------------------------------------------------
        public override bool XP_IncValue()
        {
            if (!Checked)
            {
                //Console.WriteLine("Change: inc");
                data.Data = LocalSwitch.ON;
                return true;
            }
            else return false;
        }

        public override bool XP_DecValue()
        {
            if (Checked) 
            {
                //Console.WriteLine("Change: dec");
                data.Data = LocalSwitch.OFF;
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
