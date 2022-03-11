using System;
using System.Drawing;
using System.Windows.Forms;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    public abstract partial class XP50BaseControl : UserControl
    {
        // Callback
        public event EventHandler ValueChanged = null;

        // Fields
        protected string caption = "Vol:";
        protected readonly StringFormat sf = new StringFormat();
        protected TextBox tbEnter = new TextBox();
        protected bool over = false;
        protected bool pushed = false;
        protected int y;
        protected SizeF size;
        protected Rectangle rect;

        // Caption
        public virtual string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                XP_CalculateBounds();
                this.Invalidate();
            }
        }
        // Enable Editor
        public bool EnableEditor { get; set; } = false;
        // Enable Context
        public bool EnableContext { get; set; } = false;

        // Constructor
        public XP50BaseControl()
        {
            InitializeComponent();

            XP_CalculateBounds();

            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            MouseEnter += XP50BaseControl_MouseEnter;
            MouseLeave += XP50BaseControl_MouseLeave;
            MouseWheel += XP50BaseControl_MouseWheel;

            tbEnter.KeyDown += TbEnter_KeyDown;
        }

        // --------------------------------------------------  TextBox  -----------------------------------------------------------------
        private void TbEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XP_EndEdit(sender, e);
                this.Controls.Remove(tbEnter);
                this.Invalidate();
                e.Handled = true;
                ValueChanged?.Invoke(sender, e);
            }
        }

        // ------------------------------------------------  Mouse Wheel Control  -------------------------------------------------------
        private void XP50BaseControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (over)
            {
                if (e.Delta > 0) XP_IncValue();
                if (e.Delta < 0) XP_DecValue();
                this.Invalidate();
                ValueChanged?.Invoke(sender, e);
            }
        }

        private void XP50BaseControl_MouseLeave(object sender, EventArgs e)
        {
            over = false;
        }

        private void XP50BaseControl_MouseEnter(object sender, EventArgs e)
        {
            Focus();
            over = true;
        }

        //------------------------------------------------  Mouse Drag Control  ---------------------------------------------------------
        private void XP50BaseControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                y = e.Y;
                pushed = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (EnableContext) XP_RightClick(sender, e);
            }
        }

        private void XP50BaseControl_MouseUp(object sender, MouseEventArgs e)
        {
            pushed = false;
        }

        private void XP50BaseControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (pushed)
            {
                if (e.Y > y) XP_DecValue();
                if (e.Y < y) XP_IncValue(); ;
                y = e.Y;
                this.Invalidate();
                ValueChanged?.Invoke(sender, e);
            }
        }

        //---------------------------------------------------  EDIT  --------------------------------------------------------------------
        private void XP50BaseControl_DoubleClick(object sender, EventArgs e)
        {
            if (EnableEditor) XP_BeginEdit();
        }

        //-----------------------------------------------------  PAINT  -----------------------------------------------------------------
        private void XP50BaseControl_Paint(object sender, PaintEventArgs e)
        {
            XP_Drawing(e.Graphics);
        }

        //_________________________________________  VIRTUAL METHODS  _________________________________________________
        // Increment Value
        public virtual void XP_IncValue()
        {

        }

        // Decrement Value
        public virtual void XP_DecValue()
        {

        }

        // Overridable Drawing Fuction
        public virtual void XP_Drawing(Graphics gr)
        {
            //Caption
            gr.DrawString(caption, Font, new SolidBrush(ForeColor), this.ClientRectangle, sf);
        }

        // Calculate
        protected virtual void XP_CalculateBounds()
        {
            size = Graphics.FromHwnd(this.Handle).MeasureString(caption, Font);
            rect = this.ClientRectangle;
            rect.Offset((int)size.Width, 0);
        }

        // SelectCommand()
        public virtual void XP_RightClick(object sender, MouseEventArgs e)
        {

        }

        // Enter
        public virtual void XP_EndEdit(object sender, KeyEventArgs e)
        {
            
        }

        // Dbl click Override
        public virtual void XP_BeginEdit()
        {
            tbEnter.Location = rect.Location;
            this.Controls.Add(tbEnter);
            tbEnter.Focus();
        }
    }
}
