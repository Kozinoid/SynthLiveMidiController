using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController.ParameterControls
{
    public partial class CtlSongCommandListField : XP50BaseControl
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
