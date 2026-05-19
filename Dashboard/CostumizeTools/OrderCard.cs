using AppDomain.Models;
using AppInfrastructure.Data;
using AppInfrastructure.Repository;
using Dashboard.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
    
namespace Dashboard
{
    public partial class OrderCard : UserControl
    {
        public OrderCard()
        {
            InitializeComponent();
        }

        private void OrderCard_Load(object sender, EventArgs e)
        {
            RoundControl(lblStatusBadge, 20);
        }

        public void SetStatus (string statusText, Color badgeColor)
        {
            lblStatusBadge.Text = statusText;
            lblStatusBadge.BackColor = badgeColor;
        }

        private void OrderCard_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show(AllMeasurements, "Order Details: " + CustomerName);
        }

        private void RoundControl(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            control.Region = new Region(path);
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerName
        {
            get => lblCustomerName.Text;
            set => lblCustomerName.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OrderDate
        {
            get => lblOrderDate.Text;
            set => lblOrderDate.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Deadline
        {
            get => lblDeadlineDate.Text;
            set => lblDeadlineDate.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Gender
        {
            get => lblGender.Text;
            set => lblGender.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AllMeasurements { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object?[]? MeasurementId { get; set; }

        private async void lblStatusBadge_Click(object sender, EventArgs e)
        {
            if (lblStatusBadge.Text == "In Progress")
            {
                if (MeasurementId == null || MeasurementId.Length == 0 || MeasurementId[0] == null)
                {
                    MessageBox.Show("Error: Measurement ID is blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string targetGuidStr = MeasurementId[0]!.ToString()!;

                try
                {
                    using (var db = new SewingDbContext())
                    {
                        var record = await db.Measurements.FirstOrDefaultAsync(m => m.Id.ToString() == targetGuidStr && m.Status == "In Progress");

                        if (record == null)
                        {
                            MessageBox.Show("Could not find the active order in the database.");
                            return;
                        }

                        record.Status = "Completed";
                        await db.SaveChangesAsync();
                    }

                    if (Form1.GlobalDashboardController != null)
                    {
                        await Form1.GlobalDashboardController.RefreshDashboardViewAsync();
                    }

                    NotificationManager.AddNotification(
                        "Order completed",
                        $"{CustomerName}'s order was moved to Order History.");

                    if (this.Parent != null)
                    {
                        this.Parent.Controls.Remove(this);
                    }

                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database failed to update: " + ex.Message);
                    return;
                }
            }
        }

        private void foxLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void hopeRoundButton1_ClickAsync(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
               $"Are you sure you want to delete the order for \"{CustomerName}\"? This cannot be undone.",
               "Delete Order",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            if (MeasurementId == null || MeasurementId.Length == 0 || MeasurementId[0] == null)
            {
                MessageBox.Show("Cannot delete order: Invalid or missing Measurement ID array.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string targetGuidStr = MeasurementId[0]!.ToString()!;
            string deletedCustomerName = CustomerName;
    
            try
            {
                using (var db = new SewingDbContext())
                {
                    var record = await db.Measurements.FirstOrDefaultAsync(m => m.Id.ToString() == targetGuidStr);

                    if (record != null)
                    {
                        db.Measurements.Remove(record);
                        await db.SaveChangesAsync();
                    }
                }

                using (var costDb = new CostDBContext())
                {
                    var linkedCosts = await costDb.MaterialCosts
                        .Where(c => c.CustomerNameCost == this.CustomerName)
                        .ToListAsync();

                    if (linkedCosts.Any())
                    {
                        costDb.MaterialCosts.RemoveRange(linkedCosts);
                        await costDb.SaveChangesAsync();
                    }
                }

                NotificationManager.AddNotification(
                    "Order deleted",
                    $"{deletedCustomerName}'s order and linked costs were deleted.");

                if (Form1.GlobalDashboardController != null)
                {
                    await Form1.GlobalDashboardController.RefreshDashboardViewAsync();
                }

                if (this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                }
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool MatchesSearch(string searchText)
        {
            return CustomerName?.ToLower().Contains(searchText) == true ||
                   Gender?.ToLower().Contains(searchText) == true ||
                   Deadline?.ToLower().Contains(searchText) == true ||
                   OrderDate?.ToLower().Contains(searchText) == true;
        }
    }
}
    

