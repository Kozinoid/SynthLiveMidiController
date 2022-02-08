using System.Windows.Forms;
using System.Drawing;
using SynthLiveMidiController.Pictures;

namespace SynthLiveMidiController
{
    public partial class CtlOneChannelParameters : UserControl
    {
        private static KeyboardPicture picture = new KeyboardPicture();

        public CtlOneChannelParameters()
        {
            InitializeComponent();
        }

        private void pnZone_Paint(object sender, PaintEventArgs e)
        {
            picture.DrawKeyboard(e.Graphics, new Point(0, 0));
        }
    }
}
