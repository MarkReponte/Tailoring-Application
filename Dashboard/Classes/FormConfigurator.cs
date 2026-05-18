using ReaLTaiizor.Colors;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;

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

        public static void ConfigureOrderSummaryLabel(FoxLabel foxLabel1)
        {
            foxLabel1.BackColor = Color.Transparent;
            foxLabel1.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            foxLabel1.ForeColor = Color.FromArgb(102, 140, 48);
            foxLabel1.Size = new Size(261, 50);
            foxLabel1.Text = "Order Summary";
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
