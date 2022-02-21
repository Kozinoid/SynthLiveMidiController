using System.Runtime.InteropServices;


namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    // COMMON SEGMENT BUFFER CLASS
    abstract class SEGMENT_BUFFER
    {
        protected readonly int length = 0;

        // buffer
        protected byte[] buffer;

        // Buffer
        public byte[] Buffer
        {
            get { return buffer; }
        }

        // Length
        public int Length
        {
            get { return length; }
        }

        // Indexator
        public byte this[int index]
        {
            get { return buffer[index]; }
        }

        // Constructor
        protected SEGMENT_BUFFER(int len)
        {
            length = len;
            buffer = new byte[length];
        }
    }

    // PERFORMANCE COMMON BUFFER
    class PERFORMANCE_COMMON : SEGMENT_BUFFER
    {
        public PERFORMANCE_COMMON() : base(0x42) { }
    }

    // PERFORMANCE PART BUFFER
    class PERFORMANCE_PART : SEGMENT_BUFFER
    {
        public PERFORMANCE_PART() : base(0x19) { }
    }

    //========================================================================================================
    //************************************  Performance Common  ********************************************//
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

    //========================================================================================================
    //************************************  Performance Part  **********************************************//
    // Performance Part Parameters
    public enum PERFORMANCE_PART_PARAMETERS
    {
        RecieveSwitch = 0x00,                   // 00                      
        MIDIChannel,                            // 01

        PathGroupType,                          // 02
        PatchGroupID,                           // 03
        PatchNumber,                            // 04

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

    //*************************  Performance Common parameters  *****************************
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
    //========================================================================================================

    //*************************  Performance Part parameters  *****************************
    public enum RecieveSwitch : byte { OFF, ON };
    public enum PathGroupType : byte { USER_PRESET, PCM, EXP };
    public enum OutputAssign : byte { MIX, EFX, OUTPUT1, OUTPUT2, PATCH };
    public enum RecieveProgramChangeSwitch : byte { OFF, ON };
    public enum RecieveVolumeSwitch : byte { OFF, ON };
    public enum RecieveHold1Switch : byte { OFF, ON };
    public enum LocalSwitch : byte { OFF, ON };
    public enum TransmitSwitch : byte { OFF, ON };
    public enum TransmitBankSelectGroup : byte { PATCH, GROUP1, GROUP2, GROUP3, GROUP4, GROUP5, GROUP6, GROUP7 };
    //========================================================================================================

}
