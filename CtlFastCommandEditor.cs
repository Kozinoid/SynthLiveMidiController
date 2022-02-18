using System;
using System.Windows.Forms;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class CtlFastCommandEditor : UserControl
    {
        IFastListEditorSectionInterface perfData;

        // Constructor
        public CtlFastCommandEditor()
        {
            InitializeComponent();
        }

        // Set Data Interface
        public void SetInterface(IFastListEditorSectionInterface data)
        {
            perfData = data;
            perfData.FastDataReceived += PerfData_FastDataReceived;
        }

        // Data Received
        private void PerfData_FastDataReceived(object sender, SegmentDataReceivedEvendArgs ea)
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
            RefreshCommandNames();
        }

        public void RefreshSongName()
        {
            ctlPresetName.Value = perfData.GetPresetName();
        }

        public void RefreshCommandNames()
        {
            for (int i = 0; i < RolandXP50CommandSet.FastCommandCount; i++)
            {
                RefreshCommandName(i);
            }
        }

        public void RefreshCommandName(int index)
        {
            ctlFastComList.SetStringValue(index, perfData.GetCommandName(index));
        }

        //____________________________________  Commands  _______________________________________
        public void RefreshCurrentCommand()
        {
            ctlEFXSource.Value = (int)perfData.GetCommandEFXSource(ctlFastComList.ByteValue);
            // Comands
        }

        //------------------------------------  Editor  ------------------------------------------
        // Preset Name Changed
        private void ctlPresetName_ValueChanged(object sender, EventArgs e)
        {

        }

        // Command Index Changed
        private void ctlFastComList_CommandChanged(object sender, EventArgs e)
        {
            RefreshCurrentCommand();
        }

        // EFX Source Changed
        private void ctlEFXSource_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
