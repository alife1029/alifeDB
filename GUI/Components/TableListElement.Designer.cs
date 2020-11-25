
namespace GUI.Components
{
    partial class TableListElement
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
            this.pbTable = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTable)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lblName.Location = new System.Drawing.Point(68, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(252, 76);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "TableListElement1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TableListElement_MouseDown);
            this.lblName.MouseEnter += new System.EventHandler(this.TableListElement_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.TableListElement_MouseLeave);
            this.lblName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TableListElement_MouseUp);
            // 
            // pbTable
            // 
            this.pbTable.Image = global::GUI.Properties.Resources.table;
            this.pbTable.Location = new System.Drawing.Point(14, 14);
            this.pbTable.Name = "pbTable";
            this.pbTable.Size = new System.Drawing.Size(48, 48);
            this.pbTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTable.TabIndex = 0;
            this.pbTable.TabStop = false;
            this.pbTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TableListElement_MouseDown);
            this.pbTable.MouseEnter += new System.EventHandler(this.TableListElement_MouseEnter);
            this.pbTable.MouseLeave += new System.EventHandler(this.TableListElement_MouseLeave);
            this.pbTable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TableListElement_MouseUp);
            // 
            // TableListElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbTable);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Name = "TableListElement";
            this.Size = new System.Drawing.Size(320, 76);
            this.Load += new System.EventHandler(this.TableListElement_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TableListElement_MouseDown);
            this.MouseEnter += new System.EventHandler(this.TableListElement_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TableListElement_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TableListElement_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTable;
        private System.Windows.Forms.Label lblName;
    }
}
