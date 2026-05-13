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

namespace Dashboard
{
    public partial class OrderHistoryPopup : MaterialForm
    {
        public OrderHistoryPopup()
        {
            InitializeComponent();
            
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
                    var completed = await db.Measurements.Where(m => m.Status == "Completed").ToListAsync();

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
    }
}
