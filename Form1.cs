using System;
using System.Drawing;
using System.Windows.Forms;
using SynthLiveMidiController.MIDIMessages;
using SynthLiveMidiController.InstrumentList.Roland.XP50;
using SynthLiveMidiController.Picrutes;
using System.Collections.Generic;

namespace SynthLiveMidiController
{
    public partial class Form1 : Form
    {
        // Fields
        private MIDIDevice.IMidiInOutInterface mainMidiDevice = null;       // Main MIDI Device
        private readonly MidiInOutDialog dlg = new MidiInOutDialog();       // Select Midi In/Out Device Dialog
        private int midiInDevice = -1;                                      // Midi In Device Index
        private int midiOutDevice = -1;                                     // Midi Out Device Index
        private PreprocessorCommandsClass perfCommander = null;             // Command module
        private InstrumentMIDIMessages messages = null;                     // Message options
        private RolandXP50Class roland = null;                              // Roland XP50 
        private RolandXP50Performance mainPerformance;                      // Main Performance
        private SongPresetEditor songPresetEditor = new SongPresetEditor(); // Song Preset Editor
        private FastPresetEditor fastPresetEditor = new FastPresetEditor(); // Fast Preset Editor

        //------------------------------------------  BUTTON GROUP CLASS  ----------------------------------------------
        class ButtonGroup 
        {
            public event EventHandler OnGroupClick = null;

            readonly List<Button> bt_List = new List<Button>();
            int selectedButton = -1;
            readonly Color mainColor;
            readonly Color selColor;
            readonly Color backColor;
            readonly Color selBackColor;

            public ButtonGroup(Color main, Color sel, Color back, Color selBack)
            {
                mainColor = main;
                selColor = sel;
                backColor = back;
                selBackColor = selBack;
            }

            public void Add(Button bt)
            {
                bt_List.Add(bt);
                bt.Click += Bt_Click;
            }

            private void Bt_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < bt_List.Count; i++)
                {
                    if (((Button)sender).Name == bt_List[i].Name)
                    {
                        SelectAt(i);
                        break;
                    }
                }

                OnGroupClick?.Invoke(sender, e);
            }

            public void RemoveAt(int index)
            {
                bt_List[index].Click -= Bt_Click;
                bt_List.RemoveAt(index);
            }

