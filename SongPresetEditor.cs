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
        public void SetInterface(IParametersManager data)
        {
            // Set Interface to Song Editor
        }

        // Show Editor
        public DialogResult ShowEditor(IParametersManager parameters)
        {
            return ShowDialog();
        }

        private void SongPresetEditor_Shown(object sender, EventArgs e)
        {
            // Refresh Editor
        }
    }
}
