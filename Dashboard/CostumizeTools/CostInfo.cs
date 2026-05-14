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

            if (!string.IsNullOrEmpty(_data.Description))
            {
                string[] lines = _data.Description.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string l in lines)
                {
                    string[] parts = l.Split(new[] { " - " }, StringSplitOptions.None);

                    if (parts.Length >= 3)
                    {
                        string item = parts[0].Trim();
                        string metersStr = parts[1].Replace("m", "").Trim();
                        string priceStr = parts[2].Replace("₱", "").Trim();

                        double.TryParse(metersStr, out var m);
                        decimal.TryParse(priceStr, out var p);
                        decimal rowTotal = (decimal)m * p;

                        dgvMaterialListSaved.Rows.Add(item, metersStr + "m", "₱" + p.ToString("N2"), "₱" + rowTotal.ToString("N2"));
                    }
                }
            }
        }

        private void btnBackToComputationHistory_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
