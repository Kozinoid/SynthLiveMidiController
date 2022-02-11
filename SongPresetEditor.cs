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
    }
}
