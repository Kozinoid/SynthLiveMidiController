using System.Drawing;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlPerformanceNameField : XP50BaseControl
    {
        // Fields
        protected XP50String12 data;

        // Value
        public string Value
        {
            get { return data.Text; }
            set
            {
                data.Text = value;
                XP_CalculateBounds();
                this.Invalidate();
            }
        }

        // Constructor
        public CtlPerformanceNameField()
        {
            InitializeComponent();

            caption = "Perf:";
            data.Text = "";
            EnableEditor = true;

            XP_CalculateBounds();
        }

        // End Edit
        public override void XP_EndEdit(object sender, KeyEventArgs e)
        {
            Value = tbEnter.Text;
            base.XP_EndEdit(sender, e);
        }

        //------------------------------------------------------  Drawing  --------------------------------------------------------------
        public override void XP_Drawing(Graphics gr)
        {
            base.XP_Drawing(gr);
            gr.DrawString(data.Text, Font, new SolidBrush(ForeColor), rect, sf);
        }
    }
}
