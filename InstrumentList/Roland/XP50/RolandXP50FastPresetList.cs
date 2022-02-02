using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using SynthLiveMidiController.File;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    //--------------------------------------------  Fast Preset List Class  ----------------------------------------------------------
    class RolandXP50FastPresetList
    {
        // Fields
        private readonly IFastListStorageSectionInterface instrument;                                   // Main Performance&Command Object
        private readonly List<RolandXP50FastPreset> fastPresetList = new List<RolandXP50FastPreset>();  // Song Preset List
        private RolandXP50FastPreset temporaryFastPreset;                                               // Temporary Preset
        private RolandXP50FastPreset templateFastPreset;                                                // Template Preset
        private string templateFileName = "";                                                           // Default path

        // Constructor
        public RolandXP50FastPresetList(IFastListStorageSectionInterface dev)
        {
            instrument = dev;
            fastPresetList = new List<RolandXP50FastPreset>();
            templateFastPreset = new RolandXP50FastPreset();
            temporaryFastPreset = new RolandXP50FastPreset();

            templateFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Templates\\NewFastTemplate");

            // Load New Fast Template
            LoadNewFastTemplate();
            LoadTemporaryFromTemplate();

            // Load Fast List data

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
        }

        // Insert preset to List at <index> position
        public void InsertPresetAt(int index)
        {
            // Insert into List
        }

        // Delete preset from List at <index> position
        public void DeletePresetAt(int index)
        {

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
            RolandXP50FastPreset obj = new RolandXP50FastPreset();
            obj.PresetName = PresetName;
            obj.FastData = new byte[FastData.Length];
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
            PresetName = dev.PresetName;
            FastData = dev.GetFastData();
            for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            {
                CommandNames[i] = dev.GetCommandName(i);
            }
            FastCommandSection = dev.GetFastCommandSection();
        }

        // Set Data To Performance
        public void SetDataToPerformance(IFastListStorageSectionInterface dev)
        {
            dev.PresetName = PresetName;
            dev.SetFastData(FastData);
            for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            {
                dev.SetCommandName(i, CommandNames[i]);
            }
            dev.SetFastCommandSection(FastCommandSection);
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
