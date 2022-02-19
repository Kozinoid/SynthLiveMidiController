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
    public partial class CtlEFXSourceField : CtlByteField
    {
        string stringValue;
        string[] array = { "Perf", "1", "2", "3", "4", "5", "6", "7", "8", "9", "11", "12", "13", "14", "15", "16" };

        public CtlEFXSourceField()
        {
            InitializeComponent();

            _value = 0;
            caption = "EFX:";
            min = 0;
            max = 15;
        }

        public override byte ByteValue
        {
            get { return (byte)_value; }
            set
            {
                int res = ValidateValue(value);
                _value = res;
            }
        }

        public override void Drawing(Graphics gr)
        {
            stringValue = array[_value];

            gr.DrawString(caption, Font, new SolidBrush(ForeColor), this.ClientRectangle, sf);
            gr.DrawString(stringValue, Font, new SolidBrush(ForeColor), rect, sf);
        }

        protected override void CalculateBounds()
        {
            base.CalculateBounds();
        }
    }
}
