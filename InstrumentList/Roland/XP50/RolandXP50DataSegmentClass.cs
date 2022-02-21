using System;
using System.Text;
using System.Runtime.InteropServices;
using SynthLiveMidiController.MIDIMessages;
using System.Collections.Generic;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    //Dictionary<int, OneParameterFieldManager> parameters;
    //--------------------------------  One Fiel Manager  -------------------------------------
    class OneParameterFieldManager
    {
        readonly string name = "";
        readonly int offset = 0;
        readonly int length = 1;
        readonly byte[] parameterValue;

        public string Name
        {
            get { return name; }
        }
        public int Offset
        {
            get { return offset; }
        }
        public int Length
        {
            get { return length; }
        }
        public byte[] ParameterValue
        {
            get
            {
                byte[] res = new byte[length];
                for (int i = 0; i < length; i++)
                {
                    res[i] = parameterValue[i];
                }
                return res;
            }
            set
            {
                for (int i = 0; i < length; i++)
                {
                    parameterValue[i] = value[i];
                }
            }
        }

        public OneParameterFieldManager(string nm, int os, int len)
        {
            name = nm;
            length = len;
            offset = os;
            parameterValue = new byte[len];
        }

        //----------------------------  TEST  -------------------------------
        public void Print()
        {
            Console.Write(name);
            Console.Write(" = ");
            for (int i = 0; i < Length; i++)
            {
                Console.Write("{0:X2} ", parameterValue[i]);
            }
            Console.WriteLine();
        }
    }

    // -----------------------------------------------  Data Segment Base Class  ---------------------------------------------------------------------
    abstract class DataSegmentClass
    {
        // Main Segment Address
        protected readonly uint segmentAddress;

        // Main segment address getter
        public uint SegmentAddress { get { return segmentAddress; } }

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
        // Parameters Manager
        private Dictionary<PERFORMANCE_COMMON_PARAMETERS, OneParameterFieldManager> parametersManager;

        // Modified Fields
        List<OneParameterFieldManager> modified = new List<OneParameterFieldManager>();
        public List<OneParameterFieldManager> Modified
        {
            get { return modified; }
        }

        // Structure
        PERFORMANCE_COMMON performanceCommonData;

        // Structure Length
        public override uint Length
        {
            get { return (uint)performanceCommonData.Length; }
        }

        // Constructor
        public PerformanceCommonClass(uint segAddr) : base(segAddr)
        {
            performanceCommonData = new PERFORMANCE_COMMON();
            ParametersManagerInit();
        }

        // Parameters Manager Init
        private void ParametersManagerInit()
        {
            parametersManager = new Dictionary<PERFORMANCE_COMMON_PARAMETERS, OneParameterFieldManager>();
            foreach (PERFORMANCE_COMMON_PARAMETERS par in Enum.GetValues(typeof(PERFORMANCE_COMMON_PARAMETERS)))
            {
                int length = 1;
                if (par == PERFORMANCE_COMMON_PARAMETERS.PerformanceName) length = 12;
                if (par == PERFORMANCE_COMMON_PARAMETERS.PerformanceTempo) length = 2;
                int offset = (int)par;

                OneParameterFieldManager item = new OneParameterFieldManager(par.ToString(), offset, length);
                parametersManager.Add(par, item);
            }
        }

        // Data Array -> Structure
        public void CopyDataToStructure(byte[] data)
        {
            CopyDataToStructure(data, 0);
        }

        // Data Array -> Structure at Address
        public void CopyDataToStructure(byte[] data, int offset)
        {
            Array.Copy(data, 0, performanceCommonData.Buffer, offset, data.Length);
        }

        // Structure -> Data Array
        public override byte[] ToByteArray()
        {
            int length = performanceCommonData.Length;
            byte[] data = new byte[length];
            Array.Copy(performanceCommonData.Buffer, data, length);
            return data;
        }

        // Send
        public override void SendData(IPerformanceMIDIInOutInterface commander)
        {
            commander.SendData(segmentAddress, ToByteArray());
        }

        // Request
        public override void RequestData(IPerformanceMIDIInOutInterface commander)
        {
            commander.RequestData(segmentAddress, Length);
        }

        // Set Parameter in Parameter Field
        public void SetParameterInField(PERFORMANCE_COMMON_PARAMETERS param, byte[] value)
        {
            OneParameterFieldManager field = parametersManager[param];
            int len = field.Length;
            for (int i = 0; i < len; i++)
            {
                field.ParameterValue[i] = value[i];
            }
        }

        // Copy Parameter in Structure
        public void CopyParameterInStructure(PERFORMANCE_COMMON_PARAMETERS param)
        {
            OneParameterFieldManager field = parametersManager[param];
            CopyDataToStructure(field.ParameterValue, field.Offset);
        }

        // Send Parameter to Roland
        public void SendParameter(PERFORMANCE_COMMON_PARAMETERS param, IPerformanceMIDIInOutInterface commander)
        {
            uint addr = segmentAddress + (uint)parametersManager[param].Offset;
            commander.SendData(addr, parametersManager[param].ParameterValue);
        }

        // Scan Structure. Find non equal parameters. Copy parameters.
        public void ScanModifiedParameters()
        {
            ResetModified();

            foreach (PERFORMANCE_COMMON_PARAMETERS param in Enum.GetValues(typeof(PERFORMANCE_COMMON_PARAMETERS)))
            {
                OneParameterFieldManager field = parametersManager[param];
                int len = field.Length;
                int off = field.Offset;
                bool equal = true;
                for (int i = 0; i < len; i++)
                {
                    if (performanceCommonData[off + i] != field.ParameterValue[i])
                    {
                        equal = false;
                    }
                }
                if (!equal)
                {
                    byte[] buf = new byte[len];
                    Array.Copy(performanceCommonData.Buffer, off, buf, 0, len);
                    field.ParameterValue = buf;
                    modified.Add(field);
                }
            }
        }

        // Reset Modified
        public void ResetModified()
        {
            modified.Clear();
        }
    }

    // -------------------------------------------------  Performance Part Data Class  ---------------------------------------------------------------
    class PerformancePartClass : DataSegmentClass
    {
        // Parameters Manager
        private Dictionary<PERFORMANCE_PART_PARAMETERS, OneParameterFieldManager> parametersManager;

        // Modified Fields
        List<OneParameterFieldManager> modified = new List<OneParameterFieldManager>();
        public List<OneParameterFieldManager> Modified
        {
            get { return modified; }
        }

        // Structure
        PERFORMANCE_PART performancePartData;

        // Structure Length
        public override uint Length
        {
            get { return (uint)performancePartData.Length; }
        }

        // Constructor
        public PerformancePartClass(uint segAddr) : base(segAddr)
        {
            performancePartData = new PERFORMANCE_PART();
            ParametersManagerInit();
        }

        // Parameters Manager Init
        private void ParametersManagerInit()
        {
            parametersManager = new Dictionary<PERFORMANCE_PART_PARAMETERS, OneParameterFieldManager>();
            foreach (PERFORMANCE_PART_PARAMETERS par in Enum.GetValues(typeof(PERFORMANCE_PART_PARAMETERS)))
            {
                int length = 1;
                if (par == PERFORMANCE_PART_PARAMETERS.PatchNumber) length = 2;
                if (par == PERFORMANCE_PART_PARAMETERS.TransmitVolume) length = 2;
                int offset = (int)par;
                OneParameterFieldManager item = new OneParameterFieldManager(par.ToString(), offset, length);
                parametersManager.Add(par, item);
            }
        }

        // Data Array -> Structure
        public void CopyDataToStructure(byte[] data)
        {
            CopyDataToStructure(data, 0);
        }

        // Data Array -> Structure at Address
        public void CopyDataToStructure(byte[] data, int offset)
        {
            Array.Copy(data, 0, performancePartData.Buffer, offset, data.Length);
        }

        // Structure -> Data Array
        public override byte[] ToByteArray()
        {
            int length = performancePartData.Length;
            byte[] data = new byte[length];
            Array.Copy(performancePartData.Buffer, data, length);
            return data;
        }

        // Send
        public override void SendData(IPerformanceMIDIInOutInterface commander)
        {
            commander.SendData(segmentAddress, ToByteArray());
        }

        // Request
        public override void RequestData(IPerformanceMIDIInOutInterface commander)
        {
            commander.RequestData(segmentAddress, Length);
        }

        // Set Parameter in Parameter Field
        public void SetParameterInField(PERFORMANCE_PART_PARAMETERS param, byte[] value)
        {
            OneParameterFieldManager field = parametersManager[param];
            int len = field.Length;
            for (int i = 0; i < len; i++)
            {
                field.ParameterValue[i] = value[i];
            }
        }

        // Copy Parameter in Structure
        public void CopyParameterInStructure(PERFORMANCE_PART_PARAMETERS param)
        {
            OneParameterFieldManager field = parametersManager[param];
            CopyDataToStructure(field.ParameterValue, field.Offset);
        }

        // Send Parameter to Roland
        public void SendParameter(PERFORMANCE_PART_PARAMETERS param, IPerformanceMIDIInOutInterface commander)
        {
            uint addr = segmentAddress + (uint)parametersManager[param].Offset;
            commander.SendData(addr, parametersManager[param].ParameterValue);
        }

        // Scan Structure. Find non equal parameters. Copy parameters.
        public void ScanModifiedParameters()
        {
            ResetModified();

            foreach (PERFORMANCE_PART_PARAMETERS param in Enum.GetValues(typeof(PERFORMANCE_PART_PARAMETERS)))
            {
                OneParameterFieldManager field = parametersManager[param];
                int len = field.Length;
                int off = field.Offset;
                bool equal = true;
                for (int i = 0; i < len; i++)
                {
                    if (performancePartData[off + i] != field.ParameterValue[i])
                    {
                        equal = false;
                    }
                }
                if (!equal)
                {
                    byte[] buf = new byte[len];
                    Array.Copy(performancePartData.Buffer, off, buf, 0, len);
                    field.ParameterValue = buf;
                    modified.Add(field);
                }
            }
        }

        // Reset Modified
        public void ResetModified()
        {
            modified.Clear();
        }
    }
}
