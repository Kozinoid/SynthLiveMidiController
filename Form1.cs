using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;

namespace SynthLiveMidiController
{
    public partial class Form1 : Form
    {
        MIDIDevice.IMidiInOutInterface midiDevice = null;       // Main MIDI Device
        private readonly MidiInOutDialog dlg = new MidiInOutDialog();    // Select Midi In/Out Device Dialog
        private int midiInDevice = -1;                          // Midi In Device Index
        private int midiOutDevice = -1;                         // Midi Out Device Index

        public Form1()
        {
            InitializeComponent();
        }

        // Form loading...
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowSelectMidiDeviceDialog();                           // Show Device In/Out Dialog
            midiDevice = new MIDIDevice.SanfordMidiDevice();        // Create MIDI Device
            midiDevice.InitDevices(midiInDevice, midiOutDevice);    // Init In/Out devices
        }

        // Form closing...
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            midiDevice?.CloseDevices();
        }

        // Select MIDI devices or exit
        private void ShowSelectMidiDeviceDialog()
        {
            do
            {
                DialogResult dr = dlg.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    midiInDevice = dlg.SelectedInIndex;
                    midiOutDevice = dlg.SelectedOutIndex;
                }
                else if (dr == DialogResult.Abort)
                {
                    Environment.Exit(0);
                }
            }
            while ((midiInDevice < 0) || (midiOutDevice < 0));
        }
    }
}
