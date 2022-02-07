using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynthLiveMidiController
{
    public partial class NoteKeyControl : UserControl
    {
        private readonly static string[] keys = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "B", "H" };

        // Fields
        private byte level = 48;
        private string caption = "Value";

        // Properties
        public byte Value
        {
            get { return level; }
            set
            {
                level = value;
                PrintValue();
            }
        }
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                PrintValue();
            }
        }

        // Constructor
        public NoteKeyControl()
        {
            InitializeComponent();
        }

        // ---------------------------------------------  Graphics  ---------------------------------------------------
        // Print Value
        public void PrintValue()
        {
            string note = string.Format("{0}{1}", keys[level % 12], ((level / 12) - 1));

            lb_Caption.Text = string.Format("{0}: {1}", caption, note);
        }
        // Fore color changed
        private void NoteKeyControl_ForeColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        // Back color changed
        private void NoteKeyControl_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
