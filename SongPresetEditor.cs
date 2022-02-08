using System.Windows.Forms;
using SynthLiveMidiController.Pictures;
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

        // Show Editor
        public DialogResult ShowEditor(ISongListEditorSectionInterface parameters)
        {
            return ShowDialog();
        }
    }
}
