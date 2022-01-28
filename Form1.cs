using System;
using System.Windows.Forms;
using SynthLiveMidiController.MIDIMessages;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class Form1 : Form
    {
        private MIDIDevice.IMidiInOutInterface mainMidiDevice = null;       // Main MIDI Device
        private readonly MidiInOutDialog dlg = new MidiInOutDialog();       // Select Midi In/Out Device Dialog
        private int midiInDevice = -1;                                      // Midi In Device Index
        private int midiOutDevice = -1;                                     // Midi Out Device Index
        private PerformanceCommandsClass perfCommander = null;               // Command module
        private InstrumentMIDIMessages messages = null;                     // Message options
        private RolandXP50Class roland = null;                              // Roland XP50 
        private RolandXP50Performance mainPerformance;

        public Form1()
        {
            InitializeComponent();
        }

        // Form loading...
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowSelectMidiDeviceDialog();                                   // Show Device In/Out Dialog
            mainMidiDevice = new MIDIDevice.SanfordMidiDevice();            // Create MIDI Device
            mainMidiDevice.InitDevices(midiInDevice, midiOutDevice);        // Init In/Out devices

            roland = new RolandXP50Class();                                 // Use Roland XP50 
            messages = new InstrumentMIDIMessages(roland);                  // Use Roland XP50 message options

            perfCommander = new PerformanceCommandsClass(mainMidiDevice, messages);    // Command module

            mainPerformance = new RolandXP50Performance(RolandXP50Performance.TemporaryPerformanceAddress, perfCommander);
        }

        // Form closing...
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            perfCommander.Stop();
            mainMidiDevice?.CloseDevices();                                 // close MIDI Device
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

      //---------------------------------------  TEST  --------------------------------------------
        byte[] songBuffer;
        byte[] fastBuffer;

        private void button3_Click(object sender, EventArgs e)
        {
            mainPerformance.RequestPerformance();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            songBuffer = mainPerformance.GetSongData();
            fastBuffer = mainPerformance.GetFastData();

            TestClass.PrintBuffer(songBuffer, "Song:");
            TestClass.PrintBuffer(fastBuffer, "Fast:");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RolandXP50Performance secondPerformance = new RolandXP50Performance(RolandXP50Performance.TemporaryPerformanceAddress, perfCommander);
            secondPerformance.SetSongData(songBuffer);
            secondPerformance.SetFastdata(fastBuffer);
            secondPerformance.SendPerformance();
        }


    }
}
