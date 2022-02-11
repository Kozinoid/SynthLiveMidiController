using System.Windows.Forms;
using System.Drawing;
using SynthLiveMidiController.Pictures;

namespace SynthLiveMidiController
{
    public partial class CtlOneChannelParameters : UserControl
    {
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
    }
}
