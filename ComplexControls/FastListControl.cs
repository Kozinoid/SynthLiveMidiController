using System;
using System.IO;
using System.Windows.Forms;
using SynthLiveMidiController.File;
using SynthLiveMidiController.InstrumentList.Roland.XP50;
using SynthLiveMidiController.Picrutes;

namespace SynthLiveMidiController
{
    public partial class FastListControl : UserControl
    {
        // Fields
        private IFastListStorageSectionInterface instrument;            // Main Performance&Command Object

        private RolandXP50FastPreset temporaryFastPreset;               // Temporary Preset
        private RolandXP50FastPreset templateFastPreset;                // Template Preset
        private string templateFileName = "";                           // Default path

        // Constructor
        public FastListControl()
        {
            InitializeComponent();
        }

        // -------------------------------------------  Visual Options  ------------------------------------------------------
        // Fore Color
        private void FastListControl_ForeColorChanged(object sender, EventArgs e)
        {
            ChangeCellStyle();
        }

        // Back Color
        private void FastListControl_BackColorChanged(object sender, EventArgs e)
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
            dgv_FastListView.ColumnHeadersDefaultCellStyle = cellStyle;
            dgv_FastListView.DefaultCellStyle = cellStyle;
        }

        // Load Template and Temporary Data  !!!! PREPARE FAST LIST
        public void LoadData(IFastListStorageSectionInterface dev)
        {
            instrument = dev;
            templateFastPreset = new RolandXP50FastPreset();
            temporaryFastPreset = new RolandXP50FastPreset();

            templateFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Templates\\NewFastTemplate");

            // Load New Fast Template
            LoadNewFastTemplate();
            LoadTemporaryFromTemplate();

            // Load Fast List data
            TestFillSongSheet(); // Test
        }

        // Load New Song Template
        public void LoadNewFastTemplate()
        {
            MultiDataFileStream mdfs = new MultiDataFileStream(templateFileName, FileMode.Open, FileAccess.Read);
            templateFastPreset.LoadPreset(mdfs);
            mdfs.Close();
        }

        // Save New Song Template
        public void SaveNewFastTemplate()
        {
            MultiDataFileStream mdfs = new MultiDataFileStream(templateFileName, FileMode.OpenOrCreate, FileAccess.Write);
            templateFastPreset.SavePreset(mdfs);
            mdfs.Close();
        }

        // Template -> Temporary
        public void LoadTemporaryFromTemplate()
        {
            temporaryFastPreset = (RolandXP50FastPreset)templateFastPreset.Clone();
        }

        // Temporary -> Template
        public void StoreTemporaryToTemplate()
        {
            templateFastPreset = (RolandXP50FastPreset)temporaryFastPreset.Clone();
        }

        // Add preset to List
        public void AddNewPreset()
        {
            // Add to List
            int i = dgv_FastListView.Rows.Count;
            dgv_FastListView.Rows.Add(i.ToString(), string.Format("Song Name {0}", i), "Ctl+D1");

            // Tag
        }

        // Insert preset to List at <index> position
        public void InsertPresetAt(int index)
        {
            // Insert into List
            int i = dgv_FastListView.Rows.Count;
            dgv_FastListView.Rows.Insert(index, i.ToString(), string.Format("Song Name {0}", i),  "Ctl+D1");

            //Tag
        }

        // Delete preset from List at <index> position
        public void DeletePresetAt(int index)
        {
            // Tag
            dgv_FastListView.Rows[index].Tag = null;

            // Remove
            dgv_FastListView.Rows.RemoveAt(index);
        }

        // Get Temporary Data from Performance object
        public void GetTemporaryDataFromPerformance()
        {
            temporaryFastPreset.GetDataFromPerformance(instrument);
        }

        // Set Temporary Data to Performance object
        public void SetTemporaryDataToPerformance()
        {
            temporaryFastPreset.SetDataToPerformance(instrument);
        }

        //------------------- TEST -----------------------
        public void PrintData()
        {
            Console.WriteLine("TEMPORARY FAST");
            temporaryFastPreset.PrintData();
            Console.WriteLine("TEMPLATE FAST");
            templateFastPreset.PrintData();
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

    //--------------------------------------------  Fast Preset Class  ---------------------------------------------------------------
    class RolandXP50FastPreset : ICloneable
    {
        public string PresetName { get; set; }
        public byte[] FastData { get; set; }
        public string[] CommandNames { get; set; }
        public byte[] FastCommandSection { get; set; }

        // Constructor
        public RolandXP50FastPreset()
        {
            PresetName = "";
            CommandNames = new string[RolandXP50CommandSet.FastCommandCount];
        }

        // Clone Preset Object
        public object Clone()
        {
            RolandXP50FastPreset obj = new RolandXP50FastPreset
            {
                PresetName = PresetName,
                FastData = new byte[FastData.Length]
            };
            Array.Copy(FastData, obj.FastData, FastData.Length);
            for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            {
                obj.CommandNames[i] = CommandNames[i];
            }
            obj.FastCommandSection = new byte[FastCommandSection.Length];
            Array.Copy(FastCommandSection, obj.FastCommandSection, FastCommandSection.Length);

            return obj;
        }

        // Get Data From Performance
        public void GetDataFromPerformance(IFastListStorageSectionInterface dev)
        {
            //PresetName = dev.GetPresetName();
            //FastData = dev.GetFastData();
            //for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            //{
            //    CommandNames[i] = dev.GetCommandName(i);
            //}
            //FastCommandSection = dev.GetFastCommandSection();
        }

        // Set Data To Performance
        public void SetDataToPerformance(IFastListStorageSectionInterface dev)
        {
            //dev.SetPresetName(PresetName);
            //dev.SetFastData(FastData);
            //for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            //{
            //    dev.SetCommandName(i, CommandNames[i]);
            //}
            //dev.SetFastCommandSection(FastCommandSection);
        }

        // Save Preset To File
        public void SavePreset(MultiDataFileStream mdfs)
        {
            mdfs.WriteString(PresetName);
            mdfs.WriteByteArray(FastData);
            for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            {
                mdfs.WriteString(CommandNames[i]);
            }
            mdfs.WriteByteArray(FastCommandSection);
        }

        // Load Preset To File
        public void LoadPreset(MultiDataFileStream mdfs)
        {
            PresetName = mdfs.ReadString();
            FastData = mdfs.ReadByteArray();
            for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            {
                CommandNames[i] = mdfs.ReadString();
            }
            FastCommandSection = mdfs.ReadByteArray();
        }

        //------------------- TEST -----------------------
        public void PrintData()
        {
            Console.WriteLine("Fast Data:");
            Console.WriteLine("Fast name: {0}", PresetName);
            for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            {
                Console.WriteLine(CommandNames[i]);
            }
        }
    }
}
