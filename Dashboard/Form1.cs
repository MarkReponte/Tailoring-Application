using ReaLTaiizor.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using MyResources = Dashboard.Properties.Resources;

namespace Dashboard
{
    public partial class dashboardPanel : MaterialForm
    {

        public dashboardPanel()
        {
            InitializeComponent();



        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            
            pnlNotification.Visible = !pnlNotification.Visible;

            if (pnlNotification.Visible)
            {
                pnlNotification.Size = new Size(300, 400);
                pnlNotification.BringToFront();


                int x = this.ClientSize.Width - pnlNotification.Width - 10;
                int y = 60;

                pnlNotification.Location = new Point(x, y);
            }
        }

        private void btnCloseNotification_Click(object sender, EventArgs e)
        {
            pnlNotification.Visible = false;
        }

        private void materialCard3_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
