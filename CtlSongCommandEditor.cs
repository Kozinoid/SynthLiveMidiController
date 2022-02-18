using System;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class CtlSongCommandEditor : UserControl
    {
        ISongListEditorSectionInterface perfData;

        // Constructor
        public CtlSongCommandEditor()
        {
            InitializeComponent();
        }

        // Set Data Interface
        public void SetInterface(ISongListEditorSectionInterface data)
        {
            perfData = data;
            perfData.SongDataReceived += PerfData_SongDataReceived;
        }

        // Data Received
        private void PerfData_SongDataReceived(object sender, SegmentDataReceivedEvendArgs ea)
        {
            RefreshAllFields();
        }

        //-------------------------------------  REFRESH  --------------------------------------------
        public void RefreshAllFields()
        {
            RefreshHeader();
            RefreshCurrentCommand();
        }

        //____________________________________  Header  ________________________________________
        public void RefreshHeader()
        {
            RefreshSongName();
            RefreshSingerName();
            RefreshPerformanceTitle();
            RefreshCommandNames();
            RefreshTempo();
        }

        public void RefreshSongName()
        {
            ctlSongName.Value = perfData.GetSongName();
        }

        public void RefreshSingerName()
        {
            ctlSingerName.Value = perfData.GetSinger();
        }

        public void RefreshPerformanceTitle()
        {
            ctlPerformanceName.Value = perfData.GetPerformanceTitle();
        }

        public void RefreshCommandNames()
        {
            for (int i = 0; i < RolandXP50CommandSet.SongCommandCount; i++)
            {
                RefreshCommandName(i);
            }
        }

        public void RefreshCommandName(int index)
        {
            ctlSongComList.SetStringValue(index, perfData.GetCommandName(index));
        }

        public void RefreshTempo()
        {
            ctlTempo.Value = perfData.GetTempo();
        }

        //____________________________________  Commands  _______________________________________
        public void RefreshCurrentCommand()
        {
            RefreshEFXSourse(ctlSongComList.ByteValue);
            // Comands
        }

        public void RefreshEFXSourse(int index)
        {
            ctlEFXSource.Value = (int)perfData.GetCommandEFXSource(index);
        }

        //------------------------------------  Editor  ------------------------------------------
        // Song Name Changed
        private void ctlSongName_ValueChanged(object sender, EventArgs e)
        {
            perfData.SetSongName(ctlSongName.Value);
        }

        // Singer Changed
        private void ctlSingerName_ValueChanged(object sender, EventArgs e)
        {
            perfData.SetSinger(ctlSingerName.Value);
        }

        // Performance Name Changed
        private void ctlPerformanceName_ValueChanged(object sender, EventArgs e)
        {
            perfData.SetPerformanceTitle(ctlPerformanceName.Value);
        }

        // Command Index Changed
        private void ctlSongComList_CommandChanged(object sender, EventArgs e)
        {
            RefreshCurrentCommand();
        }

        // Tempo Changed
        private void ctlTempo_ValueChanged(object sender, EventArgs e)
        {
            perfData.SetTempo(ctlTempo.ByteValue);
        }

        // EFX Source Changed
        private void ctlEFXSource_ValueChanged(object sender, EventArgs e)
        {
            perfData.SetCommandEFXSource(ctlSongComList.ByteValue, (EFXSource)ctlEFXSource.Value);
        }
    }
}