            public void SelectAt(int index)
            {
                selectedButton = index;
                for (int i = 0; i < bt_List.Count; i++)
                {
                    if (i == selectedButton)
                    {
                        bt_List[i].ForeColor = selColor;
                        bt_List[i].BackColor = selBackColor;
                    }
                    else
                    {
                        bt_List[i].ForeColor = mainColor;
                        bt_List[i].BackColor = backColor;
                    }
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        // Song Command Buttons
        readonly ButtonGroup bgSong = new ButtonGroup(VisualOptions.mainTextColor, VisualOptions.selTextColor, VisualOptions.backgroundColor, VisualOptions.selBackgroundColor);
        // Fast Command Buttons
        readonly ButtonGroup bgFast = new ButtonGroup(VisualOptions.mainTextColor, VisualOptions.selTextColor, VisualOptions.backgroundColor, VisualOptions.selBackgroundColor);

        // Constructor Form1
        public Form1()
        {
            InitializeComponent();

            LoadPatchNames();
            PrepareButtonGroups();
        }

        // Load Patch Names
        private void LoadPatchNames()
        {
            BankNameConvertor.LoadData();
        }

        // Prepare Button Groups
        private void PrepareButtonGroups()
        {
            bgSong.Add(bt_S1);
            bgSong.Add(bt_S2);
            bgSong.Add(bt_S3);
            bgSong.Add(bt_S4);
            bgSong.Add(bt_S5);
            bgSong.Add(bt_S6);
            bgSong.Add(bt_S7);
            bgSong.Add(bt_S8);
            bgSong.Add(bt_S9);
            bgSong.Add(bt_S10);

            bgFast.Add(bt_N1);
            bgFast.Add(bt_N2);
            bgFast.Add(bt_N3);
            bgFast.Add(bt_N4);
            bgFast.Add(bt_N5);
            bgFast.Add(bt_N6);
            bgFast.Add(bt_N7);
            bgFast.Add(bt_N8);
            bgFast.Add(bt_N9);

            bgSong.OnGroupClick += BgSong_OnGroupClick;
            bgFast.OnGroupClick += BgFast_OnGroupClick;
        }

        // Fast Command was selected
        private void BgFast_OnGroupClick(object sender, EventArgs e)
        {
            bgSong.SelectAt(-1);
        }

        // Song Command was selected
        private void BgSong_OnGroupClick(object sender, EventArgs e)
        {
            bgFast.SelectAt(-1);
        }

        // Form loading...
        private void Form1_Load(object sender, EventArgs e)
        {
            SetVisualoptions();
            SetupDevices();
        }

        // Visual Options
        private void SetVisualoptions()
        {
            // Font
            this.Font = VisualOptions.mainFont;
            songListControl.Font = VisualOptions.mainFont;
            fastListControl.Font = VisualOptions.mainFont;
            songPresetEditor.Font = VisualOptions.mainFont;
            fastPresetEditor.Font = VisualOptions.mainFont;
            lb_SongName.Font = VisualOptions.displayNameFont;
            lb_CommandName.Font = VisualOptions.displayTempoFont;
            lb_Tempo.Font = VisualOptions.displayTempoFont;

            // Fore Color
            this.ForeColor = VisualOptions.mainTextColor;
            songListControl.ForeColor = VisualOptions.mainTextColor;
            fastListControl.ForeColor = VisualOptions.mainTextColor;
            songPresetEditor.ForeColor = VisualOptions.mainTextColor;
            fastPresetEditor.ForeColor = VisualOptions.mainTextColor;

            // Background Color
            this.BackColor = VisualOptions.backgroundColor;
            songListControl.BackColor = VisualOptions.backgroundColor;
            fastListControl.BackColor = VisualOptions.backgroundColor;
            songPresetEditor.BackColor = VisualOptions.backgroundColor;
            fastPresetEditor.BackColor = VisualOptions.backgroundColor;
        }

        // Setup Devices
        private void SetupDevices()
        {
            ShowSelectMidiDeviceDialog();                                   // Show Device In/Out Dialog
            mainMidiDevice = new MIDIDevice.SanfordMidiDevice();            // Create MIDI Device
            mainMidiDevice.InitDevices(midiInDevice, midiOutDevice);        // Init In/Out devices

            roland = new RolandXP50Class();                                 // Use Roland XP50 
            messages = new InstrumentMIDIMessages(roland);                  // Use Roland XP50 message options

            perfCommander = new PreprocessorCommandsClass(mainMidiDevice, messages);                                        // Command module

            mainPerformance = new RolandXP50Performance(RolandXP50Performance.TemporaryPerformanceAddress, perfCommander);  // Main Performance

            songListControl.LoadData(mainPerformance);      // Song List    
            trackListControl.LoadData(mainPerformance);     // Track List (Loading manually!!!!!!!!)
            fastListControl.LoadData(mainPerformance);      // Fast List
            songPresetEditor.SetInterface(mainPerformance); // Attach Performance to Song Editor
            fastPresetEditor.SetInterface(mainPerformance); // Attach Performance to Fast Editor

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

        // -------------------------------------------------  DRAW TABCONTROL  ------------------------------------------------------------------
        // Draw Tab Control Pages Buttons
        private void tab_Control_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font font = VisualOptions.mainFont;
            Rectangle rect = tab_Control.GetTabRect(e.Index);
            
            e.Graphics.FillRectangle((e.State == DrawItemState.Selected) ? VisualOptions.selBeckgroundBrush : VisualOptions.backgroundBrush, rect);
            e.Graphics.DrawRectangle(VisualOptions.borderPen, rect);
            e.Graphics.DrawString(tab_Control.TabPages[e.Index].Text, font, (e.State == DrawItemState.Selected) ? VisualOptions.selBrush : VisualOptions.mainBrush, rect, VisualOptions.mainStringFormat);
        }

        // ---------------------------------------------------------  BUTTONS  ------------------------------------------------------------------
        // OPTOINS Button
        private void bt_Options_Click(object sender, EventArgs e)
        {
            songPresetEditor.ShowEditor(mainPerformance);
            //fastPresetEditor.ShowEditor(mainPerformance);
        }

        //---------------------------------------  TEST  --------------------------------------------
        private void bt_act1_Click(object sender, EventArgs e)
        {
            mainPerformance.RequestPerformance();
        }

        private void bt_act2_Click(object sender, EventArgs e)
        {
            songListControl.GetTemporaryDataFromPerformance();
            fastListControl.GetTemporaryDataFromPerformance();

            songListControl.PrintData();
            fastListControl.PrintData();
        }

        private void bt_act3_Click(object sender, EventArgs e)
        {
            songListControl.StoreTemporaryToTemplate();
            fastListControl.StoreTemporaryToTemplate();

            songListControl.SaveNewSongTemplate();
            fastListControl.SaveNewFastTemplate();
        }

        private void bt_act4_Click(object sender, EventArgs e)
        {
            songListControl.LoadNewSongTemplate();
            fastListControl.LoadNewFastTemplate();

            songListControl.LoadTemporaryFromTemplate();
            fastListControl.LoadTemporaryFromTemplate();
        }

        private void bt_act5_Click(object sender, EventArgs e)
        {
            songListControl.SetTemporaryDataToPerformance();
            fastListControl.SetTemporaryDataToPerformance();
        }

        private void bt_Act6_Click(object sender, EventArgs e)
        {
            mainPerformance.SendPerformance();
        }
    }
}
