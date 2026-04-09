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
            btn = new ReaLTaiizor.Controls.MaterialTabControl();
            MainDashboard = new TabPage();
            materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            btnNotification = new ReaLTaiizor.Controls.MaterialButton();
            Order = new TabPage();
            materialCard2 = new ReaLTaiizor.Controls.MaterialCard();
            cboSearch = new ReaLTaiizor.Controls.HopeComboBox();
            materialLabel3 = new ReaLTaiizor.Controls.MaterialLabel();
            btnNotificationOrder = new ReaLTaiizor.Controls.MaterialButton();
            BodyMeasurement = new TabPage();
            materialCard4 = new ReaLTaiizor.Controls.MaterialCard();
            materialLabel4 = new ReaLTaiizor.Controls.MaterialLabel();
            btnNotificationBodyMeasurement = new ReaLTaiizor.Controls.MaterialButton();
            CostConsumption = new TabPage();
            materialCard5 = new ReaLTaiizor.Controls.MaterialCard();
            materialLabel5 = new ReaLTaiizor.Controls.MaterialLabel();
            btnNotificationCostConsumption = new ReaLTaiizor.Controls.MaterialButton();
            Revenue = new TabPage();
            materialCard6 = new ReaLTaiizor.Controls.MaterialCard();
            materialLabel6 = new ReaLTaiizor.Controls.MaterialLabel();
            btnNotificationRevenue = new ReaLTaiizor.Controls.MaterialButton();
            pnlNotification = new ReaLTaiizor.Controls.MaterialCard();
            materialCard3 = new ReaLTaiizor.Controls.MaterialCard();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            btnCloseNotification = new ReaLTaiizor.Controls.MaterialButton();
            btn.SuspendLayout();
            MainDashboard.SuspendLayout();
            materialCard1.SuspendLayout();
            Order.SuspendLayout();
            materialCard2.SuspendLayout();
            BodyMeasurement.SuspendLayout();
            materialCard4.SuspendLayout();
            CostConsumption.SuspendLayout();
            materialCard5.SuspendLayout();
            Revenue.SuspendLayout();
            materialCard6.SuspendLayout();
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
            // btn
            // 
            btn.Controls.Add(MainDashboard);
            btn.Controls.Add(Order);
            btn.Controls.Add(BodyMeasurement);
            btn.Controls.Add(CostConsumption);
            btn.Controls.Add(Revenue);
            btn.Depth = 0;
            btn.Dock = DockStyle.Fill;
            btn.ImageList = imageList;
            btn.Location = new Point(3, 64);
            btn.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btn.Multiline = true;
            btn.Name = "btn";
            btn.SelectedIndex = 0;
            btn.Size = new Size(878, 394);
            btn.TabIndex = 0;
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
            Order.Controls.Add(materialCard2);
            Order.ImageKey = "order.png";
            Order.Location = new Point(4, 24);
            Order.Name = "Order";
            Order.Padding = new Padding(3);
            Order.Size = new Size(870, 366);
            Order.TabIndex = 1;
            Order.Text = "Order";
            Order.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(cboSearch);
            materialCard2.Controls.Add(materialLabel3);
            materialCard2.Controls.Add(btnNotificationOrder);
            materialCard2.Depth = 0;
            materialCard2.Dock = DockStyle.Top;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(3, 3);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(864, 50);
            materialCard2.TabIndex = 2;
            // 
            // cboSearch
            // 
            cboSearch.Dock = DockStyle.Right;
            cboSearch.DrawMode = DrawMode.OwnerDrawFixed;
            cboSearch.FlatStyle = FlatStyle.Flat;
            cboSearch.Font = new Font("Segoe UI", 12F);
            cboSearch.ForeColor = Color.Black;
            cboSearch.FormattingEnabled = true;
            cboSearch.ItemHeight = 21;
            cboSearch.Location = new Point(568, 14);
            cboSearch.Name = "cboSearch";
            cboSearch.Size = new Size(242, 27);
            cboSearch.TabIndex = 10;
            cboSearch.Text = "Search...";
            cboSearch.Enter += cboSearch_Enter;
            cboSearch.Leave += cboSearch_Leave;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Dock = DockStyle.Left;
            materialLabel3.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel3.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            materialLabel3.Location = new Point(14, 14);
            materialLabel3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(51, 24);
            materialLabel3.TabIndex = 2;
            materialLabel3.Text = "Order";
            // 
            // btnNotificationOrder
            // 
            btnNotificationOrder.AutoSize = false;
            btnNotificationOrder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNotificationOrder.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNotificationOrder.Depth = 0;
            btnNotificationOrder.Dock = DockStyle.Right;
            btnNotificationOrder.HighEmphasis = true;
            btnNotificationOrder.Icon = MyResources.bell;
            btnNotificationOrder.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Default;
            btnNotificationOrder.ImageKey = "(none)";
            btnNotificationOrder.Location = new Point(810, 14);
            btnNotificationOrder.Margin = new Padding(4, 6, 4, 6);
            btnNotificationOrder.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnNotificationOrder.Name = "btnNotificationOrder";
            btnNotificationOrder.NoAccentTextColor = Color.Empty;
            btnNotificationOrder.Size = new Size(40, 22);
            btnNotificationOrder.TabIndex = 2;
            btnNotificationOrder.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Text;
            btnNotificationOrder.UseAccentColor = false;
            btnNotificationOrder.UseVisualStyleBackColor = true;
            btnNotificationOrder.Click += btnNotificationOrder_Click;
            // 
            // BodyMeasurement
            // 
            BodyMeasurement.Controls.Add(materialCard4);
            BodyMeasurement.ImageKey = "bodyMeasurement.png";
            BodyMeasurement.Location = new Point(4, 24);
            BodyMeasurement.Name = "BodyMeasurement";
            BodyMeasurement.Size = new Size(870, 366);
            BodyMeasurement.TabIndex = 2;
            BodyMeasurement.Text = "Body Measurement";
            BodyMeasurement.UseVisualStyleBackColor = true;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(materialLabel4);
            materialCard4.Controls.Add(btnNotificationBodyMeasurement);
            materialCard4.Depth = 0;
            materialCard4.Dock = DockStyle.Top;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(0, 0);
            materialCard4.Margin = new Padding(14);
            materialCard4.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(14);
            materialCard4.Size = new Size(870, 50);
            materialCard4.TabIndex = 2;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Dock = DockStyle.Left;
            materialLabel4.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel4.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            materialLabel4.Location = new Point(14, 14);
            materialLabel4.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(176, 24);
            materialLabel4.TabIndex = 2;
            materialLabel4.Text = "Body Measurement";
            // 
            // btnNotificationBodyMeasurement
            // 
            btnNotificationBodyMeasurement.AutoSize = false;
            btnNotificationBodyMeasurement.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNotificationBodyMeasurement.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNotificationBodyMeasurement.Depth = 0;
            btnNotificationBodyMeasurement.Dock = DockStyle.Right;
            btnNotificationBodyMeasurement.HighEmphasis = true;
            btnNotificationBodyMeasurement.Icon = MyResources.bell;
            btnNotificationBodyMeasurement.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Default;
            btnNotificationBodyMeasurement.ImageKey = "(none)";
            btnNotificationBodyMeasurement.Location = new Point(816, 14);
            btnNotificationBodyMeasurement.Margin = new Padding(4, 6, 4, 6);
            btnNotificationBodyMeasurement.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnNotificationBodyMeasurement.Name = "btnNotificationBodyMeasurement";
            btnNotificationBodyMeasurement.NoAccentTextColor = Color.Empty;
            btnNotificationBodyMeasurement.Size = new Size(40, 22);
            btnNotificationBodyMeasurement.TabIndex = 2;
            btnNotificationBodyMeasurement.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Text;
            btnNotificationBodyMeasurement.UseAccentColor = false;
            btnNotificationBodyMeasurement.UseVisualStyleBackColor = true;
            // 
            // CostConsumption
            // 
            CostConsumption.Controls.Add(materialCard5);
            CostConsumption.ImageKey = "cost.png";
            CostConsumption.Location = new Point(4, 24);
            CostConsumption.Name = "CostConsumption";
            CostConsumption.Size = new Size(870, 366);
            CostConsumption.TabIndex = 3;
            CostConsumption.Text = "Cost Consumption";
            CostConsumption.UseVisualStyleBackColor = true;
            // 
            // materialCard5
            // 
            materialCard5.BackColor = Color.FromArgb(255, 255, 255);
            materialCard5.Controls.Add(materialLabel5);
            materialCard5.Controls.Add(btnNotificationCostConsumption);
            materialCard5.Depth = 0;
            materialCard5.Dock = DockStyle.Top;
            materialCard5.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard5.Location = new Point(0, 0);
            materialCard5.Margin = new Padding(14);
            materialCard5.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard5.Name = "materialCard5";
            materialCard5.Padding = new Padding(14);
            materialCard5.Size = new Size(870, 50);
            materialCard5.TabIndex = 3;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Dock = DockStyle.Left;
            materialLabel5.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel5.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            materialLabel5.Location = new Point(14, 14);
            materialLabel5.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(165, 24);
            materialLabel5.TabIndex = 2;
            materialLabel5.Text = "Cost Consumption";
            // 
            // btnNotificationCostConsumption
            // 
            btnNotificationCostConsumption.AutoSize = false;
            btnNotificationCostConsumption.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNotificationCostConsumption.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNotificationCostConsumption.Depth = 0;
            btnNotificationCostConsumption.Dock = DockStyle.Right;
            btnNotificationCostConsumption.HighEmphasis = true;
            btnNotificationCostConsumption.Icon = MyResources.bell;
            btnNotificationCostConsumption.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Default;
            btnNotificationCostConsumption.ImageKey = "(none)";
            btnNotificationCostConsumption.Location = new Point(816, 14);
            btnNotificationCostConsumption.Margin = new Padding(4, 6, 4, 6);
            btnNotificationCostConsumption.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnNotificationCostConsumption.Name = "btnNotificationCostConsumption";
            btnNotificationCostConsumption.NoAccentTextColor = Color.Empty;
            btnNotificationCostConsumption.Size = new Size(40, 22);
            btnNotificationCostConsumption.TabIndex = 2;
            btnNotificationCostConsumption.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Text;
            btnNotificationCostConsumption.UseAccentColor = false;
            btnNotificationCostConsumption.UseVisualStyleBackColor = true;
            btnNotificationCostConsumption.Click += btnNotificationCostConsumption_Click;
            // 
            // Revenue
            // 
            Revenue.Controls.Add(materialCard6);
            Revenue.ImageKey = "revenue.png";
            Revenue.Location = new Point(4, 24);
            Revenue.Name = "Revenue";
            Revenue.Size = new Size(870, 366);
            Revenue.TabIndex = 4;
            Revenue.Text = "Revenue";
            Revenue.UseVisualStyleBackColor = true;
            // 
            // materialCard6
            // 
            materialCard6.BackColor = Color.FromArgb(255, 255, 255);
            materialCard6.Controls.Add(materialLabel6);
            materialCard6.Controls.Add(btnNotificationRevenue);
            materialCard6.Depth = 0;
            materialCard6.Dock = DockStyle.Top;
            materialCard6.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard6.Location = new Point(0, 0);
            materialCard6.Margin = new Padding(14);
            materialCard6.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard6.Name = "materialCard6";
            materialCard6.Padding = new Padding(14);
            materialCard6.Size = new Size(870, 50);
            materialCard6.TabIndex = 3;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Dock = DockStyle.Left;
            materialLabel6.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel6.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.H6;
            materialLabel6.Location = new Point(14, 14);
            materialLabel6.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(78, 24);
            materialLabel6.TabIndex = 2;
            materialLabel6.Text = "Revenue";
            // 
            // btnNotificationRevenue
            // 
            btnNotificationRevenue.AutoSize = false;
            btnNotificationRevenue.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNotificationRevenue.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNotificationRevenue.Depth = 0;
            btnNotificationRevenue.Dock = DockStyle.Right;
            btnNotificationRevenue.HighEmphasis = true;
            btnNotificationRevenue.Icon = MyResources.bell;
            btnNotificationRevenue.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Default;
            btnNotificationRevenue.ImageKey = "(none)";
            btnNotificationRevenue.Location = new Point(816, 14);
            btnNotificationRevenue.Margin = new Padding(4, 6, 4, 6);
            btnNotificationRevenue.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            btnNotificationRevenue.Name = "btnNotificationRevenue";
            btnNotificationRevenue.NoAccentTextColor = Color.Empty;
            btnNotificationRevenue.Size = new Size(40, 22);
            btnNotificationRevenue.TabIndex = 2;
            btnNotificationRevenue.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Text;
            btnNotificationRevenue.UseAccentColor = false;
            btnNotificationRevenue.UseVisualStyleBackColor = true;
            btnNotificationRevenue.Click += btnNotificationRevenue_Click;
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
            Controls.Add(btn);
            Controls.Add(pnlNotification);
            DrawerAutoHide = false;
            DrawerAutoShow = true;
            DrawerBackgroundWithAccent = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = btn;
            DrawerUseColors = true;
            Name = "dashboardPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RE Sewing Creations";
            WindowState = FormWindowState.Maximized;
            btn.ResumeLayout(false);
            MainDashboard.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            Order.ResumeLayout(false);
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            BodyMeasurement.ResumeLayout(false);
            materialCard4.ResumeLayout(false);
            materialCard4.PerformLayout();
            CostConsumption.ResumeLayout(false);
            materialCard5.ResumeLayout(false);
            materialCard5.PerformLayout();
            Revenue.ResumeLayout(false);
            materialCard6.ResumeLayout(false);
            materialCard6.PerformLayout();
            pnlNotification.ResumeLayout(false);
            materialCard3.ResumeLayout(false);
            materialCard3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ImageList imageList;
        private ReaLTaiizor.Controls.MaterialTabControl btn;
        private TabPage MainDashboard;
        private TabPage Order;
        private TabPage BodyMeasurement;
        private TabPage CostConsumption;
        private TabPage Revenue;
        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.MaterialButton btnNotification;
        private ReaLTaiizor.Controls.MaterialCard pnlNotification;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialButton btnCloseNotification;
        private ReaLTaiizor.Controls.MaterialCard materialCard3;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private ReaLTaiizor.Controls.MaterialCard materialCard2;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel3;
        private ReaLTaiizor.Controls.MaterialButton btnNotificationOrder;
        private ReaLTaiizor.Controls.HopeComboBox cboSearch;
        private ReaLTaiizor.Controls.MaterialCard materialCard4;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel4;
        private ReaLTaiizor.Controls.MaterialButton btnNotificationBodyMeasurement;
        private ReaLTaiizor.Controls.MaterialCard materialCard5;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel5;
        private ReaLTaiizor.Controls.MaterialButton btnNotificationCostConsumption;
        private ReaLTaiizor.Controls.MaterialCard materialCard6;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel6;
        private ReaLTaiizor.Controls.MaterialButton btnNotificationRevenue;
    }
}
