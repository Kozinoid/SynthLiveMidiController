using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using SynthLiveMidiController.File;
using SynthLiveMidiController.InstrumentList.Roland.XP50;
using SynthLiveMidiController.Picrutes;

namespace SynthLiveMidiController
{
    public partial class SongListControl : UserControl
    {
        // Fields
        private ISongListStorageSectionInterface instrument;            // Main Performance&Command Object

        private RolandXP50SongPreset temporarySongPreset;               // Temporary Preset
        private RolandXP50SongPreset templateSongPreset;                // Template Preset
        private string templateFileName = "";                           // Default path

        // Constructor
        public SongListControl()
        {
            InitializeComponent();
        }

        // -------------------------------------------  Visual Options  ------------------------------------------------------
        // Fore Color
        private void SongListControl_ForeColorChanged(object sender, EventArgs e)
        {
            ChangeCellStyle();
        }

        // Back Color
        private void SongListControl_BackColorChanged(object sender, EventArgs e)
        {
            ChangeCellStyle();
        }

        // Change cell style
        private void ChangeCellStyle()
        {
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                ForeColor = VisualOptions.mainTextColor,
                SelectionForeColor = VisualOptions.selTextColor,
                BackColor = VisualOptions.backgroundColor,
                SelectionBackColor = VisualOptions.selBackgroundColor,
                Font = VisualOptions.mainFont
            };
            dgv_SongListView.ColumnHeadersDefaultCellStyle = cellStyle;
            dgv_SongListView.DefaultCellStyle = cellStyle;
        }

        // -----------------------------------------  Methods  ---------------------------------------------------------------
        // Load Template and Temporary Data
        public void LoadData(ISongListStorageSectionInterface dev)
        {
            instrument = dev;
            templateSongPreset = new RolandXP50SongPreset();
            temporarySongPreset = new RolandXP50SongPreset();

            templateFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Templates\\NewSongTemplate");

            // Load New Song Template
            LoadNewSongTemplate();
            LoadTemporaryFromTemplate();

            // Load Song List data
            TestFillSongSheet(); // Test
        }

        // Load New Song Template
        public void LoadNewSongTemplate()
        {
            MultiDataFileStream mdfs = new MultiDataFileStream(templateFileName, FileMode.Open, FileAccess.Read);
            templateSongPreset.LoadPreset(mdfs);
            mdfs.Close();
        }

        // Save New Song Template
        public void SaveNewSongTemplate()
        {
            MultiDataFileStream mdfs = new MultiDataFileStream(templateFileName, FileMode.OpenOrCreate, FileAccess.Write);
            templateSongPreset.SavePreset(mdfs);
            mdfs.Close();
        }

        // Template -> Temporary
        public void LoadTemporaryFromTemplate()
        {
            temporarySongPreset = (RolandXP50SongPreset)templateSongPreset.Clone();
        }

        // Temporary -> Template
        public void StoreTemporaryToTemplate()
        {
            templateSongPreset = (RolandXP50SongPreset)temporarySongPreset.Clone();
        }

        // Add preset to List
        public void AddNewPreset()
        {
            // Add to List
            int i = dgv_SongListView.Rows.Count;
            dgv_SongListView.Rows.Add(i.ToString(), string.Format("Song Name {0}", i), string.Format("Singer {0}", i), "F#m", "120");

            // Tag
        }

        // Insert preset to List at <index> position
        public void InsertPresetAt(int index)
        {
            // Insert into List
            int i = dgv_SongListView.Rows.Count;
            dgv_SongListView.Rows.Insert(index, i.ToString(), string.Format("Song Name {0}", i), string.Format("Singer {0}", i), "F#m", "120");

            //Tag
        }

        // Delete preset from List at <index> position
        public void RemovePresetAt(int index)
        {
            // Tag
            dgv_SongListView.Rows[index].Tag = null;

            // Remove
            dgv_SongListView.Rows.RemoveAt(index);
        }

        // Get Temporary Data from Performance object
        public void GetTemporaryDataFromPerformance()
        {
            temporarySongPreset.GetDataFromPerformance(instrument);
        }

