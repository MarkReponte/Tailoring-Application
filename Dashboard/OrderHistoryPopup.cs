using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class OrderHistoryPopup : MaterialForm
    {
        public OrderHistoryPopup()
        {
            InitializeComponent();
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
