
namespace SynthLiveMidiController
{
    partial class CtlOneChannelParameters
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
            this.pn_Parameters = new System.Windows.Forms.Panel();
            this.ctlKeyzoneField1 = new SynthLiveMidiController.CtlKeyzoneField();
            this.ctlChorus = new SynthLiveMidiController.CtlByteField();
            this.ctlReverb = new SynthLiveMidiController.CtlByteField();
            this.ctlPatch = new SynthLiveMidiController.CtlPatchSelectField();
            this.ctlKeyUp = new SynthLiveMidiController.CtlKeyField();
            this.ctlOctave = new SynthLiveMidiController.CtlOctaveField();
            this.ctlKeyDown = new SynthLiveMidiController.CtlKeyField();
            this.ctlPan = new SynthLiveMidiController.CtlPanField();
            this.ctlVolume = new SynthLiveMidiController.CtlByteField();
            this.ctlHold = new SynthLiveMidiController.CtlBoolField();
            this.ctlChannel = new SynthLiveMidiController.CtlChannelField();
            this.pn_Parameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Parameters
            // 
            this.pn_Parameters.Controls.Add(this.ctlChorus);
            this.pn_Parameters.Controls.Add(this.ctlReverb);
            this.pn_Parameters.Controls.Add(this.ctlPatch);
            this.pn_Parameters.Controls.Add(this.ctlKeyUp);
            this.pn_Parameters.Controls.Add(this.ctlOctave);
            this.pn_Parameters.Controls.Add(this.ctlKeyDown);
            this.pn_Parameters.Controls.Add(this.ctlPan);
            this.pn_Parameters.Controls.Add(this.ctlVolume);
            this.pn_Parameters.Controls.Add(this.ctlHold);
            this.pn_Parameters.Controls.Add(this.ctlChannel);
            this.pn_Parameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_Parameters.Location = new System.Drawing.Point(0, 0);
            this.pn_Parameters.Name = "pn_Parameters";
            this.pn_Parameters.Size = new System.Drawing.Size(459, 56);
            this.pn_Parameters.TabIndex = 0;
            // 
            // ctlKeyzoneField1
            // 
            this.ctlKeyzoneField1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlKeyzoneField1.Location = new System.Drawing.Point(459, 0);
            this.ctlKeyzoneField1.Name = "ctlKeyzoneField1";
            this.ctlKeyzoneField1.Size = new System.Drawing.Size(435, 56);
            this.ctlKeyzoneField1.TabIndex = 1;
            // 
            // ctlChorus
            // 
            this.ctlChorus.ByteValue = ((byte)(127));
            this.ctlChorus.Caption = "Chor:";
            this.ctlChorus.Location = new System.Drawing.Point(155, 31);
            this.ctlChorus.Name = "ctlChorus";
            this.ctlChorus.Size = new System.Drawing.Size(70, 22);
            this.ctlChorus.TabIndex = 9;
            this.ctlChorus.Value = 127;
            // 
            // ctlReverb
            // 
            this.ctlReverb.ByteValue = ((byte)(127));
            this.ctlReverb.Caption = "Rev:";
            this.ctlReverb.Location = new System.Drawing.Point(155, 3);
            this.ctlReverb.Name = "ctlReverb";
            this.ctlReverb.Size = new System.Drawing.Size(70, 22);
            this.ctlReverb.TabIndex = 8;
            this.ctlReverb.Value = 127;
            // 
            // ctlPatch
            // 
            this.ctlPatch.Caption = "Patch:";
            this.ctlPatch.Location = new System.Drawing.Point(231, 31);
            this.ctlPatch.Name = "ctlPatch";
            this.ctlPatch.PatchBuffer = new byte[] {
        ((byte)(0)),
        ((byte)(3)),
        ((byte)(0)),
        ((byte)(0))};
            this.ctlPatch.Size = new System.Drawing.Size(198, 22);
            this.ctlPatch.TabIndex = 7;
            // 
            // ctlKeyUp
            // 
            this.ctlKeyUp.ByteValue = ((byte)(127));
            this.ctlKeyUp.Caption = "Up:";
            this.ctlKeyUp.Location = new System.Drawing.Point(383, 3);
            this.ctlKeyUp.Name = "ctlKeyUp";
            this.ctlKeyUp.Size = new System.Drawing.Size(70, 22);
            this.ctlKeyUp.TabIndex = 6;
            this.ctlKeyUp.Value = 127;
            // 
            // ctlOctave
            // 
            this.ctlOctave.ByteValue = ((byte)(3));
            this.ctlOctave.Caption = "Oct:";
            this.ctlOctave.Location = new System.Drawing.Point(307, 3);
            this.ctlOctave.Name = "ctlOctave";
            this.ctlOctave.Size = new System.Drawing.Size(70, 22);
            this.ctlOctave.TabIndex = 5;
            this.ctlOctave.Value = 0;
            // 
            // ctlKeyDown
            // 
            this.ctlKeyDown.ByteValue = ((byte)(0));
            this.ctlKeyDown.Caption = "Down:";
            this.ctlKeyDown.Location = new System.Drawing.Point(231, 3);
            this.ctlKeyDown.Name = "ctlKeyDown";
            this.ctlKeyDown.Size = new System.Drawing.Size(70, 22);
            this.ctlKeyDown.TabIndex = 4;
            this.ctlKeyDown.Value = 0;
            // 
            // ctlPan
            // 
            this.ctlPan.ByteValue = ((byte)(63));
            this.ctlPan.Caption = "Pan:";
            this.ctlPan.Location = new System.Drawing.Point(79, 31);
            this.ctlPan.Name = "ctlPan";
            this.ctlPan.Size = new System.Drawing.Size(70, 22);
            this.ctlPan.TabIndex = 3;
            this.ctlPan.Value = 0;
            // 
            // ctlVolume
            // 
            this.ctlVolume.ByteValue = ((byte)(127));
            this.ctlVolume.Caption = "Vol:";
            this.ctlVolume.Location = new System.Drawing.Point(79, 3);
            this.ctlVolume.Name = "ctlVolume";
            this.ctlVolume.Size = new System.Drawing.Size(70, 22);
            this.ctlVolume.TabIndex = 2;
            this.ctlVolume.Value = 127;
            // 
            // ctlHold
            // 
            this.ctlHold.Caption = "Hold:";
            this.ctlHold.Checked = false;
            this.ctlHold.Location = new System.Drawing.Point(3, 31);
            this.ctlHold.Name = "ctlHold";
            this.ctlHold.Size = new System.Drawing.Size(70, 22);
            this.ctlHold.TabIndex = 1;
            // 
            // ctlChannel
            // 
            this.ctlChannel.ByteValue = ((byte)(0));
            this.ctlChannel.Caption = "Chan:";
            this.ctlChannel.Location = new System.Drawing.Point(3, 3);
            this.ctlChannel.Name = "ctlChannel";
            this.ctlChannel.Size = new System.Drawing.Size(70, 22);
            this.ctlChannel.TabIndex = 0;
            this.ctlChannel.Value = 1;
            // 
            // CtlOneChannelParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ctlKeyzoneField1);
            this.Controls.Add(this.pn_Parameters);
            this.DoubleBuffered = true;
            this.Name = "CtlOneChannelParameters";
            this.Size = new System.Drawing.Size(894, 56);
            this.pn_Parameters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Parameters;
        private CtlByteField ctlChorus;
        private CtlByteField ctlReverb;
        private CtlPatchSelectField ctlPatch;
        private CtlKeyField ctlKeyUp;
        private CtlOctaveField ctlOctave;
        private CtlKeyField ctlKeyDown;
        private CtlPanField ctlPan;
        private CtlByteField ctlVolume;
        private CtlBoolField ctlHold;
        private CtlChannelField ctlChannel;
        private CtlKeyzoneField ctlKeyzoneField1;
    }
}