        // Set Temporary Data to Performance object
        public void SetTemporaryDataToPerformance()
        {
            temporarySongPreset.SetDataToPerformance(instrument);
        }

        //------------------- TEST -----------------------
        public void PrintData()
        {
            Console.WriteLine("TEMPORARY SONG");
            temporarySongPreset.PrintData();
            Console.WriteLine("TEMPLATE SONG");
            templateSongPreset.PrintData();
        }

        // Fill List
        public void TestFillSongSheet()
        {
            for (int i = 0; i < 50; i++)
            {
                AddNewPreset();
            }
        }
    }

    //--------------------------------------------  Song Preset Class  ---------------------------------------------------------------
    class RolandXP50SongPreset : ICloneable
    {
        public string PresetName { get; set; }
        public string Singer { get; set; }
        public string Key { get; set; }
        public byte[] SongData { get; set; }
        public string[] CommandNames { get; set; }
        public byte[] SongCommandSection { get; set; }

        // Constructor
        public RolandXP50SongPreset()
        {
            PresetName = "";
            Singer = "";
            Key = "";
            CommandNames = new string[RolandXP50CommandSet.SongCommandCount];
        }

        // Clone Preset Object
        public object Clone()
        {
            RolandXP50SongPreset obj = new RolandXP50SongPreset
            {
                PresetName = PresetName,
                Singer = Singer,
                Key = Key,
                SongData = new byte[SongData.Length]
            };
            Array.Copy(SongData, obj.SongData, SongData.Length);
            for (int i = 0; i < RolandXP50CommandSet.SongCommandCount; i++)
            {
                obj.CommandNames[i] = CommandNames[i];
            }
            obj.SongCommandSection = new byte[SongCommandSection.Length];
            Array.Copy(SongCommandSection, obj.SongCommandSection, SongCommandSection.Length);

            return obj;
        }

        // Get Data From Performance
        public void GetDataFromPerformance(ISongListStorageSectionInterface dev)
        {
            PresetName = dev.PresetName;
            Singer = dev.Singer;
            Key = dev.Key;
            SongData = dev.GetSongData();
            for (int i = 0; i < RolandXP50CommandSet.SongCommandCount; i++)
            {
                CommandNames[i] = dev.GetCommandName(i);
            }
            SongCommandSection = dev.GetSongCommandSection();
        }

        // Set Data To Performance
        public void SetDataToPerformance(ISongListStorageSectionInterface dev)
        {
            dev.PresetName = PresetName;
            dev.Singer = Singer;
            dev.Key = Key;
            dev.SetSongData(SongData);
            for (int i = 0; i < RolandXP50CommandSet.SongCommandCount; i++)
            {
                dev.SetCommandName(i, CommandNames[i]);
            }
            dev.SetSongCommandSection(SongCommandSection);
        }

        // Save Preset To File
        public void SavePreset(MultiDataFileStream mdfs)
        {
            mdfs.WriteString(PresetName);
            mdfs.WriteString(Singer);
            mdfs.WriteString(Key);
            mdfs.WriteByteArray(SongData);
            for (int i = 0; i < RolandXP50CommandSet.SongCommandCount; i++)
            {
                mdfs.WriteString(CommandNames[i]);
            }
            mdfs.WriteByteArray(SongCommandSection);
        }

        // Load Preset To File
        public void LoadPreset(MultiDataFileStream mdfs)
        {
            PresetName = mdfs.ReadString();
            Singer = mdfs.ReadString();
            Key = mdfs.ReadString();
            SongData = mdfs.ReadByteArray();
            for (int i = 0; i < RolandXP50CommandSet.SongCommandCount; i++)
            {
                CommandNames[i] = mdfs.ReadString();
            }
            SongCommandSection = mdfs.ReadByteArray();
        }

        //------------------- TEST -----------------------
        public void PrintData()
        {
            Console.WriteLine("Song Data:");
            Console.WriteLine("Song name: {0}", PresetName);
            Console.WriteLine("Singer: {0}", Singer);
            Console.WriteLine("Key: {0}", Key);
            for (int i = 0; i < RolandXP50CommandSet.SongCommandCount; i++)
            {
                Console.WriteLine(CommandNames[i]);
            }
        }
    }
}
