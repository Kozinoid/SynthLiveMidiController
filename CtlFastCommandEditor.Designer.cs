
namespace SynthLiveMidiController
{
    partial class CtlFastCommandEditor
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
            this.ctlFastComList = new SynthLiveMidiController.CtlFastCommandListField();
            this.ctlEFXSource = new SynthLiveMidiController.CtlEFXSourceField();
            this.ctlPresetName = new SynthLiveMidiController.CtlStringField();
            this.ctlChannelParameters = new SynthLiveMidiController.CtlChannelParametersListEditor();
            this.pn_HeadPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_HeadPanel
            // 
            this.pn_HeadPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_HeadPanel.Controls.Add(this.ctlFastComList);
            this.pn_HeadPanel.Controls.Add(this.ctlEFXSource);
            this.pn_HeadPanel.Controls.Add(this.ctlPresetName);
            this.pn_HeadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_HeadPanel.Location = new System.Drawing.Point(0, 0);
            this.pn_HeadPanel.Name = "pn_HeadPanel";
            this.pn_HeadPanel.Size = new System.Drawing.Size(996, 31);
            this.pn_HeadPanel.TabIndex = 1;
            // 
            // ctlFastComList
            // 
            this.ctlFastComList.ByteValue = ((byte)(0));
            this.ctlFastComList.Caption = "Fast Command:";
            this.ctlFastComList.Location = new System.Drawing.Point(324, 3);
            this.ctlFastComList.Margin = new System.Windows.Forms.Padding(2);
            this.ctlFastComList.Name = "ctlFastComList";
            this.ctlFastComList.Size = new System.Drawing.Size(184, 22);
            this.ctlFastComList.TabIndex = 5;
            this.ctlFastComList.Value = 1;
            this.ctlFastComList.CommandChanged += new System.EventHandler(this.ctlFastComList_CommandChanged);
            // 
            // ctlEFXSource
            // 
            this.ctlEFXSource.ByteValue = ((byte)(0));
            this.ctlEFXSource.Caption = "EFX:";
            this.ctlEFXSource.Location = new System.Drawing.Point(698, 3);
            this.ctlEFXSource.Name = "ctlEFXSource";
            this.ctlEFXSource.Size = new System.Drawing.Size(70, 22);
            this.ctlEFXSource.TabIndex = 4;
            this.ctlEFXSource.Value = 0;
            this.ctlEFXSource.ValueChanged += new System.EventHandler(this.ctlEFXSource_ValueChanged);
            // 
            // ctlPresetName
            // 
            this.ctlPresetName.Caption = "Preset Name:";
            this.ctlPresetName.Location = new System.Drawing.Point(31, 3);
            this.ctlPresetName.Name = "ctlPresetName";
            this.ctlPresetName.Size = new System.Drawing.Size(240, 22);
            this.ctlPresetName.TabIndex = 0;
            this.ctlPresetName.Value = "";
            this.ctlPresetName.ValueChanged += new System.EventHandler(this.ctlPresetName_ValueChanged);
            // 
            // ctlChannelParameters
            // 
            this.ctlChannelParameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctlChannelParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlChannelParameters.Location = new System.Drawing.Point(0, 31);
            this.ctlChannelParameters.Name = "ctlChannelParameters";
            this.ctlChannelParameters.Size = new System.Drawing.Size(996, 565);
            this.ctlChannelParameters.TabIndex = 2;
            // 
            // CtlFastCommandEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.ctlChannelParameters);
            this.Controls.Add(this.pn_HeadPanel);
            this.Name = "CtlFastCommandEditor";
            this.Size = new System.Drawing.Size(996, 596);
            this.pn_HeadPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_HeadPanel;
        private CtlFastCommandListField ctlFastComList;
        private CtlEFXSourceField ctlEFXSource;
        private CtlStringField ctlPresetName;
        private CtlChannelParametersListEditor ctlChannelParameters;
    }
}
