
namespace SynthLiveMidiController
{
    partial class KeyRangeControl
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
            this.lb_Lower = new SynthLiveMidiController.NoteKeyControl();
            this.lb_Octave = new SynthLiveMidiController.ShiftControl();
            this.lb_Upper = new SynthLiveMidiController.NoteKeyControl();
            this.SuspendLayout();
            // 
            // lb_Lower
            // 
            this.lb_Lower.Caption = "Lower";
            this.lb_Lower.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Lower.Location = new System.Drawing.Point(0, 0);
            this.lb_Lower.Name = "lb_Lower";
            this.lb_Lower.Size = new System.Drawing.Size(76, 16);
            this.lb_Lower.TabIndex = 0;
            this.lb_Lower.Value = ((byte)(0));
            // 
            // lb_Octave
            // 
            this.lb_Octave.Caption = "Octave";
            this.lb_Octave.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Octave.Location = new System.Drawing.Point(76, 0);
            this.lb_Octave.Name = "lb_Octave";
            this.lb_Octave.Size = new System.Drawing.Size(76, 16);
            this.lb_Octave.TabIndex = 1;
            this.lb_Octave.Value = 0;
            // 
            // lb_Upper
            // 
            this.lb_Upper.Caption = "Upper";
            this.lb_Upper.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Upper.Location = new System.Drawing.Point(152, 0);
            this.lb_Upper.Name = "lb_Upper";
            this.lb_Upper.Size = new System.Drawing.Size(76, 16);
            this.lb_Upper.TabIndex = 2;
            this.lb_Upper.Value = ((byte)(127));
            // 
            // KeyRangeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_Upper);
            this.Controls.Add(this.lb_Octave);
            this.Controls.Add(this.lb_Lower);
            this.Name = "KeyRangeControl";
            this.Size = new System.Drawing.Size(233, 16);
            this.ResumeLayout(false);

        }

        #endregion

        private NoteKeyControl lb_Lower;
        private ShiftControl lb_Octave;
        private NoteKeyControl lb_Upper;
    }
}
