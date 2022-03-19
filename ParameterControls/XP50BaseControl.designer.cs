
namespace SynthLiveMidiController.ParameterControls
{
    partial class XP50BaseControl
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
            // XP50BaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "XP50BaseControl";
            this.Size = new System.Drawing.Size(120, 27);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.XP50BaseControl_Paint);
            this.DoubleClick += new System.EventHandler(this.XP50BaseControl_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XP50BaseControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.XP50BaseControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XP50BaseControl_MouseUp);
            this.Resize += new System.EventHandler(this.XP50BaseControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
