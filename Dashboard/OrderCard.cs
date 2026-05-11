using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class OrderCard : UserControl
    {
        public OrderCard()
        {
            InitializeComponent();
        }

        private void OrderCard_Load(object sender, EventArgs e)
        {
            RoundControl(lblStatusBadge, 15);
        }

        private void OrderCard_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show(AllMeasurements, "Order Details: " + CustomerName);
        }

        private void RoundControl(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            control.Region = new Region(path);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomerName
        {
            get => lblCustomerName.Text;
            set => lblCustomerName.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OrderDate
        {
            get => lblOrderDate.Text;
            set => lblOrderDate.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Deadline
        {
            get => lblDeadlineDate.Text; 
            set => lblDeadlineDate.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Gender
        {
            get => lblGender.Text;
            set => lblGender.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AllMeasurements { get; set; }
    }
}
    

