using System;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class SongPresetEditor : Form
    {
        ISongListEditorSectionInterface perfData;

        // Constructor
        public SongPresetEditor()
        {
            InitializeComponent();
        }

        // Set Data Interface
        public void SetInterface(ISongListEditorSectionInterface data)
        {
            perfData = data;
            perfData.SongDataReceived += PerfData_SongDataReceived;
        }

        // Data Received
        private void PerfData_SongDataReceived(object sender, SegmentDataReceivedEvendArgs ea)
        {
            //Console.WriteLine("Song Preset Editor {0}", ea.segment);
        }

        // Show Editor
        public DialogResult ShowEditor(ISongListEditorSectionInterface parameters)
        {
            return ShowDialog();
        }

        //--------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            //ctlChannelParametersListEditor1.AddNew();
        }

        private void bt_Del_Click(object sender, EventArgs e)
        {
           // ctlChannelParametersListEditor1.RemoveSelected();
        }

        private void bt_Clear_Click(object sender, EventArgs e)
        {
            //ctlChannelParametersListEditor1.Clear();
        }
    }
}
