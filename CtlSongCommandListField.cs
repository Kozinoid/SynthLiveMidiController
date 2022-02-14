using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
