﻿using SynthLiveMidiController.MIDIMessages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    // **********************************************************  ALL PERFORMANCE DATA CLASS  ***************************************************************
    class RolandXP50Performance
    {
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
        private readonly string defaultPath = "";
        private readonly string txtPath = "";

        // Constructor
        public RolandXP50Performance(uint perfAddr, IPerformanceMIDIInOutInterface comm)                         // Constructor
        {
            defaultPath = Path.GetDirectoryName(Application.ExecutablePath);
            txtPath = Path.Combine(defaultPath, "InstrumentList\\Roland\\XP50\\Txt");
            BankNameConvertor.LoadData(txtPath, "USER.txt", "Bank A.txt", "Bank B.txt", "Bank C.txt", "GM.txt", "Bank EXP-A.txt", "Bank Exp-B.txt");

            performanceAddress = perfAddr;
            performanceCommon = new PerformanceCommonClass(performanceAddress);
            performancePartList = new List<PerformancePartClass>();
            for (int i = 0; i < MIDIChannelCount; i++)
            {
                performancePartList.Add(new PerformancePartClass(performanceAddress + 0x1000u + 0x100u * (uint)i));
            }

            commander = comm;

            commander.OnChannelEvent += Commander_OnChannelEvent;
            commander.OnSysExEditDataEvent += Commander_OnSysExEditDataEvent;
            commander.OnSysExRquestedDataEvent += Commander_OnSysExRquestedDataEvent;
        }

        //---------------------------------- Send/Request Methods  ---------------------------------------------
        // MIDI Commander Send Performance Common
        public void SendPerformanceCommon()
        {
            performanceCommon.SendData(commander);
        }

        // MIDI Commander Sent Performance Part #cannel
        public void SendPerformancePart(int channel)
        {
            performancePartList[channel].SendData(commander);
        }

        // MIDI Commander Send Data
        public void SendPerformance()
        {
            SendPerformanceCommon();
            for (int i = 0; i < MIDIChannelCount; i++)
            {
                SendPerformancePart(i);
            }
        }

        // MIDI Commander Send Song Data
        public void SendSongData()
        {
            performanceCommon.SendData(commander);
            for (int i = 0; i < SongChannelCount; i++)
            {
                performancePartList[i].SendData(commander);
            }
        }

        // MIDI Commander Send Fast Data
        public void SendQuickData()
        {
            for (int i = SongChannelCount; i < FastChannelCount; i++)
            {
                performancePartList[i].SendData(commander);
            }
        }

        // MIDI Commander Request Data
        public void RequestPerformance()
        {
            performanceCommon.RequestData(commander);
            for (int i = 0; i < MIDIChannelCount; i++)
            {
                performancePartList[i].RequestData(commander);
            }
        }

        // MIDI Commander Request Song Data
        public void RequestSongData()
        {
            performanceCommon.RequestData(commander);
            for (int i = 0; i < SongChannelCount; i++)
            {
                performancePartList[i].RequestData(commander);
            }
        }

        // MIDI Commander Request Fast Data
        public void RequestQuickData()
        {
            for (int i = SongChannelCount; i < FastChannelCount; i++)
            {
                performancePartList[i].RequestData(commander);
            }
        }

        //====================================  RECEIVE  CALLBACKS  ===========================================
        private void Commander_OnSysExRquestedDataEvent(object sender, MIDIEvents.SysExEventArgs e)
        {
            SystemExclusiveBaseClass msg = new SystemExclusiveBaseClass(e.Buffer);
            int target = DetectTarget(msg);
        }

        private void Commander_OnSysExEditDataEvent(object sender, MIDIEvents.SysExEventArgs e)
        {
            SystemExclusiveBaseClass msg = new SystemExclusiveBaseClass(e.Buffer);
            int target = DetectTarget(msg);
        }

        int msb = -1, lsb = -1, patch = -1;
        private void Commander_OnChannelEvent(object sender, MIDIEvents.ChannelEventArgs e)
        {
            switch(e.Command)
            {
                case MIDIEvents.ChannelCommand.Controller:
                    if (e.Data1 == 0x00)
                    {
                        msb = e.Data2;
                    }
                    else if (e.Data1 == 0x20)
                    {
                        lsb = e.Data2;
                    }
                    //else
                    //{
                    //    // _____________________________  Other Control change  _________________________________
                    //}
                    break;

                case MIDIEvents.ChannelCommand.ProgramChange:
                    patch = e.Data1;
                    string name = BankNameConvertor.GetPatchName(BankNameConvertor.ChannelCommandToBuffer(msb, lsb, patch));
                    //Console.WriteLine(name);
                    break;

                //case MIDIEvents.ChannelCommand.NoteOn:
                //    break;

                //case MIDIEvents.ChannelCommand.NoteOff:
                //    break;

                //case MIDIEvents.ChannelCommand.PitchWheel:
                //    break;

                //case MIDIEvents.ChannelCommand.PolyPressure:
                //    break;

                //case MIDIEvents.ChannelCommand.ChannelPressure:
                //    break;
            }
        }

        // Detect target of message
        private int DetectTarget(SystemExclusiveBaseClass msg)
        {
            int result = -1;

            uint addr = msg.GetAddressFromArray();
            if ((addr >= performanceCommon.SegmentAddress) && (addr < performanceCommon.SegmentAddress + performanceCommon.Length))
            {
                byte[] buf = performanceCommon.Data;
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
                        byte[] buf = performancePartList[i].Data;
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

        //--------------------------  Set/Get data to/from perfopmance methods  ---------------------------------
        // Set Performance Common
        public void SetPerformanceCommon(byte[] buffer)
        {
            performanceCommon.CopyDataToStructure(buffer);
        }

        // Set Performance Part #channel
        public void SetPerformancePart(byte[] buffer, int channel)
        {
            performancePartList[channel].CopyDataToStructure(buffer);
        }

        // Get Performance Common
        public byte[] GetPerformanceCommon()
        {
            //while (performanceCommon.Requested) { };
            return performanceCommon.Data;
        }

        // Get Performance Part #channel
        public byte[] GetPerformancePart(int channel)
        {
            //while (performanceCommon.Requested) { };
            return performancePartList[channel].Data;
        }

        // Set Song Data
        public void SetSongData(byte[] buffer)
        {
            int index = 0;

            byte[] perfData = new byte[performanceCommon.Length];
            Array.Copy(buffer, index, perfData, 0, performanceCommon.Length);
            SetPerformanceCommon(perfData);

            index += (int)performanceCommon.Length;

            for (int i = 0; i < SongChannelCount; i++)
            {
                byte[] partData = new byte[performancePartList[i].Length];
                Array.Copy(buffer, index, partData, 0, performancePartList[i].Length);
                SetPerformancePart(partData, i);

                index += (int)performancePartList[i].Length;
            }
        }

        // Get Song Data
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

        // set fast data
        public void SetFastdata(byte[] buffer)
        {
            int index = 0;

            for (int i = SongChannelCount; i < MIDIChannelCount; i++)
            {
                byte[] partData = new byte[performancePartList[i].Length];
                Array.Copy(buffer, index, partData, 0, performancePartList[i].Length);
                SetPerformancePart(partData, i);

                index += (int)performancePartList[i].Length;
            }
        }

        // Get FAst Data
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
    }


    // -----------------------------------------------  Data Segment Base Class  ---------------------------------------------------------------------
    abstract class DataSegmentClass
    {
        protected readonly uint segmentAddress;                         // Main Segment Address
        public uint SegmentAddress { get { return segmentAddress; } }   // Main segment address getter

        //protected bool requested = false;
        //public bool Requested { get { return requested; } set { requested = value; } }

        // Base Constructor
        protected DataSegmentClass(uint addr)
        {
            segmentAddress = addr;
        }

        public abstract void SendData(IPerformanceMIDIInOutInterface commander);
        public abstract void RequestData(IPerformanceMIDIInOutInterface commander);
    }

    // ---------------------------------------------  Performance Common Data Class  -----------------------------------------------------------------
    class PerformanceCommonClass : DataSegmentClass
    {
        // Structure
        PERFORMANCE_COMMON performanceCommonData;

        // Structure -> Data Array
        public byte[] Data
        {
            get
            {
                int rawsize = Marshal.SizeOf(performanceCommonData);
                IntPtr buffer = Marshal.AllocHGlobal(rawsize);
                Marshal.StructureToPtr(performanceCommonData, buffer, false);
                byte[] rawdata = new byte[rawsize];
                Marshal.Copy(buffer, rawdata, 0, rawsize);
                Marshal.FreeHGlobal(buffer);
                return rawdata;
            }
        }

        // Structure Length
        public uint Length
        {
            get { return (uint)Marshal.SizeOf(performanceCommonData); }
        }

        // Constructor
        public PerformanceCommonClass(uint segAddr) : base(segAddr)
        {
            performanceCommonData = new PERFORMANCE_COMMON();
        }

        // Data Array -> Structure
        public void CopyDataToStructure(byte[] data)
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            PERFORMANCE_COMMON temp = (PERFORMANCE_COMMON)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PERFORMANCE_COMMON));
            handle.Free();
            performanceCommonData = temp;
        }

        // Send
        public override void SendData(IPerformanceMIDIInOutInterface commander)
        {
            commander.SendData(segmentAddress, Data);
        }

        // Request
        public override void RequestData(IPerformanceMIDIInOutInterface commander)
        {
            //requested = true;
            commander.RequestData(segmentAddress, Length);
        }
    }

    // -------------------------------------------------  Performance Part Data Class  ---------------------------------------------------------------
    class PerformancePartClass : DataSegmentClass
    {
        // Structure
        PERFORMANCE_PART performancePartData;

        // Structure -> Data Array
        public byte[] Data
        {
            get
            {
                int rawsize = Marshal.SizeOf(performancePartData);
                IntPtr buffer = Marshal.AllocHGlobal(rawsize);
                Marshal.StructureToPtr(performancePartData, buffer, false);
                byte[] rawdata = new byte[rawsize];
                Marshal.Copy(buffer, rawdata, 0, rawsize);
                Marshal.FreeHGlobal(buffer);
                return rawdata;
            }
        }

        // Structure Length
        public uint Length
        {
            get { return (uint)Marshal.SizeOf(performancePartData); }
        }

        // Constructor
        public PerformancePartClass(uint segAddr) : base(segAddr)
        {
            performancePartData = new PERFORMANCE_PART();
        }

        // Data Array -> Structure
        public void CopyDataToStructure(byte[] data)
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            PERFORMANCE_PART temp = (PERFORMANCE_PART)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PERFORMANCE_PART));
            handle.Free();
            performancePartData = temp;
        }

        // Send
        public override void SendData(IPerformanceMIDIInOutInterface commander)
        {
            commander.SendData(segmentAddress, Data);
        }

        // Request
        public override void RequestData(IPerformanceMIDIInOutInterface commander)
        {
            //requested = true;
            commander.RequestData(segmentAddress, Length);
        }
    }
}
