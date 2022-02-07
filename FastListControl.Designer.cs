
namespace SynthLiveMidiController
{
    partial class FastListControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_FastListView = new System.Windows.Forms.DataGridView();
            this.cl1_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl2_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl5_Tempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FastListView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_FastListView
            // 
            this.dgv_FastListView.AllowUserToAddRows = false;
            this.dgv_FastListView.AllowUserToDeleteRows = false;
            this.dgv_FastListView.AllowUserToResizeColumns = false;
            this.dgv_FastListView.AllowUserToResizeRows = false;
            this.dgv_FastListView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_FastListView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_FastListView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FastListView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_FastListView.ColumnHeadersHeight = 24;
            this.dgv_FastListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_FastListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl1_Num,
            this.cl2_Name,
            this.cl5_Tempo});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_FastListView.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_FastListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_FastListView.EnableHeadersVisualStyles = false;
            this.dgv_FastListView.Location = new System.Drawing.Point(0, 0);
            this.dgv_FastListView.MultiSelect = false;
            this.dgv_FastListView.Name = "dgv_FastListView";
            this.dgv_FastListView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FastListView.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_FastListView.RowHeadersVisible = false;
            this.dgv_FastListView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_FastListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_FastListView.Size = new System.Drawing.Size(516, 706);
            this.dgv_FastListView.TabIndex = 3;
            // 
            // cl1_Num
            // 
            this.cl1_Num.DefaultCellStyle = dataGridViewCellStyle8;
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
            this.cl2_Name.DefaultCellStyle = dataGridViewCellStyle9;
            this.cl2_Name.FillWeight = 300F;
            this.cl2_Name.HeaderText = "Название пресета";
            this.cl2_Name.MinimumWidth = 6;
            this.cl2_Name.Name = "cl2_Name";
            this.cl2_Name.ReadOnly = true;
            this.cl2_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cl5_Tempo
            // 
            this.cl5_Tempo.DefaultCellStyle = dataGridViewCellStyle10;
            this.cl5_Tempo.FillWeight = 118.842F;
            this.cl5_Tempo.HeaderText = "Клавиша";
            this.cl5_Tempo.MinimumWidth = 6;
            this.cl5_Tempo.Name = "cl5_Tempo";
            this.cl5_Tempo.ReadOnly = true;
            this.cl5_Tempo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cl5_Tempo.Width = 80;
            // 
            // FastListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_FastListView);
            this.Name = "FastListControl";
            this.Size = new System.Drawing.Size(516, 706);
            this.BackColorChanged += new System.EventHandler(this.FastListControl_BackColorChanged);
            this.ForeColorChanged += new System.EventHandler(this.FastListControl_ForeColorChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FastListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_FastListView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl1_Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl2_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl5_Tempo;
    }
}
