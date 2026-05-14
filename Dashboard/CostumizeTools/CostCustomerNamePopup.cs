using AppDomain.Models;
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
    

    public partial class CostCustomerNamePopup : MaterialForm
    {
        public CostCustomerNamePopup(MaterialCost mathResults)
        {
            InitializeComponent();
            
        }

        private void btnBackCost_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescription_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveCostFinal_Click(object sender, EventArgs e)
        {
            string name = txtCostCostumerName.Text;
            string description = txtDescription.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a customer name.");
                return;
            }

            this.Hide();

           
        }
    }
}
