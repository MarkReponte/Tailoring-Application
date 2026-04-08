using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Dashboard
{
    public partial class dashboardPanel : MaterialForm
    {
        public dashboardPanel()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            // Theme and color scheme
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(
                MaterialSkin.Primary.Blue600,
                MaterialSkin.Primary.Blue700,
                MaterialSkin.Primary.Blue200,
                MaterialSkin.Accent.LightBlue200,
                MaterialSkin.TextShade.WHITE
            );

            // Create and add the custom sidebar menu (left dock)
            CreateSidebarMenu();

            this.DrawerTabControl = materialTabControl;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerUseColors = true;
            this.materialTabControl.ImageList = imageList;
            this.materialTabControl.TabPages[0].ImageKey = "dashboard.png";
            this.materialTabControl.TabPages[1].ImageKey = "order.png";
            // keep remaining tab images set in Designer

            // materialTabControl.BringToFront(); // not needed since the sidebar is docked left
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        // ---- Sidebar/menu implementation ----
        private void CreateSidebarMenu()
        {
            // Sidebar container: left docked so materialTabControl (Dock=Fill) fills remaining area
            Panel sidebarMenu = new Panel
            {
                Dock = DockStyle.Left,
                Width = 256,
                BackColor = Color.FromArgb(18, 18, 18) // dark background to match typical sidebar
            };

            // Common fonts (fallback to default if Inter is not available)
            Font menuFontRegular = new Font("Inter", 14, FontStyle.Regular);
            Font menuFontBold = new Font("Inter", 14, FontStyle.Bold);

            // Create buttons that correspond to existing tab pages
            Button btnDashboard = CreateMenuItem("Dashboard", new Point(0, 0), menuFontBold, Color.White, sidebarMenu.BackColor);
            Button btnOrder = CreateMenuItem("Order", new Point(0, 50), menuFontRegular, Color.FromArgb(180, 180, 180), sidebarMenu.BackColor);
            Button btnBodyMeasurement = CreateMenuItem("Body Measurement", new Point(0, 100), menuFontRegular, Color.FromArgb(180, 180, 180), sidebarMenu.BackColor);
            Button btnCost = CreateMenuItem("Cost Consumption", new Point(0, 150), menuFontRegular, Color.FromArgb(180, 180, 180), sidebarMenu.BackColor);
            Button btnRevenue = CreateMenuItem("Revenue", new Point(0, 200), menuFontRegular, Color.FromArgb(180, 180, 180), sidebarMenu.BackColor);

            // Wire clicks to switch tabs (indexes defined in Designer)
            btnDashboard.Click += (s, e) => SelectTabByIndex(0, btnDashboard);
            btnOrder.Click += (s, e) => SelectTabByIndex(1, btnOrder);
            btnBodyMeasurement.Click += (s, e) => SelectTabByIndex(2, btnBodyMeasurement);
            btnCost.Click += (s, e) => SelectTabByIndex(3, btnCost);
            btnRevenue.Click += (s, e) => SelectTabByIndex(4, btnRevenue);

            // Add buttons to sidebar
            sidebarMenu.Controls.Add(btnDashboard);
            sidebarMenu.Controls.Add(btnOrder);
            sidebarMenu.Controls.Add(btnBodyMeasurement);
            sidebarMenu.Controls.Add(btnCost);
            sidebarMenu.Controls.Add(btnRevenue);

            // Add sidebar to form (left-docked)
            // Insert before materialTabControl so docking layout stays predictable
            this.Controls.Add(sidebarMenu);
            sidebarMenu.BringToFront();

            // Mark initial selection to match the initial tab
            HighlightSelectedButton(btnDashboard);
        }

        private Button CreateMenuItem(string text, Point location, Font font, Color foreColor, Color backColor)
        {
            Button btn = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(256, 44),
                Font = font,
                ForeColor = foreColor,
                BackColor = backColor,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(16, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void SelectTabByIndex(int tabIndex, Button clickedButton)
        {
            if (materialTabControl != null && tabIndex >= 0 && tabIndex < materialTabControl.TabCount)
            {
                materialTabControl.SelectedIndex = tabIndex;
                HighlightSelectedButton(clickedButton);
            }
        }

        private void HighlightSelectedButton(Button active)
        {
            // Iterate sidebar children; set default and highlight the active button
            foreach (Control c in this.Controls)
            {
                if (c is Panel panel && panel.Dock == DockStyle.Left)
                {
                    foreach (Control child in panel.Controls)
                    {
                        if (child is Button b)
                        {
                            // default style
                            b.BackColor = panel.BackColor;
                            b.ForeColor = Color.FromArgb(180, 180, 180);
                            b.Font = new Font(b.Font, FontStyle.Regular);
                        }
                    }

                    // highlight selected
                    if (active != null)
                    {
                        active.BackColor = Color.FromArgb(206, 208, 248); // light highlight
                        active.ForeColor = Color.FromArgb(44, 53, 224);    // accent text color
                        active.Font = new Font(active.Font, FontStyle.Bold);
                    }

                    return;
                }
            }
        }
    }
}
