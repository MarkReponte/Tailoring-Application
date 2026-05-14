using AppInfrastructure.Data;
using MaterialSkin.Controls;
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
    public partial class ComputationHistoryPopup : MaterialForm
    {
        public ComputationHistoryPopup()
        {
            InitializeComponent();
        }

        private async void ComputationHistoryPop_Load(object sender, EventArgs e)
        {
            flpComputationHistory.Controls.Clear();

            using (var db = new CostDBContext())
            {
                var savedCosts = await db.MaterialCosts.Include(c=> c.Items).OrderByDescending(c => c.Id).ToListAsync();

                foreach (var cost in savedCosts)
                {
                    CostCard card = new CostCard(); 

                    card.lblCustomerNameCost.Text = cost.CustomerNameCost;
                    card.lblDescription.Text = cost.Description;
                    card.lblGrandTotal.Text = "₱" + cost.GrandTotalCost.ToString("N2");

                    flpComputationHistory.Controls.Add(card);

                    card.Click += (s, ev) =>
                    {
                        var infoForm = new CostInfo(cost);
                        infoForm.ShowDialog();
                        infoForm.StartPosition = FormStartPosition.CenterScreen;

                    };

                }
            }
        }

        private void btnViewCostConsumption_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
