namespace Dashboard
{
    partial class OrderHistoryPopup
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            flpOrderHistory = new FlowLayoutPanel();
            panel1 = new Panel();
            btnViewOrders = new ReaLTaiizor.Controls.HopeButton();
            pictureBox3 = new PictureBox();
            lblOrderHistory = new ReaLTaiizor.Controls.MaterialLabel();
            materialCard1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.BorderStyle = BorderStyle.FixedSingle;
            materialCard1.Controls.Add(flpOrderHistory);
            materialCard1.Controls.Add(panel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(1);
            materialCard1.Size = new Size(820, 449);
            materialCard1.TabIndex = 0;
            // 
            // flpOrderHistory
            // 
            flpOrderHistory.Dock = DockStyle.Fill;
            flpOrderHistory.Location = new Point(1, 66);
            flpOrderHistory.Name = "flpOrderHistory";
            flpOrderHistory.Size = new Size(816, 380);
            flpOrderHistory.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnViewOrders);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(lblOrderHistory);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(816, 65);
            panel1.TabIndex = 0;
            // 
            // btnViewOrders
            // 
            btnViewOrders.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnViewOrders.BorderColor = Color.FromArgb(220, 223, 230);
            btnViewOrders.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnViewOrders.DangerColor = Color.FromArgb(245, 108, 108);
            btnViewOrders.DefaultColor = Color.FromArgb(255, 255, 255);
            btnViewOrders.Font = new Font("Segoe UI", 12F);
            btnViewOrders.HoverTextColor = Color.FromArgb(120, 160, 0);
            btnViewOrders.InfoColor = Color.FromArgb(144, 147, 153);
            btnViewOrders.Location = new Point(672, 15);
            btnViewOrders.Name = "btnViewOrders";
            btnViewOrders.PrimaryColor = Color.FromArgb(141, 182, 0);
            btnViewOrders.Size = new Size(120, 35);
            btnViewOrders.SuccessColor = Color.FromArgb(103, 194, 58);
            btnViewOrders.TabIndex = 159;
            btnViewOrders.Text = "View Orders";
            btnViewOrders.TextColor = Color.White;
            btnViewOrders.WarningColor = Color.FromArgb(230, 162, 60);
            btnViewOrders.Click += btnViewOrders_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.dashboard;
            pictureBox3.Location = new Point(12, 15);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(34, 35);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // lblOrderHistory
            // 
            lblOrderHistory.AutoSize = true;
            lblOrderHistory.Depth = 0;
            lblOrderHistory.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblOrderHistory.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle1;
            lblOrderHistory.Location = new Point(52, 24);
            lblOrderHistory.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblOrderHistory.Name = "lblOrderHistory";
            lblOrderHistory.Size = new Size(93, 19);
            lblOrderHistory.TabIndex = 6;
            lblOrderHistory.Text = "Order History";
            // 
            // OrderHistoryPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 449);
            Controls.Add(materialCard1);
            Name = "OrderHistoryPopup";
            Padding = new Padding(0);
            materialCard1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.MaterialLabel lblOrderHistory;
        private PictureBox pictureBox3;
        private ReaLTaiizor.Controls.HopeButton btnViewOrders;
        public FlowLayoutPanel flpOrderHistory;
        private Panel panel1;
    }
}
