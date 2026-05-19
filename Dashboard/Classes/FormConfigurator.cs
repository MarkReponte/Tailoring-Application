using ReaLTaiizor.Colors;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using System.Diagnostics.Metrics;

namespace Dashboard.Classes
{
    public static class FormConfigurator
    {
        public static void ConfigureMaterialSkin(MaterialForm form)
        {
            var manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(form);
            manager.Theme = MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new MaterialColorScheme(
            primary: Color.FromArgb(141, 182, 0),
            darkPrimary: Color.FromArgb(70, 95, 0),
            lightPrimary: Color.FromArgb(215, 235, 150),
            accent: Color.FromArgb(69, 98, 20),
            textShade: MaterialTextShade.WHITE
        );
    }

    public static void ConfigureInputFonts(Control txtName, ComboBox hcbGender)
    {
        Font inputFont = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
        txtName.Font = inputFont;

        hcbGender.DrawMode = DrawMode.Normal;
        hcbGender.Font = inputFont;
    }

        public static void ConfigureAccentHoverButton(MaterialButton button,
            EventHandler mouseEnter, EventHandler mouseLeave)
        {
            button.Type = MaterialButton.MaterialButtonType.Contained;
            button.HighEmphasis = true;
            button.NoAccentTextColor = Color.White;
            button.UseAccentColor = false;
            button.UseVisualStyleBackColor = true;

            button.MouseEnter -= mouseEnter;
            button.MouseLeave -= mouseLeave;
            button.MouseEnter += mouseEnter;
            button.MouseLeave += mouseLeave;

            button.Invalidate();
        }

            public static void ConfigureCostConsumptionBackground(
    Control costConsumption, MaterialCard materialCard10)
        {
            var bg = Color.FromArgb(249, 250, 252);
            costConsumption.BackColor = bg;
            if (materialCard10 == null) return;
            materialCard10.BackColor = bg;
            materialCard10.Invalidate();
        }
        public static void ConfigureDashboardLabel(MoonLabel moonLabel1,MoonLabel moonLabel2,MoonLabel moonLabel3)
        {
            moonLabel1.AutoSize = true;
            moonLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            moonLabel1.BackColor = Color.Transparent;
            moonLabel1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            moonLabel1.ForeColor = Color.Black;
            
            moonLabel1.Name = "moonLabel1";
            moonLabel1.Size = new Size(137, 30);
            moonLabel1.TabIndex = 2;
            moonLabel1.Text = "Monthly Cost";

            moonLabel2.AutoSize = true;
            moonLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            moonLabel2.BackColor = Color.Transparent;
            moonLabel2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            moonLabel2.ForeColor = Color.Black;
           
            moonLabel2.Name = "moonLabel2";
            moonLabel2.Size = new Size(175, 30);
            moonLabel2.TabIndex = 3;
            moonLabel2.Text = "Monthly Revenue";

            moonLabel3.AutoSize = true;
            moonLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            moonLabel3.BackColor = Color.Transparent;
            moonLabel3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            moonLabel3.ForeColor = Color.Black;
            
            moonLabel3.Name = "moonLabel3";
            moonLabel3.Size = new Size(111, 30);
            moonLabel3.TabIndex = 4;
            moonLabel3.Text = "Customers";
        }
        public static void ConfigureOrderSummaryLabel(FoxLabel foxLabel1, MoonLabel lblMonthlyCost, MoonLabel lblMonthlyRevenue, MoonLabel lblCustomers)
        {
            foxLabel1.BackColor = Color.Transparent;
            foxLabel1.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            foxLabel1.ForeColor = Color.FromArgb(102, 140, 48);
            foxLabel1.Size = new Size(261, 50);
            foxLabel1.Text = "Order Summary";

            lblMonthlyCost.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblMonthlyCost.AutoSize = true;
            lblMonthlyCost.BackColor = Color.Transparent;
            lblMonthlyCost.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMonthlyCost.ForeColor = Color.FromArgb(19, 121, 45); ;
            
            lblMonthlyCost.Name = "lblMonthlyCost";
            lblMonthlyCost.Size = new Size(91, 37);
            lblMonthlyCost.TabIndex = 3;
            lblMonthlyCost.Text = "₱ 0.00";

            lblMonthlyRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblMonthlyRevenue.AutoSize = true;
            lblMonthlyRevenue.BackColor = Color.Transparent;
            lblMonthlyRevenue.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMonthlyRevenue.ForeColor = Color.FromArgb(11, 103, 204);

            lblMonthlyRevenue.Name = "lblMonthlyRevenue";
            lblMonthlyRevenue.Size = new Size(91, 37);
            lblMonthlyRevenue.TabIndex = 4;
            lblMonthlyRevenue.Text = "₱ 0.00";

            lblCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblCustomers.AutoSize = true;
            lblCustomers.BackColor = Color.Transparent;
            lblCustomers.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomers.ForeColor = Color.FromArgb(21, 113, 33);

            lblCustomers.Name = "lblCustomers";
            lblCustomers.Size = new Size(32, 37);
            lblCustomers.TabIndex = 5;
            lblCustomers.Text = "0";
        }
        public static void FormPadding(MaterialCard materialCard10, MaterialCard mcMeasurement)
        {
            materialCard10.Padding = new Padding(0);
            mcMeasurement.Padding = new Padding(0, 17, 0, 0);
        }
        public static void ConfigureCostButtonPreview(MaterialCard materialCard10)
        {
            if (materialCard10 == null) return;

            var costButton = materialCard10.Controls
                .Find("button1", false)
                .FirstOrDefault() as System.Windows.Forms.Button;

            if (costButton == null) return;

            costButton.UseVisualStyleBackColor = false;
            costButton.FlatStyle = FlatStyle.Flat;
            costButton.BackColor = Color.Blue;
            costButton.ForeColor = Color.White;
            costButton.FlatAppearance.BorderSize = 0;
            costButton.FlatAppearance.MouseOverBackColor = Color.RoyalBlue;
            costButton.FlatAppearance.MouseDownBackColor = Color.Navy;
            costButton.BringToFront();
        }
    }
    }
