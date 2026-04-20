using ReaLTaiizor.Forms;
using ReaLTaiizor.Colors;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
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

            var materialSkinManager = ReaLTaiizor.Manager.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = ReaLTaiizor.Manager.MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ReaLTaiizor.Colors.MaterialColorScheme(
               primary: System.Drawing.Color.FromArgb(141, 182, 0),
               darkPrimary: System.Drawing.Color.FromArgb(110, 145, 0),
               lightPrimary: System.Drawing.Color.FromArgb(180, 215, 60),
               accent: System.Drawing.Color.FromArgb(255, 204, 0),
               textShade: ReaLTaiizor.Util.MaterialTextShade.WHITE
            );


        }

        private void UpdateGrandTotal()
        {
            double materialSum = 0;

            foreach (DataGridViewRow row in dgvMaterialList.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    materialSum += Convert.ToDouble(row.Cells[3].Value);
                }
            }
            txtMaterialTotal.Text = materialSum.ToString("N2");

            double labor = 0;
            double.TryParse(txtLaborCost.Text, out labor);
            double quantity = 0;
            double.TryParse(txtQuantity.Text, out quantity);

            double totalLabor = labor * quantity;
            txtTotalLabor.Text = totalLabor.ToString("N2");

            double grandTotal = materialSum + totalLabor;
            lblGrandTotalCost.Text = "₱ " + grandTotal.ToString("N2");

        }
        private int targetHeight = 400;

        public void NotificationPanel()
        {
            if (!pnlNotification.Visible)
            {
                int x = this.ClientSize.Width - pnlNotification.Width - 10;
                int y = 60;
                pnlNotification.Location = new Point(x, y);
                pnlNotification.Size = new Size(300, 0);

                pnlNotification.Visible = true;
                pnlNotification.BringToFront();

                animationTimer.Start();
            }
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (pnlNotification.Height < 410)
            {
                pnlNotification.Height += 50;
            }
            else
            {
                pnlNotification.Height = targetHeight;
                animationTimer.Stop();
            }
        }

        private void dashboardPanel_Load(object sender, EventArgs e)
        {
            hcbSearch.Text = "Search...";
            hcbSearch.ForeColor = Color.FromArgb(150, 150, 150);
            this.ActiveControl = null;


        }

        private void btnCloseNotification_Click(object sender, EventArgs e)
        {
            pnlNotification.Visible = false;
        }

        private void cboSearch_Enter(Object sender, EventArgs e)
        {
            hcbSearch.Select(0, 0);

            if (hcbSearch.Text == "Search...")
            {
                hcbSearch.Text = "";
                hcbSearch.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void cboSearch_TextChanged(object sender, EventArgs e)
        {
            if (hcbSearch.Text != "Search..." && hcbSearch.Text != "")
            {
                hcbSearch.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void cboSearch_Leave(Object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hcbSearch.Text))
            {
                hcbSearch.Text = "Search...";
                hcbSearch.ForeColor = Color.FromArgb(150, 150, 150);
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

        private void btnNotificationBodyMeasurement_Click(object sender, EventArgs e)
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

        private void flwpnlOrderList_MouseEnter(object sender, EventArgs e)
        {
            flwpnlOrderList.Focus();
        }

        private void btnCostAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItem.Text) || string.IsNullOrWhiteSpace(txtMetersNeed.Text))
            {
                MessageBox.Show("Please enter the Item and Meters");
                return;
            }

            try
            {
                double m = Convert.ToDouble(txtMetersNeed.Text);
                double p = Convert.ToDouble(txtPrice.Text);
                double rowTotal = m * p;

                dgvMaterialList.Rows.Add(txtItem.Text, m, p, rowTotal);

                txtItem.Clear();
                txtMetersNeed.Clear();
                txtPrice.Clear();
                txtItem.Focus();

                UpdateGrandTotal();
            }
            catch { MessageBox.Show("Please enter valid number"); }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdateGrandTotal();
        }

        private void txtLaborCost_TextChanged(object sender, EventArgs e)
        {
            UpdateGrandTotal();
        }

        private void btnCostClear_Click(object sender, EventArgs e)
        {
            txtItem.Clear();
            txtMetersNeed.Clear();
            txtPrice.Clear();

            dgvMaterialList.Rows.Clear();

            txtMaterialTotal.Clear();
            txtLaborCost.Clear();
            txtQuantity.Clear();
            txtTotalLabor.Clear();

            lblGrandTotalCost.Text = "₱ 0.00";

            txtItem.Focus();
        }


    
    }
}
