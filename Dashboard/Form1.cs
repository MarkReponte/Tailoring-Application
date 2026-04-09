using ReaLTaiizor.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using MyResources = Dashboard.Properties.Resources;
using ReaLTaiizor.Controls;

namespace Dashboard
{
    public partial class dashboardPanel : MaterialForm
    {

        public dashboardPanel()
        {
            InitializeComponent();



        }

        public void NotificationPanel()
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

        private void dashboardPanel_Load(object sender, EventArgs e)
        {
            cboSearch.Text = "Search...";
            cboSearch.ForeColor = Color.FromArgb(150, 150, 150);
            this.ActiveControl = null;
        }

        private void btnCloseNotification_Click(object sender, EventArgs e)
        {
            pnlNotification.Visible = false;
        }

        private void cboSearch_Enter(Object sender, EventArgs e)
        {
            cboSearch.Select(0, 0);

            if (cboSearch.Text == "Search...")
            {
                cboSearch.Text = "";
                cboSearch.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void cboSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboSearch.Text != "Search..." && cboSearch.Text != "")
            {
                cboSearch.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void cboSearch_Leave(Object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSearch.Text))
            {
                cboSearch.Text = "Search...";
                cboSearch.ForeColor = Color.FromArgb(150, 150, 150);
            }
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {

            NotificationPanel();

        }

        private void btnNotificationOrder_Click(object sender, EventArgs e)
        {
            NotificationPanel();
        }
        private void btnNotificationCostConsumption_Click(object sender, EventArgs e)
        {
            NotificationPanel();
        }

        private void btnNotificationRevenue_Click(object sender, EventArgs e)
        {
            NotificationPanel();
        }

    }
}
