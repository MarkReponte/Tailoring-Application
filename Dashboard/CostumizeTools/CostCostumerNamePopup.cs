using AppDomain.Models;
using AppInfrastructure.Data;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dashboard.CostumizeTools
{
    

    public partial class CostCostumerNamePopup : MaterialForm
    {
        private MaterialCost _finalData;

        public CostCostumerNamePopup(MaterialCost mathResults)
        {
            InitializeComponent();
            _finalData = mathResults;
        }

        private void btnBackCost_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private async void btnSaveCostFinal_Click(object sender, EventArgs e)
        {
            string name = txtCostCostumerName.Text;
            string description = txtDescription.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a customer name.");
                return;
            }

            btnSaveCostFinal.Enabled = false;
            try
            {
                _finalData.CustomerNameCost = name;
                _finalData.Description = description;

                using (var db = new CostDBContext())
                {
                    db.MaterialCosts.Add(_finalData);

                    await db.SaveChangesAsync();
                }

                MessageBox.Show("Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Exception realError = ex;
                while (realError.InnerException != null)
                    realError = realError.InnerException;

                MessageBox.Show($"Actual SQL Error: {realError.Message}");
            }



        }
    }
}
