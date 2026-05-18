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

namespace Dashboard
{
    public partial class OrderHistoryPopup : MaterialForm
    {
        private readonly MeasurementRepository _measurementRepo;
        public OrderHistoryPopup(MeasurementRepository measurementRepo)
        {
            InitializeComponent();
            _measurementRepo = measurementRepo;
            
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
                            Deadline = m.OrderDeadline.ToString("MM/dd/yy"),
                            OrderDate = DateTime.Now.ToString("MM/dd/yy"),
                        };

                        card.lblStatusBadge.Text = "Completed";
                        card.lblStatusBadge.BackColor = Color.Gray;

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
                await _measurementRepo.DeleteAllCompletedAsync();
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
