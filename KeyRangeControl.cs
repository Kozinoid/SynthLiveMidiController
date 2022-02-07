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
    public partial class KeyRangeControl : UserControl
    {
        // Fields
        private byte lowerKey = 0;
        private byte upperKey = 127;
        private byte octaveShift = 3;

        // Properties
        public byte LowerKey
        {
            get { return lowerKey; }
            set
            {
                lowerKey = value;
                if (lowerKey > upperKey) upperKey = lowerKey;
                PrintValue();
            }
        }

        public byte UpperKey
        {
            get { return upperKey; }
            set
            {
                upperKey = value;
                if (upperKey < lowerKey) lowerKey = upperKey;
                PrintValue();
            }
        }

        public byte OctaveShift
        {
            get { return octaveShift; }
            set
            {
                int calc;
                byte newVal = value;
                if (newVal > 6) newVal = 6;
                int delta = (newVal - octaveShift) * 12;
                if ((lowerKey > 0) || (lowerKey < 127))
                {
                    calc = lowerKey + delta;
                    if (calc > 127) calc = 127;
                    if (calc < 0) calc = 0;
                    lowerKey = (byte)calc;
                }

                if ((upperKey > 0) || (upperKey < 127))
                {
                    calc = upperKey + delta;
                    if (calc > 127) calc = 127;
                    if (calc < 0) calc = 0;
                    upperKey = (byte)calc;
                }

                PrintValue();
            }
        }

        public byte KeyboardLower
        {
            get => (byte)(lowerKey + ((3 - octaveShift) * 12));
            set 
            { 
                lowerKey = (byte)(value - ((3 - octaveShift) * 12));
                PrintValue();
            }
        }

        public byte KeyboardUpper
        {
            get => (byte)(upperKey + ((3 - octaveShift) * 12));
            set 
            { 
                upperKey = (byte)(value - ((3 - octaveShift) * 12));
                PrintValue();
            }
        }

        public int KeyboardOctaveShift
        {
            get => octaveShift - 3;
            set
            {
                octaveShift = (byte)(value + 3);
                if (octaveShift > 6) octaveShift = 6;
                PrintValue();
            }
    }

        // Constructor
        public KeyRangeControl()
        {
            InitializeComponent();
        }

        // ---------------------------------------------  Graphics  ---------------------------------------------------
        // Print Value
        private void PrintValue()
        {
            lb_Lower.Value = lowerKey;
            lb_Octave.Value = KeyboardOctaveShift;
            lb_Upper.Value = upperKey;
        }
    }
}
