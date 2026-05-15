using AppDomain.Models;
using AppInfrastructure.Data;
using AppInfrastructure.Repository;
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
        private readonly CostRepository _costRepo;

        public CostCostumerNamePopup(MaterialCost mathResults, CostRepository costRepo)
        {
            InitializeComponent();
            _finalData = mathResults;
            _costRepo = costRepo;
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
                
                await _costRepo.AddAsync(_finalData);
                await _costRepo.SaveAsync();

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
