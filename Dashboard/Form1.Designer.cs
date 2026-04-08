namespace Dashboard
{
    partial class dashboardPanel
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboardPanel));
            materialTabControl = new MaterialSkin.Controls.MaterialTabControl();
            Dashboard = new TabPage();
            Dashboard_Panel = new Panel();
            Order = new TabPage();
            bodyMeasurement = new TabPage();
            costConsumption = new TabPage();
            Revenue = new TabPage();
            imageList = new ImageList(components);
            materialTabControl.SuspendLayout();
            Dashboard.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl
            // 
            materialTabControl.Controls.Add(Dashboard);
            materialTabControl.Controls.Add(Order);
            materialTabControl.Controls.Add(bodyMeasurement);
            materialTabControl.Controls.Add(costConsumption);
            materialTabControl.Controls.Add(Revenue);
            materialTabControl.Depth = 0;
            materialTabControl.Dock = DockStyle.Fill;
            materialTabControl.ImageList = imageList;
            materialTabControl.Location = new Point(3, 64);
            materialTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl.Multiline = true;
            materialTabControl.Name = "materialTabControl";
            materialTabControl.SelectedIndex = 0;
            materialTabControl.Size = new Size(878, 394);
            materialTabControl.TabIndex = 0;
            // 
            // Dashboard
            // 
            Dashboard.BackColor = Color.Transparent;
            Dashboard.Controls.Add(Dashboard_Panel);
            Dashboard.ImageKey = "dashboard.png";
            Dashboard.Location = new Point(4, 29);
            Dashboard.Name = "Dashboard";
            Dashboard.Padding = new Padding(3);
            Dashboard.Size = new Size(870, 361);
            Dashboard.TabIndex = 0;
            Dashboard.Text = "Dashboard";
            // 
            // Dashboard_Panel
            // 
            Dashboard_Panel.BackColor = Color.Silver;
            Dashboard_Panel.BorderStyle = BorderStyle.FixedSingle;
            Dashboard_Panel.Dock = DockStyle.Top;
            Dashboard_Panel.Location = new Point(3, 3);
            Dashboard_Panel.Name = "Dashboard_Panel";
            Dashboard_Panel.Size = new Size(864, 100);
            Dashboard_Panel.TabIndex = 0;
            Dashboard_Panel.Paint += panel1_Paint;
            // 
            // Order
            // 
            Order.ImageKey = "order.png";
            Order.Location = new Point(4, 29);
            Order.Name = "Order";
            Order.Padding = new Padding(3);
            Order.Size = new Size(870, 361);
            Order.TabIndex = 1;
            Order.Text = "Order";
            Order.UseVisualStyleBackColor = true;
            // 
            // bodyMeasurement
            // 
            bodyMeasurement.ImageKey = "bodyMeasurement.png";
            bodyMeasurement.Location = new Point(4, 29);
            bodyMeasurement.Name = "bodyMeasurement";
            bodyMeasurement.Size = new Size(870, 361);
            bodyMeasurement.TabIndex = 2;
            bodyMeasurement.Text = "Body Measurement";
            bodyMeasurement.UseVisualStyleBackColor = true;
            // 
            // costConsumption
            // 
            costConsumption.ImageKey = "cost.png";
            costConsumption.Location = new Point(4, 29);
            costConsumption.Name = "costConsumption";
            costConsumption.Size = new Size(870, 361);
            costConsumption.TabIndex = 3;
            costConsumption.Text = "Cost Consumption";
            costConsumption.UseVisualStyleBackColor = true;
            // 
            // Revenue
            // 
            Revenue.ImageKey = "revenue.png";
            Revenue.Location = new Point(4, 29);
            Revenue.Name = "Revenue";
            Revenue.Size = new Size(870, 361);
            Revenue.TabIndex = 4;
            Revenue.Text = "Revenue";
            Revenue.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "dashboard.png");
            imageList.Images.SetKeyName(1, "order.png");
            imageList.Images.SetKeyName(2, "bodyMeasurement.png");
            imageList.Images.SetKeyName(3, "cost.png");
            imageList.Images.SetKeyName(4, "revenue.png");
            // 
            // dashboardPanel
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = SystemColors.Control;
            ClientSize = new Size(884, 461);
            Controls.Add(materialTabControl);
            DrawerAutoHide = false;
            DrawerAutoShow = true;
            DrawerShowIconsWhenHidden = true;
            DrawerUseColors = true;
            Name = "dashboardPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RE Sewing Creations";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            materialTabControl.ResumeLayout(false);
            Dashboard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl;
        private TabPage Dashboard;
        private TabPage Order;
        private ImageList imageList;
        private TabPage bodyMeasurement;
        private TabPage costConsumption;
        private TabPage Revenue;
        private Panel Dashboard_Panel;
    }
}
