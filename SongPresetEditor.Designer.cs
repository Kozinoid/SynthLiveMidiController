
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
            this.pn_Buttons = new System.Windows.Forms.Panel();
            this.bt_Clear = new System.Windows.Forms.Button();
            this.bt_Del = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.pn_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Buttons
            // 
            this.pn_Buttons.Controls.Add(this.bt_Clear);
            this.pn_Buttons.Controls.Add(this.bt_Del);
            this.pn_Buttons.Controls.Add(this.bt_Add);
            this.pn_Buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_Buttons.Location = new System.Drawing.Point(0, 529);
            this.pn_Buttons.Name = "pn_Buttons";
            this.pn_Buttons.Size = new System.Drawing.Size(984, 32);
            this.pn_Buttons.TabIndex = 1;
            // 
            // bt_Clear
            // 
            this.bt_Clear.Location = new System.Drawing.Point(165, 3);
            this.bt_Clear.Name = "bt_Clear";
            this.bt_Clear.Size = new System.Drawing.Size(75, 23);
            this.bt_Clear.TabIndex = 2;
            this.bt_Clear.Text = "Clear";
            this.bt_Clear.UseVisualStyleBackColor = true;
            this.bt_Clear.Click += new System.EventHandler(this.bt_Clear_Click);
            // 
            // bt_Del
            // 
            this.bt_Del.Location = new System.Drawing.Point(84, 3);
            this.bt_Del.Name = "bt_Del";
            this.bt_Del.Size = new System.Drawing.Size(75, 23);
            this.bt_Del.TabIndex = 1;
            this.bt_Del.Text = "Delete";
            this.bt_Del.UseVisualStyleBackColor = true;
            this.bt_Del.Click += new System.EventHandler(this.bt_Del_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(3, 3);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 23);
            this.bt_Add.TabIndex = 0;
            this.bt_Add.Text = "Add";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // SongPresetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pn_Buttons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SongPresetEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Song Preset Editor";
            this.pn_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pn_Buttons;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button bt_Clear;
        private System.Windows.Forms.Button bt_Del;
    }
}