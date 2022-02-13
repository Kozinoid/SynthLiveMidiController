using System;
using System.Drawing;
using System.Windows.Forms;

namespace SynthLiveMidiController
{
    public partial class CtlStringField : UserControl
    {
        public event EventHandler ValueChanged = null;

        // Fields
        protected string _value = "";
        protected string caption = "Name:";
        protected readonly StringFormat sf = new StringFormat();
        protected TextBox tbEnter = new TextBox();
        protected Rectangle rect;
        protected SizeF size;

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
        public string Value
        {
            get { return _value; }
            set
            {
                _value = ValidateValue(value);
                CalculateBounds();
                this.Invalidate();
            }
        }

        // Constructor
        public CtlStringField()
        {
            InitializeComponent();

            CalculateBounds();

            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;

            tbEnter.KeyDown += TbEnter_KeyDown;
        }

        // Validate value
        protected virtual string ValidateValue(string argument)
        {
            string res = argument;
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
        private void CtlStringField_Paint(object sender, PaintEventArgs e)
        {
            Drawing(e.Graphics);
        }

        // Overridable Drawing Fuction
        public virtual void Drawing(Graphics gr)
        {
            gr.DrawString(caption, Font, new SolidBrush(ForeColor), this.ClientRectangle, sf);
            gr.DrawString(_value, Font, new SolidBrush(ForeColor), rect, sf);
        }

        // Double Click
        private void CtlStringField_DoubleClick(object sender, EventArgs e)
        {
            tbEnter.Text = _value;
            tbEnter.Location = rect.Location;
            tbEnter.Size = new Size(this.ClientRectangle.Width - rect.Left, this.ClientRectangle.Height);
            this.Controls.Add(tbEnter);
            tbEnter.Focus();
        }

        // End Edit
        private void TbEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _value = ValidateValue(tbEnter.Text);
                this.Controls.Remove(tbEnter);
                CalculateBounds();
                this.Invalidate();
                e.Handled = true;
                ValueChanged?.Invoke(sender, e);
            }
        }
    }
}
