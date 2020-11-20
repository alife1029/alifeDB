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

        private void StartupScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_OpenDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
                tbDbPath_OpenDb.Text = fileDialog.FileName;

            fileDialog.Dispose();
        }

        private void btnBrowse_CreateDb_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                tbDbPath_CreateDb.Text = folderBrowserDialog.SelectedPath;

            folderBrowserDialog.Dispose();
        }
    }
}
