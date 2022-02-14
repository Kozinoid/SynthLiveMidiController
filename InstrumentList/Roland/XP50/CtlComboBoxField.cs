using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    public partial class CtlComboBoxField : CtlByteField
    {
        private int shift = 0;
        private List<string> list;
        private int capacity = 0;

        public override byte ByteValue 
        {
            get { return (byte)(base.ByteValue - (byte)shift); }  
            set => base.ByteValue = (byte)(value + (byte)shift); 
        }

        public CtlComboBoxField()
        {
            InitializeComponent();

            caption = "Command:";
            min = 1;
            max = 10;
            shift = 1;

            capacity = max - min;
            list = new List<string>();
            for (int i = 0; i < capacity; i++)
            {
                list.Add("");
            }
        }

        public void SetStringValue(int intValue, string strValue)
        {
            int index = ValidateValue(intValue) - shift;
            list[intValue] = strValue;
        }

        protected override int ValidateValue(int argument)
        {
            return base.ValidateValue(argument);
        }

        public override void Drawing(Graphics gr)
        {
            //string text = (list != null) ? (_value.ToString() + " - " + list[_value - shift]) : (_value.ToString() + " - ");
            gr.DrawString(caption, Font, new SolidBrush(ForeColor), this.ClientRectangle, sf);
            //gr.DrawString(text, Font, new SolidBrush(ForeColor), rect, sf);
        }

        protected override void CalculateBounds()
        {
            base.CalculateBounds();
        }
    }
}
