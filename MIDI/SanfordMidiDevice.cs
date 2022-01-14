/*
    lass for working with the Sanford library
 */

using System;
using System.Threading;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
using System.Windows.Forms;
using MIDIEvents;

namespace MIDIDevice
{
    class SanfordMidiDevice : IMidiInOutInterface
    {
        //-----------------------------------------------------------------------------------------------------
        //|                                          DEVICES FIELDS                                           |
        //-----------------------------------------------------------------------------------------------------

        private static InputDevice inDevice = null;
        private static OutputDevice opDevice = null;

        //-----------------------------------------------------------------------------------------------------
        //|                                              EVENTS                                               |
        //-----------------------------------------------------------------------------------------------------

        event ChannelHandler ChannelEvent;
        event SysExHandler SysExEvent;
        event ChannelHandler IMidiInOutInterface.ChannelEvent
        {
            add
            {
                ChannelEvent += value;
            }

            remove
            {
                ChannelEvent -= value; ;
            }
        }
        event SysExHandler IMidiInOutInterface.SysExEvent
        {
            add
            {
                SysExEvent += value; ;
            }

            remove
            {
                SysExEvent -= value; ;
            }
        }

        //-----------------------------------------------------------------------------------------------------
        //|                               INPUT/OUTPUT DEVICES INIT/CLOSE                                     |
        //-----------------------------------------------------------------------------------------------------

        // Init In/Out Devices
        public bool InitDevices(int inIndex, int outIndex)
        {
            try
            {
                inDevice = new InputDevice(inIndex);

                inDevice.ChannelMessageReceived += HandleChannelMessageReceived;
                inDevice.SysExMessageReceived += HandleSysExMessageReceived;
                inDevice.Error += new EventHandler<ErrorEventArgs>(InDevice_Error);
                inDevice.StartRecording();
            }
            catch
            {
                MessageBox.Show(String.Format("Create input device #{0} error", inIndex));
                return false;
            }

            try
            {
                opDevice = new OutputDevice(outIndex);
            }
            catch
            {
                MessageBox.Show(String.Format("Create output device #{0} error", outIndex));
                return false;
            }

            return true;
        }

        // Close In/Out Devices
        public void CloseDevices()
        {
            if (opDevice != null)
            {
                try
                {
                    opDevice.Close();
                }
                catch
                {
                    MessageBox.Show(String.Format("Closing output device #{0} error", opDevice.ToString()));
                }
            }

            if (inDevice != null)
            {
                try
                {
                    inDevice.StopRecording();
                    inDevice.Reset();
                    inDevice.ChannelMessageReceived -= HandleChannelMessageReceived;
                    inDevice.SysExMessageReceived -= HandleSysExMessageReceived;
                    inDevice.Error -= new EventHandler<ErrorEventArgs>(InDevice_Error);
                    inDevice.Close();
                }
                catch
                {
                    MessageBox.Show(String.Format("Closing input device #{0} error", inDevice.ToString()));
                }
                
            }
        }

        //-----------------------------------------------------------------------------------------------------
        //|                                            CALLBACKS                                              |
        //-----------------------------------------------------------------------------------------------------

        // Channel message received
        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            ChannelEventArgs ea = new ChannelEventArgs(GetEventChannelCommand(e.Message.Command), e.Message.MidiChannel, e.Message.Data1, e.Message.Data2);
            ChannelEvent?.Invoke(this, ea);
        }

        // System exclusive message received
        private void HandleSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            SysExEventArgs ea = new SysExEventArgs(e.Message.GetBytes());
            SysExEvent?.Invoke(this, ea);
        }

        // Error handler
        private void InDevice_Error(object sender, ErrorEventArgs e)
        {
            // Handle error
        }

        //----------------------------------------------------------------------------------------------------
        //|                                          OUTPUT COMMANDS                                         |
        //----------------------------------------------------------------------------------------------------

        // Send SysEx Message
        public void SendSysExMessage(byte[] buf)
        {
            SysExMessage message = new SysExMessage(buf);
            opDevice.Send(message);
        }

        // Send Channel Message 1 
        public void SendChannelMessage(EventChannelCommand command, int midiChannel, int data1)
        {
            ChannelCommand cmd = GetChannelCommand(command);
            ChannelMessage message = new ChannelMessage(cmd, midiChannel, data1);
            opDevice.Send(message);
        }

        // Send Channel Message 2 
        public void SendChannelMessage(EventChannelCommand command, int midiChannel, int data1, int data2)
        {
            ChannelCommand cmd = GetChannelCommand(command);
            ChannelMessage message = new ChannelMessage(cmd, midiChannel, data1, data2);
            opDevice.Send(message);
        }

        // Command Converter App -> Sanford
        private ChannelCommand GetChannelCommand(EventChannelCommand cmd)
        {
            switch (cmd)
            {
                case EventChannelCommand.ChannelPressure:
                    return ChannelCommand.ChannelPressure;

                case EventChannelCommand.Controller:
                    return ChannelCommand.Controller;

                case EventChannelCommand.NoteOff:
                    return ChannelCommand.NoteOff;

                case EventChannelCommand.NoteOn:
                    return ChannelCommand.NoteOn;
;
                case EventChannelCommand.PitchWheel:
                    return ChannelCommand.PitchWheel;

                case EventChannelCommand.ProgramChange:
                    return ChannelCommand.ProgramChange;

                default:
                    return ChannelCommand.PolyPressure;
            }
        }

        // Command Converter Sanford -> App
        private EventChannelCommand GetEventChannelCommand(ChannelCommand cmd)
        {
            switch (cmd)
            {
                case ChannelCommand.ChannelPressure:
                    return EventChannelCommand.ChannelPressure;

                case ChannelCommand.Controller:
                    return EventChannelCommand.Controller;

                case ChannelCommand.NoteOff:
                    return EventChannelCommand.NoteOff;

                case ChannelCommand.NoteOn:
                    return EventChannelCommand.NoteOn;
                    ;
                case ChannelCommand.PitchWheel:
                    return EventChannelCommand.PitchWheel;

                case ChannelCommand.ProgramChange:
                    return EventChannelCommand.ProgramChange;

                default:
                    return EventChannelCommand.PolyPressure;
            }
        }
        
    }
}
