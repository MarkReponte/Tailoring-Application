using AppInfrastructure.Data;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using AppInfrastructure.Repository;
using Dashboard.Classes;
using System.Dynamic;

namespace Dashboard
{
    public partial class OrderHistoryPopup : MaterialForm
    {
        private readonly MeasurementRepository _measurementRepo;
        private readonly CostRepository _costRepo;
        public OrderHistoryPopup(MeasurementRepository measurementRepo, CostRepository costRepo)
        {
            InitializeComponent();
            _measurementRepo = measurementRepo;
            _costRepo = costRepo;
        }

     

        private async void OrderHistoryPopup_Load(object sender, EventArgs e)
        {
            await LoadCompleteOrdersAsync();
        }

        public async Task LoadCompleteOrdersAsync()
        {
            flpOrderHistory.Controls.Clear();
            try
            {
                using (var db = new SewingDbContext())
                {
                    var completed = await db.Measurements.Where(m => m.Status.ToLower() == "completed").ToListAsync();

                    foreach (var m in completed)
                    {
                        OrderCard card = new OrderCard
                        {
                            CustomerName = m.CustomerName,
                            Gender = m.Gender,
                            OrderDate = m.DateCreated.ToString("MM/dd/yy"),
                            Deadline = m.OrderDeadline.ToString("MM/dd/yy"),
                            AllMeasurements = MeasurementFormatter.ToDisplayString(m),
                            MeasurementId = new object[] {m.Id}
                        };

                        card.SetStatus("Completed", Color.Gray);

                        flpOrderHistory.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Async loading failed: {ex.Message}");
            }
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void btnClearAll_Click(object sender, EventArgs e)
        {
            if (flpOrderHistory.Controls.Count == 0)
            {
                MessageBox.Show("There are no completed orders to clear.", "Nothing to Clear", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to permanently delete all completed orders? This cannot be undone.",
                "Clear All Orders",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var completedCustomerNames = new List<string>();
                foreach(Control control in flpOrderHistory.Controls)
                {
                    if (control is OrderCard card)
                    {
                        completedCustomerNames.Add(card.CustomerName);
                    }
                }

                await _measurementRepo.DeleteAllCompletedAsync();
                if(_costRepo != null && completedCustomerNames.Any())
                {
                    await _costRepo.DeleteAllCompletedCostsAsync(completedCustomerNames);
                }

                if(Form1.GlobalDashboardController != null)
                {
                    await Form1.GlobalDashboardController.RefreshDashboardViewAsync();
                }

                flpOrderHistory.Controls.Clear();

                MessageBox.Show("All completed orders have been cleared.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to clear orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
