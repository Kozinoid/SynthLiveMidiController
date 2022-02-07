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

        //------------------------------------------------------------------------------------
        // TEST
        private void FastPresetEditor_Paint(object sender, PaintEventArgs e)
        {
            kbdPicture.DrawKeyboard(e.Graphics, 100, 100);
        }
    }
}
