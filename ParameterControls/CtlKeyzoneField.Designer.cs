
namespace SynthLiveMidiController
{
    partial class CtlKeyzoneField
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
            this.SuspendLayout();
            // 
            // CtlKeyzoneField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "CtlKeyzoneField";
            this.Size = new System.Drawing.Size(440, 56);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CtlKeyzoneField_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CtlKeyzoneField_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtlKeyzoneField_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CtlKeyzoneField_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
