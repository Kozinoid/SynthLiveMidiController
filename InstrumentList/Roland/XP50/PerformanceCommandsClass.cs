using SynthLiveMidiController.MIDIEvents;
using SynthLiveMidiController.MIDIMessages;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    class PerformanceCommandsClass : IPerformanceMIDIInOutInterface
    {
        private readonly MIDIDevice.IMidiInOutInterface mainMidiDevice;
        private readonly MIDIMessageProcessor processor = null;                              // Message queue processor
        private readonly InstrumentMIDIMessages messages;

        public event SysExHandler OnSysExRquestedDataEvent;
        public event SysExHandler OnSysExEditDataEvent;
        public event ChannelHandler OnChannelEvent;

        public PerformanceCommandsClass(MIDIDevice.IMidiInOutInterface dev, InstrumentMIDIMessages mes)
        {
            mainMidiDevice = dev;
            processor = new MIDIMessageProcessor(dev);           // Create message queue processor
            messages = mes;

            processor.OnChannelEvent += Processor_OnChannelEvent;
            processor.OnSysExEditDataEvent += Processor_OnSysExEditDataEvent;
            processor.OnSysExRquestedDataEvent += Processor_OnSysExRquestedDataEvent;
        }

        public void Stop()
        {
            processor.StopProcess();                                        // Stop message queue processor
        }

        //======================================================  CALLBACKS  ==============================================================
        private void Processor_OnSysExRquestedDataEvent(object sender, MIDIEvents.SysExEventArgs e)
        {
            OnSysExRquestedDataEvent?.Invoke(sender, e);
        }

        private void Processor_OnSysExEditDataEvent(object sender, MIDIEvents.SysExEventArgs e)
        {
            OnSysExEditDataEvent?.Invoke(sender, e);
        }

        private void Processor_OnChannelEvent(object sender, MIDIEvents.ChannelEventArgs e)
        {
            OnChannelEvent?.Invoke(sender, e);
        }

        // ==============================================  INTERFACE IMPLEMENTATION  ======================================================
        // Send data to Roland XP50 memory
        public void SendData(uint addr, byte[] data)
        {
            SystemExclusiveDT1Class mes = messages.GetSystemExclusiveDT1Message(addr, data);
            processor.SendMessage(mes);
        }

        // Request data from Roland XP50 memory
        public void RequestData(uint addr, uint len)
        {
            SystemExclusiveRequestClass mes = messages.GetSystemExclusiveRequestMessage(addr, len);
            processor.SendMessage(mes);
        }
    }
}
