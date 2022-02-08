using System;
using System.Drawing;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class CtlPatchSelectField : UserControl
    {
        public event EventHandler PatchChange = null;

        // Fields
        private byte[] patchBuffer;
        private string caption = "Patch:";
        private readonly StringFormat sf = new StringFormat();
        private bool over = false;
        private Rectangle rect;
        private SizeF size;
        private int y;
        private bool pushed = false;

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

        // Buffer
        public byte[] PatchBuffer
        {
            get { return patchBuffer; }
            set
            {
                patchBuffer = value;
                CalculateBounds();
                this.Invalidate();
            }
        }

        // Constructor
        public CtlPatchSelectField()
        {
            InitializeComponent();

            patchBuffer = BankNameConvertor.ChannelCommandToBuffer(81, 0, 0);

            CalculateBounds();

            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            MouseEnter += CtlPatchSelectField_MouseEnter;
            MouseLeave += CtlPatchSelectField_MouseLeave;
            MouseWheel += CtlPatchSelectField_MouseWheel; ;
        }

        // ------------------------------------------------  Mouse Wheel Control  -------------------------------------------------------
        private void CtlPatchSelectField_MouseWheel(object sender, MouseEventArgs e)
        {
            if (over)
            {
                if (e.Delta > 0) NextPatch();
                if (e.Delta < 0) PrevPatch();
                CalculateBounds();
                this.Invalidate();
                PatchChange?.Invoke(sender, e);
            }
        }

        private void CtlPatchSelectField_MouseLeave(object sender, EventArgs e)
        {
            over = false;
        }

        private void CtlPatchSelectField_MouseEnter(object sender, EventArgs e)
        {
            Focus();
            over = true;
        }

        //------------------------------------------------  Mouse Drag Control  ---------------------------------------------------------
        private void CtlPatchSelectField_MouseDown(object sender, MouseEventArgs e)
        {
            y = e.Y;
            pushed = true;
        }

        private void CtlPatchSelectField_MouseUp(object sender, MouseEventArgs e)
        {
            pushed = false;
        }

        private void CtlPatchSelectField_MouseMove(object sender, MouseEventArgs e)
        {
            if (pushed)
            {
                if (e.Y > y) PrevPatch();
                if (e.Y < y) NextPatch(); 
                CalculateBounds();
                this.Invalidate();
                PatchChange?.Invoke(sender, e);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        private void NextPatch()
        {
            patchBuffer = BankNameConvertor.Next(patchBuffer);
        }

        private void PrevPatch()
        {
            patchBuffer = BankNameConvertor.Prev(patchBuffer);
        }
        //-------------------------------------------------------------------------------------------------------------------------------

        // Calculate
        protected virtual void CalculateBounds()
        {
            size = Graphics.FromHwnd(this.Handle).MeasureString(caption, Font);
            rect = this.ClientRectangle;
            rect.Offset((int)size.Width, 0);
        }

        // Drawing
        private void CtlPatchSelectField_Paint(object sender, PaintEventArgs e)
        {
            Drawing(e.Graphics);
        }

        // Overridable Drawing Fuction
        public void Drawing(Graphics gr)
        {
            string patchName = "";
            if (BankNameConvertor.IsLoaded) patchName = BankNameConvertor.GetPatchName(patchBuffer);
            gr.DrawString(caption, Font, new SolidBrush(ForeColor), this.ClientRectangle, sf);
            gr.DrawString(patchName, Font, new SolidBrush(ForeColor), rect, sf);
        }

        // Double Click
        private void CtlPatchSelectField_DoubleClick(object sender, EventArgs e)
        {
            SelectPatchDialog spd = new SelectPatchDialog
            {
                CommandBuffer = PatchBuffer
            };
            if (spd.ShowDialog() == DialogResult.OK)
            {
                //Console.WriteLine("Ok");
                PatchBuffer = spd.CommandBuffer;
            }
        }
    }
}
