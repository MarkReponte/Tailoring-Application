using AppDomain.Models;
using AppInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
    
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



        private async void lblStatusBadge_Click(object sender, EventArgs e)
        {
            if (lblStatusBadge.Text == "In Progress")
            {
                try
                {
                    using (var db = new SewingDbContext())
                    {
                        var record = await db.Measurements.FirstOrDefaultAsync(m => m.CustomerName == this.CustomerName);

                        if (record != null)
                        {
                            record.Status = "Completed";
                            int rowsAffected = await db.SaveChangesAsync();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Saved to Database Successfully!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database failed to update: " + ex.Message);
                    return;
                }

                if(this.Parent != null)
                {
                    this.Parent.Controls.Remove(this);
                }

                MessageBox.Show("Order marked as Completed. You can view it in the History window.");
            }
        }
    }
}
    

