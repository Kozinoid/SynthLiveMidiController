using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    //**********************************************************  PERFORMANCE COMMON  *****************************************************************
    //----------------------------------------------------------------  EVENTS  -----------------------------------------------------------------------
    class PerformanceCommonParametersEventErgs : EventArgs
    {
        public readonly PERFORMANCE_COMMON_PARAMETERS parameter;
        public PerformanceCommonParametersEventErgs(PERFORMANCE_COMMON_PARAMETERS prs)
        {
            parameter = prs;
        }
    }
    // delegate
    delegate void PerformanceCommonParametersEventHandler(object sender, PerformanceCommonParametersEventErgs e);

    //-----------------------------------------------------  Performance Common Interface  ------------------------------------------------------------
    interface IPerformanceCommonInterface
    {
        PerformanceCommonParametersEventHandler RequestCallback(PerformanceCommonParametersEventHandler eHandler, PERFORMANCE_COMMON_PARAMETERS[] prs);
        void SetParameter(PerformanceCommonParametersEventHandler id, PERFORMANCE_COMMON_PARAMETERS parameter);
    }

    //-----------------------------------------------  PERFORMANCE COMMON  PARAMETER ROUTER  ----------------------------------------------------------
    class PerformanceCommonParameterRouter : IPerformanceCommonInterface
    {
        // Event List
        PerformanceCommonEventList eventList;

        // Constructor
        public PerformanceCommonParameterRouter()
        {
            eventList = new PerformanceCommonEventList();
        }

        // Request Performance Common Parameters
        public PerformanceCommonParametersEventHandler RequestCallback(PerformanceCommonParametersEventHandler eHandler, PERFORMANCE_COMMON_PARAMETERS[] prs)
        {
            return eventList.AddCallback(eHandler, prs);
        }

        // Set Performance Common Parameters
        public void SetParameter(PerformanceCommonParametersEventHandler id, PERFORMANCE_COMMON_PARAMETERS parameter)
        {
            foreach (PerformanceCommonParametersEventHandler eHandler in eventList.GetKeys())
            {
                foreach (PERFORMANCE_COMMON_PARAMETERS prm in eventList[eHandler])
                {
                    if (prm == parameter)
                    {
                        if (eHandler != id)
                        {
                            eHandler?.Invoke(this, new PerformanceCommonParametersEventErgs(parameter));
                        }
                    }

                }
            }
        }
    }

    //--------------------------------------------------------  Performance Common Event List  --------------------------------------------------------
    class PerformanceCommonEventList
    {
        Dictionary<PerformanceCommonParametersEventHandler, PERFORMANCE_COMMON_PARAMETERS[]> eventList = new Dictionary<PerformanceCommonParametersEventHandler, PERFORMANCE_COMMON_PARAMETERS[]>();

        public Dictionary<PerformanceCommonParametersEventHandler, PERFORMANCE_COMMON_PARAMETERS[]>.KeyCollection GetKeys()
        {
            return eventList.Keys;
        }

        public PERFORMANCE_COMMON_PARAMETERS[] this[PerformanceCommonParametersEventHandler evnt]
        {
            get { return eventList[evnt]; }
        }

        public PerformanceCommonParametersEventHandler AddCallback(PerformanceCommonParametersEventHandler eHandler, PERFORMANCE_COMMON_PARAMETERS[] prs)
        {
            eventList.Add(eHandler, prs);
            return eHandler;
        }
    }




    //**********************************************************  PERFORMANCE PART  *******************************************************************
    //---------------------------------------------------------------  EVENTS  ------------------------------------------------------------------------
    class PerformancePartParametersEventErgs : EventArgs
    {
        public readonly PERFORMANCE_PART_PARAMETERS parameter;
        public PerformancePartParametersEventErgs(PERFORMANCE_PART_PARAMETERS prs)
        {
            parameter = prs;
        }
    }
    // delegate
    delegate void PerformancePartParametersEventHandler(object sender, PerformancePartParametersEventErgs e);

    //-----------------------------------------------------  Performance Part Interface  --------------------------------------------------------------
    interface IPerformancePartInterface
    {
        PerformancePartParametersEventHandler RequestCallback(PerformancePartParametersEventHandler eHandler, PERFORMANCE_PART_PARAMETERS[] prs);
        void SetParameter(PerformancePartParametersEventHandler id, PERFORMANCE_PART_PARAMETERS parameter);
    }

    //------------------------------------------------  PERFORMANCE PART  PARAMETER ROUTER  -----------------------------------------------------------
    class PerformancePartParameterRouter : IPerformancePartInterface
    {
        // Event List
        PerformancePartEventList eventList;

        // Constructor
        public PerformancePartParameterRouter()
        {
            eventList = new PerformancePartEventList();
        }

        // Request Performance Part Parameters
        public PerformancePartParametersEventHandler RequestCallback(PerformancePartParametersEventHandler eHandler, PERFORMANCE_PART_PARAMETERS[] prs)
        {
            return eventList.AddCallback(eHandler, prs);
        }

        // Set Performance Part Parameters
        public void SetParameter(PerformancePartParametersEventHandler id, PERFORMANCE_PART_PARAMETERS parameter)
        {
            foreach (PerformancePartParametersEventHandler eHandler in eventList.GetKeys())
            {
                foreach (PERFORMANCE_PART_PARAMETERS prm in eventList[eHandler])
                {
                    if (prm == parameter)
                    {
                        if (eHandler != id)
                        {
                            eHandler?.Invoke(this, new PerformancePartParametersEventErgs(parameter));
                        }
                    }

                }
            }
        }
    }

    //--------------------------------------------------------  Performance Common Event List  --------------------------------------------------------
    class PerformancePartEventList
    {
        Dictionary<PerformancePartParametersEventHandler, PERFORMANCE_PART_PARAMETERS[]> eventList = new Dictionary<PerformancePartParametersEventHandler, PERFORMANCE_PART_PARAMETERS[]>();

        public Dictionary<PerformancePartParametersEventHandler, PERFORMANCE_PART_PARAMETERS[]>.KeyCollection GetKeys()
        {
            return eventList.Keys;
        }

        public PERFORMANCE_PART_PARAMETERS[] this[PerformancePartParametersEventHandler evnt]
        {
            get { return eventList[evnt]; }
        }

        public PerformancePartParametersEventHandler AddCallback(PerformancePartParametersEventHandler eHandler, PERFORMANCE_PART_PARAMETERS[] prs)
        {
            eventList.Add(eHandler, prs);
            return eHandler;
        }
    }
}
