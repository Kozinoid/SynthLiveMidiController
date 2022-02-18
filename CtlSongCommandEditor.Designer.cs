
namespace SynthLiveMidiController
{
    partial class CtlSongCommandEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pn_HeadPanel = new System.Windows.Forms.Panel();
            this.ctlChannelParameters = new SynthLiveMidiController.CtlChannelParametersListEditor();
            this.ctlSongComList = new SynthLiveMidiController.CtlSongCommandListField();
            this.ctlEFXSource = new SynthLiveMidiController.CtlEFXSourceField();
            this.ctlTempo = new SynthLiveMidiController.CtlTempoField();
            this.ctlPerformanceName = new SynthLiveMidiController.CtlPerformanceNameField();
            this.ctlSingerName = new SynthLiveMidiController.CtlStringField();
            this.ctlSongName = new SynthLiveMidiController.CtlStringField();
            this.pn_HeadPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_HeadPanel
            // 
            this.pn_HeadPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_HeadPanel.Controls.Add(this.ctlSongComList);
            this.pn_HeadPanel.Controls.Add(this.ctlEFXSource);
            this.pn_HeadPanel.Controls.Add(this.ctlTempo);
            this.pn_HeadPanel.Controls.Add(this.ctlPerformanceName);
            this.pn_HeadPanel.Controls.Add(this.ctlSingerName);
            this.pn_HeadPanel.Controls.Add(this.ctlSongName);
            this.pn_HeadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_HeadPanel.Location = new System.Drawing.Point(0, 0);
            this.pn_HeadPanel.Name = "pn_HeadPanel";
            this.pn_HeadPanel.Size = new System.Drawing.Size(996, 57);
            this.pn_HeadPanel.TabIndex = 0;
            // 
            // ctlChannelParameters
            // 
            this.ctlChannelParameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctlChannelParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlChannelParameters.Location = new System.Drawing.Point(0, 57);
            this.ctlChannelParameters.Name = "ctlChannelParameters";
            this.ctlChannelParameters.Size = new System.Drawing.Size(996, 539);
            this.ctlChannelParameters.TabIndex = 3;
            // 
            // ctlSongComList
            // 
            this.ctlSongComList.ByteValue = ((byte)(0));
            this.ctlSongComList.Caption = "Song Command:";
            this.ctlSongComList.Location = new System.Drawing.Point(319, 31);
            this.ctlSongComList.Margin = new System.Windows.Forms.Padding(2);
            this.ctlSongComList.Name = "ctlSongComList";
            this.ctlSongComList.Size = new System.Drawing.Size(184, 22);
            this.ctlSongComList.TabIndex = 5;
            this.ctlSongComList.Value = 1;
            this.ctlSongComList.CommandChanged += new System.EventHandler(this.ctlSongComList_CommandChanged);
            // 
            // ctlEFXSource
            // 
            this.ctlEFXSource.ByteValue = ((byte)(0));
            this.ctlEFXSource.Caption = "EFX:";
            this.ctlEFXSource.Location = new System.Drawing.Point(698, 31);
            this.ctlEFXSource.Name = "ctlEFXSource";
            this.ctlEFXSource.Size = new System.Drawing.Size(70, 22);
            this.ctlEFXSource.TabIndex = 4;
            this.ctlEFXSource.Value = 0;
            this.ctlEFXSource.ValueChanged += new System.EventHandler(this.ctlEFXSource_ValueChanged);
            // 
            // ctlTempo
            // 
            this.ctlTempo.ByteValue = ((byte)(120));
            this.ctlTempo.Caption = "Tempo:";
            this.ctlTempo.Location = new System.Drawing.Point(698, 3);
            this.ctlTempo.Name = "ctlTempo";
            this.ctlTempo.Size = new System.Drawing.Size(70, 22);
            this.ctlTempo.TabIndex = 3;
            this.ctlTempo.Value = 120;
            this.ctlTempo.ValueBuffer = new byte[] {
        ((byte)(0)),
        ((byte)(0))};
            this.ctlTempo.ValueChanged += new System.EventHandler(this.ctlTempo_ValueChanged);
            // 
            // ctlPerformanceName
            // 
            this.ctlPerformanceName.Caption = "Performance Name:";
            this.ctlPerformanceName.Location = new System.Drawing.Point(319, 3);
            this.ctlPerformanceName.Name = "ctlPerformanceName";
            this.ctlPerformanceName.Size = new System.Drawing.Size(240, 22);
            this.ctlPerformanceName.TabIndex = 2;
            this.ctlPerformanceName.Value = "            ";
            this.ctlPerformanceName.ValueChanged += new System.EventHandler(this.ctlPerformanceName_ValueChanged);
            // 
            // ctlSingerName
            // 
            this.ctlSingerName.Caption = "Singer/Author:";
            this.ctlSingerName.Location = new System.Drawing.Point(31, 31);
            this.ctlSingerName.Name = "ctlSingerName";
            this.ctlSingerName.Size = new System.Drawing.Size(240, 22);
            this.ctlSingerName.TabIndex = 1;
            this.ctlSingerName.Value = "";
            this.ctlSingerName.ValueChanged += new System.EventHandler(this.ctlSingerName_ValueChanged);
            // 
            // ctlSongName
            // 
            this.ctlSongName.Caption = "Somg Name:";
            this.ctlSongName.Location = new System.Drawing.Point(31, 3);
            this.ctlSongName.Name = "ctlSongName";
            this.ctlSongName.Size = new System.Drawing.Size(240, 22);
            this.ctlSongName.TabIndex = 0;
            this.ctlSongName.Value = "";
            this.ctlSongName.ValueChanged += new System.EventHandler(this.ctlSongName_ValueChanged);
            // 
            // CtlSongCommandEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.ctlChannelParameters);
            this.Controls.Add(this.pn_HeadPanel);
            this.Name = "CtlSongCommandEditor";
            this.Size = new System.Drawing.Size(996, 596);
            this.pn_HeadPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_HeadPanel;
        private CtlStringField ctlSongName;
        private CtlSongCommandListField ctlSongComList;
        private CtlEFXSourceField ctlEFXSource;
        private CtlTempoField ctlTempo;
        private CtlPerformanceNameField ctlPerformanceName;
        private CtlStringField ctlSingerName;
        private CtlChannelParametersListEditor ctlChannelParameters;
    }
}
