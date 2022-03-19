using System.Drawing;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlPatchSelectField : XP50BaseControl
    {
        // Fields
        protected XP50PatchBytes data;

        // Buffer
        public byte[] PatchBuffer
        {
            get { return data.ByteArray; }
            set
            {
                data.ByteArray = value;
                XP_CalculateBounds();
                this.Invalidate();
            }
        }

        // Constructor
        public CtlPatchSelectField()
        {
            InitializeComponent();

            caption = "Patch:";
            PatchBuffer = BankNameConvertor.ChannelCommandToBuffer(81, 0, 0);
            EnableEditor = true;

            XP_CalculateBounds();
        }

        // ---------------------------------------------------  Value change  -----------------------------------------------------------
        public override bool XP_IncValue()
        {
            PatchBuffer = BankNameConvertor.Next(PatchBuffer);

            return true;
        }

        public override bool XP_DecValue()
        {
            PatchBuffer = BankNameConvertor.Prev(PatchBuffer);

            return true;
        }

        //------------------------------------------------------  Drawing  --------------------------------------------------------------
        public override void XP_Drawing(Graphics gr)
        {
            base.XP_Drawing(gr);
            if (BankNameConvertor.IsLoaded)
            {
                gr.DrawString(BankNameConvertor.GetPatchName(data.ByteArray), Font, new SolidBrush(ForeColor), rect, sf);
            }
            else
            {
                gr.DrawString(data.ToString(), Font, new SolidBrush(ForeColor), rect, sf);
            }
        }

        //------------------------------------------------------  Double Ckick  ---------------------------------------------------------
        public override void XP_BeginEdit()
        {
            SelectPatchDialog spd = new SelectPatchDialog
            {
                CommandBuffer = PatchBuffer
            };
            if (spd.ShowDialog() == DialogResult.OK)
            {
                PatchBuffer = spd.CommandBuffer;
            }
        }
    }
}
