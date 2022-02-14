using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class CtlFastCommandListField : CtlUniversalComboBoxField
    {
        public CtlFastCommandListField()
        {
            InitializeComponent();

            min = 1;
            max = RolandXP50CommandSet.FastCommandCount;
            caption = "Fast Command:";
        }
    }
}
