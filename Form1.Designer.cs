
namespace SynthLiveMidiController
{
    partial class Form1
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
            this.bt_act2 = new System.Windows.Forms.Button();
            this.bt_act3 = new System.Windows.Forms.Button();
            this.bt_act1 = new System.Windows.Forms.Button();
            this.bt_act4 = new System.Windows.Forms.Button();
            this.bt_act5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_act2
            // 
            this.bt_act2.Location = new System.Drawing.Point(12, 41);
            this.bt_act2.Name = "bt_act2";
            this.bt_act2.Size = new System.Drawing.Size(131, 23);
            this.bt_act2.TabIndex = 0;
            this.bt_act2.Text = "Get to Storage";
            this.bt_act2.UseVisualStyleBackColor = true;
            this.bt_act2.Click += new System.EventHandler(this.bt_act2_Click);
            // 
            // bt_act3
            // 
            this.bt_act3.Location = new System.Drawing.Point(12, 70);
            this.bt_act3.Name = "bt_act3";
            this.bt_act3.Size = new System.Drawing.Size(131, 23);
            this.bt_act3.TabIndex = 1;
            this.bt_act3.Text = "Print Daa";
            this.bt_act3.UseVisualStyleBackColor = true;
            this.bt_act3.Click += new System.EventHandler(this.bt_act3_Click);
            // 
            // bt_act1
            // 
            this.bt_act1.Location = new System.Drawing.Point(12, 12);
            this.bt_act1.Name = "bt_act1";
            this.bt_act1.Size = new System.Drawing.Size(131, 23);
            this.bt_act1.TabIndex = 2;
            this.bt_act1.Text = "Request Performance";
            this.bt_act1.UseVisualStyleBackColor = true;
            this.bt_act1.Click += new System.EventHandler(this.bt_act1_Click);
            // 
            // bt_act4
            // 
            this.bt_act4.Location = new System.Drawing.Point(12, 99);
            this.bt_act4.Name = "bt_act4";
            this.bt_act4.Size = new System.Drawing.Size(131, 23);
            this.bt_act4.TabIndex = 3;
            this.bt_act4.Text = "Set from Storage";
            this.bt_act4.UseVisualStyleBackColor = true;
            this.bt_act4.Click += new System.EventHandler(this.bt_act4_Click);
            // 
            // bt_act5
            // 
            this.bt_act5.Location = new System.Drawing.Point(12, 128);
            this.bt_act5.Name = "bt_act5";
            this.bt_act5.Size = new System.Drawing.Size(131, 23);
            this.bt_act5.TabIndex = 4;
            this.bt_act5.Text = "Send Performance";
            this.bt_act5.UseVisualStyleBackColor = true;
            this.bt_act5.Click += new System.EventHandler(this.bt_act5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(159, 450);
            this.Controls.Add(this.bt_act5);
            this.Controls.Add(this.bt_act4);
            this.Controls.Add(this.bt_act1);
            this.Controls.Add(this.bt_act3);
            this.Controls.Add(this.bt_act2);
            this.Name = "Form1";
            this.Text = "Synth Live MIDI Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_act2;
        private System.Windows.Forms.Button bt_act3;
        private System.Windows.Forms.Button bt_act1;
        private System.Windows.Forms.Button bt_act4;
        private System.Windows.Forms.Button bt_act5;
    }
}

