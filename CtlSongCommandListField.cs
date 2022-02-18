using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class CtlSongCommandListField : CtlUniversalComboBoxField
    {
        public CtlSongCommandListField()
        {
            InitializeComponent();

            min = 1;
            max = RolandXP50CommandSet.SongCommandCount;
            caption = "Song Command:";
        }
    }
}
