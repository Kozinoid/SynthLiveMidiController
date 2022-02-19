using System;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class FastPresetEditor : Form
    {
        // Constructor
        public FastPresetEditor()
        {
            InitializeComponent();
        }

        // Set Data Interface
        public void SetInterface(IFastListEditorSectionInterface data)
        {
            // Set Interface to FAst Editor
        }

        // Show Editor
        public DialogResult ShowEditor(IFastListEditorSectionInterface parameters)
        {
            return ShowDialog();
        }

        private void FastPresetEditor_Shown(object sender, EventArgs e)
        {
            // Refresh Editor
        }
    }
}
