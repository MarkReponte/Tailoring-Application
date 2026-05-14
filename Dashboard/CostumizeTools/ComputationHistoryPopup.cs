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
    public partial class ComputationHistoryPopup : MaterialForm
    {
        public ComputationHistoryPopup()
        {
            InitializeComponent();
        }

        private void btnViewCostConsumption_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
