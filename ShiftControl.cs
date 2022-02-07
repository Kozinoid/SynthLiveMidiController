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
    public partial class ShiftControl : UserControl
    {
        // Fields
        private int level = 0;
        private string caption = "Value";
        private int minValue = -63;
        private int maxValue = 63;

        // Properties
        public int Value
        {
            get { return level; }
            set
            {
                level = value;
                if (level < minValue) level = minValue;
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
        public int MinValue
        {
            get => minValue;
            set 
            {
                minValue = value;
                if (minValue > maxValue) minValue = maxValue;
            } 
        }
        public int MaxValue
        {
            get => maxValue;
            set 
            {
                maxValue = value;
                if (maxValue < minValue) maxValue = minValue;
            }
        }

        // Constructor
        public ShiftControl()
        {
            InitializeComponent();
        }

        // ---------------------------------------------  Graphics  ---------------------------------------------------
        // Print Value
        private void PrintValue()
        {
            lb_Caption.Text = string.Format("{0}: {1}", caption, level);
        }

        private void ShiftControl_ForeColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ShiftControl_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
