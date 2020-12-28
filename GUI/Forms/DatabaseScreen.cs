using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Components;
using alifeDB.Database;
using alifeDB.Database.Core;

namespace GUI.Forms
{
    public partial class DatabaseScreen : Form
    {
        private StartupScreen startupScreen;
        private DatabaseCursor database;
        private readonly string dbPath;


        public DatabaseScreen()
        {
            database = new DatabaseCursor();
            InitializeComponent();
        }
        public DatabaseScreen(StartupScreen startupScreen, string dbPath)
        {
            this.startupScreen = startupScreen;
            this.dbPath = dbPath;
            database = new DatabaseCursor();
            InitializeComponent();
        }

        private void DatabaseScreen_Load(object sender, EventArgs e)
        {
            database.Connect(dbPath);



            // Veritabanı adını bulmak için yapılan işlemler            
            string dbName;
            // Son backslash olan karakterin indeksini alır
            int lastBackSlashIndex = 0;
            for (int i = 0; i < dbPath.Length; i++)
            {
                if (dbPath[i] == '\\' || dbPath[i] == '/')
                    lastBackSlashIndex = i + 1;
            }
            // Veritabanı adını bulur
            dbName = dbPath.Substring(lastBackSlashIndex, dbPath.Length - lastBackSlashIndex)
                            .Replace(".alfdb", null);
            lblDbName.Text = dbName;




            // Tüm tabloları dolaşır
            foreach (Table t in database.GetTables())
            {
                TableListElement newElement = new TableListElement();
                newElement.Text = t.Name;
                newElement.Margin = new Padding(0, 0, 0, 6);
                newElement.AddOnClickEvent(TableListElement_Click);

                tableListPanel.Controls.Add(newElement);
            }

            // Butonlara Eventleri Atar
            goToMainMenuButton.AddOnClickEvent(GoToMainMenu);
            btnSave.AddOnClickEvent(SaveDB);
        }

        private void TableListElement_Click(object sender, EventArgs e)
        {
            string text = null;

            try {
                text = ((TableListElement)sender).Text;
            } catch (Exception) {
                try {
                    text = ((Label)sender).Parent.Text;
                } catch (Exception) {
                    try {
                        text = ((PictureBox)sender).Parent.Text;
                    } catch (Exception) {
                        throw;
                    }
                }
            }

            // Ekranda DataGridView yerine çıkan öneri yazısını kaldırıp DataGridView'ı Görünür Yapar
            if (lblHint.Visible)
            {
                lblHint.Visible = false;
                dgvRecords.Visible = true;
            }

            // DatabaseCursor'da tıklanan tabloya gider
            database.GoToTable(text);
            // Tablo adının gösterildiği label'a tablonun adını yazar
            lblTableName.Text = text;

            // DataGridView'ı ayarlar
            InitDataGridView(text);
            GC.Collect();
        }
        private void InitDataGridView(string tableName)
        {
            // DataGridView'ı sıfırlar
            dgvRecords.ColumnCount = 1;
            dgvRecords.Columns[0].Name = null;
            dgvRecords.RowCount = 1;
            for (int counter = 0; counter < dgvRecords.Rows[0].Cells.Count; counter++)
                dgvRecords.Rows[0].Cells[counter].Value = null;

            // Tabloyu yükler
            Table table = database.GetTable(tableName);

            // Tablonun sütunlarını DataGridView'a ekler
            dgvRecords.ColumnCount = table.ColumnCount;
            for (int index = 0; index < table.ColumnCount; index++)
                dgvRecords.Columns[index].Name = table.ColumnNames[index];


            // Tablodaki kayıtları DataGridView'a ekler
            // Eğer kayıtlı herhangi bir şey yoksa metodu burada bitirir
            if (table.RecordCount == 0)
                return;

            // Tablodaki satır sayısını ayarlar
            dgvRecords.RowCount = table.RecordCount;
            // Tüm kayıtları dolaşır
            int i = 0;
            foreach (object[] record in table.TableRecords)
            {
                int j = 0;
                foreach (object cell in record)
                {
                    dgvRecords.Rows[i].Cells[j].Value = cell.ToString();
                    ++j;
                }
                ++i;
            }
            dgvRecords.Rows.Add(new DataGridViewRow());
        }

        private void DatabaseScreen_Dispose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveDB(object sender, EventArgs e)
        {
            database.Commit();
        }
        private void GoToMainMenu(object sender, EventArgs e)
        {
            // Bu sayfayı gizleyip başlangıç sayfasını gösterir
            Hide();
            startupScreen.Show();

            // RAM'i gereksiz verilerden temizler
            startupScreen = null;
            database = null;
            Dispose();
            GC.Collect();
        }
    }
}
