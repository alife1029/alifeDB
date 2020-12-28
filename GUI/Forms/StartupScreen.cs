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

        private void LoadDatabaseScreen(string dbPath)
        {
            DatabaseScreen databaseScreen = new DatabaseScreen(this, dbPath);
            Hide();
            databaseScreen.Show();
        }

        private void btnBrowse_OpenDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
                LoadDatabaseScreen(fileDialog.FileName);
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
            LoadDatabaseScreen(tbDbPath_OpenDb.Text);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try {
                if (tbDbName.Text.Substring(tbDbName.Text.Length - 6) != ".alfdb")
                    tbDbName.Text += ".alfdb";
            }

            // Hata alındıysa, veritabanı adı kısmına girilen isim 6 karakterden kısadır
            // Haliyle veritabanı adının sonunda .alfdb yoktur
            catch (Exception) { 
                tbDbName.Text += ".alfdb"; 
            }

            if (tbDbPath_CreateDb.Text[tbDbPath_CreateDb.Text.Length - 1] != '\\')
                LoadDatabaseScreen(tbDbPath_CreateDb.Text + "\\" + tbDbName.Text);
            else
                LoadDatabaseScreen(tbDbPath_CreateDb.Text + tbDbName.Text);
        }
    }
}
