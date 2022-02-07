using System;
using System.Drawing;
using System.Windows.Forms;
using SynthLiveMidiController.Picrutes;

namespace SynthLiveMidiController
{
    public partial class CheckBoxControl : UserControl
    {
        // Fields
        private bool isChecked = false;
        private string caption = "Check";

        // Properties
        public bool IsChecked
        {
            get { return isChecked; }
            set 
            {
                isChecked = value;
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
        public CheckBoxControl()
        {
            InitializeComponent();
            lb_Caption.Click += CheckBoxControl_Click;
        }

        // CLick
        private void CheckBoxControl_Click(object sender, EventArgs e)
        {
            IsChecked = !isChecked;
            this.Invalidate();
        }

        // ---------------------------------------------  Graphics  ---------------------------------------------------
        // Print Value
        private void PrintValue()
        {
            lb_Caption.Text = string.Format("{0}: ", caption);
        }
        // Fore color changed
        private void CheckBoxControl_ForeColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        // Back color changed
        private void CheckBoxControl_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        // Drawing...
        private void CheckBoxControl_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = lb_Caption.Bounds;
            float size = Font.Size;
            Rectangle btRect = new Rectangle(new Point(rect.Width, (rect.Height - (int)size) / 2), new Size((int)size, (int)size));
            if (isChecked)
            {
                e.Graphics.FillEllipse(VisualOptions.mainBrush, btRect);
            }
            else
            {
                e.Graphics.DrawEllipse(VisualOptions.mainPen, btRect);
            }
        }
    }
}
