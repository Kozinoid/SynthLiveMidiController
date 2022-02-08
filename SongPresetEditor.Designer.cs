
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
            this.ctlOneChannelParameters1 = new SynthLiveMidiController.CtlOneChannelParameters();
            this.ctlOneChannelParameters2 = new SynthLiveMidiController.CtlOneChannelParameters();
            this.ctlOneChannelParameters3 = new SynthLiveMidiController.CtlOneChannelParameters();
            this.ctlOneChannelParameters4 = new SynthLiveMidiController.CtlOneChannelParameters();
            this.SuspendLayout();
            // 
            // ctlOneChannelParameters1
            // 
            this.ctlOneChannelParameters1.Location = new System.Drawing.Point(3, 12);
            this.ctlOneChannelParameters1.Name = "ctlOneChannelParameters1";
            this.ctlOneChannelParameters1.Size = new System.Drawing.Size(904, 58);
            this.ctlOneChannelParameters1.TabIndex = 0;
            // 
            // ctlOneChannelParameters2
            // 
            this.ctlOneChannelParameters2.Location = new System.Drawing.Point(3, 76);
            this.ctlOneChannelParameters2.Name = "ctlOneChannelParameters2";
            this.ctlOneChannelParameters2.Size = new System.Drawing.Size(904, 58);
            this.ctlOneChannelParameters2.TabIndex = 1;
            // 
            // ctlOneChannelParameters3
            // 
            this.ctlOneChannelParameters3.Location = new System.Drawing.Point(3, 140);
            this.ctlOneChannelParameters3.Name = "ctlOneChannelParameters3";
            this.ctlOneChannelParameters3.Size = new System.Drawing.Size(904, 58);
            this.ctlOneChannelParameters3.TabIndex = 2;
            // 
            // ctlOneChannelParameters4
            // 
            this.ctlOneChannelParameters4.Location = new System.Drawing.Point(3, 204);
            this.ctlOneChannelParameters4.Name = "ctlOneChannelParameters4";
            this.ctlOneChannelParameters4.Size = new System.Drawing.Size(904, 58);
            this.ctlOneChannelParameters4.TabIndex = 3;
            // 
            // SongPresetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.ctlOneChannelParameters4);
            this.Controls.Add(this.ctlOneChannelParameters3);
            this.Controls.Add(this.ctlOneChannelParameters2);
            this.Controls.Add(this.ctlOneChannelParameters1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SongPresetEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Song Preset Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private CtlOneChannelParameters ctlOneChannelParameters1;
        private CtlOneChannelParameters ctlOneChannelParameters2;
        private CtlOneChannelParameters ctlOneChannelParameters3;
        private CtlOneChannelParameters ctlOneChannelParameters4;
    }
}