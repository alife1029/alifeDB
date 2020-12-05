
namespace GUI.Forms
{
    partial class StartupScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnBrowse_OpenDb = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDbPath_OpenDb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDbPath_CreateDb = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnBrowse_CreateDb = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(2, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bir AlfDB Veritabanını Aç";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.btnBrowse_OpenDb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDbPath_OpenDb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-10, -37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 617);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOpen.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnOpen.Location = new System.Drawing.Point(151, 502);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(159, 38);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Aç";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnBrowse_OpenDb
            // 
            this.btnBrowse_OpenDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnBrowse_OpenDb.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnBrowse_OpenDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse_OpenDb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBrowse_OpenDb.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnBrowse_OpenDb.Location = new System.Drawing.Point(151, 222);
            this.btnBrowse_OpenDb.Name = "btnBrowse_OpenDb";
            this.btnBrowse_OpenDb.Size = new System.Drawing.Size(159, 38);
            this.btnBrowse_OpenDb.TabIndex = 3;
            this.btnBrowse_OpenDb.Text = "Göz At";
            this.btnBrowse_OpenDb.UseVisualStyleBackColor = false;
            this.btnBrowse_OpenDb.Click += new System.EventHandler(this.btnBrowse_OpenDb_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.Menu;
            this.label3.Location = new System.Drawing.Point(31, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Veritabanının Konumu:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbDbPath_OpenDb
            // 
            this.tbDbPath_OpenDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbDbPath_OpenDb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDbPath_OpenDb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbDbPath_OpenDb.ForeColor = System.Drawing.SystemColors.Info;
            this.tbDbPath_OpenDb.Location = new System.Drawing.Point(35, 174);
            this.tbDbPath_OpenDb.Name = "tbDbPath_OpenDb";
            this.tbDbPath_OpenDb.Size = new System.Drawing.Size(394, 27);
            this.tbDbPath_OpenDb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.Menu;
            this.label2.Location = new System.Drawing.Point(467, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "Yeni Bir AlfDB Veritabanı Oluştur";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.Menu;
            this.label4.Location = new System.Drawing.Point(470, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Veritabanının Adı:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbDbName
            // 
            this.tbDbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbDbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDbName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbDbName.ForeColor = System.Drawing.SystemColors.Info;
            this.tbDbName.Location = new System.Drawing.Point(474, 137);
            this.tbDbName.Name = "tbDbName";
            this.tbDbName.Size = new System.Drawing.Size(423, 27);
            this.tbDbName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.Menu;
            this.label5.Location = new System.Drawing.Point(470, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Veritabanının Bulunduğu Klasör:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbDbPath_CreateDb
            // 
            this.tbDbPath_CreateDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tbDbPath_CreateDb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDbPath_CreateDb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbDbPath_CreateDb.ForeColor = System.Drawing.SystemColors.Info;
            this.tbDbPath_CreateDb.Location = new System.Drawing.Point(474, 221);
            this.tbDbPath_CreateDb.Name = "tbDbPath_CreateDb";
            this.tbDbPath_CreateDb.Size = new System.Drawing.Size(423, 27);
            this.tbDbPath_CreateDb.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCreate.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnCreate.Location = new System.Drawing.Point(612, 465);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(159, 38);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Oluştur";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnBrowse_CreateDb
            // 
            this.btnBrowse_CreateDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnBrowse_CreateDb.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnBrowse_CreateDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse_CreateDb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBrowse_CreateDb.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnBrowse_CreateDb.Location = new System.Drawing.Point(609, 268);
            this.btnBrowse_CreateDb.Name = "btnBrowse_CreateDb";
            this.btnBrowse_CreateDb.Size = new System.Drawing.Size(159, 38);
            this.btnBrowse_CreateDb.TabIndex = 8;
            this.btnBrowse_CreateDb.Text = "Göz At";
            this.btnBrowse_CreateDb.UseVisualStyleBackColor = false;
            this.btnBrowse_CreateDb.Click += new System.EventHandler(this.btnBrowse_CreateDb_Click);
            // 
            // StartupScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(929, 566);
            this.Controls.Add(this.btnBrowse_CreateDb);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDbPath_CreateDb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "StartupScreen";
            this.Text = "AlifeDB Veritabanı";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDbPath_OpenDb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse_OpenDb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDbName;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDbPath_CreateDb;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBrowse_CreateDb;
    }
}