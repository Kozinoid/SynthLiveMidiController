﻿
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
            this.valueControl1 = new SynthLiveMidiController.ValueControl();
            this.SuspendLayout();
            // 
            // valueControl1
            // 
            this.valueControl1.Caption = "Value";
            this.valueControl1.Location = new System.Drawing.Point(136, 301);
            this.valueControl1.MaxValue = ((byte)(127));
            this.valueControl1.Name = "valueControl1";
            this.valueControl1.ShiftValue = ((byte)(0));
            this.valueControl1.Size = new System.Drawing.Size(76, 16);
            this.valueControl1.TabIndex = 0;
            this.valueControl1.Value = ((byte)(127));
            // 
            // SongPresetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.valueControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SongPresetEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Song Preset Editor";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SongPresetEditor_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private ValueControl valueControl1;
    }
}