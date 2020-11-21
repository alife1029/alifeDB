using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class StartupScreen : Form
    {
        public StartupScreen()
        {
            InitializeComponent();
        }

        private void LoadDatabaseScreen(string dbPath, string dbName)
        {
            DatabaseScreen databaseScreen = new DatabaseScreen(this, dbPath, dbName);
            this.Hide();
            databaseScreen.Show();
        }

        private void btnBrowse_OpenDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
                LoadDatabaseScreen(fileDialog.FileName, fileDialog.SafeFileName);
        }

        private void btnBrowse_CreateDb_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                tbDbPath_CreateDb.Text = folderBrowserDialog.SelectedPath;

            folderBrowserDialog.Dispose();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string dbPath;
            string dbName;

            dbPath = tbDbPath_OpenDb.Text;

            // Veritabanı adını bulmak için yapılan işlemler
            // Son backslash olan karakterin indeksini alır
            int lastBackSlashIndex = 0;
            for(int i = 0; i < dbPath.Length; i++)
            {
                if (dbPath[i] == '\\' ||dbPath[i] == '/')
                    lastBackSlashIndex = i + 1;
            }
            // Veritabanı adını bulur
            dbName = dbPath.Substring(lastBackSlashIndex, dbPath.Length - lastBackSlashIndex)
                            .Replace(".alfdb", null);

            LoadDatabaseScreen(dbPath, dbName);
        }
    }
}
