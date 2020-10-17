using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using alifeDB.Database;

namespace GUI
{
    public partial class Form1 : Form
    {
        private string fileName;
        private string filePath;
        private Database db;

        public Form1()
        {
            InitializeComponent();
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

            db = SaveSystem.LoadDB(filePath);

            List<Table> tables = db.GetTables();

            // Hali hazırda bulunan bütün sekmeleri siler
            foreach (TabPage tabPage in databaseTablesTabControl.TabPages)
            {
                databaseTablesTabControl.TabPages.Remove(tabPage);
            }

            // Okunan veritabanına göre sekmeleri ekler
            foreach (Table t in tables)
                databaseTablesTabControl.TabPages.Add(t.GetName());
        }
    }
}
