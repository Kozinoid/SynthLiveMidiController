using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    //                                                                   EVENTS                                                                 |
    //===========================================================================================================================================
    // Modified Parameters Event Args
    public class ModifiedParameterFieldsEventArgs<T> : EventArgs where T : Enum
    {
        //private OneParameterFieldManager<T>[] modifiedParameters;
        private int segment;
        private T parameter;
        private byte[] value;

        //public OneParameterFieldManager<T>[] ModifiedParameters { get { return modifiedParameters; } }
        public int Segment { get { return segment; } }
        public T Parameter { get { return parameter; } }
        public byte[] Value { get { return value; } }

        public ModifiedParameterFieldsEventArgs(int target, T par, byte[] val)
        {
            segment = target;
            parameter = par;
            value = val;
        }
    }

    // Segment Changed Event Args
    //public class SegmentChangedEventArgs : EventArgs
    //{
    //    private int segment;
    //    public int Segment { get { return segment; } }

    //    public SegmentChangedEventArgs(int target)
    //    {
    //        segment = target;
    //    }
    //}

    // ========================================================  SEGMENT PARAMETERS  ===========================================================
    // Performance Common Parameters
    public enum PERFORMANCE_COMMON_PARAMETERS
    {
        PerformanceName = 0x00,     // 00

        EFXSource = 0x0C,           // 0C
        EFXType,                    // 0D
        EFXParameter1,              // 0E
        EFXParameter2,              // 0F
        EFXParameter3,              // 10
        EFXParameter4,              // 11
        EFXParameter5,              // 12
        EFXParameter6,              // 13
        EFXParameter7,              // 14
        EFXParameter8,              // 15
        EFXParameter9,              // 16
        EFXParameter10,             // 17
        EFXParameter11,             // 18
        EFXParameter12,             // 19
        EFXOutputAssign,            // 1A
        EFXMixOutSendLevel,         // 1B
        EFXChorusSendLevel,         // 1C
        EFXReverbSendLevel,         // 1D
        EFXControlSource1,          // 1E
        EFXControlDepth1,           // 1F
        EFXControlSource2,          // 20
        EFXControlDepth2,           // 21
        ChorusLevel,                // 22
        ChorusRate,                 // 23
        ChorusDepth,                // 24
        ChorusPreDelay,             // 25
        ChorusFeedback,             // 26
        ChorusOutput,               // 27
        ReverbType,                 // 28
        ReverbLevel,                // 29
        ReverbTime,                 // 2A
        ReverbHPDump,               // 2B
        DelayFeedback,              // 2C

        PerformanceTempo = 0x2D,    // 2D

        KeyboardRangeSwitch = 0x2F, // 2F

        KeyboardMode = 0x40,        // 40
        ClockSource                 // 41
    }

    // Performance Part Parameters
    public enum PERFORMANCE_PART_PARAMETERS
    {
        RecieveSwitch = 0x00,                   // 00                      
        MIDIChannel,                            // 01

        //PathGroupType,                        
        //PatchGroupID,                         
        PatchNumber,                            // 02

        PartLevel = 0x06,                       // 06
        PartPan,                                // 07
        PartCoarseTune,                         // 08
        PartFineTune,                           // 09
        OutputAssign,                           // 0A
        MIXEFXSendLevel,                        // 0B
        ChorusSendLevel,                        // 0C
        ReverbSendLevel,                        // 0D

        RecieveProgramChangeSwitch,             // 0E
        RecieveVolumeSwitch,                    // 0F
        RecieveHold1Switch,                     // 10
        KeyboardRangeLower,                     // 11
        KeyboardRangeUpper,                     // 12

        OctaveShift,                            // 13
        LocalSwitch,                            // 14
        TransmitSwitch,                         // 15
        TransmitBankSelectGroup,                // 16
        TransmitVolume                          // 17
    }

    //*************************************************  Performance Common CONSTANTS  ********************************************************
    public enum EFXSource : byte
    {
        PERFORM, Part1, Part2, Part3, Part4, Part5, Part6, Part7, Part8, Part9,
        Part11, Part12, Part13, Part14, Part15, Part16
    };
    public enum EFXOutputAssign : byte { MIX, OUTPUT1, OUTPUT2 };
    public enum EFXControlSource : byte { OFF, SYS_CTRL1, SYS_CTRL2, MODULATION, BREATH, FOOT, VOLUME, PAN, EXPRESSION, BENDER, AFTERTOUCH };
    public enum ChorusOutput : byte { MIX, REV, MIX_REV };
    public enum ReverbType : byte { ROOM1, ROOM2, STAGE1, STAGE2, HALL1, HALL2, DELAY, PAN_DELAY };
    public enum ReverbHPDump : byte
    {
        HPDump200, HPDump250, HPDump315, HPDump400, HPDump500, HPDump630, HPDump800,
        HPDump1000, HPDump1250, HPDump1600, HPDump2000, HPDump2500, HPDump3150, HPDump4000, HPDump5000, HPDump6300,
        HPDump8000, HPDumpBYPASS
    };
    public enum KeyboardRangeSwitch : byte { OFF, ON };
    public enum KeyboardMode : byte { LAYER, SINGLE };
    public enum ClockSource : byte { PERFORMANCE, SEQUENCER };

    //*************************************************  Performance Part CONSTANTS  ***********************************************************
    public enum RecieveSwitch : byte { OFF, ON };
    public enum PathGroupType : byte { USER_PRESET, PCM, EXP };
    public enum OutputAssign : byte { MIX, EFX, OUTPUT1, OUTPUT2, PATCH };
    public enum RecieveProgramChangeSwitch : byte { OFF, ON };
    public enum RecieveVolumeSwitch : byte { OFF, ON };
    public enum RecieveHold1Switch : byte { OFF, ON };
    public enum LocalSwitch : byte { OFF, ON };
    public enum TransmitSwitch : byte { OFF, ON };
    public enum TransmitBankSelectGroup : byte { PATCH, GROUP1, GROUP2, GROUP3, GROUP4, GROUP5, GROUP6, GROUP7 };

    // ========================================================================================================================================
    // ==========================================================  DATA TYPES  ================================================================
    // ------------------  MAIN INTERFACE  ----------------------
    interface IXP50Data
    {
        // Byte Array
        byte[] ByteArray { get; set; }
    }
    // ---------------  Numeric Interface  ----------------------
    interface IXP50Numeric
    {
        // Byte Value
        int Value { get; set; }
    }
    // ----------------  Mesured byte  --------------------------
    interface IXP50Limited
    {
        int Min { get; set; }
        int Max { get; set; }
        int Offset { get; set; }
    }
    // ----------------  ENUM List  -----------------------------
    interface IXP50EnumList : IXP50NumericData
    {
        string[] Named { get; }
    }
    // ----------------------------------------------------------
    interface IXP50NumericData : IXP50Data, IXP50Numeric { }
    interface IXP50LimitedNumericData : IXP50Data, IXP50Numeric, IXP50Limited { }

    // ==========================================================  JUST BYTE  =================================================================
    public struct XP50Byte : IXP50NumericData
    {
        // Field
        private byte data;

        // Byte Array
        public byte[] ByteArray
        {
            get => new byte[] { (byte)data };
            set => Value = value[0];
        }

        // Byte Value
        public int Value
        {
            get => (int)data;
            set => data = (byte)value;
        }

        // To String
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    // ==========================================================  TWO BYTES  =================================================================
    public struct XP50TwoBytes : IXP50NumericData
    {
        // Fields
        private byte MSB;
        private byte LSB;

        // Byte Array
        public byte[] ByteArray
        {
            get => new byte[] { MSB, LSB };
            set { MSB = value[0]; LSB = value[1]; }
        }

        // Byte Array
        public int Value
        {
            get
            {
                return (int)(MSB << 4 | LSB);
            }
            set
            {
                LSB = (byte)((byte)value & 0x0F);
                MSB = (byte)(((byte)value & 0xF0) >> 4);
            }
        }

        // To String
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    // =======================================================  LIMITED BYTE  =================================================================
    public struct XP50LimitedByte : IXP50LimitedNumericData
    {
        // Fields
        private byte data;
        private int min;
        private int max;
        private int offset;

        // Byte Array
        public byte[] ByteArray
        {
            get => new byte[] { (byte)data };
            set => Value = value[0];
        }

        // Byte Value
        public int Value
        {
            get => (int)data + offset;
            set
            {
                int res = value;
                if (res < min) res = min;
                if (res > max) res = max;
                data = (byte)(res - offset);
            }
        }

        // Byte Min
        public int Min
        {
            get => (int)min;
            set => min = (byte)value;
        }

        // Byte Max
        public int Max
        {
            get => (int)max;
            set => max = (byte)value;
        }

        // Byte Offset
        public int Offset
        {
            get => (int)offset;
            set => offset = (byte)value;
        }

        // Constructor
        public XP50LimitedByte(int bMin, int bMax, int bOffset, int defaultValue = 0)
        {
            min = bMin;
            max = bMax;
            offset = bOffset;
            int res = defaultValue;
            if (res < min) res = min;
            if (res > max) res = max;
            data = (byte)(res - offset);
        }

        // To String
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    // ========================================================  PAN BYTE  ====================================================================
    public struct XP50PanByte : IXP50LimitedNumericData
    {
        // Fields
        private byte data;
        private int min;
        private int max;
        private int offset;

        // Byte Array
        public byte[] ByteArray
        {
            get => new byte[] { (byte)data };
            set => Value = value[0];
        }

        // Byte Value
        public int Value
        {
            get => (int)data + offset;
            set
            {
                int res = value;
                if (res < min) res = min;
                if (res > max) res = max;
                data = (byte)(res - offset);
            }
        }

        // Byte Min
        public int Min
        {
            get => (int)min;
            set => min = (byte)value;
        }

        // Byte Max
        public int Max
        {
            get => (int)max;
            set => max = (byte)value;
        }

        // Byte Offset
        public int Offset
        {
            get => (int)offset;
            set => offset = (byte)value;
        }

        // Constructor
        public XP50PanByte(int defaultValue = 0)
        {
            min = -64;
            max = 63;
            offset = -64;
            int res = defaultValue;
            if (res < min) res = min;
            if (res > max) res = max;
            data = (byte)(res - offset);
        }

        // To String
        public override string ToString()
        {
            string res = "C";
            if (Value < 0) res = string.Format("L{0}", Math.Abs(Value));
            if (Value > 0) res = string.Format("R{0}", Math.Abs(Value));
            return res;
        }
    }

    // =========================================================  ANY ENUM BYTE  ==============================================================
    public struct XP50EFXEnum<T> : IXP50EnumList where T : Enum
    {
        // Field
        private T data;

        // Byte Array
        public byte[] ByteArray
        {
            get => new byte[] { Convert.ToByte(data) };
            set => Value = value[0];
        }

        // Byte Value
        public int Value
        {
            get => Convert.ToInt32(data);
            set => data = (T)Enum.Parse(typeof(T), data.ToString());
        }

        // Enum
        public string[] Named => Enum.GetNames(typeof(T));

        // Constructor
        public XP50EFXEnum(T value)
        {
            data = value;
        }

        // To String
        public override string ToString()
        {
            return Enum.GetName(typeof(T), data);
        }
    }

    // ===================================================  INT conversion union  ==============================================================
    [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
    struct IntUnion
    {
        [System.Runtime.InteropServices.FieldOffset(0)]
        public int i;

        [System.Runtime.InteropServices.FieldOffset(0)]
        public byte b1;

        [System.Runtime.InteropServices.FieldOffset(1)]
        public byte b2;

        [System.Runtime.InteropServices.FieldOffset(2)]
        public byte b3;

        [System.Runtime.InteropServices.FieldOffset(3)]
        public byte b4;
    }

    // --------------------------------------------------------  Convertor Callback  ---------------------------------------------------------
    public delegate string GetPatchString(byte[] buf);
    // ==========================================================  PATCH NUMBER  =============================================================
    public struct XP50PatchBytes : IXP50NumericData
    {
        // Callback to Convert
        public GetPatchString GetPatchStringHandler;

        // Fields
        IntUnion patchData;

        // Byte Array
        public byte[] ByteArray
        {
            get => new byte[] { patchData.b1, patchData.b2, patchData.b3, patchData.b4 };
            set { patchData.b1 = value[0]; patchData.b2 = value[1]; patchData.b3 = value[2]; patchData.b4 = value[3]; }
        }

        // Byte Array
        public int Value
        {
            get
            {
                return patchData.i;
            }
            set
            {
                patchData.i = value;
            }
        }

        // Constructor
        public XP50PatchBytes(GetPatchString callback)
        {
            GetPatchStringHandler = callback;
            patchData.b1 = 0;
            patchData.b2 = 0;
            patchData.b3 = 0;
            patchData.b4 = 0;
            patchData.i = 0;
        }

        // To String
        public override string ToString()
        {
            string res;
            if (GetPatchStringHandler != null) res = GetPatchStringHandler(ByteArray);
            else res = Value.ToString();
            return res;
        }
    }

    // ========================================================  STRING 12 CHARS  =============================================================
    public struct XP50String12 : IXP50Data
    {
        const byte space = 32;

        // Fields
        private byte bt1;
        private byte bt2;
        private byte bt3;
        private byte bt4;
        private byte bt5;
        private byte bt6;
        private byte bt7;
        private byte bt8;
        private byte bt9;
        private byte bt10;
        private byte bt11;
        private byte bt12;

        // Byte Array
        public byte[] ByteArray
        {
            get => new byte[]
            {
                bt1,
                bt2,
                bt3,
                bt4,
                bt5,
                bt6,
                bt7,
                bt8,
                bt9,
                bt10,
                bt11,
                bt12
            };
            set
            {
                bt1 = value[0];
                bt2 = value[1];
                bt3 = value[2];
                bt4 = value[3];
                bt5 = value[4];
                bt6 = value[5];
                bt7 = value[6];
                bt8 = value[7];
                bt9 = value[8];
                bt10 = value[9];
                bt11 = value[10];
                bt12 = value[11];
            }
        }

        // Te3xt
        public string Text
        {
            get
            {
                string str = "";
                str = Encoding.Default.GetString(ByteArray);
                return str;
            }
            set
            {
                int length = value.Length;
                byte[] buf = new byte[12];
                for (int i = 0; i < 12; i++)
                {
                    buf[i] = space;
                }
                for (int i = 0; i < length; i++)
                {
                    buf[i] = Encoding.Default.GetBytes(value)[i];
                }
                //buf = Encoding.Default.GetBytes(value);
                ByteArray = buf;
            }
        }

        // Constructor
        public XP50String12(byte initNyte)
        {
            bt1 = initNyte;
            bt2 = initNyte;
            bt3 = initNyte;
            bt4 = initNyte;
            bt5 = initNyte;
            bt6 = initNyte;
            bt7 = initNyte;
            bt8 = initNyte;
            bt9 = initNyte;
            bt10 = initNyte;
            bt11 = initNyte;
            bt12 = initNyte;
        }

        // To String
        public override string ToString()
        {
            return Text;
        }
    }
}
