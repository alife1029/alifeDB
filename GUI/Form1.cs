using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using alifeDB.Database;
using alifeDB.Database.Core;

namespace GUI
{
    public partial class Form1 : Form
    {
        private string fileName;
        private string filePath;
        private readonly DatabaseCursor db;

        public Form1()
        {
            InitializeComponent();
            db = new DatabaseCursor();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "alfDB Veritabanı Dosyası | *alfdb";
            fileDialog.Title = "Bir alfDB Veritabanı Dosyası Seçiniz";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                fileName = fileDialog.SafeFileName;

                tbDatabasePath.Text = filePath;
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            db.Connect(filePath, fileName);

            List<Table> tables = db.GetTables();

            // Hali hazırda bulunan bütün sekmeleri siler
            foreach (TabPage tabPage in databaseTablesTabControl.TabPages)
            {
                databaseTablesTabControl.TabPages.Remove(tabPage);
            }

            // Okunan veritabanına göre sekmeleri ekler
            foreach (Table t in tables)
                databaseTablesTabControl.TabPages.Add(t.GetName());

            // Sekmeye kayıtları ekler
            CreateDataGrid(databaseTablesTabControl.TabPages[0]);
        }

        private void CreateDataGrid(Control parent)
        {
            DataGridView dataGridView = new DataGridView
            {
                Parent = databaseTablesTabControl.TabPages[0],
                Location = new Point(0, 0),
                Height = parent.Height,
                Width = parent.Width
            };

            Table currentTable = db.GetTable(parent.Text);

            /*for (int i = 0; i < 1; i++)
            {
                Record currentRecord = currentTable.GetRecord(Convert.ToUInt64(i));
                object[] currentDatas = new object[6];

                for (int j = 0; j < 6; j++)
                {
                    
                }

                dataGridView.Rows.Add();
            }*/
        }
    }
}
