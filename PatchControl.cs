using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class PatchControl : UserControl
    {
        // Fields
        private byte[] patchBuffer = BankNameConvertor.ChannelCommandToBuffer(81, 0, 5);
        private string caption = "Patch";

        // Properties
        public byte[] PatchBuffer
        {
            get => patchBuffer;
            set 
            { 
                patchBuffer = value;
            }
        }

        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
            }
        }

        // Constructor
        public PatchControl()
        {
            InitializeComponent();
            lb_Caption.Click += PatchControl_Click;
        }

        // Click
        private void PatchControl_Click(object sender, System.EventArgs e)
        {
            SelectPatchDialog spd = new SelectPatchDialog
            {
                CommandBuffer = patchBuffer
            };

            spd.ShowDialog();

            patchBuffer = spd.CommandBuffer;
            PrintValue();
        }

        // ---------------------------------------------  Graphics  ---------------------------------------------------
        // Print Value
        public void PrintValue()
        {
            string str = "";
            if (patchBuffer != null)
            {
                if (patchBuffer.Length > 0)  str = BankNameConvertor.GetPatchName(PatchBuffer);
            }
            lb_Caption.Text = string.Format("{0}: {1}", caption, str);
        }

    }
}
