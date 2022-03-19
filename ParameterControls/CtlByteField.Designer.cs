
namespace SynthLiveMidiController.ParameterControls
{
    partial class CtlByteField
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
            // CtlByteField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "CtlByteField";
            this.Size = new System.Drawing.Size(70, 22);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CtlByteField_Paint);
            this.DoubleClick += new System.EventHandler(this.CtlByteField_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CtlByteField_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtlByteField_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CtlByteField_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
