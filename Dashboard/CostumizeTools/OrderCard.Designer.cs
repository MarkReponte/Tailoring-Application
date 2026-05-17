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
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(141, 182, 0);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(11, 117);
            panel1.TabIndex = 0;
            // 
            // foxLabel1
            // 
            foxLabel1.BackColor = Color.Transparent;
            foxLabel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            foxLabel1.ForeColor = Color.FromArgb(120, 120, 120);
            foxLabel1.Location = new Point(870, 30);
            foxLabel1.Margin = new Padding(3, 4, 3, 4);
            foxLabel1.Name = "foxLabel1";
            foxLabel1.Size = new Size(78, 25);
            foxLabel1.TabIndex = 4;
            foxLabel1.Text = "Ordered:";
            // 
            // foxLabel2
            // 
            foxLabel2.BackColor = Color.Transparent;
            foxLabel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            foxLabel2.ForeColor = Color.FromArgb(120, 120, 120);
            foxLabel2.Location = new Point(870, 62);
            foxLabel2.Margin = new Padding(3, 4, 3, 4);
            foxLabel2.Name = "foxLabel2";
            foxLabel2.Size = new Size(78, 25);
            foxLabel2.TabIndex = 5;
            foxLabel2.Text = "Deadline:";
            // 
            // lblOrderDate
            // 
            lblOrderDate.BackColor = Color.Transparent;
            lblOrderDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderDate.ForeColor = Color.FromArgb(64, 64, 64);
            lblOrderDate.Location = new Point(955, 30);
            lblOrderDate.Margin = new Padding(3, 4, 3, 4);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(78, 25);
            lblOrderDate.TabIndex = 6;
            lblOrderDate.Text = "00/00/00";
            // 
            // lblDeadlineDate
            // 
            lblDeadlineDate.BackColor = Color.Transparent;
            lblDeadlineDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeadlineDate.ForeColor = Color.FromArgb(64, 64, 64);
            lblDeadlineDate.Location = new Point(955, 62);
            lblDeadlineDate.Margin = new Padding(3, 4, 3, 4);
            lblDeadlineDate.Name = "lblDeadlineDate";
            lblDeadlineDate.Size = new Size(78, 25);
            lblDeadlineDate.TabIndex = 7;
            lblDeadlineDate.Text = "00/00/00";
            // 
            // lblStatusBadge
            // 
            lblStatusBadge.AutoSize = true;
            lblStatusBadge.BackColor = Color.FromArgb(141, 182, 0);
            lblStatusBadge.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusBadge.ForeColor = Color.White;
            lblStatusBadge.Location = new Point(1068, 41);
            lblStatusBadge.Name = "lblStatusBadge";
            lblStatusBadge.Size = new Size(131, 31);
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
            lblCustomerName.Location = new Point(53, 25);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(93, 37);
            lblCustomerName.TabIndex = 9;
            lblCustomerName.Text = "Name";
            // 
            // poison
            // 
            poison.BackColor = Color.Transparent;
            poison.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            poison.ForeColor = Color.FromArgb(120, 120, 120);
            poison.Location = new Point(56, 79);
            poison.Margin = new Padding(3, 4, 3, 4);
            poison.Name = "poison";
            poison.Size = new Size(78, 25);
            poison.TabIndex = 10;
            poison.Text = "Gender:";
            // 
            // lblGender
            // 
            lblGender.BackColor = Color.Transparent;
            lblGender.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGender.ForeColor = Color.FromArgb(64, 64, 64);
            lblGender.Location = new Point(117, 79);
            lblGender.Margin = new Padding(3, 4, 3, 4);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(78, 25);
            lblGender.TabIndex = 11;
            lblGender.Text = "Male";
            // 
            // OrderCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblGender);
            Controls.Add(poison);
            Controls.Add(lblCustomerName);
            Controls.Add(lblStatusBadge);
            Controls.Add(lblDeadlineDate);
            Controls.Add(lblOrderDate);
            Controls.Add(foxLabel2);
            Controls.Add(foxLabel1);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "OrderCard";
            Size = new Size(1256, 117);
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
    }
}
