
namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    partial class SelectPatchDialog
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
            this.pn_BankListPanel = new System.Windows.Forms.Panel();
            this.lv_BankNameList = new System.Windows.Forms.ListView();
            this.lv_PatchList = new System.Windows.Forms.ListView();
            this.bt_Ok = new System.Windows.Forms.Button();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pn_BankListPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_BankListPanel
            // 
            this.pn_BankListPanel.Controls.Add(this.lv_BankNameList);
            this.pn_BankListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_BankListPanel.Location = new System.Drawing.Point(0, 0);
            this.pn_BankListPanel.Name = "pn_BankListPanel";
            this.pn_BankListPanel.Size = new System.Drawing.Size(134, 571);
            this.pn_BankListPanel.TabIndex = 0;
            // 
            // lv_BankNameList
            // 
            this.lv_BankNameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_BankNameList.HideSelection = false;
            this.lv_BankNameList.Location = new System.Drawing.Point(0, 0);
            this.lv_BankNameList.MultiSelect = false;
            this.lv_BankNameList.Name = "lv_BankNameList";
            this.lv_BankNameList.Size = new System.Drawing.Size(134, 571);
            this.lv_BankNameList.TabIndex = 0;
            this.lv_BankNameList.UseCompatibleStateImageBehavior = false;
            this.lv_BankNameList.View = System.Windows.Forms.View.List;
            this.lv_BankNameList.SelectedIndexChanged += new System.EventHandler(this.lv_BankNameList_SelectedIndexChanged);
            // 
            // lv_PatchList
            // 
            this.lv_PatchList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_PatchList.HideSelection = false;
            this.lv_PatchList.Location = new System.Drawing.Point(134, 0);
            this.lv_PatchList.MultiSelect = false;
            this.lv_PatchList.Name = "lv_PatchList";
            this.lv_PatchList.Size = new System.Drawing.Size(820, 571);
            this.lv_PatchList.TabIndex = 1;
            this.lv_PatchList.UseCompatibleStateImageBehavior = false;
            this.lv_PatchList.View = System.Windows.Forms.View.List;
            this.lv_PatchList.SelectedIndexChanged += new System.EventHandler(this.lv_PatchList_SelectedIndexChanged_1);
            // 
            // bt_Ok
            // 
            this.bt_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt_Ok.Location = new System.Drawing.Point(661, 3);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(75, 23);
            this.bt_Ok.TabIndex = 2;
            this.bt_Ok.Text = "Ok";
            this.bt_Ok.UseVisualStyleBackColor = true;
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Cancel.Location = new System.Drawing.Point(742, 3);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancel.TabIndex = 3;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_Ok);
            this.panel1.Controls.Add(this.bt_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(134, 542);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 29);
            this.panel1.TabIndex = 4;
            // 
            // SelectPatchDialog
            // 
            this.AcceptButton = this.bt_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_Cancel;
            this.ClientSize = new System.Drawing.Size(954, 571);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lv_PatchList);
            this.Controls.Add(this.pn_BankListPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectPatchDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Patch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectPatchDialog_FormClosing);
            this.Shown += new System.EventHandler(this.SelectPatchDialog_Shown);
            this.VisibleChanged += new System.EventHandler(this.SelectPatchDialog_VisibleChanged);
            this.pn_BankListPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_BankListPanel;
        private System.Windows.Forms.ListView lv_BankNameList;
        private System.Windows.Forms.ListView lv_PatchList;
        private System.Windows.Forms.Button bt_Ok;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Panel panel1;
    }
}