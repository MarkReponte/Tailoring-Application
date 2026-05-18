namespace Dashboard.CostumizeTools
{
    partial class CostCostumerNamePopup
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
            materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            btnBackCost = new ReaLTaiizor.Controls.HopeButton();
            btnSaveCostFinal = new ReaLTaiizor.Controls.HopeButton();
            panel1 = new Panel();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            txtDescription = new ReaLTaiizor.Controls.PoisonTextBox();
            materialLabel41 = new ReaLTaiizor.Controls.MaterialLabel();
            txtCostCostumerName = new ReaLTaiizor.Controls.PoisonTextBox();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.BorderStyle = BorderStyle.FixedSingle;
            materialCard1.Controls.Add(btnBackCost);
            materialCard1.Controls.Add(btnSaveCostFinal);
            materialCard1.Controls.Add(panel1);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Controls.Add(txtDescription);
            materialCard1.Controls.Add(materialLabel41);
            materialCard1.Controls.Add(txtCostCostumerName);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14, 14, 14, 14);
            materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(1);
            materialCard1.Size = new Size(400, 200);
            materialCard1.TabIndex = 0;
            // 
            // btnBackCost
            // 
            btnBackCost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBackCost.BorderColor = Color.FromArgb(141, 182, 0);
            btnBackCost.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnBackCost.DangerColor = Color.FromArgb(245, 108, 108);
            btnBackCost.DefaultColor = Color.FromArgb(255, 255, 255);
            btnBackCost.Font = new Font("Segoe UI", 12F);
            btnBackCost.HoverTextColor = Color.FromArgb(120, 160, 0);
            btnBackCost.InfoColor = Color.FromArgb(144, 147, 153);
            btnBackCost.Location = new Point(229, 164);
            btnBackCost.Name = "btnBackCost";
            btnBackCost.PrimaryColor = Color.White;
            btnBackCost.Size = new Size(72, 23);
            btnBackCost.SuccessColor = Color.FromArgb(103, 194, 58);
            btnBackCost.TabIndex = 173;
            btnBackCost.Text = "Back";
            btnBackCost.TextColor = Color.FromArgb(141, 182, 0);
            btnBackCost.WarningColor = Color.FromArgb(230, 162, 60);
            btnBackCost.Click += btnBackCost_Click;
            // 
            // btnSaveCostFinal
            // 
            btnSaveCostFinal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveCostFinal.BorderColor = Color.FromArgb(220, 223, 230);
            btnSaveCostFinal.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnSaveCostFinal.DangerColor = Color.FromArgb(245, 108, 108);
            btnSaveCostFinal.DefaultColor = Color.FromArgb(255, 255, 255);
            btnSaveCostFinal.Font = new Font("Segoe UI", 12F);
            btnSaveCostFinal.HoverTextColor = Color.FromArgb(120, 160, 0);
            btnSaveCostFinal.InfoColor = Color.FromArgb(144, 147, 153);
            btnSaveCostFinal.Location = new Point(310, 164);
            btnSaveCostFinal.Name = "btnSaveCostFinal";
            btnSaveCostFinal.PrimaryColor = Color.FromArgb(141, 182, 0);
            btnSaveCostFinal.Size = new Size(67, 24);
            btnSaveCostFinal.SuccessColor = Color.FromArgb(103, 194, 58);
            btnSaveCostFinal.TabIndex = 172;
            btnSaveCostFinal.Text = "Save";
            btnSaveCostFinal.TextColor = Color.White;
            btnSaveCostFinal.WarningColor = Color.FromArgb(230, 162, 60);
            btnSaveCostFinal.Click += btnSaveCostFinal_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(141, 182, 0);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(19, 196);
            panel1.TabIndex = 55;
            // 
            // materialLabel1
            // 
            materialLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            materialLabel1.Location = new Point(44, 95);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(78, 17);
            materialLabel1.TabIndex = 54;
            materialLabel1.Text = "Description:";
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            txtDescription.CustomButton.Image = null;
            txtDescription.CustomButton.Location = new Point(134, 1);
            txtDescription.CustomButton.Name = "";
            txtDescription.CustomButton.Size = new Size(18, 16);
            txtDescription.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            txtDescription.CustomButton.TabIndex = 1;
            txtDescription.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            txtDescription.CustomButton.UseSelectable = true;
            txtDescription.CustomButton.Visible = false;
            txtDescription.Location = new Point(178, 93);
            txtDescription.MaxLength = 32767;
            txtDescription.Name = "txtDescription";
            txtDescription.PasswordChar = '\0';
            txtDescription.PromptText = "(e.g. Pants, Shirt)";
            txtDescription.ScrollBars = ScrollBars.None;
            txtDescription.SelectedText = "";
            txtDescription.SelectionLength = 0;
            txtDescription.SelectionStart = 0;
            txtDescription.ShortcutsEnabled = true;
            txtDescription.Size = new Size(175, 23);
            txtDescription.TabIndex = 53;
            txtDescription.UseSelectable = true;
            txtDescription.WaterMark = "(e.g. Pants, Shirt)";
            txtDescription.WaterMarkColor = Color.FromArgb(109, 109, 109);
            txtDescription.WaterMarkFont = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            // 
            // materialLabel41
            // 
            materialLabel41.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel41.AutoSize = true;
            materialLabel41.Depth = 0;
            materialLabel41.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel41.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            materialLabel41.Location = new Point(44, 66);
            materialLabel41.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel41.Name = "materialLabel41";
            materialLabel41.Size = new Size(43, 17);
            materialLabel41.TabIndex = 52;
            materialLabel41.Text = "Name:";
            // 
            // txtCostCostumerName
            // 
            // 
            // 
            // 
            txtCostCostumerName.CustomButton.Image = null;
            txtCostCostumerName.CustomButton.Location = new Point(134, 1);
            txtCostCostumerName.CustomButton.Name = "";
            txtCostCostumerName.CustomButton.Size = new Size(18, 16);
            txtCostCostumerName.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            txtCostCostumerName.CustomButton.TabIndex = 1;
            txtCostCostumerName.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            txtCostCostumerName.CustomButton.UseSelectable = true;
            txtCostCostumerName.CustomButton.Visible = false;
            txtCostCostumerName.Location = new Point(178, 64);
            txtCostCostumerName.MaxLength = 32767;
            txtCostCostumerName.Name = "txtCostCostumerName";
            txtCostCostumerName.PasswordChar = '\0';
            txtCostCostumerName.ScrollBars = ScrollBars.None;
            txtCostCostumerName.SelectedText = "";
            txtCostCostumerName.SelectionLength = 0;
            txtCostCostumerName.SelectionStart = 0;
            txtCostCostumerName.ShortcutsEnabled = true;
            txtCostCostumerName.Size = new Size(175, 23);
            txtCostCostumerName.TabIndex = 51;
            txtCostCostumerName.UseSelectable = true;
            txtCostCostumerName.WaterMarkColor = Color.FromArgb(109, 109, 109);
            txtCostCostumerName.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            // 
            // CostCostumerNamePopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 200);
            Controls.Add(materialCard1);
            Name = "CostCostumerNamePopup";
            Padding = new Padding(0);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CostCostumerNamePopup";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.PoisonTextBox txtCostCostumerName;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.PoisonTextBox txtDescription;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel41;
        private Panel panel1;
        private ReaLTaiizor.Controls.HopeButton btnSaveCostFinal;
        private ReaLTaiizor.Controls.HopeButton btnBackCost;
    }
}