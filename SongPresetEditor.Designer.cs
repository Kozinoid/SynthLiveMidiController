
namespace SynthLiveMidiController
{
    partial class SongPresetEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctlSongComEditor = new SynthLiveMidiController.CtlSongCommandEditor();
            this.SuspendLayout();
            // 
            // ctlSongComEditor
            // 
            this.ctlSongComEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctlSongComEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlSongComEditor.Location = new System.Drawing.Point(0, 0);
            this.ctlSongComEditor.Name = "ctlSongComEditor";
            this.ctlSongComEditor.Size = new System.Drawing.Size(984, 561);
            this.ctlSongComEditor.TabIndex = 2;
            // 
            // SongPresetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.ctlSongComEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SongPresetEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Song Preset Editor";
            this.Shown += new System.EventHandler(this.SongPresetEditor_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private CtlSongCommandEditor ctlSongComEditor;
    }
}