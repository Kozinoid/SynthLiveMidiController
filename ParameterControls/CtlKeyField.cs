using System.Drawing;

namespace SynthLiveMidiController
{
    public partial class CtlKeyField : CtlByteField
    {
        private readonly string[] keys = {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "B", "H"};
        string stringValue;

        // Constructor
        public CtlKeyField()
        {
            InitializeComponent();
            caption = "Key:";
        }

        // Overridable Drawing Fuction
        public override void Drawing(Graphics gr)
        {
            stringValue = keys[_value % 12] + (_value / 12 - 1).ToString();
            gr.DrawString(caption, Font, new SolidBrush(ForeColor), this.ClientRectangle, sf);
            gr.DrawString(stringValue, Font, new SolidBrush(ForeColor), rect, sf);
        }
    }
}
