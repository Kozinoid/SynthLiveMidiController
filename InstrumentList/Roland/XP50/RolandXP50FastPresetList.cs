using System;
using System.Collections.Generic;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    //--------------------------------------------  Fast Preset List Class  ----------------------------------------------------------
    class RolandXP50FastPresetList
    {
        private readonly IFastListStorageSectionInterface instrument;
        private readonly List<RolandXP50FastPreset> fastPresetList = new List<RolandXP50FastPreset>();

        public RolandXP50FastPresetList(IFastListStorageSectionInterface dev)
        {
            instrument = dev;
            fastPresetList = new List<RolandXP50FastPreset>();

            // Load New Fast Template

            // Load Fast List data
        }

        public void GetData()
        {

        }

        public void SetData()
        {
;
        }

        //------------------- TEST -----------------------
        public void PrintData()
        {
            
        }
    }

    //--------------------------------------------  Fast Preset Class  ---------------------------------------------------------------
    class RolandXP50FastPreset : ICloneable
    {
        public string PresetName { get; set; }
        public byte[] FastData { get; set; }
        public string[] CommandNames { get; set; }
        public byte[] FastCommandSection { get; set; }

        public RolandXP50FastPreset()
        {
            PresetName = "";
            CommandNames = new string[RolandXP50CommandSet.FastCommandCount];
        }

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

        public void GetData(IFastListStorageSectionInterface dev)
        {
            PresetName = dev.PresetName;
            FastData = dev.GetFastData();
            for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            {
                CommandNames[i] = dev.GetCommandName(i);
            }
            FastCommandSection = dev.GetFastCommandSection();
        }

        public void SetData(IFastListStorageSectionInterface dev)
        {
            dev.PresetName = PresetName;
            dev.SetFastData(FastData);
            for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            {
                dev.SetCommandName(i, CommandNames[i]);
            }
            dev.SetFastCommandSection(FastCommandSection);
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
