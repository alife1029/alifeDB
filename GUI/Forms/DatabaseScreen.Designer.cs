
namespace GUI.Forms
{
    partial class DatabaseScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new GUI.Components.AlifeDbButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDbName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.alifeDbButton1 = new GUI.Components.AlifeDbButton();
            this.alifeDbButton2 = new GUI.Components.AlifeDbButton();
            this.alifeDbButton3 = new GUI.Components.AlifeDbButton();
            this.lblTableName = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.alifeDbButton4 = new GUI.Components.AlifeDbButton();
            this.goToMainMenuButton = new GUI.Components.AlifeDbButton();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.lblHint = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblDbName);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(379, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 78);
            this.panel2.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSave.ButtonImage = global::GUI.Properties.Resources.diskette;
            this.btnSave.ButtonText = "Kaydet";
            this.btnSave.Location = new System.Drawing.Point(592, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label4.Location = new System.Drawing.Point(77, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "(.alfdb)";
            // 
            // lblDbName
            // 
            this.lblDbName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblDbName.Location = new System.Drawing.Point(77, 7);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(569, 31);
            this.lblDbName.TabIndex = 1;
            this.lblDbName.Text = "Database Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = global::GUI.Properties.Resources.database;
            this.pictureBox1.Location = new System.Drawing.Point(7, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableListPanel
            // 
            this.tableListPanel.AutoScroll = true;
            this.tableListPanel.Location = new System.Drawing.Point(12, 104);
            this.tableListPanel.Name = "tableListPanel";
            this.tableListPanel.Size = new System.Drawing.Size(356, 492);
            this.tableListPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label2.Location = new System.Drawing.Point(136, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tablolar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.alifeDbButton1);
            this.flowLayoutPanel1.Controls.Add(this.alifeDbButton2);
            this.flowLayoutPanel1.Controls.Add(this.alifeDbButton3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(379, 95);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(379, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // alifeDbButton1
            // 
            this.alifeDbButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.alifeDbButton1.ButtonImage = global::GUI.Properties.Resources.plus;
            this.alifeDbButton1.ButtonText = "Sütun Ekle";
            this.alifeDbButton1.Location = new System.Drawing.Point(0, 0);
            this.alifeDbButton1.Margin = new System.Windows.Forms.Padding(0);
            this.alifeDbButton1.Name = "alifeDbButton1";
            this.alifeDbButton1.Size = new System.Drawing.Size(115, 32);
            this.alifeDbButton1.TabIndex = 0;
            // 
            // alifeDbButton2
            // 
            this.alifeDbButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.alifeDbButton2.ButtonImage = global::GUI.Properties.Resources.clear;
            this.alifeDbButton2.ButtonText = "Sütun Sil";
            this.alifeDbButton2.Location = new System.Drawing.Point(131, 0);
            this.alifeDbButton2.Margin = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.alifeDbButton2.Name = "alifeDbButton2";
            this.alifeDbButton2.Size = new System.Drawing.Size(115, 32);
            this.alifeDbButton2.TabIndex = 1;
            // 
            // alifeDbButton3
            // 
            this.alifeDbButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.alifeDbButton3.ButtonImage = global::GUI.Properties.Resources.clear;
            this.alifeDbButton3.ButtonText = "Kaydı Sil";
            this.alifeDbButton3.Location = new System.Drawing.Point(262, 0);
            this.alifeDbButton3.Margin = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.alifeDbButton3.Name = "alifeDbButton3";
            this.alifeDbButton3.Size = new System.Drawing.Size(115, 32);
            this.alifeDbButton3.TabIndex = 2;
            // 
            // lblTableName
            // 
            this.lblTableName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTableName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblTableName.Location = new System.Drawing.Point(764, 99);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(305, 31);
            this.lblTableName.TabIndex = 5;
            this.lblTableName.Text = "Kayıtlar";
            this.lblTableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.alifeDbButton4);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 66);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(356, 32);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // alifeDbButton4
            // 
            this.alifeDbButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.alifeDbButton4.ButtonImage = global::GUI.Properties.Resources.plus;
            this.alifeDbButton4.ButtonText = "Yeni Tablo Ekle";
            this.alifeDbButton4.Location = new System.Drawing.Point(0, 0);
            this.alifeDbButton4.Margin = new System.Windows.Forms.Padding(0);
            this.alifeDbButton4.Name = "alifeDbButton4";
            this.alifeDbButton4.Size = new System.Drawing.Size(136, 32);
            this.alifeDbButton4.TabIndex = 7;
            // 
            // goToMainMenuButton
            // 
            this.goToMainMenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.goToMainMenuButton.ButtonImage = global::GUI.Properties.Resources.exit;
            this.goToMainMenuButton.ButtonText = "Ana Menü";
            this.goToMainMenuButton.Location = new System.Drawing.Point(13, 13);
            this.goToMainMenuButton.Name = "goToMainMenuButton";
            this.goToMainMenuButton.Size = new System.Drawing.Size(116, 32);
            this.goToMainMenuButton.TabIndex = 7;
            // 
            // dgvRecords
            // 
            this.dgvRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRecords.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecords.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvRecords.EnableHeadersVisualStyles = false;
            this.dgvRecords.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.dgvRecords.Location = new System.Drawing.Point(379, 134);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRecords.RowHeadersWidth = 40;
            this.dgvRecords.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(3);
            this.dgvRecords.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRecords.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvRecords.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvRecords.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgvRecords.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(185)))));
            this.dgvRecords.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.dgvRecords.RowTemplate.Height = 30;
            this.dgvRecords.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecords.Size = new System.Drawing.Size(690, 462);
            this.dgvRecords.TabIndex = 8;
            this.dgvRecords.Visible = false;
            // 
            // lblHint
            // 
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.lblHint.Location = new System.Drawing.Point(379, 93);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(690, 521);
            this.lblHint.TabIndex = 11;
            this.lblHint.Text = "Yeni bir tablo oluşturun veya soldaki tablo listesinden tıklayarak bir tablo açın" +
    ".";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DatabaseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.goToMainMenuButton);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableListPanel);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DatabaseScreen";
            this.Text = "AlifeDB Veritabanı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseScreen_Dispose);
            this.Load += new System.EventHandler(this.DatabaseScreen_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel tableListPanel;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Components.AlifeDbButton alifeDbButton4;
        private Components.AlifeDbButton btnSave;
        private Components.AlifeDbButton goToMainMenuButton;
        private System.Windows.Forms.DataGridView dgvRecords;
        private Components.AlifeDbButton alifeDbButton1;
        private Components.AlifeDbButton alifeDbButton2;
        private Components.AlifeDbButton alifeDbButton3;
        private System.Windows.Forms.Label lblHint;
    }
}