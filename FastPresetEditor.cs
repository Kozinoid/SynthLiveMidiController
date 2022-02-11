using System;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class FastPresetEditor : Form
    {
        IFastListEditorSectionInterface perfData;

        // Constructor
        public FastPresetEditor()
        {
            InitializeComponent();
        }

        // Set Data Interface
        public void SetInterface(IFastListEditorSectionInterface data)
        {
            perfData = data;
            perfData.FastDataReceived += PerfData_FastDataReceived;
        }

        // Data Received
        private void PerfData_FastDataReceived(object sender, SegmentDataReceivedEvendArgs ea)
        {
            //Console.WriteLine("Fast Preset Editor {0}", ea.segment);
        }

        // Show Editor
        public DialogResult ShowEditor(IFastListEditorSectionInterface parameters)
        {
            return ShowDialog();
        }
    }
}
