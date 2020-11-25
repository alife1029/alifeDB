using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Components
{
    public partial class TableListElement : UserControl
    {
        private bool mouseEntered;

        public override string Text { get => base.Text; set { base.Text = value; lblName.Text = value; } }

        public TableListElement()
        {
            InitializeComponent();
        }

        private void TableListElement_Load(object sender, EventArgs e)
        {
            lblName.Text = Text;
        }

        private void TableListElement_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(100, 100, 100);
            lblName.BackColor = Color.FromArgb(100, 100, 100);
            pbTable.BackColor = Color.FromArgb(100, 100, 100);
            
            mouseEntered = true;
        }

        private void TableListElement_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(70, 70, 70);
            lblName.BackColor = Color.FromArgb(70, 70, 70);
            pbTable.BackColor = Color.FromArgb(70, 70, 70);

            mouseEntered = false;
        }

        private void TableListElement_MouseDown(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(50, 50, 50);
            lblName.BackColor = Color.FromArgb(50, 50, 50);
            pbTable.BackColor = Color.FromArgb(50, 50, 50);
        }

        private void TableListElement_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mouseEntered)
            {
                BackColor = Color.FromArgb(70, 70, 70);
                lblName.BackColor = Color.FromArgb(70, 70, 70);
                pbTable.BackColor = Color.FromArgb(70, 70, 70);
            }
            else
            {
                BackColor = Color.FromArgb(100, 100, 100);
                lblName.BackColor = Color.FromArgb(100, 100, 100);
                pbTable.BackColor = Color.FromArgb(100, 100, 100);
            }
        }

        public void AddOnClickEvent(EventHandler e)
        {
            Click += e;
            pbTable.Click += e;
            lblName.Click += e;
        }
    }
}
