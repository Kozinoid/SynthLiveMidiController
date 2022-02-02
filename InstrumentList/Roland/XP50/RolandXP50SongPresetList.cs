using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using SynthLiveMidiController.File;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    //--------------------------------------------  Song Preset List Class  ----------------------------------------------------------
    class RolandXP50SongPresetList
    {
        // Fields
        private readonly ISongListStorageSectionInterface instrument;                                   // Main Performance&Command Object
        private readonly List<RolandXP50SongPreset> songPresetList = new List<RolandXP50SongPreset>();  // Song Preset List
        private RolandXP50SongPreset temporarySongPreset;                                               // Temporary Preset
        private RolandXP50SongPreset templateSongPreset;                                                // Template Preset
        private string templateFileName = "";                                                           // Default path

        // Constructor
        public RolandXP50SongPresetList(ISongListStorageSectionInterface dev)
        {
            instrument = dev;
            songPresetList = new List<RolandXP50SongPreset>();
            templateSongPreset = new RolandXP50SongPreset();
            temporarySongPreset = new RolandXP50SongPreset();

            templateFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Templates\\NewSongTemplate");

            // Load New Song Template
            LoadNewSongTemplate();
            LoadTemporaryFromTemplate();

            // Load Song List data

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
            RolandXP50SongPreset obj = new RolandXP50SongPreset();
            obj.PresetName = PresetName;
            obj.Singer = Singer;
            obj.Key = Key;
            obj.SongData = new byte[SongData.Length];
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
