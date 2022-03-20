using System.Drawing;
using System.Windows.Forms;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlStringField : XP50BaseControl
    {
        // Fields
        protected string data;

        // Value
        public string Value
        {
            get { return data; }
            set
            {
                data = value;
                XP_CalculateBounds();
                this.Invalidate();
            }
        }

        // Constructor
        public CtlStringField()
        {
            InitializeComponent();

            data = "";
            caption = "Name: ";
            EnableEditor = true;

            XP_CalculateBounds();
        }

        public override void XP_EndEdit(object sender, KeyEventArgs e)
        {
            Value = tbEnter.Text;
            base.XP_EndEdit(sender, e);
        }

        //------------------------------------------------------  Drawing  --------------------------------------------------------------
        public override void XP_Drawing(Graphics gr)
        {
            base.XP_Drawing(gr);
            gr.DrawString(data, Font, new SolidBrush(ForeColor), rect, sf);
        }
    }
}
