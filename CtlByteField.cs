using System;
using System.Drawing;
using System.Windows.Forms;

namespace SynthLiveMidiController
{
    public partial class CtlByteField : UserControl
    {
        public event EventHandler ValueChanged = null;

        // Fields
        protected int min = 0;
        protected int max = 127;
        protected int _value = 127;
        protected string caption = "Vol:";
        protected readonly StringFormat sf = new StringFormat();
        protected TextBox tbEnter = new TextBox();
        protected Rectangle rect;
        protected SizeF size;
        protected bool over = false;
        protected int y;
        protected bool pushed = false;

        // Caption
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                CalculateBounds();
                this.Invalidate();
            }
        }

        // Value
        public int Value
        {
            get { return _value; }
            set
            {
                _value = ValidateValue(value);
                CalculateBounds();
                this.Invalidate();
            }
        }

        // ByteValue
        public virtual byte ByteValue
        {
            get { return (byte)_value; }
            set { Value = value; }
        }

        // Constructor
        public CtlByteField()
        {
            InitializeComponent();

            CalculateBounds();

            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            MouseEnter += CtlByteField_MouseEnter;
            MouseLeave += CtlByteField_MouseLeave;
            MouseWheel += CtlByteField_MouseWheel;

            tbEnter.KeyDown += TbEnter_KeyDown;
        }

        // ------------------------------------------------  Mouse Wheel Control  -------------------------------------------------------
        private void CtlByteField_MouseWheel(object sender, MouseEventArgs e)
        {
            if (over)
            {
                int delta = (e.Delta > 0) ? 1 : -1;
                _value = ValidateValue(_value + delta);
                this.Invalidate();
                ValueChanged?.Invoke(sender, e);
            }
        }

        private void CtlByteField_MouseLeave(object sender, EventArgs e)
        {
            over = false;
        }

        private void CtlByteField_MouseEnter(object sender, EventArgs e)
        {
            Focus();
            over = true;
        }

        //------------------------------------------------  Mouse Drag Control  ---------------------------------------------------------
        private void CtlByteField_MouseDown(object sender, MouseEventArgs e)
        {
            y = e.Y;
            pushed = true;
        }

        private void CtlByteField_MouseUp(object sender, MouseEventArgs e)
        {
            pushed = false;
        }

        private void CtlByteField_MouseMove(object sender, MouseEventArgs e)
        {
            if (pushed)
            {
                int delta = 0;
                if (e.Y > y) delta = -1;
                if (e.Y < y) delta = 1;
                y = e.Y;
                _value = ValidateValue(_value + delta);
                this.Invalidate();
                ValueChanged?.Invoke(sender, e);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------

        // Validate value
        protected virtual int ValidateValue(int argument)
        {
            int res = argument;
            if (res < min) res = min;
            if (res > max) res = max;
            return res;
        }

        // Calculate
        protected virtual void CalculateBounds()
        {
            size = Graphics.FromHwnd(this.Handle).MeasureString(caption, Font);
            rect = this.ClientRectangle;
            rect.Offset((int)size.Width, 0);
        }

        // Drawing
        private void CtlByteField_Paint(object sender, PaintEventArgs e)
        {
            Drawing(e.Graphics);
        }

        // Overridable Drawing Fuction
        public virtual void Drawing(Graphics gr)
        {
            gr.DrawString(caption, Font, new SolidBrush(ForeColor), this.ClientRectangle, sf);
            gr.DrawString(_value.ToString(), Font, new SolidBrush(ForeColor), rect, sf);
        }

        // Double Click
        private void CtlByteField_DoubleClick(object sender, EventArgs e)
        {
            tbEnter.Text = _value.ToString();
            tbEnter.Location = rect.Location;
            this.Controls.Add(tbEnter);
            tbEnter.Focus();
        }

        // End Edit
        private void TbEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int res;
                try
                {
                    res = int.Parse(tbEnter.Text);

                    this.Controls.Remove(tbEnter);
                    _value = ValidateValue(res);
                    this.Invalidate();
                    e.Handled = true;
                    ValueChanged?.Invoke(sender, e);
                }
                catch
                {
                    MessageBox.Show("Value is not valid!");
                }
            }
        }
    }
}
