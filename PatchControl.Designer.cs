
namespace SynthLiveMidiController
{
    partial class PatchControl
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
            this.lb_Caption = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Caption
            // 
            this.lb_Caption.AutoSize = true;
            this.lb_Caption.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Caption.Location = new System.Drawing.Point(0, 0);
            this.lb_Caption.Name = "lb_Caption";
            this.lb_Caption.Size = new System.Drawing.Size(35, 13);
            this.lb_Caption.TabIndex = 0;
            this.lb_Caption.Text = "Patch";
            // 
            // PatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_Caption);
            this.Name = "PatchControl";
            this.Size = new System.Drawing.Size(136, 16);
            this.Click += new System.EventHandler(this.PatchControl_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Caption;
    }
}
