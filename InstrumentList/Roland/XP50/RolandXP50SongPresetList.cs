using System;
using System.Collections.Generic;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    //--------------------------------------------  Song Preset List Class  ----------------------------------------------------------
    class RolandXP50SongPresetList
    {
        private readonly ISongListStorageSectionInterface instrument;
        private readonly List<RolandXP50SongPreset> songPresetList = new List<RolandXP50SongPreset>();

        public RolandXP50SongPresetList(ISongListStorageSectionInterface dev)
        {
            instrument = dev;
            songPresetList = new List<RolandXP50SongPreset>();

            // Load New Song Template

            // Load Song List data

        }

        public void GetData() 
        {
            
        }

        public void SetData()
        {
            
        }

        //------------------- TEST -----------------------
        public void PrintData()
        {
            
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

        public RolandXP50SongPreset()
        {
            PresetName = "";
            Singer = "";
            Key = "";
            CommandNames = new string[RolandXP50CommandSet.SongCommandCount];
        }

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

        public void GetData(ISongListStorageSectionInterface dev)
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

        public void SetData(ISongListStorageSectionInterface dev)
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
