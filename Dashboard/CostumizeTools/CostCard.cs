using AppDomain.Models;
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

        public void SetData(MaterialCost data)
        {
            lblCustomerNameCost.Text = data.CustomerNameCost;
            lblDescription.Text = data.Description;
            lblDateSaved.Text = DateTime.Now.ToString("MM/dd/yy");
            lblGrandTotal.Text = "₱ " + data.GrandTotalCost.ToString("N2");
        }

       
    }
}
