﻿using System.Windows.Forms;
using SynthLiveMidiController.Pictures;
using SynthLiveMidiController.InstrumentList.Roland.XP50;

namespace SynthLiveMidiController
{
    public partial class SongPresetEditor : Form
    {
        // TEST
        readonly KeyboardPicture kbdPicture = new KeyboardPicture();

        // Constructor
        public SongPresetEditor()
        {
            InitializeComponent();
        }

        // Show Editor
        public DialogResult ShowEditor(ISongListEditorSectionInterface parameters)
        {
            return ShowDialog();
        }

        //------------------------------------------------------------------------------------
        // TEST
        private void SongPresetEditor_Paint(object sender, PaintEventArgs e)
        {
            kbdPicture.DrawKeyboard(e.Graphics, 0, 0);
        }
    }
}
