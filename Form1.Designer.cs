
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
            this.pn_LeftPanel = new System.Windows.Forms.Panel();
            this.tab_Control = new System.Windows.Forms.TabControl();
            this.tab_SongList = new System.Windows.Forms.TabPage();
            this.songListControl = new SynthLiveMidiController.SongListControl();
            this.tab_TrackList = new System.Windows.Forms.TabPage();
            this.trackListControl = new SynthLiveMidiController.SongListControl();
            this.tab_FastPresets = new System.Windows.Forms.TabPage();
            this.fastListControl = new SynthLiveMidiController.FastListControl();
            this.pn_ButtonPanel = new System.Windows.Forms.Panel();
            this.gb_Controls = new System.Windows.Forms.GroupBox();
            this.bt_Options = new System.Windows.Forms.Button();
            this.lb_Tempo = new System.Windows.Forms.Label();
            this.lb_CommandName = new System.Windows.Forms.Label();
            this.lb_SongName = new System.Windows.Forms.Label();
            this.bt_N9 = new System.Windows.Forms.Button();
            this.bt_N3 = new System.Windows.Forms.Button();
            this.bt_N2 = new System.Windows.Forms.Button();
            this.bt_N8 = new System.Windows.Forms.Button();
            this.bt_N7 = new System.Windows.Forms.Button();
            this.bt_N6 = new System.Windows.Forms.Button();
            this.bt_N1 = new System.Windows.Forms.Button();
            this.bt_S10 = new System.Windows.Forms.Button();
            this.bt_N4 = new System.Windows.Forms.Button();
            this.bt_N5 = new System.Windows.Forms.Button();
            this.bt_S9 = new System.Windows.Forms.Button();
            this.bt_S8 = new System.Windows.Forms.Button();
            this.bt_S7 = new System.Windows.Forms.Button();
            this.bt_S6 = new System.Windows.Forms.Button();
            this.bt_S5 = new System.Windows.Forms.Button();
            this.bt_S4 = new System.Windows.Forms.Button();
            this.bt_S3 = new System.Windows.Forms.Button();
            this.bt_S2 = new System.Windows.Forms.Button();
            this.bt_S1 = new System.Windows.Forms.Button();
            this.pn_PicturePanel = new System.Windows.Forms.Panel();
            this.pn_LeftPanel.SuspendLayout();
            this.tab_Control.SuspendLayout();
            this.tab_SongList.SuspendLayout();
            this.tab_TrackList.SuspendLayout();
            this.tab_FastPresets.SuspendLayout();
            this.pn_ButtonPanel.SuspendLayout();
            this.gb_Controls.SuspendLayout();
            this.pn_PicturePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_act2
            // 
            this.bt_act2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_act2.Location = new System.Drawing.Point(565, 41);
            this.bt_act2.Name = "bt_act2";
            this.bt_act2.Size = new System.Drawing.Size(131, 23);
            this.bt_act2.TabIndex = 0;
            this.bt_act2.Text = "Get and Print";
            this.bt_act2.UseVisualStyleBackColor = true;
            this.bt_act2.Click += new System.EventHandler(this.bt_act2_Click);
            // 
            // bt_act3
            // 
            this.bt_act3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_act3.Location = new System.Drawing.Point(565, 70);
            this.bt_act3.Name = "bt_act3";
            this.bt_act3.Size = new System.Drawing.Size(131, 23);
            this.bt_act3.TabIndex = 1;
            this.bt_act3.Text = "Store Data";
            this.bt_act3.UseVisualStyleBackColor = true;
            this.bt_act3.Click += new System.EventHandler(this.bt_act3_Click);
            // 
            // bt_act1
            // 
            this.bt_act1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_act1.Location = new System.Drawing.Point(565, 12);
            this.bt_act1.Name = "bt_act1";
            this.bt_act1.Size = new System.Drawing.Size(131, 23);
            this.bt_act1.TabIndex = 2;
            this.bt_act1.Text = "Request Performance";
            this.bt_act1.UseVisualStyleBackColor = true;
            this.bt_act1.Click += new System.EventHandler(this.bt_act1_Click);
            // 
            // bt_act4
            // 
            this.bt_act4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_act4.Location = new System.Drawing.Point(565, 99);
            this.bt_act4.Name = "bt_act4";
            this.bt_act4.Size = new System.Drawing.Size(131, 23);
            this.bt_act4.TabIndex = 3;
            this.bt_act4.Text = "Load Data";
            this.bt_act4.UseVisualStyleBackColor = true;
            this.bt_act4.Click += new System.EventHandler(this.bt_act4_Click);
            // 
            // bt_act5
            // 
            this.bt_act5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_act5.Location = new System.Drawing.Point(565, 128);
            this.bt_act5.Name = "bt_act5";
            this.bt_act5.Size = new System.Drawing.Size(131, 23);
            this.bt_act5.TabIndex = 4;
            this.bt_act5.Text = "Send Performance";
            this.bt_act5.UseVisualStyleBackColor = true;
            this.bt_act5.Click += new System.EventHandler(this.bt_act5_Click);
            // 
            // pn_LeftPanel
            // 
            this.pn_LeftPanel.Controls.Add(this.tab_Control);
            this.pn_LeftPanel.Controls.Add(this.pn_ButtonPanel);
            this.pn_LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.pn_LeftPanel.Name = "pn_LeftPanel";
            this.pn_LeftPanel.Size = new System.Drawing.Size(496, 801);
            this.pn_LeftPanel.TabIndex = 5;
            // 
            // tab_Control
            // 
            this.tab_Control.Controls.Add(this.tab_SongList);
            this.tab_Control.Controls.Add(this.tab_TrackList);
            this.tab_Control.Controls.Add(this.tab_FastPresets);
            this.tab_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Control.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tab_Control.Location = new System.Drawing.Point(0, 0);
            this.tab_Control.Margin = new System.Windows.Forms.Padding(0);
            this.tab_Control.Name = "tab_Control";
            this.tab_Control.Padding = new System.Drawing.Point(0, 0);
            this.tab_Control.SelectedIndex = 0;
            this.tab_Control.Size = new System.Drawing.Size(496, 677);
            this.tab_Control.TabIndex = 1;
            this.tab_Control.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tab_Control_DrawItem);
            // 
            // tab_SongList
            // 
            this.tab_SongList.AutoScroll = true;
            this.tab_SongList.Controls.Add(this.songListControl);
            this.tab_SongList.Location = new System.Drawing.Point(4, 22);
            this.tab_SongList.Margin = new System.Windows.Forms.Padding(0);
            this.tab_SongList.Name = "tab_SongList";
            this.tab_SongList.Size = new System.Drawing.Size(488, 651);
            this.tab_SongList.TabIndex = 0;
            this.tab_SongList.Text = "Писок песен";
            this.tab_SongList.UseVisualStyleBackColor = true;
            // 
            // songListControl
            // 
            this.songListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songListControl.Location = new System.Drawing.Point(0, 0);
            this.songListControl.Margin = new System.Windows.Forms.Padding(0);
            this.songListControl.Name = "songListControl";
            this.songListControl.Size = new System.Drawing.Size(488, 651);
            this.songListControl.TabIndex = 1;
            // 
            // tab_TrackList
            // 
            this.tab_TrackList.AutoScroll = true;
            this.tab_TrackList.Controls.Add(this.trackListControl);
            this.tab_TrackList.Location = new System.Drawing.Point(4, 22);
            this.tab_TrackList.Margin = new System.Windows.Forms.Padding(0);
            this.tab_TrackList.Name = "tab_TrackList";
            this.tab_TrackList.Size = new System.Drawing.Size(488, 651);
            this.tab_TrackList.TabIndex = 1;
            this.tab_TrackList.Text = "Трэклист";
            this.tab_TrackList.UseVisualStyleBackColor = true;
            // 
            // trackListControl
            // 
            this.trackListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackListControl.Location = new System.Drawing.Point(0, 0);
            this.trackListControl.Margin = new System.Windows.Forms.Padding(0);
            this.trackListControl.Name = "trackListControl";
            this.trackListControl.Size = new System.Drawing.Size(488, 651);
            this.trackListControl.TabIndex = 0;
            // 
            // tab_FastPresets
            // 
            this.tab_FastPresets.AutoScroll = true;
            this.tab_FastPresets.Controls.Add(this.fastListControl);
            this.tab_FastPresets.Location = new System.Drawing.Point(4, 22);
            this.tab_FastPresets.Margin = new System.Windows.Forms.Padding(0);
            this.tab_FastPresets.Name = "tab_FastPresets";
            this.tab_FastPresets.Size = new System.Drawing.Size(488, 651);
            this.tab_FastPresets.TabIndex = 2;
            this.tab_FastPresets.Text = "Быстрые клавиши";
            this.tab_FastPresets.UseVisualStyleBackColor = true;
            // 
            // fastListControl
            // 
            this.fastListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastListControl.Location = new System.Drawing.Point(0, 0);
            this.fastListControl.Name = "fastListControl";
            this.fastListControl.Size = new System.Drawing.Size(488, 651);
            this.fastListControl.TabIndex = 0;
            // 
            // pn_ButtonPanel
            // 
            this.pn_ButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn_ButtonPanel.Controls.Add(this.gb_Controls);
            this.pn_ButtonPanel.Controls.Add(this.bt_N9);
            this.pn_ButtonPanel.Controls.Add(this.bt_N3);
            this.pn_ButtonPanel.Controls.Add(this.bt_N2);
            this.pn_ButtonPanel.Controls.Add(this.bt_N8);
            this.pn_ButtonPanel.Controls.Add(this.bt_N7);
            this.pn_ButtonPanel.Controls.Add(this.bt_N6);
            this.pn_ButtonPanel.Controls.Add(this.bt_N1);
            this.pn_ButtonPanel.Controls.Add(this.bt_S10);
            this.pn_ButtonPanel.Controls.Add(this.bt_N4);
            this.pn_ButtonPanel.Controls.Add(this.bt_N5);
            this.pn_ButtonPanel.Controls.Add(this.bt_S9);
            this.pn_ButtonPanel.Controls.Add(this.bt_S8);
            this.pn_ButtonPanel.Controls.Add(this.bt_S7);
            this.pn_ButtonPanel.Controls.Add(this.bt_S6);
            this.pn_ButtonPanel.Controls.Add(this.bt_S5);
            this.pn_ButtonPanel.Controls.Add(this.bt_S4);
            this.pn_ButtonPanel.Controls.Add(this.bt_S3);
            this.pn_ButtonPanel.Controls.Add(this.bt_S2);
            this.pn_ButtonPanel.Controls.Add(this.bt_S1);
            this.pn_ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_ButtonPanel.Location = new System.Drawing.Point(0, 677);
            this.pn_ButtonPanel.Name = "pn_ButtonPanel";
            this.pn_ButtonPanel.Size = new System.Drawing.Size(496, 124);
            this.pn_ButtonPanel.TabIndex = 0;
            // 
            // gb_Controls
            // 
            this.gb_Controls.Controls.Add(this.bt_Options);
            this.gb_Controls.Controls.Add(this.lb_Tempo);
            this.gb_Controls.Controls.Add(this.lb_CommandName);
            this.gb_Controls.Controls.Add(this.lb_SongName);
            this.gb_Controls.Location = new System.Drawing.Point(10, 2);
            this.gb_Controls.Name = "gb_Controls";
            this.gb_Controls.Size = new System.Drawing.Size(354, 79);
            this.gb_Controls.TabIndex = 1;
            this.gb_Controls.TabStop = false;
            // 
            // bt_Options
            // 
            this.bt_Options.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Options.Location = new System.Drawing.Point(288, 18);
            this.bt_Options.Name = "bt_Options";
            this.bt_Options.Size = new System.Drawing.Size(60, 23);
            this.bt_Options.TabIndex = 3;
            this.bt_Options.Text = "Options";
            this.bt_Options.UseVisualStyleBackColor = true;
            this.bt_Options.Click += new System.EventHandler(this.bt_Options_Click);
            // 
            // lb_Tempo
            // 
            this.lb_Tempo.AutoSize = true;
            this.lb_Tempo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Tempo.Location = new System.Drawing.Point(284, 45);
            this.lb_Tempo.Name = "lb_Tempo";
            this.lb_Tempo.Size = new System.Drawing.Size(57, 19);
            this.lb_Tempo.TabIndex = 2;
            this.lb_Tempo.Text = "T = 120";
            // 
            // lb_CommandName
            // 
            this.lb_CommandName.AutoSize = true;
            this.lb_CommandName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_CommandName.Location = new System.Drawing.Point(7, 45);
            this.lb_CommandName.Name = "lb_CommandName";
            this.lb_CommandName.Size = new System.Drawing.Size(137, 19);
            this.lb_CommandName.TabIndex = 1;
            this.lb_CommandName.Text = "1 - Command Name";
            // 
            // lb_SongName
            // 
            this.lb_SongName.AutoSize = true;
            this.lb_SongName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_SongName.Location = new System.Drawing.Point(7, 16);
            this.lb_SongName.Name = "lb_SongName";
            this.lb_SongName.Size = new System.Drawing.Size(141, 23);
            this.lb_SongName.TabIndex = 0;
            this.lb_SongName.Text = "000 - Song Name";
            // 
            // bt_N9
            // 
            this.bt_N9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_N9.Location = new System.Drawing.Point(450, 8);
            this.bt_N9.Name = "bt_N9";
            this.bt_N9.Size = new System.Drawing.Size(30, 24);
            this.bt_N9.TabIndex = 0;
            this.bt_N9.Text = "F9";
            this.bt_N9.UseVisualStyleBackColor = false;
            // 
            // bt_N3
            // 
            this.bt_N3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_N3.Location = new System.Drawing.Point(450, 87);
            this.bt_N3.Name = "bt_N3";
            this.bt_N3.Size = new System.Drawing.Size(30, 24);
            this.bt_N3.TabIndex = 0;
            this.bt_N3.Text = "F3";
            this.bt_N3.UseVisualStyleBackColor = false;
            // 
            // bt_N2
            // 
            this.bt_N2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_N2.Location = new System.Drawing.Point(414, 87);
            this.bt_N2.Name = "bt_N2";
            this.bt_N2.Size = new System.Drawing.Size(30, 24);
            this.bt_N2.TabIndex = 0;
            this.bt_N2.Text = "F2";
            this.bt_N2.UseVisualStyleBackColor = false;
            // 
            // bt_N8
            // 
            this.bt_N8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_N8.Location = new System.Drawing.Point(414, 8);
            this.bt_N8.Name = "bt_N8";
            this.bt_N8.Size = new System.Drawing.Size(30, 24);
            this.bt_N8.TabIndex = 0;
            this.bt_N8.Text = "F8";
            this.bt_N8.UseVisualStyleBackColor = false;
            // 
            // bt_N7
            // 
            this.bt_N7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_N7.Location = new System.Drawing.Point(378, 8);
            this.bt_N7.Name = "bt_N7";
            this.bt_N7.Size = new System.Drawing.Size(30, 24);
            this.bt_N7.TabIndex = 0;
            this.bt_N7.Text = "F7";
            this.bt_N7.UseVisualStyleBackColor = false;
            // 
            // bt_N6
            // 
            this.bt_N6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_N6.Location = new System.Drawing.Point(450, 47);
            this.bt_N6.Name = "bt_N6";
            this.bt_N6.Size = new System.Drawing.Size(30, 24);
            this.bt_N6.TabIndex = 0;
            this.bt_N6.Text = "F6";
            this.bt_N6.UseVisualStyleBackColor = false;
            // 
            // bt_N1
            // 
            this.bt_N1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_N1.Location = new System.Drawing.Point(378, 86);
            this.bt_N1.Name = "bt_N1";
            this.bt_N1.Size = new System.Drawing.Size(30, 24);
            this.bt_N1.TabIndex = 0;
            this.bt_N1.Text = "F1";
            this.bt_N1.UseVisualStyleBackColor = false;
            // 
            // bt_S10
            // 
            this.bt_S10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_S10.Location = new System.Drawing.Point(334, 87);
            this.bt_S10.Name = "bt_S10";
            this.bt_S10.Size = new System.Drawing.Size(30, 24);
            this.bt_S10.TabIndex = 0;
            this.bt_S10.Text = "0";
            this.bt_S10.UseVisualStyleBackColor = false;
            // 
            // bt_N4
            // 
            this.bt_N4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_N4.Location = new System.Drawing.Point(378, 47);
            this.bt_N4.Name = "bt_N4";
            this.bt_N4.Size = new System.Drawing.Size(30, 24);
            this.bt_N4.TabIndex = 0;
            this.bt_N4.Text = "F4";
            this.bt_N4.UseVisualStyleBackColor = false;
            // 
            // bt_N5
            // 
            this.bt_N5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_N5.Location = new System.Drawing.Point(414, 47);
            this.bt_N5.Name = "bt_N5";
            this.bt_N5.Size = new System.Drawing.Size(30, 24);
            this.bt_N5.TabIndex = 0;
            this.bt_N5.Text = "F5";
            this.bt_N5.UseVisualStyleBackColor = false;
            // 
            // bt_S9
            // 
            this.bt_S9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_S9.Location = new System.Drawing.Point(298, 87);
            this.bt_S9.Name = "bt_S9";
            this.bt_S9.Size = new System.Drawing.Size(30, 24);
            this.bt_S9.TabIndex = 0;
            this.bt_S9.Text = "9";
            this.bt_S9.UseVisualStyleBackColor = false;
            // 
            // bt_S8
            // 
            this.bt_S8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_S8.Location = new System.Drawing.Point(262, 87);
            this.bt_S8.Name = "bt_S8";
            this.bt_S8.Size = new System.Drawing.Size(30, 24);
            this.bt_S8.TabIndex = 0;
            this.bt_S8.Text = "8";
            this.bt_S8.UseVisualStyleBackColor = false;
            // 
            // bt_S7
            // 
            this.bt_S7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_S7.Location = new System.Drawing.Point(226, 87);
            this.bt_S7.Name = "bt_S7";
            this.bt_S7.Size = new System.Drawing.Size(30, 24);
            this.bt_S7.TabIndex = 0;
            this.bt_S7.Text = "7";
            this.bt_S7.UseVisualStyleBackColor = false;
            // 
            // bt_S6
            // 
            this.bt_S6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_S6.Location = new System.Drawing.Point(190, 87);
            this.bt_S6.Name = "bt_S6";
            this.bt_S6.Size = new System.Drawing.Size(30, 24);
            this.bt_S6.TabIndex = 0;
            this.bt_S6.Text = "6";
            this.bt_S6.UseVisualStyleBackColor = false;
            // 
            // bt_S5
            // 
            this.bt_S5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_S5.Location = new System.Drawing.Point(154, 87);
            this.bt_S5.Name = "bt_S5";
            this.bt_S5.Size = new System.Drawing.Size(30, 24);
            this.bt_S5.TabIndex = 0;
            this.bt_S5.Text = "5";
            this.bt_S5.UseVisualStyleBackColor = false;
            // 
            // bt_S4
            // 
            this.bt_S4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_S4.Location = new System.Drawing.Point(118, 87);
            this.bt_S4.Name = "bt_S4";
            this.bt_S4.Size = new System.Drawing.Size(30, 24);
            this.bt_S4.TabIndex = 0;
            this.bt_S4.Text = "4";
            this.bt_S4.UseVisualStyleBackColor = false;
            // 
            // bt_S3
            // 
            this.bt_S3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_S3.Location = new System.Drawing.Point(82, 87);
            this.bt_S3.Name = "bt_S3";
            this.bt_S3.Size = new System.Drawing.Size(30, 24);
            this.bt_S3.TabIndex = 0;
            this.bt_S3.Text = "3";
            this.bt_S3.UseVisualStyleBackColor = false;
            // 
            // bt_S2
            // 
            this.bt_S2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_S2.Location = new System.Drawing.Point(46, 87);
            this.bt_S2.Name = "bt_S2";
            this.bt_S2.Size = new System.Drawing.Size(30, 24);
            this.bt_S2.TabIndex = 0;
            this.bt_S2.Text = "2";
            this.bt_S2.UseVisualStyleBackColor = false;
            // 
            // bt_S1
            // 
            this.bt_S1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_S1.Location = new System.Drawing.Point(10, 87);
            this.bt_S1.Name = "bt_S1";
            this.bt_S1.Size = new System.Drawing.Size(30, 24);
            this.bt_S1.TabIndex = 0;
            this.bt_S1.Text = "1";
            this.bt_S1.UseVisualStyleBackColor = false;
            // 
            // pn_PicturePanel
            // 
            this.pn_PicturePanel.Controls.Add(this.bt_act1);
            this.pn_PicturePanel.Controls.Add(this.bt_act3);
            this.pn_PicturePanel.Controls.Add(this.bt_act5);
            this.pn_PicturePanel.Controls.Add(this.bt_act4);
            this.pn_PicturePanel.Controls.Add(this.bt_act2);
            this.pn_PicturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_PicturePanel.Location = new System.Drawing.Point(496, 0);
            this.pn_PicturePanel.Name = "pn_PicturePanel";
            this.pn_PicturePanel.Size = new System.Drawing.Size(708, 801);
            this.pn_PicturePanel.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1204, 801);
            this.Controls.Add(this.pn_PicturePanel);
            this.Controls.Add(this.pn_LeftPanel);
            this.ForeColor = System.Drawing.Color.GreenYellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Synth Live MIDI Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pn_LeftPanel.ResumeLayout(false);
            this.tab_Control.ResumeLayout(false);
            this.tab_SongList.ResumeLayout(false);
            this.tab_TrackList.ResumeLayout(false);
            this.tab_FastPresets.ResumeLayout(false);
            this.pn_ButtonPanel.ResumeLayout(false);
            this.gb_Controls.ResumeLayout(false);
            this.gb_Controls.PerformLayout();
            this.pn_PicturePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_act2;
        private System.Windows.Forms.Button bt_act3;
        private System.Windows.Forms.Button bt_act1;
        private System.Windows.Forms.Button bt_act4;
        private System.Windows.Forms.Button bt_act5;
        private System.Windows.Forms.Panel pn_LeftPanel;
        private System.Windows.Forms.Panel pn_ButtonPanel;
        private System.Windows.Forms.Panel pn_PicturePanel;
        private System.Windows.Forms.Button bt_N9;
        private System.Windows.Forms.Button bt_N3;
        private System.Windows.Forms.Button bt_N2;
        private System.Windows.Forms.Button bt_N8;
        private System.Windows.Forms.Button bt_N7;
        private System.Windows.Forms.Button bt_N6;
        private System.Windows.Forms.Button bt_N1;
        private System.Windows.Forms.Button bt_S10;
        private System.Windows.Forms.Button bt_N4;
        private System.Windows.Forms.Button bt_N5;
        private System.Windows.Forms.Button bt_S9;
        private System.Windows.Forms.Button bt_S8;
        private System.Windows.Forms.Button bt_S7;
        private System.Windows.Forms.Button bt_S6;
        private System.Windows.Forms.Button bt_S5;
        private System.Windows.Forms.Button bt_S4;
        private System.Windows.Forms.Button bt_S3;
        private System.Windows.Forms.Button bt_S2;
        private System.Windows.Forms.Button bt_S1;
        private System.Windows.Forms.GroupBox gb_Controls;
        private System.Windows.Forms.Button bt_Options;
        private System.Windows.Forms.Label lb_Tempo;
        private System.Windows.Forms.Label lb_CommandName;
        private System.Windows.Forms.Label lb_SongName;
        private SongListControl songListControl;
        private System.Windows.Forms.TabControl tab_Control;
        private System.Windows.Forms.TabPage tab_SongList;
        private System.Windows.Forms.TabPage tab_TrackList;
        private System.Windows.Forms.TabPage tab_FastPresets;
        private SongListControl trackListControl;
        private FastListControl fastListControl;
    }
}

