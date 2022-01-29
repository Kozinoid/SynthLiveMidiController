using SynthLiveMidiController.MIDIMessages;
using System.Collections.Generic;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    public class RolandXP50ChannelCommandClass
    {
        private readonly LocalSwitch localSwitch = LocalSwitch.OFF;

        public RolandXP50ChannelCommandClass(LocalSwitch sw)
        {
            localSwitch = sw;
        }
    }

    public class RolandXP50PerformanceCommand
    {
        private readonly EFXSource efxSource = EFXSource.PERFORM;
        private readonly List<RolandXP50ChannelCommandClass> channels;

        public RolandXP50PerformanceCommand(int chCount, EFXSource efx)
        {
            efxSource = efx;
            channels = new List<RolandXP50ChannelCommandClass>(chCount);
            for (int i = 0; i < chCount; i++)
            {
                channels[i] = new RolandXP50ChannelCommandClass(LocalSwitch.OFF);
            }
        }
    }

    // Command Set Base Class - Send Command, Load Commands
    class RolandXP50CommandSet
    {
        public static int SongCommandCount = 10;
        public static int FastCommandCount = 9;

        protected List<RolandXP50PerformanceCommand> commandList;
        readonly IPerformanceMIDIInOutInterface commander;          // Command Collection

        internal RolandXP50CommandSet(int commandCount, int channelCount, IPerformanceMIDIInOutInterface comm)
        {
            commander = comm;
            commandList = new List<RolandXP50PerformanceCommand>(commandCount);
            for (int i = 0; i < commandCount; i++)
            {
                commandList[i] = new RolandXP50PerformanceCommand(channelCount, EFXSource.PERFORM);
            }
        }

        public void SendCommand(int comNumber) 
        {
            if ((comNumber >= 0) || (comNumber < commandList.Count)) 
            {
               // Send Command to commander
            }
        }
    }

    // Song Command Set
    class RolandXP50SongCommandSet : RolandXP50CommandSet
    {
        public RolandXP50SongCommandSet(IPerformanceMIDIInOutInterface comm) : base(SongCommandCount, RolandXP50Performance.SongChannelCount, comm)
        {
            
        }
    }

    // Fast Command Set - Add Patch Settings
    class RolandXP50FastCommandSet : RolandXP50CommandSet
    {
        // Add Patch settings!!!!

        public RolandXP50FastCommandSet(IPerformanceMIDIInOutInterface comm) : base(FastCommandCount, RolandXP50Performance.FastChannelCount, comm)
        {
            
        }
    }

    // SongList

    // FastPresetList
}
