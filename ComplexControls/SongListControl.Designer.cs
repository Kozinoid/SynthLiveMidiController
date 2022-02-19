
namespace SynthLiveMidiController
{
    partial class SongListControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_SongListView = new System.Windows.Forms.DataGridView();
            this.cl1_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl2_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl3_Singer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl4_Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl5_Tempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SongListView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_SongListView
            // 
            this.dgv_SongListView.AllowUserToAddRows = false;
            this.dgv_SongListView.AllowUserToDeleteRows = false;
            this.dgv_SongListView.AllowUserToResizeColumns = false;
            this.dgv_SongListView.AllowUserToResizeRows = false;
            this.dgv_SongListView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_SongListView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_SongListView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SongListView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_SongListView.ColumnHeadersHeight = 24;
            this.dgv_SongListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_SongListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl1_Num,
            this.cl2_Name,
            this.cl3_Singer,
            this.cl4_Key,
            this.cl5_Tempo});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SongListView.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_SongListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SongListView.EnableHeadersVisualStyles = false;
            this.dgv_SongListView.Location = new System.Drawing.Point(0, 0);
            this.dgv_SongListView.MultiSelect = false;
            this.dgv_SongListView.Name = "dgv_SongListView";
            this.dgv_SongListView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SongListView.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_SongListView.RowHeadersVisible = false;
            this.dgv_SongListView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_SongListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SongListView.Size = new System.Drawing.Size(516, 706);
            this.dgv_SongListView.TabIndex = 2;
            // 
            // cl1_Num
            // 
            this.cl1_Num.DefaultCellStyle = dataGridViewCellStyle10;
            this.cl1_Num.FillWeight = 24.88151F;
            this.cl1_Num.HeaderText = "№";
            this.cl1_Num.MinimumWidth = 6;
            this.cl1_Num.Name = "cl1_Num";
            this.cl1_Num.ReadOnly = true;
            this.cl1_Num.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl1_Num.Width = 35;
            // 
            // cl2_Name
            // 
            this.cl2_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cl2_Name.DefaultCellStyle = dataGridViewCellStyle11;
            this.cl2_Name.FillWeight = 300F;
            this.cl2_Name.HeaderText = "Название";
            this.cl2_Name.MinimumWidth = 6;
            this.cl2_Name.Name = "cl2_Name";
            this.cl2_Name.ReadOnly = true;
            this.cl2_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cl3_Singer
            // 
            this.cl3_Singer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cl3_Singer.DefaultCellStyle = dataGridViewCellStyle12;
            this.cl3_Singer.FillWeight = 200F;
            this.cl3_Singer.HeaderText = "Исполнитель/Автор";
            this.cl3_Singer.MinimumWidth = 6;
            this.cl3_Singer.Name = "cl3_Singer";
            this.cl3_Singer.ReadOnly = true;
            this.cl3_Singer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cl4_Key
            // 
            this.cl4_Key.DefaultCellStyle = dataGridViewCellStyle13;
            this.cl4_Key.FillWeight = 83.54705F;
            this.cl4_Key.HeaderText = "Тон";
            this.cl4_Key.MinimumWidth = 6;
            this.cl4_Key.Name = "cl4_Key";
            this.cl4_Key.ReadOnly = true;
            this.cl4_Key.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl4_Key.Width = 40;
            // 
            // cl5_Tempo
            // 
            this.cl5_Tempo.DefaultCellStyle = dataGridViewCellStyle14;
            this.cl5_Tempo.FillWeight = 118.842F;
            this.cl5_Tempo.HeaderText = "Темп";
            this.cl5_Tempo.MinimumWidth = 6;
            this.cl5_Tempo.Name = "cl5_Tempo";
            this.cl5_Tempo.ReadOnly = true;
            this.cl5_Tempo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl5_Tempo.Width = 40;
            // 
            // SongListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_SongListView);
            this.Name = "SongListControl";
            this.Size = new System.Drawing.Size(516, 706);
            this.BackColorChanged += new System.EventHandler(this.SongListControl_BackColorChanged);
            this.ForeColorChanged += new System.EventHandler(this.SongListControl_ForeColorChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SongListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_SongListView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl1_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl2_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl3_Singer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl4_Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl5_Tempo;
    }
}
