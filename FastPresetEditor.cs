using System.Windows.Forms;
using SynthLiveMidiController.Pictures;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class FastPresetEditor : Form
    {
        // TEST
        readonly KeyboardPicture kbdPicture = new KeyboardPicture();

        // Constructor
        public FastPresetEditor()
        {
            InitializeComponent();
        }

        // Show Editor
        public DialogResult ShowEditor(IFastListEditorSectionInterface parameters)
        {
            return ShowDialog();
        }
    }
}
