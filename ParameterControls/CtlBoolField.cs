using System;
using System.Drawing;
using System.Windows.Forms;

namespace SynthLiveMidiController
{
    public partial class CtlBoolField : UserControl
    {
        public event EventHandler CheckedChange = null;

        // Fields
        private bool isChecked = false;
        private string caption = "Hold:";
        private float diameter = 10f;
        private readonly StringFormat sf = new StringFormat();
        private bool over = false;

        // Caption
        public string Caption
        {
            get { return caption; }
            set 
            {
                caption = value;
                this.Invalidate();
            }
        }

        // Checked
        public bool Checked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                this.Invalidate();
            }
        }

        // Constructor
        public CtlBoolField()
        {
            InitializeComponent();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            MouseEnter += CtlBoolField_MouseEnter;
            MouseLeave += CtlBoolField_MouseLeave;
            MouseWheel += CtlBoolField_MouseWheel;
        }

        // ------------------------------------------------  Mouse Wheel Control  -------------------------------------------------------
        private void CtlBoolField_MouseWheel(object sender, MouseEventArgs e)
        {
            if (over)
            {
                if (e.Delta > 0) isChecked = true;
                if (e.Delta < 0) isChecked = false;
                this.Invalidate();
                CheckedChange?.Invoke(sender, e);
            }
        }

        private void CtlBoolField_MouseLeave(object sender, EventArgs e)
        {
            over = false;
        }

        private void CtlBoolField_MouseEnter(object sender, EventArgs e)
        {
            Focus();
            over = true;
        }
        //-------------------------------------------------------------------------------------------------------------------------------

        // Drawing
        private void CtlBoolField_Paint(object sender, PaintEventArgs e)
        {
            diameter = Font.Size;
            SizeF size = e.Graphics.MeasureString(caption, Font);
            e.Graphics.DrawString(caption, Font, new SolidBrush(ForeColor), this.ClientRectangle, sf);

            RectangleF rect = new RectangleF(size.Width + Padding.Left + Padding.Right + Margin.Left + Margin.Right, (this.ClientRectangle.Height - size.Height) / 2 + Padding.Top + Margin.Top, diameter, diameter);

            if (Checked)
            {
                e.Graphics.FillEllipse(new SolidBrush(ForeColor), rect);
            }
            else
            {
                e.Graphics.DrawEllipse(new Pen(ForeColor), rect);
            }
        }

        // Checked change
        private void CtlBoolField_Click(object sender, EventArgs e)
        {
            Checked = !Checked;
            CheckedChange?.Invoke(sender, e);
        }
    }
}
