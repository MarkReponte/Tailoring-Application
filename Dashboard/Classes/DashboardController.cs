using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dashboard.Classes
{
    public class DashboardController
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService ?? throw new ArgumentNullException(nameof(dashboardService));
        }

        public async Task RefreshDashboardViewAsync()
        {
            try
            {
              
                var mainForm = Application.OpenForms["Form1"] as Form1;
                if (mainForm == null) return;

                Control lblCustomers = mainForm.lblCustomers;
                Control lblMonthlyRevenue = mainForm.lblMonthlyRevenue;
                Control lblMonthlyCost = mainForm.lblMonthlyCost;
                DataGridView dgvReport = mainForm.dgvReport;

                await RefreshUIAsync(lblCustomers, lblMonthlyRevenue, lblMonthlyCost, dgvReport);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Controller failed to refresh dashboard: {ex.Message}", "Refresh Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async Task ShowAndLoadDashboardAsync(object tabControlControl, object dashboardTabPageControl, System.Windows.Forms.Control lblCustomers, System.Windows.Forms.Control lblMonthlyRevenue, System.Windows.Forms.Control lblMonthlyCost, System.Windows.Forms.DataGridView dgvReport)
        {
            if (tabControlControl is System.Windows.Forms.TabControl tc &&
         dashboardTabPageControl is System.Windows.Forms.TabPage tp)
            {
                tc.SelectedTab = tp;
            }

            await RefreshUIAsync(lblCustomers, lblMonthlyRevenue, lblMonthlyCost, dgvReport);
        }

        public async Task RefreshUIAsync(System.Windows.Forms.Control lblCustomers, System.Windows.Forms.Control lblMonthlyRevenue, System.Windows.Forms.Control lblMonthlyCost, System.Windows.Forms.DataGridView dgvReport)
        {
            try
            {
                var metrics = await _dashboardService.GetMetricsAsync();

                lblCustomers.Text = metrics.NewCustomer.ToString();
                lblMonthlyRevenue.Text = $"₱ {metrics.TotalRevenue:N2}";
                lblMonthlyCost.Text = $"₱ {metrics.TotalCost:N2}";

                lblCustomers.Invalidate();
                lblMonthlyRevenue.Invalidate();
                lblMonthlyCost.Invalidate();

                lblCustomers.Parent?.Invalidate();
                lblCustomers.Parent?.Update();

                lblMonthlyRevenue.Parent?.Invalidate();
                lblMonthlyRevenue.Parent?.Update();

                lblMonthlyCost.Parent?.Invalidate();
                lblMonthlyCost.Parent?.Update();

                lblCustomers.Parent?.Refresh();
                lblMonthlyRevenue.Parent?.Refresh();
                lblMonthlyCost.Parent?.Refresh();

                var reportRows = await _dashboardService.GetDetailedReportAsync();

                dgvReport.DataSource = null;
                dgvReport.DataSource = reportRows;

                dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                var customerNameColumn = dgvReport.Columns["CustomerName"];
                var orderValueColumn = dgvReport.Columns["OrderValue"];
                var orderDeadlineColumn = dgvReport.Columns["OrderDeadline"];
                var statusColumn = dgvReport.Columns["Status"];

                if (customerNameColumn != null) customerNameColumn.HeaderText = "CUSTOMER NAME";
                if (orderValueColumn != null) orderValueColumn.HeaderText = "ORDER VALUE";
                if (orderDeadlineColumn != null) orderDeadlineColumn.HeaderText = "ORDER DATE";
                if (statusColumn != null) statusColumn.HeaderText = "STATUS";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load dashboard data: {ex.Message}", "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
