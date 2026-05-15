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
    public partial class CostInfo : MaterialForm
    {
        private MaterialCost _data;
        public CostInfo(MaterialCost incomingData)
        {
            InitializeComponent();
            _data = incomingData;

            lblCostumerName.Text = _data.CustomerNameCost;
            lblMaterialTotalSaved.Text = "₱ " + _data.MaterialTotal.ToString("N2");
            lblLaborCostSaved.Text = "₱ " + _data.LaborCost.ToString("N2");
            lblQuantitySaved.Text = _data.Quantity.ToString();
            lblTotalLaborSaved.Text = "₱ " + _data.TotalLabor.ToString("N2");
            lblGrandTotalCostSaved.Text = "₱ " + _data.GrandTotalCost.ToString("N2");

            dgvMaterialListSaved.Rows.Clear();

           if(_data.Items != null && _data.Items.Count > 0)
            {
                foreach (var item in _data.Items)
                {
                    string itemName = item.ItemName;
                    string meters = item.Meters;
                    string price = item.Price;


                    decimal.TryParse(meters.Replace("m", ""), out var m);
                    decimal.TryParse(price.Replace("₱", ""), out var p);
                    decimal rowTotal = (decimal)m * p;

                    dgvMaterialListSaved.Rows.Add(
                        itemName,
                        meters.EndsWith("m") ? meters : meters + "m",
                        price.StartsWith("₱") ? price : "₱" + price,
                        "₱" + rowTotal.ToString("N2"));
                }
            }
        }

        private async void btnBackToComputationHistory_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
