namespace Dashboard
{
    partial class OrderCard
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
            panel1 = new Panel();
            foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
            foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
            lblOrderDate = new ReaLTaiizor.Controls.FoxLabel();
            lblDeadlineDate = new ReaLTaiizor.Controls.FoxLabel();
            lblStatusBadge = new ReaLTaiizor.Controls.SkyLabel();
            lblCustomerName = new ReaLTaiizor.Controls.SkyLabel();
            poison = new ReaLTaiizor.Controls.FoxLabel();
            lblGender = new ReaLTaiizor.Controls.FoxLabel();
            hopeRoundButton1 = new ReaLTaiizor.Controls.HopeRoundButton();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(141, 182, 0);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 88);
            panel1.TabIndex = 0;
            // 
            // foxLabel1
            // 
            foxLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            foxLabel1.BackColor = Color.Transparent;
            foxLabel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            foxLabel1.ForeColor = Color.FromArgb(120, 120, 120);
            foxLabel1.Location = new Point(890, 23);
            foxLabel1.Name = "foxLabel1";
            foxLabel1.Size = new Size(68, 19);
            foxLabel1.TabIndex = 4;
            foxLabel1.Text = "Ordered:";
            foxLabel1.Click += foxLabel1_Click;
            // 
            // foxLabel2
            // 
            foxLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            foxLabel2.BackColor = Color.Transparent;
            foxLabel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            foxLabel2.ForeColor = Color.FromArgb(120, 120, 120);
            foxLabel2.Location = new Point(890, 47);
            foxLabel2.Name = "foxLabel2";
            foxLabel2.Size = new Size(68, 19);
            foxLabel2.TabIndex = 5;
            foxLabel2.Text = "Deadline:";
            // 
            // lblOrderDate
            // 
            lblOrderDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOrderDate.BackColor = Color.Transparent;
            lblOrderDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderDate.ForeColor = Color.FromArgb(64, 64, 64);
            lblOrderDate.Location = new Point(965, 23);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(68, 19);
            lblOrderDate.TabIndex = 6;
            lblOrderDate.Text = "00/00/00";
            // 
            // lblDeadlineDate
            // 
            lblDeadlineDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDeadlineDate.BackColor = Color.Transparent;
            lblDeadlineDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeadlineDate.ForeColor = Color.FromArgb(64, 64, 64);
            lblDeadlineDate.Location = new Point(965, 47);
            lblDeadlineDate.Name = "lblDeadlineDate";
            lblDeadlineDate.Size = new Size(68, 19);
            lblDeadlineDate.TabIndex = 7;
            lblDeadlineDate.Text = "00/00/00";
            // 
            // lblStatusBadge
            // 
            lblStatusBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatusBadge.AutoSize = true;
            lblStatusBadge.BackColor = Color.FromArgb(141, 182, 0);
            lblStatusBadge.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusBadge.ForeColor = Color.White;
            lblStatusBadge.Location = new Point(1063, 32);
            lblStatusBadge.Name = "lblStatusBadge";
            lblStatusBadge.Size = new Size(107, 25);
            lblStatusBadge.TabIndex = 8;
            lblStatusBadge.Text = "In Progress";
            lblStatusBadge.Click += lblStatusBadge_Click;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.BackColor = Color.White;
            lblCustomerName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.Black;
            lblCustomerName.Location = new Point(46, 19);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(71, 30);
            lblCustomerName.TabIndex = 9;
            lblCustomerName.Text = "Name";
            // 
            // poison
            // 
            poison.BackColor = Color.Transparent;
            poison.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            poison.ForeColor = Color.FromArgb(120, 120, 120);
            poison.Location = new Point(49, 59);
            poison.Name = "poison";
            poison.Size = new Size(68, 19);
            poison.TabIndex = 10;
            poison.Text = "Gender:";
            // 
            // lblGender
            // 
            lblGender.BackColor = Color.Transparent;
            lblGender.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGender.ForeColor = Color.FromArgb(64, 64, 64);
            lblGender.Location = new Point(102, 59);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(68, 19);
            lblGender.TabIndex = 11;
            lblGender.Text = "Male";
            // 
            // hopeRoundButton1
            // 
            hopeRoundButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hopeRoundButton1.BorderColor = Color.FromArgb(220, 223, 230);
            hopeRoundButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeRoundButton1.DangerColor = Color.FromArgb(245, 108, 108);
            hopeRoundButton1.DefaultColor = Color.FromArgb(255, 255, 255);
            hopeRoundButton1.Font = new Font("Segoe UI", 12F);
            hopeRoundButton1.HoverTextColor = Color.Red;
            hopeRoundButton1.InfoColor = Color.FromArgb(144, 147, 153);
            hopeRoundButton1.Location = new Point(1202, 25);
            hopeRoundButton1.Name = "hopeRoundButton1";
            hopeRoundButton1.PrimaryColor = Color.FromArgb(255, 128, 128);
            hopeRoundButton1.Size = new Size(39, 39);
            hopeRoundButton1.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeRoundButton1.TabIndex = 12;
            hopeRoundButton1.Text = "x";
            hopeRoundButton1.TextColor = Color.White;
            hopeRoundButton1.WarningColor = Color.FromArgb(230, 162, 60);
            hopeRoundButton1.Click += hopeRoundButton1_ClickAsync;
            // 
            // OrderCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(hopeRoundButton1);
            Controls.Add(lblGender);
            Controls.Add(poison);
            Controls.Add(lblCustomerName);
            Controls.Add(lblStatusBadge);
            Controls.Add(lblDeadlineDate);
            Controls.Add(lblOrderDate);
            Controls.Add(foxLabel2);
            Controls.Add(foxLabel1);
            Controls.Add(panel1);
            Name = "OrderCard";
            Size = new Size(1265, 88);
            Load += OrderCard_Load;
            Click += OrderCard_Clicked;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel2;
        public ReaLTaiizor.Controls.SkyLabel lblCustomerName;
        public ReaLTaiizor.Controls.FoxLabel lblOrderDate;
        public ReaLTaiizor.Controls.FoxLabel lblDeadlineDate;
        private ReaLTaiizor.Controls.FoxLabel poison;
        public ReaLTaiizor.Controls.FoxLabel lblGender;
        public ReaLTaiizor.Controls.SkyLabel lblStatusBadge;
        private ReaLTaiizor.Controls.HopeRoundButton hopeRoundButton1;
    }
}
