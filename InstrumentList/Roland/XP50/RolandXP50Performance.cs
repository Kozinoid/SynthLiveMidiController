using System;
using System.Collections.Generic;
using SynthLiveMidiController.MIDIMessages;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    // **********************************************************  ALL PERFORMANCE DATA CLASS  ***************************************************************
    class RolandXP50Performance : ISongListStorageSectionInterface, IFastListStorageSectionInterface, ISongListEditorSectionInterface, IFastListEditorSectionInterface
    {
        public event SegmentDataReceivedHandler SongDataReceived;
        public event SegmentDataReceivedHandler FastDataReceived;

        // -------------------------------------------  Static fields  ----------------------------------------
        public static int MIDIChannelCount = 16;
        public static int SongChannelCount = 10;
        public static int FastChannelCount = MIDIChannelCount - SongChannelCount;
        public static uint TemporaryPerformanceAddress = 0x01000000;
        public static uint[] USERPerformanceAddresses = {
                0x10000000, 0x10010000, 0x10020000, 0x10030000, 0x10040000, 0x10050000, 0x10060000, 0x10070000, 
                0x10080000, 0x10090000, 0x100A0000, 0x100B0000, 0x100C0000, 0x100D0000, 0x100E0000, 0x100F0000, 
                0x10100000, 0x10110000, 0x10120000, 0x10130000, 0x10140000, 0x10150000, 0x10160000, 0x10170000,
                0x10180000, 0x10190000, 0x101A0000, 0x101B0000, 0x101C0000, 0x101D0000, 0x101E0000, 0x101F0000
            };

        //----------------------------------------  DATA  -----------------------------------------------------
        private readonly PerformanceCommonClass performanceCommon;          // Performance common structure
        private readonly List<PerformancePartClass> performancePartList;    // Performance part list [16]
        private readonly uint performanceAddress;                           // Main performance address
        private readonly IPerformanceMIDIInOutInterface commander;          // Command Collection
        private readonly RolandXP50SongCommandSet songCommandSet;           // Song command set
        private readonly RolandXP50FastCommandSet fastCommandSet;           // FAst command set

        // Constructor
        public RolandXP50Performance(uint perfAddr, IPerformanceMIDIInOutInterface comm)                         // Constructor
        {
            performanceAddress = perfAddr;
            performanceCommon = new PerformanceCommonClass(performanceAddress);
            performancePartList = new List<PerformancePartClass>();
            for (int i = 0; i < MIDIChannelCount; i++)
            {
                performancePartList.Add(new PerformancePartClass(performanceAddress + 0x1000u + 0x100u * (uint)i));
            }

            songCommandSet = new RolandXP50SongCommandSet();
            fastCommandSet = new RolandXP50FastCommandSet();

            commander = comm;

            //commander.OnChannelEvent += Commander_OnChannelEvent;
            commander.OnSysExEditDataEvent += Commander_OnSysExEditDataEvent;
            commander.OnSysExRquestedDataEvent += Commander_OnSysExRquestedDataEvent;
        }

        //|                                                     PERFORMANCE DATA SECTION                                                        |
        //======================================================================================================================================|
        //|                                                  <<< MIDI COMMANDER COMMANDS >>>                                                    |          
        // MIDI Commander: Send Performance Common
        public void SendPerformanceCommon()
        {
            performanceCommon.SendData(commander);
        }

        // MIDI Commander: Send Performance Part #cannel
        public void SendPerformancePart(int channel)
        {
            performancePartList[channel].SendData(commander);
        }

        // MIDI Commander: Send Data
        public void SendPerformance()
        {
            SendPerformanceCommon();
            for (int i = 0; i < MIDIChannelCount; i++)
            {
                SendPerformancePart(i);
            }
        }

        // MIDI Commander: Request Data
        public void RequestPerformance()
        {
            performanceCommon.RequestData(commander);
            for (int i = 0; i < MIDIChannelCount; i++)
            {
                performancePartList[i].RequestData(commander);
            }
        }

        // MIDI Commander: Send Song Data
        public void SendSongData()
        {
            performanceCommon.SendData(commander);
            for (int i = 0; i < SongChannelCount; i++)
            {
                performancePartList[i].SendData(commander);
            }
        }

        // MIDI Commander: Send Fast Data
        public void SendFastData()
        {
            for (int i = SongChannelCount; i < FastChannelCount; i++)
            {
                performancePartList[i].SendData(commander);
            }
        }

        // MIDI Commander: Request Song Data
        public void RequestSongData()
        {
            performanceCommon.RequestData(commander);
            for (int i = 0; i < SongChannelCount; i++)
            {
                performancePartList[i].RequestData(commander);
            }
        }

        // MIDI Commander: Request Fast Data
        public void RequestFastData()
        {
            for (int i = SongChannelCount; i < FastChannelCount; i++)
            {
                performancePartList[i].RequestData(commander);
            }
        }


        //|                                                    SONG/FAST COMMAND SECTION                                                        |
        //======================================================================================================================================|
        //|                                                  <<< MIDI COMMANDER COMMANDS >>>                                                    |
        // MIDI Commander: Send Song Command
        public void SendSongCommand(int commandIndex)
        {
            songCommandSet.SendCommand(commandIndex, commander);
        }

        // MIDI Commander: Send Fast Command
        public void SendFastCommand(int commandIndex)
        {
            fastCommandSet.SendCommand(commandIndex, commander);
        }

        // MIDI Commander: Request Song Command
        public void RequestSongCommand(int commandIndex)
        {
            songCommandSet[commandIndex].efxSource = performanceCommon.EfxSource;
            for (int i = 0; i < SongChannelCount; i++)
            {
                songCommandSet[commandIndex][i].localSwitch = performancePartList[i].LocSwitch;
            }
        }

        // MIDi Commander: Request Fast Command
        public void RequestFastCommand(int commandIndex)
        {
            for (int i = SongChannelCount; i < FastChannelCount; i++)
            {
                songCommandSet[commandIndex][i - SongChannelCount].localSwitch = performancePartList[i].LocSwitch;
            }
        }

        //|                                                        CALLBACK SECTION                                                             |
        //=======================================================================================================================================
        //|                                                        CALLBACK SECTION                                                             |
        //---------------------------------------------------------------------------------------------------------------------------------------

        // ----  Variables for last received data storing  ----
        //int msb = -1;       // Most significant byte
        //int lsb = -1;       // Least significant byte
        //int patch = -1;     // Patch number

        //// Channel message received
        //private void Commander_OnChannelEvent(object sender, MIDIEvents.ChannelEventArgs e)
        //{
        //    switch (e.Command)
        //    {
        //        case MIDIEvents.ChannelCommand.Controller:
        //            if (e.Data1 == 0x00)
        //            {
        //                msb = e.Data2;
        //            }
        //            else if (e.Data1 == 0x20)
        //            {
        //                lsb = e.Data2;
        //            }
        //            //else
        //            //{
        //            //    // _____________________________  Other Control change  _________________________________
        //            //}
        //            break;

        //        case MIDIEvents.ChannelCommand.ProgramChange:
        //            patch = e.Data1;
        //            //string name = BankNameConvertor.GetPatchName(BankNameConvertor.ChannelCommandToBuffer(msb, lsb, patch));
        //            //Console.WriteLine(name);
        //            break;

        //            //case MIDIEvents.ChannelCommand.NoteOn:
        //            //    break;

        //            //case MIDIEvents.ChannelCommand.NoteOff:
        //            //    break;

        //            //case MIDIEvents.ChannelCommand.PitchWheel:
        //            //    break;

        //            //case MIDIEvents.ChannelCommand.PolyPressure:
        //            //    break;

        //            //case MIDIEvents.ChannelCommand.ChannelPressure:
        //            //    break;
        //    }
        //}

        // System exclusive: Requested data received
        private void Commander_OnSysExRquestedDataEvent(object sender, MIDIEvents.SysExEventArgs e)
        {
            SystemExclusiveBaseClass msg = new SystemExclusiveBaseClass(e.Buffer);
            int target = DetectTarget(msg);
            if ((target >= 0) && (target < SongChannelCount) || (target == 16)) SongDataReceived?.Invoke(sender, new SegmentDataReceivedEvendArgs(target));
            else if ((target >= SongChannelCount) && (target < SongChannelCount + FastChannelCount)) FastDataReceived?.Invoke(sender, new SegmentDataReceivedEvendArgs(target));
            else
            {
                // Other Segment
                //Console.WriteLine("Other segment");
            }

        }

        // System exclusive: Data for edit received
        private void Commander_OnSysExEditDataEvent(object sender, MIDIEvents.SysExEventArgs e)
        {
            SystemExclusiveBaseClass msg = new SystemExclusiveBaseClass(e.Buffer);
            int target = DetectTarget(msg);
            if ((target >= 0) && (target < SongChannelCount) || (target == 16)) SongDataReceived?.Invoke(sender, new SegmentDataReceivedEvendArgs(target));
            else if ((target >= SongChannelCount) && (target < SongChannelCount + FastChannelCount)) FastDataReceived?.Invoke(sender, new SegmentDataReceivedEvendArgs(target));
            else
            {
                // Other Segment
                //Console.WriteLine("Other segment");
            }
        }

        // Detect target of message
        private int DetectTarget(SystemExclusiveBaseClass msg)
        {
            int result = -1;

            uint addr = msg.GetAddressFromArray();
            if ((addr >= performanceCommon.SegmentAddress) && (addr < performanceCommon.SegmentAddress + performanceCommon.Length))
            {
                byte[] buf = performanceCommon.ToByteArray();
                uint off = msg.GetAddressFromArray() - performanceCommon.SegmentAddress;

                SetDataInBuffer(buf, off, msg.GetDataFromArray());

                performanceCommon.CopyDataToStructure(buf);
                //performanceCommon.Requested = false;

                result = 16;
            }
            else
            {
                for (int i = 0; i < performancePartList.Count; i++)
                {
                    if ((addr >= performancePartList[i].SegmentAddress) && (addr < performancePartList[i].SegmentAddress + performancePartList[i].Length))
                    {
                        byte[] buf = performancePartList[i].ToByteArray();
                        uint off = msg.GetAddressFromArray() - performancePartList[i].SegmentAddress;

                        SetDataInBuffer(buf, off, msg.GetDataFromArray());

                        performancePartList[i].CopyDataToStructure(buf);
                        //performancePartList[i].Requested = false;

                        result = i;
                        break;
                    }
                }
            }

            return result;  // 16 - Performance Common, 0-15 - Performance Part (1-16), -1 - no result;
        }

        // Set Data in Buffer
        private void SetDataInBuffer(byte[] buffer, uint offset, byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                buffer[offset + i] = data[i];
            }
        }

        //|                                                          INTERFACES SECTION                                                         |
        //======================================================================================================================================|
        //-----------------------------------------------------------------  Additional  -------------------------------------------------------|
        // Set Performance Common
        private void SetPerformanceCommon(byte[] data)
        {
            performanceCommon.CopyDataToStructure(data);
        }

        // Set Performance Part #channel
        private void SetPerformancePart(byte[] data, int channel)
        {
            performancePartList[channel].CopyDataToStructure(data);
        }

        // Get Performance Common
        private byte[] GetPerformanceCommon()
        {
            //while (performanceCommon.Requested) { };
            return performanceCommon.ToByteArray();
        }

        // Get Performance Part #channel
        private byte[] GetPerformancePart(int channel)
        {
            //while (performanceCommon.Requested) { };
            return performancePartList[channel].ToByteArray();
        }

        //--------------------------------------------------  ISongListStorageSectionInterface  ------------------------------------------------|

        string ISongPresetName.PresetName 
        {
            get => songCommandSet.PresetName;
            set => songCommandSet.PresetName = value; 
        }
        public string Singer 
        { 
            get => songCommandSet.Singer;
            set => songCommandSet.Singer = value; 
        }
        public string Key 
        {
            get => songCommandSet.Key;
            set => songCommandSet.Key = value;
        }

        public void SetSongData(byte[] data)
        {
            int index = 0;

            byte[] perfData = new byte[performanceCommon.Length];
            Array.Copy(data, index, perfData, 0, performanceCommon.Length);
            SetPerformanceCommon(perfData);

            index += (int)performanceCommon.Length;

            for (int i = 0; i < SongChannelCount; i++)
            {
                byte[] partData = new byte[performancePartList[i].Length];
                Array.Copy(data, index, partData, 0, performancePartList[i].Length);
                SetPerformancePart(partData, i);

                index += (int)performancePartList[i].Length;
            }
        }

        public byte[] GetSongData()
        {
            byte[] buffer = new byte[performanceCommon.Length + performancePartList[0].Length * SongChannelCount];
            int index = 0;

            Array.Copy(GetPerformanceCommon(), 0, buffer, index, performanceCommon.Length);
            index += (int)performanceCommon.Length;

            for (int i = 0; i < SongChannelCount; i++)
            {
                Array.Copy(GetPerformancePart(i), 0, buffer, index, performancePartList[i].Length);
                index += (int)performancePartList[i].Length;
            }

            return buffer;
        }

        string ISongPresetName.GetCommandName(int comNumber)
        {
            return songCommandSet.GetCommandName(comNumber);
        }

        void ISongPresetName.SetCommandName(int comNumber, string name)
        {
            songCommandSet.SetCommandName(comNumber, name);
        }

        public void SetSongCommandSection(byte[] data)
        {
            songCommandSet.FromByteArray(data);
        }

        public byte[] GetSongCommandSection()
        {
            return songCommandSet.ToByteArray();
        }

        //-------------------------------------------------  IFastListStorageSectionInterface  -------------------------------------------------|
        string IFastPresetName.PresetName
        {
            get => fastCommandSet.PresetName;
            set => fastCommandSet.PresetName = value;
        }
        
        public void SetFastData(byte[] data)
        {
            int index = 0;

            for (int i = SongChannelCount; i < MIDIChannelCount; i++)
            {
                byte[] partData = new byte[performancePartList[i].Length];
                Array.Copy(data, index, partData, 0, performancePartList[i].Length);
                SetPerformancePart(partData, i);

                index += (int)performancePartList[i].Length;
            }
        }

        public byte[] GetFastData()
        {
            byte[] buffer = new byte[performancePartList[0].Length * (MIDIChannelCount - SongChannelCount)];
            int index = 0;

            for (int i = SongChannelCount; i < MIDIChannelCount; i++)
            {
                Array.Copy(GetPerformancePart(i), 0, buffer, index, performancePartList[i].Length);
                index += (int)performancePartList[i].Length;
            }

            return buffer;
        }

        string IFastPresetName.GetCommandName(int comNumber)
        {
            return fastCommandSet.GetCommandName(comNumber);
        }

        void IFastPresetName.SetCommandName(int comNumber, string name)
        {
            fastCommandSet.SetCommandName(comNumber, name);
        }

        public void SetFastCommandSection(byte[] data)
        {
            fastCommandSet.FromByteArray(data);
        }

        public byte[] GetFastCommandSection()
        {
            return fastCommandSet.ToByteArray();
        }

        //-------------------------------------------------  ISongListEditorSectionInterface  --------------------------------------------------|
        public string PerformanceTitle 
        {
            get => performanceCommon.PerformanceName;
            set => performanceCommon.PerformanceName = value; 
        }

        public byte Tempo 
        {
            get => performanceCommon.Tempo;
            set => performanceCommon.Tempo = value; 
        }

        EFXSource ISongCommandsEditInterface.GetCommandEFXSource(int comNumber)
        {
            return songCommandSet.GetCommandEFXSource(comNumber);
        }

        void ISongCommandsEditInterface.SetCommandEFXSource(int comNumber, EFXSource src)
        {
            songCommandSet.SetCommandEFXSource(comNumber, src);
        }

        LocalSwitch ISongCommandsEditInterface.GetCommandLocalSwitch(int comNumber, int midichannel)
        {
            int channel = midichannel;
            return songCommandSet.GetCommandLocalSwitch(comNumber, channel);
        }

        void ISongCommandsEditInterface.SetCommandLocalSwitch(int comNumber, int midichannel, LocalSwitch lcSw)
        {
            int channel = midichannel;
            songCommandSet.SetCommandLocalSwitch(comNumber, channel, lcSw);
        }

        //-------------------------------------------------  IFastListEditorSectionInterface  --------------------------------------------------|
        EFXSource IFastCommandsEditInterface.GetCommandEFXSource(int comNumber)
        {
            return fastCommandSet.GetCommandEFXSource(comNumber);
        }

        void IFastCommandsEditInterface.SetCommandEFXSource(int comNumber, EFXSource src)
        {
            fastCommandSet.SetCommandEFXSource(comNumber, src);
        }

        LocalSwitch IFastCommandsEditInterface.GetCommandLocalSwitch(int comNumber, int midichannel)
        {
            int channel = midichannel - SongChannelCount;
            return fastCommandSet.GetCommandLocalSwitch(comNumber, channel);
        }

        void IFastCommandsEditInterface.SetCommandLocalSwitch(int comNumber, int midichannel, LocalSwitch lcSw)
        {
            int channel = midichannel - SongChannelCount;
            fastCommandSet.SetCommandLocalSwitch(comNumber, channel, lcSw);
        }

        //----------------------------------------------------  IPerformancePartInterface  -----------------------------------------------------|
        public RecieveHold1Switch GetRecieveHold1Switch(int channel)
        {
            return performancePartList[channel].Hold1Switch;
        }

        public void SetRecieveHold1Switch(int channel, RecieveHold1Switch hold)
        {
            performancePartList[channel].Hold1Switch = hold;
        }

        public byte GetLowerKey(int channel)
        {
            return performancePartList[channel].LowerKey;
        }

        public void SetLowerKey(int channel, byte key)
        {
            performancePartList[channel].LowerKey = key;
        }

        public byte GetUpperKey(int channel)
        {
            return performancePartList[channel].UpperKey;
        }

        public void SetUpperKey(int channel, byte key)
        {
            performancePartList[channel].UpperKey = key;
        }

        public byte GetVolume(int channel)
        {
            return performancePartList[channel].Volume;
        }

        public void SetVolume(int channel, byte val)
        {
            performancePartList[channel].Volume = val;
        }

        public byte GetPan(int channel)
        {
            return performancePartList[channel].Pan;
        }

        public void SetPan(int channel, byte val)
        {
            performancePartList[channel].Pan = val;
        }

        public byte GetReverb(int channel)
        {
            return performancePartList[channel].Reverb;
        }

        public void SetReverb(int channel, byte val)
        {
            performancePartList[channel].Reverb = val;
        }

        public byte GetChorus(int channel)
        {
            return performancePartList[channel].Chorus;
        }

        public void SetChorus(int channel, byte val)
        {
            performancePartList[channel].Chorus = val;
        }

        public byte[] GetPatch(int channel)
        {
            return performancePartList[channel].PatchCommandArray;
        }

        public void SetPatch(int channel, byte[] data)
        {
            performancePartList[channel].PatchCommandArray = data;
        }

        public byte GetOctaveShift(int channel)
        {
            return performancePartList[channel].OctaveShift;
        }

        public void SetOctaveShift(int channel, byte val)
        {
            performancePartList[channel].OctaveShift = val;
        }
    }

    public class SegmentDataReceivedEvendArgs : EventArgs
    {
        public int segment = 0;

        public SegmentDataReceivedEvendArgs(int num)
        {
            segment = num;
        }
    }
    public delegate void SegmentDataReceivedHandler(object sender, SegmentDataReceivedEvendArgs ea);
}
