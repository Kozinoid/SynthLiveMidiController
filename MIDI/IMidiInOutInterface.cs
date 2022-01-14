/*
    This interface is intended to align the application with different MIDI libraries.
 */

using MIDIEvents;

namespace MIDIDevice
{
    interface IMidiInOutInterface
    {
        //-----------------------------------------------------------------------------------------------------
        //|                                              EVENTS                                               |
        //-----------------------------------------------------------------------------------------------------
        event ChannelHandler ChannelEvent;
        event SysExHandler SysExEvent;

        //-----------------------------------------------------------------------------------------------------
        //|                               INPUT/OUTPUT DEVICES INIT/CLOSE                                     |
        //-----------------------------------------------------------------------------------------------------
        bool InitDevices(int inIndex, int outIndex);
        void CloseDevices();

        //----------------------------------------------------------------------------------------------------
        //|                                          OUTPUT COMMANDS                                         |
        //----------------------------------------------------------------------------------------------------
        void SendSysExMessage(byte[] buf);
        void SendChannelMessage(EventChannelCommand command, int midiChannel, int data1);
        void SendChannelMessage(EventChannelCommand command, int midiChannel, int data1, int data2);
    }
}
