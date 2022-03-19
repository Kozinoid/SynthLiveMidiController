using System;
using System.Windows.Forms;
using System.Drawing;

namespace SynthLiveMidiController
{
    public partial class CtlOneChannelParameters : UserControl
    {
        // -----------------------------------  Events  ----------------------------------------------------
        public event EventHandler SelectedChange = null;
        public event EventHandler ItemDropped = null;

        // -------------------------------------  Fields  --------------------------------------------------
        private bool selected = false;
        private readonly Color selColor = Picrutes.VisualOptions.selBackgroundColor;
        private readonly Color backColor = Picrutes.VisualOptions.backgroundColor;

        // ------------------------------------------  Drag&Drop  ------------------------------------------
        static CtlOneChannelParameters dragItem;
        static bool msDown = false;
        static bool dragging = false;
        static int drX = 0;
        static int drY = 0;

        // -------------------------------------  Properties  ----------------------------------------------
        public bool Selected
        {
            get { return selected; }
            set 
            {
                selected = value; ;
                BackColor = (selected) ? selColor : backColor;
                this.Invalidate();
            }
        }

        //--------------------------------------------------------------------------------------------------
        // Constructor
        public CtlOneChannelParameters()
        {
            InitializeComponent();
        }

        // Channel?????
        private void ctlChannel_ValueChanged(object sender, System.EventArgs e)
        {
            // Request channel parameters
        }
        // Hold
        private void ctlHold_CheckedChange(object sender, System.EventArgs e)
        {
            // Send Hold switch
        }
        // Volume
        private void ctlVolume_ValueChanged(object sender, System.EventArgs e)
        {
            // Send Volume
        }
        // Pan
        private void ctlPan_ValueChanged(object sender, System.EventArgs e)
        {
            // Send Pan
        }
        // Reverb
        private void ctlReverb_ValueChanged(object sender, System.EventArgs e)
        {
            // Send Reverb
        }
        // Chorus
        private void ctlChorus_ValueChanged(object sender, System.EventArgs e)
        {
            // Cend Chorus
        }
        // Patch
        private void ctlPatch_PatchChange(object sender, System.EventArgs e)
        {
            // Send Patch
        }
        //---------------------------------------------  ZONE  ---------------------------------------------------
        // Lower Key
        private void ctlKeyDown_ValueChanged(object sender, System.EventArgs e)
        {
            int absLowerKey = ctlKeyDown.ByteValue - 12 * ctlOctave.Value - 36;
            ctlKeyzoneField1.LowerKey = absLowerKey;
            int upperKey = ctlKeyzoneField1.UpperKey + 12 * ctlOctave.Value + 36;
            ctlKeyUp.Value = upperKey;
            SendKeyZone();
        }
        // Octave
        private void ctlOctave_ValueChanged(object sender, System.EventArgs e)
        {
            int lowerKey = ctlKeyzoneField1.LowerKey + 12 * ctlOctave.Value + 36;
            ctlKeyDown.Value = lowerKey;
            int upperKey = ctlKeyzoneField1.UpperKey + 12 * ctlOctave.Value + 36;
            ctlKeyUp.Value = upperKey;
            SendKeyZone();
        }
        // Upper Key
        private void ctlKeyUp_ValueChanged(object sender, System.EventArgs e)
        {
            int absUpperKey = ctlKeyUp.ByteValue - 12 * ctlOctave.Value - 36;
            ctlKeyzoneField1.UpperKey = absUpperKey;
            int lowerKey = ctlKeyzoneField1.LowerKey + 12 * ctlOctave.Value + 36;
            ctlKeyDown.Value = lowerKey;
            SendKeyZone();
        }
        // KeyZone
        private void ctlKeyzoneField1_KeyRangeChanged(object sender, System.EventArgs e)
        {
            int lowerKey = ctlKeyzoneField1.LowerKey + 12 * ctlOctave.Value + 36;
            ctlKeyDown.Value = lowerKey;
            int upperKey = ctlKeyzoneField1.UpperKey + 12 * ctlOctave.Value + 36;
            ctlKeyUp.Value = upperKey;
            SendKeyZone();
        }
        // Send Lower, Upper, Octave
        public void SendKeyZone()
        {
            // Send Keyzone
        }
        //---------------------------------------------------------------------------------------------------------
        // Select
        private void pn_Select_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedChange?.Invoke(this, e);

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                dragItem = this;
                msDown = true;
                drX = e.X;
                drY = e.Y;
            }
        }

        //-----------------------------------------  Drag & Drop  -------------------------------------------------
        private void pn_Select_DragDrop(object sender, DragEventArgs e)
        {
            dragging = false;

            if (e.Data.GetDataPresent(typeof(CtlOneChannelParameters))) 
            {
                msDown = false;
                dragging = false;

                ItemDropped?.Invoke(this, e);
            }
        }

        private void pn_Select_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pn_Select_MouseMove(object sender, MouseEventArgs e)
        {
            if (!msDown) return;
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if ((Math.Abs(drX - e.X) > 5) || (Math.Abs(drY - e.Y) > 5))
                {
                    dragging = true;

                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = this.DoDragDrop(dragItem, DragDropEffects.Move);
                }
            }
        }

        private void pn_Select_MouseUp(object sender, MouseEventArgs e)
        {
            msDown = false;
            dragging = false;
        }
    }
}
