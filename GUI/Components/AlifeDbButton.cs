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
    public partial class AlifeDbButton : UserControl
    {
        private bool mouseEntered;
        
        private Image buttonImage;
        public Image ButtonImage
        {
            get { return buttonImage; }
            set { buttonImage = value; buttonIcon.Image = buttonImage; }
        }

        private string buttonText;
        public string ButtonText
        {
            get { return buttonText; }
            set { buttonText = value; lblName.Text = buttonText; }
        }


        public AlifeDbButton()
        {
            InitializeComponent();
            lblName.Text = Text;
            buttonIcon.Image = buttonImage;
            mouseEntered = false;
        }

        private void AlifeDbButton_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(90, 90, 90);
            lblName.BackColor = Color.FromArgb(90, 90, 90);
            buttonIcon.BackColor = Color.FromArgb(90, 90, 90);

            mouseEntered = true;
        }

        private void AlifeDbButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(110, 110, 110);
            lblName.BackColor = Color.FromArgb(110, 110, 110);
            buttonIcon.BackColor = Color.FromArgb(110, 110, 110);
        }

        private void AlifeDbButton_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(60, 60, 60);
            lblName.BackColor = Color.FromArgb(60, 60, 60);
            buttonIcon.BackColor = Color.FromArgb(60, 60, 60);

            mouseEntered = false;
        }

        private void AlifeDbButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mouseEntered)
            {
                BackColor = Color.FromArgb(60, 60, 60);
                lblName.BackColor = Color.FromArgb(60, 60, 60);
                buttonIcon.BackColor = Color.FromArgb(60, 60, 60);
            }
            else
            {
                BackColor = Color.FromArgb(90, 90, 90);
                lblName.BackColor = Color.FromArgb(90, 90, 90);
                buttonIcon.BackColor = Color.FromArgb(90, 90, 90);
            }
        }

        public void AddOnClickEvent(EventHandler e)
        {
            Click += e;
            lblName.Click += e;
            buttonIcon.Click += e;
        }
    }
}
