
namespace GUI.Components
{
    partial class AlifeDbButton
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.buttonIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.buttonIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.lblName.Location = new System.Drawing.Point(35, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(164, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlifeDbButton_MouseDown);
            this.lblName.MouseEnter += new System.EventHandler(this.AlifeDbButton_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.AlifeDbButton_MouseLeave);
            this.lblName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AlifeDbButton_MouseUp);
            // 
            // buttonIcon
            // 
            this.buttonIcon.Location = new System.Drawing.Point(3, 3);
            this.buttonIcon.Name = "buttonIcon";
            this.buttonIcon.Size = new System.Drawing.Size(26, 26);
            this.buttonIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonIcon.TabIndex = 0;
            this.buttonIcon.TabStop = false;
            this.buttonIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlifeDbButton_MouseDown);
            this.buttonIcon.MouseEnter += new System.EventHandler(this.AlifeDbButton_MouseEnter);
            this.buttonIcon.MouseLeave += new System.EventHandler(this.AlifeDbButton_MouseLeave);
            this.buttonIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AlifeDbButton_MouseUp);
            // 
            // AlifeDbButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.buttonIcon);
            this.Name = "AlifeDbButton";
            this.Size = new System.Drawing.Size(202, 32);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlifeDbButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.AlifeDbButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.AlifeDbButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AlifeDbButton_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.buttonIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox buttonIcon;
        private System.Windows.Forms.Label lblName;
    }
}
