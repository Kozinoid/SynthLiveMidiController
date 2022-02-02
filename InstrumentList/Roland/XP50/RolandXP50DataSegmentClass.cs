using System;
using System.Text;
using System.Runtime.InteropServices;
using SynthLiveMidiController.MIDIMessages;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    // -----------------------------------------------  Data Segment Base Class  ---------------------------------------------------------------------
    abstract class DataSegmentClass
    {
        // Main Segment Address
        protected readonly uint segmentAddress;

        // Main segment address getter
        public uint SegmentAddress { get { return segmentAddress; } }   

        //protected bool requested = false;
        //public bool Requested { get { return requested; } set { requested = value; } }

        // Segment data length
        public abstract uint Length { get; }

        // Segment data to byte array
        public abstract byte[] ToByteArray();

        // Base Constructor
        protected DataSegmentClass(uint addr)
        {
            segmentAddress = addr;
        }

        // Send segment data to device
        public abstract void SendData(IPerformanceMIDIInOutInterface commander);

        // Request segment data from device via Callback events
        public abstract void RequestData(IPerformanceMIDIInOutInterface commander);
    }

    // ---------------------------------------------  Performance Common Data Class  -----------------------------------------------------------------
    class PerformanceCommonClass : DataSegmentClass
    {
        // Structure
        PERFORMANCE_COMMON performanceCommonData;

        // Имя Performance
        public string PerformanceName
        {
            get
            {
                string str = "";

                byte[] buf = new byte[12];
                buf[0] = performanceCommonData.PerformanceName1;
                buf[1] = performanceCommonData.PerformanceName2;
                buf[2] = performanceCommonData.PerformanceName3;
                buf[3] = performanceCommonData.PerformanceName4;
                buf[4] = performanceCommonData.PerformanceName5;
                buf[5] = performanceCommonData.PerformanceName6;
                buf[6] = performanceCommonData.PerformanceName7;
                buf[7] = performanceCommonData.PerformanceName8;
                buf[8] = performanceCommonData.PerformanceName9;
                buf[9] = performanceCommonData.PerformanceName10;
                buf[10] = performanceCommonData.PerformanceName11;
                buf[11] = performanceCommonData.PerformanceName12;
                str = Encoding.Default.GetString(buf);

                return str;

            }
            set
            {
                string str = value.PadRight(12, ' ');
                byte[] buf = new byte[12];
                buf = Encoding.Default.GetBytes(str);
                performanceCommonData.PerformanceName1 = buf[0];
                performanceCommonData.PerformanceName2 = buf[1];
                performanceCommonData.PerformanceName3 = buf[2];
                performanceCommonData.PerformanceName4 = buf[3];
                performanceCommonData.PerformanceName5 = buf[4];
                performanceCommonData.PerformanceName6 = buf[5];
                performanceCommonData.PerformanceName7 = buf[6];
                performanceCommonData.PerformanceName8 = buf[7];
                performanceCommonData.PerformanceName9 = buf[8];
                performanceCommonData.PerformanceName10 = buf[9];
                performanceCommonData.PerformanceName11 = buf[10];
                performanceCommonData.PerformanceName12 = buf[11];
            }
        }

        // Tempo
        public byte Tempo
        {
            get
            {
                byte lsb = performanceCommonData.PerformanceTempoLSB;
                byte msb = performanceCommonData.PerformanceTempoMSB;
                msb <<= 4;
                return (byte)(lsb | msb);
            }
            set
            {
                byte tmp = value;
                if (tmp < 20) tmp = 20;
                if (tmp > 250) tmp = 250;
                performanceCommonData.PerformanceTempoLSB = (byte)(tmp & 0x0F);
                performanceCommonData.PerformanceTempoMSB = (byte)((tmp & 0xF0) >> 4);
            }
        }

        // EFX Source
        public EFXSource EfxSource
        {
            get { return performanceCommonData.EFXSource; }
        }

        // Structure -> Data Array
        public override byte[] ToByteArray()
        {
            int rawsize = Marshal.SizeOf(performanceCommonData);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(performanceCommonData, buffer, false);
            byte[] rawdata = new byte[rawsize];
            Marshal.Copy(buffer, rawdata, 0, rawsize);
            Marshal.FreeHGlobal(buffer);
            return rawdata;
        }

        // Structure Length
        public override uint Length
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
            commander.SendData(segmentAddress, ToByteArray());
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

        // Local Switch 
        public LocalSwitch LocSwitch
        {
            get { return performancePartData.LocalSwitch; }
            set { performancePartData.LocalSwitch = value; }
        }

        // Receive Hold1 Switch
        public RecieveHold1Switch Hold1Switch
        {
            get { return performancePartData.RecieveHold1Switch; }
            set { performancePartData.RecieveHold1Switch = value; }
        }

        // Lower Key
        public byte LowerKey
        {
            get { return performancePartData.KeyboardRangeLower; }
            set { performancePartData.KeyboardRangeLower = value; }
        }

        // Upper Key
        public byte UpperKey
        {
            get { return performancePartData.KeyboardRangeUpper; }
            set { performancePartData.KeyboardRangeUpper = value; }
        }

        // Volume
        public byte Volume
        {
            get
            {
                return performancePartData.PartLevel;
            }
            set
            {
                performancePartData.PartLevel = value;
            }
        }

        // Pan
        public byte Pan
        {
            get
            {
                return performancePartData.PartPan;
            }
            set
            {
                performancePartData.PartPan = value;
            }
        }

        // Reverb
        public byte Reverb
        {
            get
            {
                return performancePartData.ReverbSendLevel;
            }
            set
            {
                performancePartData.ReverbSendLevel = value;
            }
        }

        // Chorus
        public byte Chorus
        {
            get
            {
                return performancePartData.ChorusSendLevel;
            }
            set
            {
                performancePartData.ChorusSendLevel = value;
            }
        }

        // Patch
        public byte[] PatchCommandArray
        {
            get
            {
                return new byte[] {
                (byte)performancePartData.PathGroupType,
                performancePartData.PatchGroupID,
                performancePartData.PatchNumberMSB,
                performancePartData.PatchNumberLSB};
            }
            set
            {
                performancePartData.PathGroupType = (PathGroupType)value[0];
                performancePartData.PatchGroupID = value[1];
                performancePartData.PatchNumberMSB = value[2];
                performancePartData.PatchNumberLSB = value[3];
            }
        }

        // Structure -> Data Array
        public override byte[] ToByteArray()
        {
            int rawsize = Marshal.SizeOf(performancePartData);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(performancePartData, buffer, false);
            byte[] rawdata = new byte[rawsize];
            Marshal.Copy(buffer, rawdata, 0, rawsize);
            Marshal.FreeHGlobal(buffer);
            return rawdata;
        }

        // Structure Length
        public override uint Length
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
            commander.SendData(segmentAddress, ToByteArray());
        }

        // Request
        public override void RequestData(IPerformanceMIDIInOutInterface commander)
        {
            //requested = true;
            commander.RequestData(segmentAddress, Length);
        }
    }
}
