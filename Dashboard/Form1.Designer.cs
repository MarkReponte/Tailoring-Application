using MyResources = Dashboard.Properties.Resources;

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
            imageList = new ImageList(components);
            materialTabControl1 = new ReaLTaiizor.Controls.MaterialTabControl();
            MainDashboard = new TabPage();
            materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            btnNotification = new ReaLTaiizor.Controls.MaterialButton();
            Order = new TabPage();
            BodyMeasurement = new TabPage();
            CostConsumption = new TabPage();
            Revenue = new TabPage();
            pnlNotification = new ReaLTaiizor.Controls.MaterialCard();
            materialCard3 = new ReaLTaiizor.Controls.MaterialCard();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            btnCloseNotification = new ReaLTaiizor.Controls.MaterialButton();
            materialTabControl1.SuspendLayout();
            MainDashboard.SuspendLayout();
            materialCard1.SuspendLayout();
            pnlNotification.SuspendLayout();
            materialCard3.SuspendLayout();
            SuspendLayout();
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
            imageList.Images.SetKeyName(5, "bell.png");
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(MainDashboard);
            materialTabControl1.Controls.Add(Order);
            materialTabControl1.Controls.Add(BodyMeasurement);
            materialTabControl1.Controls.Add(CostConsumption);
            materialTabControl1.Controls.Add(Revenue);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = imageList;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(878, 394);
            materialTabControl1.TabIndex = 0;
            // 
            // MainDashboard
            // 
            MainDashboard.Controls.Add(materialCard1);
            MainDashboard.ImageKey = "dashboard.png";
            MainDashboard.Location = new Point(4, 24);
            MainDashboard.Name = "MainDashboard";
            MainDashboard.Padding = new Padding(3);
            MainDashboard.Size = new Size(870, 366);
            MainDashboard.TabIndex = 0;
            MainDashboard.Text = "Dashboard";
            MainDashboard.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Controls.Add(btnNotification);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Top;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(3, 3);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(864, 50);
            materialCard1.TabIndex = 1;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Left;
            materialLabel1.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            materialLabel1.Location = new Point(14, 14);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(97, 24);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Dashboard";
            // 
            // btnNotification
            // 
            btnNotification.AutoSize = false;
            btnNotification.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNotification.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNotification.Depth = 0;
            btnNotification.Dock = DockStyle.Right;
            btnNotification.HighEmphasis = true;
            btnNotification.Icon = MyResources.bell;
            btnNotification.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Default;
            btnNotification.ImageKey = "(none)";
            btnNotification.Location = new Point(810, 14);
            btnNotification.Margin = new Padding(4, 6, 4, 6);
            btnNotification.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnNotification.Name = "btnNotification";
            btnNotification.NoAccentTextColor = Color.Empty;
            btnNotification.Size = new Size(40, 22);
            btnNotification.TabIndex = 2;
            btnNotification.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Text;
            btnNotification.UseAccentColor = false;
            btnNotification.UseVisualStyleBackColor = true;
            btnNotification.Click += btnNotification_Click;
            // 
            // Order
            // 
            Order.ImageKey = "order.png";
            Order.Location = new Point(4, 24);
            Order.Name = "Order";
            Order.Padding = new Padding(3);
            Order.Size = new Size(870, 366);
            Order.TabIndex = 1;
            Order.Text = "Order";
            Order.UseVisualStyleBackColor = true;
            // 
            // BodyMeasurement
            // 
            BodyMeasurement.ImageKey = "bodyMeasurement.png";
            BodyMeasurement.Location = new Point(4, 24);
            BodyMeasurement.Name = "BodyMeasurement";
            BodyMeasurement.Size = new Size(870, 366);
            BodyMeasurement.TabIndex = 2;
            BodyMeasurement.Text = "Body Measurement";
            BodyMeasurement.UseVisualStyleBackColor = true;
            // 
            // CostConsumption
            // 
            CostConsumption.ImageKey = "cost.png";
            CostConsumption.Location = new Point(4, 24);
            CostConsumption.Name = "CostConsumption";
            CostConsumption.Size = new Size(870, 366);
            CostConsumption.TabIndex = 3;
            CostConsumption.Text = "Cost Consumption";
            CostConsumption.UseVisualStyleBackColor = true;
            // 
            // Revenue
            // 
            Revenue.ImageKey = "revenue.png";
            Revenue.Location = new Point(4, 24);
            Revenue.Name = "Revenue";
            Revenue.Size = new Size(870, 366);
            Revenue.TabIndex = 4;
            Revenue.Text = "Revenue";
            Revenue.UseVisualStyleBackColor = true;
            // 
            // pnlNotification
            // 
            pnlNotification.BackColor = Color.FromArgb(255, 255, 255);
            pnlNotification.Controls.Add(materialCard3);
            pnlNotification.Depth = 0;
            pnlNotification.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlNotification.Location = new Point(627, 45);
            pnlNotification.Margin = new Padding(14);
            pnlNotification.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            pnlNotification.Name = "pnlNotification";
            pnlNotification.Padding = new Padding(14);
            pnlNotification.Size = new Size(300, 400);
            pnlNotification.TabIndex = 2;
            pnlNotification.Visible = false;
            // 
            // materialCard3
            // 
            materialCard3.Anchor = AnchorStyles.Top;
            materialCard3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.BorderStyle = BorderStyle.FixedSingle;
            materialCard3.Controls.Add(materialLabel2);
            materialCard3.Controls.Add(btnCloseNotification);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(0, 0);
            materialCard3.Margin = new Padding(14);
            materialCard3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(14);
            materialCard3.Size = new Size(300, 50);
            materialCard3.TabIndex = 1;
            materialCard3.Paint += materialCard3_Paint;
            // 
            // materialLabel2
            // 
            materialLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(113, 17);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(84, 19);
            materialLabel2.TabIndex = 1;
            materialLabel2.Text = "Notification";
            // 
            // btnCloseNotification
            // 
            btnCloseNotification.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseNotification.AutoSize = false;
            btnCloseNotification.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCloseNotification.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCloseNotification.Depth = 0;
            btnCloseNotification.ForeColor = Color.Black;
            btnCloseNotification.HighEmphasis = true;
            btnCloseNotification.Icon = null;
            btnCloseNotification.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            btnCloseNotification.Location = new Point(280, 6);
            btnCloseNotification.Margin = new Padding(4, 6, 4, 6);
            btnCloseNotification.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnCloseNotification.Name = "btnCloseNotification";
            btnCloseNotification.NoAccentTextColor = Color.Empty;
            btnCloseNotification.Size = new Size(14, 20);
            btnCloseNotification.TabIndex = 0;
            btnCloseNotification.Text = "X";
            btnCloseNotification.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Text;
            btnCloseNotification.UseAccentColor = true;
            btnCloseNotification.UseVisualStyleBackColor = true;
            btnCloseNotification.Click += btnCloseNotification_Click;
            // 
            // dashboardPanel
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.Control;
            ClientSize = new Size(884, 461);
            Controls.Add(pnlNotification);
            Controls.Add(materialTabControl1);
            DrawerAutoHide = false;
            DrawerAutoShow = true;
            DrawerBackgroundWithAccent = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            DrawerUseColors = true;
            Name = "dashboardPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RE Sewing Creations";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            materialTabControl1.ResumeLayout(false);
            MainDashboard.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            pnlNotification.ResumeLayout(false);
            materialCard3.ResumeLayout(false);
            materialCard3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ImageList imageList;
        private ReaLTaiizor.Controls.MaterialTabControl materialTabControl1;
        private TabPage MainDashboard;
        private TabPage Order;
        private TabPage BodyMeasurement;
        private TabPage CostConsumption;
        private TabPage Revenue;
        private ReaLTaiizor.Controls.MaterialCard materialCard2;
        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.MaterialButton btnNotification;
        private ReaLTaiizor.Controls.MaterialCard pnlNotification;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialButton btnCloseNotification;
        private ReaLTaiizor.Controls.MaterialCard materialCard3;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
    }
}
