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
        private readonly DatabaseCursor database;
        private readonly StartupScreen startupScreen;
        private string dbPath;
        private string dbName;


        public DatabaseScreen()
        {
            database = new DatabaseCursor();
            InitializeComponent();
        }
        public DatabaseScreen(StartupScreen startupScreen, string dbPath, string dbName)
        {
            this.startupScreen = startupScreen;
            this.dbPath = dbPath;
            this.dbName = dbName;
            database = new DatabaseCursor();
            InitializeComponent();
        }

        private void DatabaseScreen_Load(object sender, EventArgs e)
        {
            database.Connect(dbPath, dbName);

            // Tüm tabloları dolaşır
            foreach (Table t in database.GetTables())
            {
                TableListElement newElement = new TableListElement();
                newElement.Text = t.GetName();

                tableListPanel.Controls.Add(newElement);
            }
        }
        private void DatabaseScreen_Dispose(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
