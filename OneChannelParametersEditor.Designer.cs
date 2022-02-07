
namespace SynthLiveMidiController
{
    partial class OneChannelParametersEditor
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
            this.valueControl1 = new SynthLiveMidiController.ValueControl();
            this.checkBoxControl1 = new SynthLiveMidiController.CheckBoxControl();
            this.valueControl2 = new SynthLiveMidiController.ValueControl();
            this.shiftControl1 = new SynthLiveMidiController.ShiftControl();
            this.keyRangeControl1 = new SynthLiveMidiController.KeyRangeControl();
            this.patchControl1 = new SynthLiveMidiController.PatchControl();
            this.SuspendLayout();
            // 
            // valueControl1
            // 
            this.valueControl1.Caption = "Channel";
            this.valueControl1.Location = new System.Drawing.Point(3, 3);
            this.valueControl1.MaxValue = ((byte)(15));
            this.valueControl1.Name = "valueControl1";
            this.valueControl1.ShiftValue = ((byte)(1));
            this.valueControl1.Size = new System.Drawing.Size(72, 16);
            this.valueControl1.TabIndex = 0;
            this.valueControl1.Value = ((byte)(0));
            // 
            // checkBoxControl1
            // 
            this.checkBoxControl1.Caption = "Hold";
            this.checkBoxControl1.IsChecked = false;
            this.checkBoxControl1.Location = new System.Drawing.Point(3, 25);
            this.checkBoxControl1.Name = "checkBoxControl1";
            this.checkBoxControl1.Size = new System.Drawing.Size(60, 16);
            this.checkBoxControl1.TabIndex = 1;
            // 
            // valueControl2
            // 
            this.valueControl2.Caption = "Volume";
            this.valueControl2.Location = new System.Drawing.Point(72, 3);
            this.valueControl2.MaxValue = ((byte)(127));
            this.valueControl2.Name = "valueControl2";
            this.valueControl2.ShiftValue = ((byte)(0));
            this.valueControl2.Size = new System.Drawing.Size(71, 16);
            this.valueControl2.TabIndex = 2;
            this.valueControl2.Value = ((byte)(127));
            // 
            // shiftControl1
            // 
            this.shiftControl1.Caption = "Pan";
            this.shiftControl1.Location = new System.Drawing.Point(148, 3);
            this.shiftControl1.MaxValue = 63;
            this.shiftControl1.MinValue = -63;
            this.shiftControl1.Name = "shiftControl1";
            this.shiftControl1.Size = new System.Drawing.Size(60, 16);
            this.shiftControl1.TabIndex = 3;
            this.shiftControl1.Value = 0;
            // 
            // keyRangeControl1
            // 
            this.keyRangeControl1.KeyboardLower = ((byte)(0));
            this.keyRangeControl1.KeyboardOctaveShift = 0;
            this.keyRangeControl1.KeyboardUpper = ((byte)(127));
            this.keyRangeControl1.Location = new System.Drawing.Point(72, 25);
            this.keyRangeControl1.LowerKey = ((byte)(0));
            this.keyRangeControl1.Name = "keyRangeControl1";
            this.keyRangeControl1.OctaveShift = ((byte)(3));
            this.keyRangeControl1.Size = new System.Drawing.Size(235, 16);
            this.keyRangeControl1.TabIndex = 4;
            this.keyRangeControl1.UpperKey = ((byte)(127));
            // 
            // patchControl1
            // 
            this.patchControl1.Caption = "Patch";
            this.patchControl1.Location = new System.Drawing.Point(225, 3);
            this.patchControl1.Name = "patchControl1";
            this.patchControl1.PatchBuffer = new byte[] {
        ((byte)(0)),
        ((byte)(3)),
        ((byte)(0)),
        ((byte)(5))};
            this.patchControl1.Size = new System.Drawing.Size(273, 16);
            this.patchControl1.TabIndex = 5;
            // 
            // OneChannelParametersEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.patchControl1);
            this.Controls.Add(this.keyRangeControl1);
            this.Controls.Add(this.shiftControl1);
            this.Controls.Add(this.valueControl2);
            this.Controls.Add(this.checkBoxControl1);
            this.Controls.Add(this.valueControl1);
            this.Name = "OneChannelParametersEditor";
            this.Size = new System.Drawing.Size(513, 44);
            this.ResumeLayout(false);

        }

        #endregion

        private ValueControl valueControl1;
        private CheckBoxControl checkBoxControl1;
        private ValueControl valueControl2;
        private ShiftControl shiftControl1;
        private KeyRangeControl keyRangeControl1;
        private PatchControl patchControl1;
    }
}
