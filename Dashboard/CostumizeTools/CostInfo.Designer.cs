namespace Dashboard.CostumizeTools
{
    partial class CostInfo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            lblDescription = new ReaLTaiizor.Controls.MaterialLabel();
            lblCostumerName = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            panel1 = new Panel();
            btnBackToComputationHistory = new ReaLTaiizor.Controls.HopeButton();
            pictureBox3 = new PictureBox();
            lblOrderHistory = new ReaLTaiizor.Controls.MaterialLabel();
            groupBox1 = new ReaLTaiizor.Controls.GroupBox();
            lblTotalLaborSaved = new ReaLTaiizor.Controls.PoisonLabel();
            lblQuantitySaved = new ReaLTaiizor.Controls.PoisonLabel();
            lblLaborCostSaved = new ReaLTaiizor.Controls.PoisonLabel();
            lblMaterialTotalSaved = new ReaLTaiizor.Controls.PoisonLabel();
            lblGrandTotalCostSaved = new ReaLTaiizor.Controls.PoisonLabel();
            materialLabel64 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel63 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel62 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel61 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel60 = new ReaLTaiizor.Controls.MaterialLabel();
            dgvMaterialListSaved = new ReaLTaiizor.Controls.PoisonDataGridView();
            colItem = new DataGridViewTextBoxColumn();
            ColMeters = new DataGridViewTextBoxColumn();
            colPricePerMeter = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            materialCard1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterialListSaved).BeginInit();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.BorderStyle = BorderStyle.FixedSingle;
            materialCard1.Controls.Add(lblDescription);
            materialCard1.Controls.Add(lblCostumerName);
            materialCard1.Controls.Add(materialLabel2);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Controls.Add(panel1);
            materialCard1.Controls.Add(groupBox1);
            materialCard1.Controls.Add(dgvMaterialListSaved);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(1);
            materialCard1.Size = new Size(750, 370);
            materialCard1.TabIndex = 0;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Depth = 0;
            lblDescription.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblDescription.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            lblDescription.Location = new Point(281, 73);
            lblDescription.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(74, 17);
            lblDescription.TabIndex = 168;
            lblDescription.Text = "Description";
            // 
            // lblCostumerName
            // 
            lblCostumerName.AutoSize = true;
            lblCostumerName.Depth = 0;
            lblCostumerName.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblCostumerName.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            lblCostumerName.Location = new Point(60, 73);
            lblCostumerName.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblCostumerName.Name = "lblCostumerName";
            lblCostumerName.Size = new Size(104, 17);
            lblCostumerName.TabIndex = 167;
            lblCostumerName.Text = "Costumer Name";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel2.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            materialLabel2.Location = new Point(197, 73);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(78, 17);
            materialLabel2.TabIndex = 166;
            materialLabel2.Text = "Description:";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            materialLabel1.Location = new Point(11, 73);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(43, 17);
            materialLabel1.TabIndex = 165;
            materialLabel1.Text = "Name:";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnBackToComputationHistory);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(lblOrderHistory);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(746, 50);
            panel1.TabIndex = 164;
            // 
            // btnBackToComputationHistory
            // 
            btnBackToComputationHistory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBackToComputationHistory.BorderColor = Color.FromArgb(220, 223, 230);
            btnBackToComputationHistory.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnBackToComputationHistory.DangerColor = Color.FromArgb(245, 108, 108);
            btnBackToComputationHistory.DefaultColor = Color.FromArgb(255, 255, 255);
            btnBackToComputationHistory.Font = new Font("Segoe UI", 12F);
            btnBackToComputationHistory.HoverTextColor = Color.FromArgb(120, 160, 0);
            btnBackToComputationHistory.InfoColor = Color.FromArgb(144, 147, 153);
            btnBackToComputationHistory.Location = new Point(654, 11);
            btnBackToComputationHistory.Name = "btnBackToComputationHistory";
            btnBackToComputationHistory.PrimaryColor = Color.FromArgb(141, 182, 0);
            btnBackToComputationHistory.Size = new Size(67, 24);
            btnBackToComputationHistory.SuccessColor = Color.FromArgb(103, 194, 58);
            btnBackToComputationHistory.TabIndex = 172;
            btnBackToComputationHistory.Text = "Back";
            btnBackToComputationHistory.TextColor = Color.White;
            btnBackToComputationHistory.WarningColor = Color.FromArgb(230, 162, 60);
            btnBackToComputationHistory.Click += btnBackToComputationHistory_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.dashboard;
            pictureBox3.Location = new Point(8, 7);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(34, 35);
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // lblOrderHistory
            // 
            lblOrderHistory.AutoSize = true;
            lblOrderHistory.Depth = 0;
            lblOrderHistory.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblOrderHistory.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle1;
            lblOrderHistory.Location = new Point(48, 16);
            lblOrderHistory.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            lblOrderHistory.Name = "lblOrderHistory";
            lblOrderHistory.Size = new Size(120, 19);
            lblOrderHistory.TabIndex = 8;
            lblOrderHistory.Text = "Cost Information";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.BackColor = Color.Transparent;
            groupBox1.BackGColor = Color.Transparent;
            groupBox1.BaseColor = Color.Transparent;
            groupBox1.BorderColorG = Color.FromArgb(159, 159, 161);
            groupBox1.BorderColorH = Color.FromArgb(182, 180, 186);
            groupBox1.Controls.Add(lblTotalLaborSaved);
            groupBox1.Controls.Add(lblQuantitySaved);
            groupBox1.Controls.Add(lblLaborCostSaved);
            groupBox1.Controls.Add(lblMaterialTotalSaved);
            groupBox1.Controls.Add(lblGrandTotalCostSaved);
            groupBox1.Controls.Add(materialLabel64);
            groupBox1.Controls.Add(materialLabel63);
            groupBox1.Controls.Add(materialLabel62);
            groupBox1.Controls.Add(materialLabel61);
            groupBox1.Controls.Add(materialLabel60);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.HeaderColor = Color.FromArgb(141, 182, 0);
            groupBox1.Location = new Point(422, 57);
            groupBox1.MinimumSize = new Size(136, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 28, 5, 5);
            groupBox1.Size = new Size(300, 300);
            groupBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            groupBox1.TabIndex = 163;
            groupBox1.Text = "Order Summary";
            // 
            // lblTotalLaborSaved
            // 
            lblTotalLaborSaved.AutoSize = true;
            lblTotalLaborSaved.Location = new Point(187, 161);
            lblTotalLaborSaved.Name = "lblTotalLaborSaved";
            lblTotalLaborSaved.Size = new Size(40, 19);
            lblTotalLaborSaved.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Green;
            lblTotalLaborSaved.TabIndex = 174;
            lblTotalLaborSaved.Text = "0,000";
            lblTotalLaborSaved.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            // 
            // lblQuantitySaved
            // 
            lblQuantitySaved.AutoSize = true;
            lblQuantitySaved.Location = new Point(187, 125);
            lblQuantitySaved.Name = "lblQuantitySaved";
            lblQuantitySaved.Size = new Size(40, 19);
            lblQuantitySaved.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Green;
            lblQuantitySaved.TabIndex = 173;
            lblQuantitySaved.Text = "0,000";
            lblQuantitySaved.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            // 
            // lblLaborCostSaved
            // 
            lblLaborCostSaved.AutoSize = true;
            lblLaborCostSaved.Location = new Point(187, 91);
            lblLaborCostSaved.Name = "lblLaborCostSaved";
            lblLaborCostSaved.Size = new Size(40, 19);
            lblLaborCostSaved.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Green;
            lblLaborCostSaved.TabIndex = 172;
            lblLaborCostSaved.Text = "0,000";
            lblLaborCostSaved.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            // 
            // lblMaterialTotalSaved
            // 
            lblMaterialTotalSaved.AutoSize = true;
            lblMaterialTotalSaved.Location = new Point(187, 53);
            lblMaterialTotalSaved.Name = "lblMaterialTotalSaved";
            lblMaterialTotalSaved.Size = new Size(40, 19);
            lblMaterialTotalSaved.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Green;
            lblMaterialTotalSaved.TabIndex = 171;
            lblMaterialTotalSaved.Text = "0,000";
            lblMaterialTotalSaved.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            // 
            // lblGrandTotalCostSaved
            // 
            lblGrandTotalCostSaved.AutoSize = true;
            lblGrandTotalCostSaved.FontSize = ReaLTaiizor.Extension.Poison.PoisonLabelSize.Tall;
            lblGrandTotalCostSaved.Location = new Point(117, 247);
            lblGrandTotalCostSaved.Name = "lblGrandTotalCostSaved";
            lblGrandTotalCostSaved.Size = new Size(52, 25);
            lblGrandTotalCostSaved.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Green;
            lblGrandTotalCostSaved.TabIndex = 170;
            lblGrandTotalCostSaved.Text = "0,000";
            lblGrandTotalCostSaved.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            // 
            // materialLabel64
            // 
            materialLabel64.AutoSize = true;
            materialLabel64.Depth = 0;
            materialLabel64.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel64.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            materialLabel64.Location = new Point(13, 205);
            materialLabel64.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel64.Name = "materialLabel64";
            materialLabel64.Size = new Size(113, 17);
            materialLabel64.TabIndex = 169;
            materialLabel64.Text = "Grand Total Cost:";
            // 
            // materialLabel63
            // 
            materialLabel63.AutoSize = true;
            materialLabel63.Depth = 0;
            materialLabel63.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel63.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            materialLabel63.Location = new Point(13, 163);
            materialLabel63.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel63.Name = "materialLabel63";
            materialLabel63.Size = new Size(79, 17);
            materialLabel63.TabIndex = 167;
            materialLabel63.Text = "Total Labor:";
            // 
            // materialLabel62
            // 
            materialLabel62.AutoSize = true;
            materialLabel62.Depth = 0;
            materialLabel62.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel62.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            materialLabel62.Location = new Point(13, 127);
            materialLabel62.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel62.Name = "materialLabel62";
            materialLabel62.Size = new Size(60, 17);
            materialLabel62.TabIndex = 165;
            materialLabel62.Text = "Quantity:";
            // 
            // materialLabel61
            // 
            materialLabel61.AutoSize = true;
            materialLabel61.Depth = 0;
            materialLabel61.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel61.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            materialLabel61.Location = new Point(13, 91);
            materialLabel61.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel61.Name = "materialLabel61";
            materialLabel61.Size = new Size(126, 17);
            materialLabel61.TabIndex = 163;
            materialLabel61.Text = "Labor Cost (per pc):";
            // 
            // materialLabel60
            // 
            materialLabel60.AutoSize = true;
            materialLabel60.Depth = 0;
            materialLabel60.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel60.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            materialLabel60.Location = new Point(13, 56);
            materialLabel60.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel60.Name = "materialLabel60";
            materialLabel60.Size = new Size(96, 17);
            materialLabel60.TabIndex = 162;
            materialLabel60.Text = "Material Total:";
            // 
            // dgvMaterialListSaved
            // 
            dgvMaterialListSaved.AllowUserToOrderColumns = true;
            dgvMaterialListSaved.AllowUserToResizeRows = false;
            dgvMaterialListSaved.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvMaterialListSaved.BorderStyle = BorderStyle.None;
            dgvMaterialListSaved.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvMaterialListSaved.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(141, 182, 0);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(141, 182, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMaterialListSaved.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMaterialListSaved.ColumnHeadersHeight = 40;
            dgvMaterialListSaved.Columns.AddRange(new DataGridViewColumn[] { colItem, ColMeters, colPricePerMeter, colTotal });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(141, 182, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMaterialListSaved.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMaterialListSaved.EnableHeadersVisualStyles = false;
            dgvMaterialListSaved.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvMaterialListSaved.GridColor = Color.FromArgb(141, 182, 0);
            dgvMaterialListSaved.Location = new Point(11, 110);
            dgvMaterialListSaved.Name = "dgvMaterialListSaved";
            dgvMaterialListSaved.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvMaterialListSaved.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMaterialListSaved.RowHeadersVisible = false;
            dgvMaterialListSaved.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvMaterialListSaved.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterialListSaved.Size = new Size(385, 247);
            dgvMaterialListSaved.TabIndex = 162;
            // 
            // colItem
            // 
            colItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colItem.HeaderText = "Item";
            colItem.Name = "colItem";
            // 
            // ColMeters
            // 
            ColMeters.HeaderText = "Meters";
            ColMeters.Name = "ColMeters";
            ColMeters.Width = 80;
            // 
            // colPricePerMeter
            // 
            colPricePerMeter.HeaderText = "Price per meter";
            colPricePerMeter.Name = "colPricePerMeter";
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            // 
            // CostInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 370);
            Controls.Add(materialCard1);
            Name = "CostInfo";
            Padding = new Padding(0);
            Text = "CostInfo";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterialListSaved).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvMaterialListSaved;
        private DataGridViewTextBoxColumn colItem;
        private DataGridViewTextBoxColumn ColMeters;
        private DataGridViewTextBoxColumn colPricePerMeter;
        private DataGridViewTextBoxColumn colTotal;
        private ReaLTaiizor.Controls.GroupBox groupBox1;
        private ReaLTaiizor.Controls.PoisonLabel lblGrandTotalCostSaved;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel64;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel63;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel62;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel61;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel60;
        private Panel panel1;
        private PictureBox pictureBox3;
        private ReaLTaiizor.Controls.MaterialLabel lblOrderHistory;
        private ReaLTaiizor.Controls.HopeButton btnBackToComputationHistory;
        private ReaLTaiizor.Controls.MaterialLabel lblDescription;
        private ReaLTaiizor.Controls.MaterialLabel lblCostumerName;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.PoisonLabel lblTotalLaborSaved;
        private ReaLTaiizor.Controls.PoisonLabel lblQuantitySaved;
        private ReaLTaiizor.Controls.PoisonLabel lblLaborCostSaved;
        private ReaLTaiizor.Controls.PoisonLabel lblMaterialTotalSaved;
    }
}