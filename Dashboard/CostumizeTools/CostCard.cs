using AppDomain.Models;
using AppInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dashboard.CostumizeTools
{
    public partial class CostCard : UserControl
    {
        public CostCard()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid MaterialCostId { get; set; }

        public void SetData(MaterialCost data)
        {
            MaterialCostId = data.Id;
            lblCustomerNameCost.Text = data.CustomerNameCost;
            lblDescription.Text = data.Description;
            lblDateSaved.Text = data.DateCreated.ToString("MM/dd/yy");
            lblGrandTotal.Text = "₱ " + data.GrandTotalCost.ToString("N2");
        }

        private async void hopeRoundButton1_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                 $"Are you sure you want to delete the cost record for \"{lblCustomerNameCost.Text}\"? This cannot be undone.",
                 "Delete Cost Record",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new CostDBContext())
                {
                   
                    var record = await db.MaterialCosts
                        .Include(c => c.Items)
                        .FirstOrDefaultAsync(c => c.Id == MaterialCostId);

                    if (record != null)
                    {
                        
                        db.MaterialItems.RemoveRange(record.Items);
                        db.MaterialCosts.Remove(record);
                        await db.SaveChangesAsync();
                    }
                }

                if (this.Parent != null)
                    this.Parent.Controls.Remove(this);

                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete cost record: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
