using System;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class SongPresetEditor : Form
    {
        // Constructor
        public SongPresetEditor()
        {
            InitializeComponent();
        }

        // Set Data Interface
        public void SetInterface(ISongListEditorSectionInterface data)
        {
            // Set Interface to Song Editor
        }

        // Show Editor
        public DialogResult ShowEditor(ISongListEditorSectionInterface parameters)
        {
            return ShowDialog();
        }

        private void SongPresetEditor_Shown(object sender, EventArgs e)
        {
            // Refresh Editor
        }
    }
}
