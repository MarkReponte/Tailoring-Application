namespace Dashboard.CostumizeTools
{
    partial class CostCard
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
            lblDescription = new ReaLTaiizor.Controls.FoxLabel();
            poison = new ReaLTaiizor.Controls.FoxLabel();
            lblCustomerNameCost = new ReaLTaiizor.Controls.SkyLabel();
            panel1 = new Panel();
            foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
            lblDateSaved = new ReaLTaiizor.Controls.FoxLabel();
            lblGrandTotal = new ReaLTaiizor.Controls.FoxLabel();
            foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
            hopeRoundButton1 = new ReaLTaiizor.Controls.HopeRoundButton();
            SuspendLayout();
            // 
            // lblDescription
            // 
            lblDescription.BackColor = Color.Transparent;
            lblDescription.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.FromArgb(64, 64, 64);
            lblDescription.Location = new Point(465, 15);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(284, 19);
            lblDescription.TabIndex = 19;
            lblDescription.Text = "e.g. Pants, Blouse";
            // 
            // poison
            // 
            poison.BackColor = Color.Transparent;
            poison.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            poison.ForeColor = Color.FromArgb(120, 120, 120);
            poison.Location = new Point(380, 15);
            poison.Name = "poison";
            poison.Size = new Size(79, 19);
            poison.TabIndex = 18;
            poison.Text = "Description:";
            // 
            // lblCustomerNameCost
            // 
            lblCustomerNameCost.AutoSize = true;
            lblCustomerNameCost.BackColor = Color.White;
            lblCustomerNameCost.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerNameCost.ForeColor = Color.Black;
            lblCustomerNameCost.Location = new Point(47, 15);
            lblCustomerNameCost.Name = "lblCustomerNameCost";
            lblCustomerNameCost.Size = new Size(71, 30);
            lblCustomerNameCost.TabIndex = 17;
            lblCustomerNameCost.Text = "Name";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(141, 182, 0);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 88);
            panel1.TabIndex = 20;
            // 
            // foxLabel1
            // 
            foxLabel1.BackColor = Color.Transparent;
            foxLabel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            foxLabel1.ForeColor = Color.FromArgb(120, 120, 120);
            foxLabel1.Location = new Point(50, 52);
            foxLabel1.Name = "foxLabel1";
            foxLabel1.Size = new Size(68, 19);
            foxLabel1.TabIndex = 12;
            foxLabel1.Text = "Date Saved:";
            // 
            // lblDateSaved
            // 
            lblDateSaved.BackColor = Color.Transparent;
            lblDateSaved.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDateSaved.ForeColor = Color.FromArgb(64, 64, 64);
            lblDateSaved.Location = new Point(124, 52);
            lblDateSaved.Name = "lblDateSaved";
            lblDateSaved.Size = new Size(68, 19);
            lblDateSaved.TabIndex = 14;
            lblDateSaved.Text = "00/00/00";
            // 
            // lblGrandTotal
            // 
            lblGrandTotal.BackColor = Color.Transparent;
            lblGrandTotal.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGrandTotal.ForeColor = Color.FromArgb(64, 64, 64);
            lblGrandTotal.Location = new Point(465, 52);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(68, 19);
            lblGrandTotal.TabIndex = 15;
            lblGrandTotal.Text = "0000";
            // 
            // foxLabel2
            // 
            foxLabel2.BackColor = Color.Transparent;
            foxLabel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            foxLabel2.ForeColor = Color.FromArgb(120, 120, 120);
            foxLabel2.Location = new Point(380, 52);
            foxLabel2.Name = "foxLabel2";
            foxLabel2.Size = new Size(79, 19);
            foxLabel2.TabIndex = 21;
            foxLabel2.Text = "Grand Total:";
            // 
            // hopeRoundButton1
            // 
            hopeRoundButton1.BorderColor = Color.FromArgb(220, 223, 230);
            hopeRoundButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeRoundButton1.DangerColor = Color.FromArgb(245, 108, 108);
            hopeRoundButton1.DefaultColor = Color.FromArgb(255, 255, 255);
            hopeRoundButton1.Font = new Font("Segoe UI", 12F);
            hopeRoundButton1.HoverTextColor = Color.Red;
            hopeRoundButton1.InfoColor = Color.FromArgb(144, 147, 153);
            hopeRoundButton1.Location = new Point(722, 25);
            hopeRoundButton1.Name = "hopeRoundButton1";
            hopeRoundButton1.PrimaryColor = Color.FromArgb(255, 128, 128);
            hopeRoundButton1.Size = new Size(39, 39);
            hopeRoundButton1.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeRoundButton1.TabIndex = 22;
            hopeRoundButton1.Text = "x";
            hopeRoundButton1.TextColor = Color.White;
            hopeRoundButton1.WarningColor = Color.FromArgb(230, 162, 60);
            hopeRoundButton1.Click += hopeRoundButton1_Click;
            // 
            // CostCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(hopeRoundButton1);
            Controls.Add(foxLabel2);
            Controls.Add(panel1);
            Controls.Add(lblDescription);
            Controls.Add(poison);
            Controls.Add(lblCustomerNameCost);
            Controls.Add(lblGrandTotal);
            Controls.Add(lblDateSaved);
            Controls.Add(foxLabel1);
            Name = "CostCard";
            Size = new Size(797, 88);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ReaLTaiizor.Controls.FoxLabel lblDescription;
        private ReaLTaiizor.Controls.FoxLabel poison;
        public ReaLTaiizor.Controls.SkyLabel lblCustomerNameCost;
        private Panel panel1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
        public ReaLTaiizor.Controls.FoxLabel lblDateSaved;
        public ReaLTaiizor.Controls.FoxLabel lblGrandTotal;
        private ReaLTaiizor.Controls.FoxLabel foxLabel2;
        private ReaLTaiizor.Controls.HopeRoundButton hopeRoundButton1;
    }
}
