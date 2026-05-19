using AppDomain.Models;
using AppInfrastructure.Data;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Dashboard.CostumizeTools;
using AppInfrastructure.Repository;
using Dashboard.Classes;
using AppInfrastructure.IRepository;
using System.Runtime.CompilerServices;
using System.Formats.Nrbf;


namespace Dashboard
{
    public partial class Form1 : MaterialForm
    {
        public static DashboardController GlobalDashboardController { get; private set; } = null!;
        private Label notificationBadge = null!;
        private System.Windows.Forms.Timer badgeFlashTimer = null!;
        private bool flashState = false;
        private readonly MeasurementRepository _measurementRepo;
        private readonly CostRepository _costRepo;
        private readonly OrderValidator _validator;
        private readonly GalleryService _galleryService;
        private readonly NotificationPopup _notificationPopup;
        private DashboardService _dashboardService;
        private DashboardController _dashboardController;

        private static void ShowWarning(string msg) =>
            MessageBox.Show(msg, "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void ShowError(string msg) =>
            MessageBox.Show(msg, "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);


        public Form1()
        {
            InitializeComponent();
            
            _notificationPopup = new NotificationPopup();
            _measurementRepo = new MeasurementRepository(new SewingDbContext());
            _costRepo = new CostRepository(new CostDBContext());
            _validator = new OrderValidator(ShowWarning, ShowError);
            _galleryService = new GalleryService();
            _dashboardService = new DashboardService(_measurementRepo, _costRepo);
            _dashboardController = new DashboardController(_dashboardService);
            GlobalDashboardController = _dashboardController;
            SetupNotificationBadge();
            SetupBadgeAnimation();

            NotificationManager.NotificationAdded += () =>
            {
                RunOnUiThread(() =>
                {
                    UpdateNotificationBadge();
                    ShowNotificationPopup(btnNotification);
                });
            };

            NotificationManager.NotificationChanged += () =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(UpdateNotificationBadge));
                }
                else
                {
                    UpdateNotificationBadge();
                }
            };
            FormConfigurator.ConfigureMaterialSkin(this);
        }

        
        private async void Form1_Load(object sender, EventArgs e)
        {

            this.Controls.Add(notificationBadge);
            this.ClientSize = new Size(1360, 768);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.None;
            UpdateNotificationBadge();
           
            materialCard10.Padding = new Padding(0);
            mcMeasurement.Padding = new Padding(0, 17, 0, 0);

            FormConfigurator.ConfigureCostConsumptionBackground(CostConsumption, materialCard10);

            FormConfigurator.ConfigureDashboardLabel(moonLabel1, moonLabel2, moonLabel3);
            FormConfigurator.ConfigureOrderSummaryLabel(foxLabel1, lblMonthlyCost, lblMonthlyRevenue, lblCustomers);
            FormConfigurator.ConfigureInputFonts(txtName, hcbGender);
            FormConfigurator.ConfigureCostButtonPreview(materialCard10);
            FormConfigurator.ConfigureAccentHoverButton(btnSaveCost, CostMaterialButton_MouseEnter, CostMaterialButton_MouseLeave);
            FormConfigurator.ConfigureAccentHoverButton(btnCostHistory, CostMaterialButton_MouseEnter, CostMaterialButton_MouseLeave);

            btnOrderHistory.Font = new Font("Segoe UI", 11f, FontStyle.Bold);


            try
            {
                TriggerDashboardView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Initial dashboard calculation failed: {ex.Message}", "Dashboard Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            await LoadActiveOrderAsync();
            await LoadSavedDesignsAsync();
            await LoadOrdersFromDatabaseAsync();

        }

        private void SetupNotificationBadge()
        {
            notificationBadge = new Label();

            notificationBadge.Size = new Size(22, 22);
            notificationBadge.BackColor = Color.Red;
            notificationBadge.ForeColor = Color.White;
            notificationBadge.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            notificationBadge.TextAlign = ContentAlignment.MiddleCenter;
            notificationBadge.Visible = false;
            notificationBadge.Region = CreateRoundRegion(notificationBadge.Width, notificationBadge.Height);

            // CHANGE btnNotification TO YOUR BELL BUTTON NAME
            notificationBadge.Location = new Point(
                btnNotification.Left + 20,
                btnNotification.Top - 5
            );

            notificationBadge.BringToFront();

            this.Controls.Add(notificationBadge);
        }

        private static Region CreateRoundRegion(int width, int height)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, width, height);
            return new Region(path);
        }

        private void SetupBadgeAnimation()
        {
            badgeFlashTimer = new System.Windows.Forms.Timer();
            badgeFlashTimer.Interval = 420;

            badgeFlashTimer.Tick += (s, e) =>
            {
                if (!notificationBadge.Visible)
                {
                    badgeFlashTimer.Stop();
                    return;
                }

                flashState = !flashState;

                if (flashState)
                {
                    notificationBadge.BackColor = Color.FromArgb(230, 0, 35);
                }
                else
                {
                    notificationBadge.BackColor = Color.FromArgb(160, 0, 25);
                }
            };
        }
        private void UpdateNotificationBadge()
        {
            int count = Dashboard.Classes.NotificationManager.UnreadCount();

            notificationBadge.Text = count > 99 ? "99+" : count.ToString();

            notificationBadge.Visible = count > 0;

            if (count > 0 && !badgeFlashTimer.Enabled)
            {
                badgeFlashTimer.Start();
            }
            else if (count == 0)
            {
                badgeFlashTimer.Stop();
                notificationBadge.BackColor = Color.FromArgb(230, 0, 35);
                flashState = false;
            }
        }

        private void RunOnUiThread(Action action)
        {
            if (IsDisposed) return;

            if (InvokeRequired)
            {
                Invoke(action);
                return;
            }

            action();
        }

        private void ShowNotificationPopup(Control anchorButton)
        {
            if (!Visible || IsDisposed) return;

            _notificationPopup.LoadNotifications();
            _notificationPopup.ShowPopup(this, anchorButton);
        }
        private void mtcSelectionControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mtcSelectionControl.SelectedTab == MainDashboard)
            {
               TriggerDashboardView();
            }
        }

        private async void TriggerDashboardView()
        {
            await _dashboardController.ShowAndLoadDashboardAsync(mtcSelectionControl, MainDashboard, lblCustomers, lblMonthlyRevenue, lblMonthlyCost, dgvReport);
        }

        private void CostMaterialButton_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is MaterialButton btn) { btn.UseAccentColor = true; btn.Invalidate(); }
        }

        private void CostMaterialButton_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is MaterialButton btn) { btn.UseAccentColor = false; btn.Invalidate(); }
        }


        private void dashboardPanel_Load(object sender, EventArgs e)
        {
            hcbSearch.Text = "Search...";
            hcbSearch.ForeColor = Color.FromArgb(150, 150, 150);
            this.ActiveControl = null;
        }

        private void cboSearch_Enter(object sender, EventArgs e)
        {
            hcbSearch.Select(0, 0);
            if (hcbSearch.Text == "Search...")
            {
                hcbSearch.Text = "";
                hcbSearch.ForeColor = Color.Black;
            }
        }

        private void cboSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hcbSearch.Text))
            {
                hcbSearch.Text = "Search...";
                hcbSearch.ForeColor = Color.FromArgb(150, 150, 150);
            }
        }

        private void hcbSearch_TextChanged(object sender, EventArgs e)
        {
            string search = hcbSearch.Text.Trim().ToLower();
            bool showAll = string.IsNullOrWhiteSpace(search) || search == "search...";

            flpOrderList.SuspendLayout();
            foreach (Control c in flpOrderList.Controls)
            {
                if (c is OrderCard card)
                    c.Visible = showAll || card.MatchesSearch(search);
            }
            flpOrderList.ResumeLayout();
        }

        private void hcbSearch_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            using var font = new Font("Segoe UI", 18F);
            using var brush = new SolidBrush(e.ForeColor);
            e.Graphics.DrawString(hcbSearch.Items[e.Index].ToString(), font, brush, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void hcbGender_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Bounds.Width <= 0 || e.Bounds.Height <= 0) return;

            ComboBox? cb = sender as ComboBox;
            Font font = cb?.Font ?? hcbGender.Font;
            string text = cb?.Items[e.Index]?.ToString() ?? string.Empty;
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color back = selected ? SystemColors.Highlight : hcbGender.BackColor;
            Color fore = selected ? SystemColors.HighlightText : hcbGender.ForeColor;

            using var bg = new SolidBrush(back);
            e.Graphics.FillRectangle(bg, e.Bounds);
            using var br = new SolidBrush(fore);
            e.Graphics.DrawString(text, font, br,
                new PointF(e.Bounds.Left + 4, e.Bounds.Top + (e.Bounds.Height - font.Height) / 2f));
        }


        private void btnNotification_Click(object sender, EventArgs e)
        {
            if (_notificationPopup.Visible)
            {
                _notificationPopup.HidePopup();
                return;
            }

            ShowNotificationPopup(btnNotification);
        }

        private void btnNotificationOrder_Click(object sender, EventArgs e) => _notificationPopup.ShowPopup(this, btnNotificationOrder);

        private void btnNotificationBodyMeasurement_Click(object sender, EventArgs e) => _notificationPopup.ShowPopup(this, btnNotificationBodyMeasurement);

        private void btnNotificationCostConsumption_Click(object sender, EventArgs e) => _notificationPopup.ShowPopup(this, btnNotificationCostConsumption);

        private void btnNotificationRevenue_Click(object sender, EventArgs e) => _notificationPopup.ShowPopup(this, btnNotificationDesign);

        private void btnCloseNotification_Click(object sender, EventArgs e) => pnlNotification.Visible = false;


        private readonly int _targetHeight = 400;

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (pnlNotification.Height < 410)
                pnlNotification.Height += 50;
            else
            {
                pnlNotification.Height = _targetHeight;
                animationTimer.Stop();
            }
        }


        private void FlwpnlOrderList_MouseEnter(object sender, EventArgs e) => flpOrderList.Focus();

        private async Task LoadActiveOrderAsync()
        {
            flpOrderList.Controls.Clear();
            try
            {
                var orders = await _measurementRepo.GetActiveOrdersAsync();
                foreach (var m in orders)
                    flpOrderList.Controls.Add(BuildOrderCard(m));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading active orders: {ex.Message}");
            }
        }

        private async Task LoadOrdersFromDatabaseAsync()
        {
            flpOrderList.Controls.Clear();
            try
            {
                using var db = new SewingDbContext();
                var savedOrders = await db.Measurements
                    .Where(m => m.Status != "Completed")
                    .ToListAsync();

                foreach (var m in savedOrders)
                    flpOrderList.Controls.Add(BuildOrderCard(m));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load orders: {ex.Message}");
            }
        }

        private static OrderCard BuildOrderCard(Measurements m) => new OrderCard
        {
            CustomerName = m.CustomerName,
            Gender = m.Gender,
            Deadline = m.OrderDeadline.ToString("MM/dd/yy"),
            OrderDate = m.DateCreated.ToString("MM/dd/yy"),
            AllMeasurements = MeasurementFormatter.ToDisplayString(m),
            MeasurementId = new object[] { m.Id }
        };


        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!_validator.Validate(
                    txtName.Text,
                    hcbGender.SelectedItem,
                    pdtOrderDeadline.Value))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                var measurements = BuildMeasurementsModel();
                await _measurementRepo.AddAsync(measurements);
                await _measurementRepo.SaveAsync();

                flpOrderList.Controls.Add(BuildOrderCard(measurements));
                NotificationManager.AddNotification(
                    "New order created",
                    $"{measurements.CustomerName}'s body measurements were saved.");
            }
            catch (Exception ex)
            {
                Exception real = ex;
                while (real.InnerException != null) real = real.InnerException;
                MessageBox.Show($"Actual SQL Error: {real.Message}");
            }

            ClearForm();
        }

        private Measurements BuildMeasurementsModel() => new Measurements
        {
            CustomerName = txtName.Text,
            Gender = hcbGender.SelectedItem.ToString(),
            OrderDeadline = pdtOrderDeadline.Value.Date,
            Status = "In Progress",
            Shoulder = GetCyberValue(txtShoulder),
            ArmCircumference = GetCyberValue(txtArmCircumference),
            FrontFigure = GetCyberValue(txtFrontFigure),
            UpperBust = GetCyberValue(txtUpperBust),
            Bust = GetCyberValue(txtBust),
            LowerBust = GetCyberValue(txtLowerBust),
            BackFigure = GetCyberValue(txtBackFigure),
            FrontChest = GetCyberValue(txtFrontChest),
            BackChest = GetCyberValue(txtBackChest),
            UpperHips = GetCyberValue(txtUpperHips),
            Waistline = GetCyberValue(txtWaistline),
            NeckDip = GetCyberValue(txtNeckDip),
            ArmHole = GetCyberValue(txtArmHole),
            SleeveLength = GetCyberValue(txtSleeveLength),
            LowerHips = GetCyberValue(txtLowerHips),
            Crotch = GetCyberValue(txtCrotch),
            Thigh = GetCyberValue(txtThigh),
            CalfCircumference = GetCyberValue(txtCalfCircumference),
            Length = GetCyberValue(txtLength)
        };

        private double GetCyberValue(CyberTextBox field)
        {
            foreach (Control c in field.Controls)
                if (c is TextBox tb)
                    return double.TryParse(tb.Text, out double v) ? v : 0;
            return 0;
        }

        private void ClearForm()
        {
            txtName.Clear();
            hcbGender.SelectedIndex = -1;
            pdtOrderDeadline.Value = DateTime.Now;

            var fields = new CyberTextBox[]
            {
                txtShoulder, txtFrontFigure, txtUpperHips, txtArmCircumference,
                txtUpperBust, txtBackFigure, txtWaistline, txtSleeveLength,
                txtBust, txtFrontChest, txtNeckDip,
                txtLowerBust, txtBackChest, txtArmHole,
                txtLowerHips, txtLength,
                txtCrotch, txtThigh, txtCalfCircumference
            };

            foreach (var field in fields)
            {
                if (field == null) continue;
                foreach (Control c in field.Controls)
                    if (c is TextBox tb) { tb.Text = ""; break; }
                field.Text = "";
                field.Invalidate();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();


        private async void UpdateGrandTotal()
        {
            var (mat, labor, grand) = CostCalculator.Calculate(
                dgvMaterialList.Rows, txtLaborCost.Text, txtQuantity.Text);

            txtMaterialTotal.Text = mat.ToString("N2");
            txtTotalLabor.Text = labor.ToString("N2");
            lblGrandTotalCost.Text = "₱ " + grand.ToString("N2");
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e) => UpdateGrandTotal();
        private void txtLaborCost_TextChanged(object sender, EventArgs e) => UpdateGrandTotal();

        private async void btnCostAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItem.Text) || string.IsNullOrWhiteSpace(txtMetersNeed.Text))
            {
                MessageBox.Show("Please enter the Item and Meters");
                return;
            }

            try
            {
                string item = txtItem.Text;
                string meters = txtMetersNeed.Text;
                string price = txtPrice.Text;

                var result = await Task.Run(() =>
                {
                    decimal.TryParse(meters, out decimal m);
                    decimal.TryParse(price, out decimal p);
                    return new { Meters = m, Price = p, Total = m * p };
                });

                dgvMaterialList.Rows.Add(item, result.Meters, result.Price, result.Total);
                txtItem.Clear(); txtMetersNeed.Clear(); txtPrice.Clear();
                txtItem.Focus();
                UpdateGrandTotal();
            }
            catch
            {
                MessageBox.Show("Please enter valid numbers");
            }
        }

        private void btnCostClear_Click(object sender, EventArgs e)
        {
            txtItem.Clear(); txtMetersNeed.Clear(); txtPrice.Clear();
            dgvMaterialList.Rows.Clear();
            txtMaterialTotal.Clear(); txtLaborCost.Clear();
            txtQuantity.Clear(); txtTotalLabor.Clear();
            lblGrandTotalCost.Text = "₱ 0.00";
            txtItem.Focus();
        }

        private async void btnSaveCost_Click(object sender, EventArgs e)
        {
            var summary = new MaterialCost
            {
                Id = Guid.NewGuid(),
                MaterialTotal = decimal.TryParse(txtMaterialTotal.Text, out var mt) ? mt : 0,
                LaborCost = decimal.TryParse(txtLaborCost.Text, out var lc) ? lc : 0,
                Quantity = double.TryParse(txtQuantity.Text, out var q) ? q : 0,
                TotalLabor = decimal.TryParse(txtTotalLabor.Text, out var tl) ? tl : 0,
                GrandTotalCost = decimal.TryParse(
                    lblGrandTotalCost.Text.Replace("₱", "").Trim(), out var gt) ? gt : 0,
                Items = new List<MaterialItem>()
            };

            foreach (DataGridViewRow row in dgvMaterialList.Rows)
            {
                if (row.IsNewRow || row.Cells[0].Value == null) continue;
                summary.Items.Add(new MaterialItem
                {
                    Id = Guid.NewGuid(),
                    ItemName = row.Cells[0].Value.ToString(),
                    Meters = row.Cells[1].Value.ToString(),
                    Price = row.Cells[2].Value.ToString(),
                    MaterialCostId = summary.Id
                });
            }

            using var costPopup = new CostCostumerNamePopup(summary, _costRepo);
            costPopup.StartPosition = FormStartPosition.CenterScreen;
            if (costPopup.ShowDialog() == DialogResult.OK)
            {
                dgvMaterialList.Rows.Clear();
                MessageBox.Show("Saved to History successfully!");
            }
        }


        private async void btnOrderHistory_Click(object sender, EventArgs e)
        {
            try
            {
                using var popup = new OrderHistoryPopup(_measurementRepo, _costRepo);
                popup.StartPosition = FormStartPosition.CenterScreen;
                await popup.LoadCompleteOrdersAsync();
                popup.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening history: {ex.Message}",
                    "History Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCostHistory_Click(object sender, EventArgs e)
        {
            try
            {
                var popup = new ComputationHistoryPopup
                { StartPosition = FormStartPosition.CenterScreen };
                popup.ShowDialog();
                await Task.Delay(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening cost history: {ex.Message}");
            }
        }


        private async Task LoadSavedDesignsAsync()
        {
            flpDesignGallery.Controls.Clear();
            foreach (string file in await _galleryService.GetImageFilesAsync())
                await AddDesignCardToGalleryAsync(file);
        }

        private async void btnAddDesign_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                string saved = await _galleryService.SaveImageAsync(ofd.FileName);
                await AddDesignCardToGalleryAsync(saved);
                MessageBox.Show("Design added and saved locally!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving design: {ex.Message}");
            }
        }

        private async Task AddDesignCardToGalleryAsync(string imagePath)
        {

            var result = DesignCardBuilder.Build();

            result.PicBox.Click += (s, ev) =>
            {
                var zoom = new Form { Size = new Size(800, 600), StartPosition = FormStartPosition.CenterScreen };
                zoom.Controls.Add(new PictureBox
                {
                    Image = result.PicBox.Image,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.Zoom
                });
                zoom.ShowDialog();
            };

            result.RemoveBtn.Click += (s, ev) =>
            {
                var confirm = MessageBox.Show(
                "Remove this design?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;


                try
                {
                    if (File.Exists(imagePath))
                        File.Delete(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not delete file: {ex.Message}");
                }


                flpDesignGallery.Controls.Remove(result.Card);
                result.Card.Dispose();
            };

            flpDesignGallery.Controls.Add(result.Card);

            try
            {
                byte[] bytes = await File.ReadAllBytesAsync(imagePath);
                using var ms = new MemoryStream(bytes);
                result.PicBox.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }
        }
        
        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
