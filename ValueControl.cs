using System;
using System.Drawing;
using System.Windows.Forms;
using SynthLiveMidiController.Picrutes;

namespace SynthLiveMidiController
{
    public partial class ValueControl : UserControl
    {
        // Fields
        private byte level = 127;
        private string caption = "Value";
        private byte maxValue = 127;
        private byte shiftValue = 0;

        // Properties
        public byte Value
        {
            get { return level; }
            set
            {
                level = value;
                if (level > maxValue) level = maxValue;
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
        public byte MaxValue
        {
            get => maxValue;
            set 
            {
                maxValue = value;
                PrintValue();
            } 
        }
        public byte ShiftValue
        {
            get => shiftValue;
            set
            {
                shiftValue = value;
                PrintValue();
            }
        }

        // Constructor
        public ValueControl()
        {
            InitializeComponent();
        }

        // ---------------------------------------------  Graphics  ---------------------------------------------------
        // Print Value
        public void PrintValue()
        {
            lb_Caption.Text = string.Format("{0}: {1}", caption, level + shiftValue);
        }
        // Fore color changed
        private void ValueControl_ForeColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        // Back color changed
        private void ValueControl_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
