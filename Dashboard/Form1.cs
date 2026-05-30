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
        private Guid? _editingMeasurementId;

        private sealed class GalleryOrderOption
        {
            public GalleryOrderOption(Guid? id, string displayName)
            {
                Id = id;
                DisplayName = displayName;
            }

            public Guid? Id { get; }
            public string DisplayName { get; }

            public override string ToString() => DisplayName;
        }

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
                    ShowNotificationPopup(GetActiveNotificationButton());
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

            this.ClientSize = new Size(1360, 768);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.None;
            UpdateNotificationBadge();

            FormConfigurator.FormPadding(materialCard10, mcMeasurement);

            FormConfigurator.ConfigureCostConsumptionBackground(CostConsumption, materialCard10);

            FormConfigurator.ConfigureDashboardLabel(moonLabel1, moonLabel2, moonLabel3);
            FormConfigurator.ConfigureOrderSummaryLabel(foxLabel1, lblMonthlyCost, lblMonthlyRevenue, lblCustomers);
            ConfigureSmoothDashboard();
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
            notificationBadge.Cursor = Cursors.Hand;
            notificationBadge.Click += btnNotification_Click;

            Control activeButton = GetActiveNotificationButton();
            Control badgeParent = activeButton.Parent ?? this;
            badgeParent.Controls.Add(notificationBadge);
            PositionNotificationBadge();

            WireNotificationBadgeAnchor(btnNotification);
            WireNotificationBadgeAnchor(btnNotificationOrder);
            WireNotificationBadgeAnchor(btnNotificationBodyMeasurement);
            WireNotificationBadgeAnchor(btnNotificationCostConsumption);
            WireNotificationBadgeAnchor(btnNotificationDesign);
            badgeParent.SizeChanged += (s, e) => PositionNotificationBadge();
        }

        private void WireNotificationBadgeAnchor(Control button)
        {
            button.LocationChanged += (s, e) => PositionNotificationBadge();
            button.SizeChanged += (s, e) => PositionNotificationBadge();

            if (button.Parent != null)
            {
                button.Parent.SizeChanged += (s, e) => PositionNotificationBadge();
            }
        }

        private Control GetActiveNotificationButton()
        {
            if (mtcSelectionControl.SelectedTab == Order) return btnNotificationOrder;
            if (mtcSelectionControl.SelectedTab == BodyMeasurement) return btnNotificationBodyMeasurement;
            if (mtcSelectionControl.SelectedTab == CostConsumption) return btnNotificationCostConsumption;
            if (mtcSelectionControl.SelectedTab == Design) return btnNotificationDesign;

            return btnNotification;
        }

        private void PositionNotificationBadge()
        {
            if (notificationBadge == null) return;

            Control activeButton = GetActiveNotificationButton();
            Control badgeParent = activeButton.Parent ?? this;

            if (notificationBadge.Parent != badgeParent)
            {
                badgeParent.Controls.Add(notificationBadge);
            }

            Point bellLocation = badgeParent.PointToClient(activeButton.PointToScreen(Point.Empty));
            notificationBadge.Location = new Point(
                bellLocation.X + activeButton.Width - notificationBadge.Width - 2,
                bellLocation.Y - 4);
            notificationBadge.BringToFront();
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
            PositionNotificationBadge();

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
            PositionNotificationBadge();

            if (mtcSelectionControl.SelectedTab == MainDashboard)
            {
                TriggerDashboardView();
            }

            if (mtcSelectionControl.SelectedTab == Design)
            {
                _ = RefreshGalleryOrderLinkCombosAsync();
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








        private void hcbSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim().ToLower();
            bool showAll = string.IsNullOrWhiteSpace(search) || search == "search...";

            flpOrderList.SuspendLayout();
            foreach (Control c in flpOrderList.Controls)
            {
                if (c is OrderCard card)
                    c.Visible = showAll || card.MatchesSearch(search);
            }
            flpOrderList.ResumeLayout();
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


        private void btnNotification_Click(object? sender, EventArgs e)
        {
            if (_notificationPopup.Visible)
            {
                _notificationPopup.HidePopup();
                return;
            }

            ShowNotificationPopup(GetActiveNotificationButton());
        }

        private void btnNotificationOrder_Click(object sender, EventArgs e) => ShowNotificationPopup(btnNotificationOrder);

        private void btnNotificationBodyMeasurement_Click(object sender, EventArgs e) => ShowNotificationPopup(btnNotificationBodyMeasurement);

        private void btnNotificationCostConsumption_Click(object sender, EventArgs e) => ShowNotificationPopup(btnNotificationCostConsumption);

        private void btnNotificationRevenue_Click(object sender, EventArgs e) => ShowNotificationPopup(btnNotificationDesign);

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
            string customerName = GetCyberText(txtName);

            if (!_validator.Validate(
                    customerName,
                    hcbGender.SelectedItem,
                    pdtOrderDeadline.Value))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }


            try
            {
                var measurements = BuildMeasurementsModel();
                if (_editingMeasurementId.HasValue)
                {
                    measurements.Id = _editingMeasurementId.Value;
                    await UpdateMeasurementAsync(measurements);
                    await LoadOrdersFromDatabaseAsync();
                    await _dashboardController.RefreshUIAsync(lblCustomers, lblMonthlyRevenue, lblMonthlyCost, dgvReport);
                    await RefreshGalleryOrderLinkCombosAsync();
                    NotificationManager.AddNotification(
                        "Order updated",
                        $"{measurements.CustomerName}'s body measurements were updated.");
                }
                else
                {
                    await _measurementRepo.AddAsync(measurements);
                    await _measurementRepo.SaveAsync();

                    flpOrderList.Controls.Add(BuildOrderCard(measurements));
                    await RefreshGalleryOrderLinkCombosAsync();
                    NotificationManager.AddNotification(
                        "New order created",
                        $"{measurements.CustomerName}'s body measurements were saved.");
                }
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
            CustomerName = GetCyberText(txtName),
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

        private static async Task UpdateMeasurementAsync(Measurements measurements)
        {
            using var db = new SewingDbContext();
            var existing = await db.Measurements.FirstOrDefaultAsync(m => m.Id == measurements.Id);

            if (existing == null)
            {
                throw new InvalidOperationException("The selected order no longer exists.");
            }

            existing.CustomerName = measurements.CustomerName;
            existing.Gender = measurements.Gender;
            existing.OrderDeadline = measurements.OrderDeadline;
            existing.Status = measurements.Status;
            existing.Shoulder = measurements.Shoulder;
            existing.ArmCircumference = measurements.ArmCircumference;
            existing.FrontFigure = measurements.FrontFigure;
            existing.UpperBust = measurements.UpperBust;
            existing.Bust = measurements.Bust;
            existing.LowerBust = measurements.LowerBust;
            existing.BackFigure = measurements.BackFigure;
            existing.FrontChest = measurements.FrontChest;
            existing.BackChest = measurements.BackChest;
            existing.UpperHips = measurements.UpperHips;
            existing.Waistline = measurements.Waistline;
            existing.NeckDip = measurements.NeckDip;
            existing.ArmHole = measurements.ArmHole;
            existing.SleeveLength = measurements.SleeveLength;
            existing.LowerHips = measurements.LowerHips;
            existing.Crotch = measurements.Crotch;
            existing.Thigh = measurements.Thigh;
            existing.CalfCircumference = measurements.CalfCircumference;
            existing.Length = measurements.Length;

            await db.SaveChangesAsync();
        }

        private static string GetCyberText(CyberTextBox field)
        {
            foreach (Control c in field.Controls)
                if (c is TextBox tb)
                    return tb.Text;

            return field.Text;
        }

        private static void SetCyberText(CyberTextBox field, string text)
        {
            foreach (Control c in field.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.Text = text;
                    break;
                }
            }

            field.Text = text;
            field.Invalidate();
        }

        private double GetCyberValue(CyberTextBox field)
        {
            foreach (Control c in field.Controls)
                if (c is TextBox tb)
                    return double.TryParse(tb.Text, out double v) ? v : 0;
            return 0;
        }

        private void ClearForm()
        {
            SetCyberText(txtName, string.Empty);
            hcbGender.SelectedIndex = -1;
            pdtOrderDeadline.Value = DateTime.Now;
            _editingMeasurementId = null;
            btnSubmit.Text = "Submit";

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
            txtMaterialTotal.Clear();
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
                MessageBox.Show("Please enter the Item and Meters/Quantity");
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
            txtMaterialTotal.Clear(); txtLaborCost.Clear(); txtQuantity.Clear(); txtTotalLabor.Clear();
            ClearForm();
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
                MessageBox.Show("Design added. You can link it to an order from its gallery card.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving design: {ex.Message}");
            }
        }

        private async Task AddDesignCardToGalleryAsync(string imagePath)
        {

            var result = DesignCardBuilder.Build();
            await ConfigureOrderLinkComboAsync(result.OrderLinkComboBox, imagePath);

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

            result.RemoveBtn.Click += async (s, ev) =>
            {
                var confirm = MessageBox.Show(
                "Remove this design?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;


                try
                {
                    await _galleryService.DeleteImageAsync(imagePath);
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

        private async Task ConfigureOrderLinkComboAsync(ComboBox combo, string imagePath)
        {
            var options = await LoadGalleryOrderOptionsAsync();
            Guid? linkedOrderId = await _galleryService.GetLinkedOrderIdAsync(imagePath);

            combo.Tag = imagePath;
            PopulateGalleryOrderCombo(combo, options, linkedOrderId);

            combo.SelectionChangeCommitted += async (s, ev) =>
            {
                if (combo.SelectedItem is not GalleryOrderOption selected) return;

                try
                {
                    await _galleryService.SetLinkedOrderAsync(imagePath, selected.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not link design to order: {ex.Message}", "Gallery Link", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        private async Task RefreshGalleryOrderLinkCombosAsync()
        {
            if (flpDesignGallery.Controls.Count == 0) return;

            var options = await LoadGalleryOrderOptionsAsync();

            foreach (Control card in flpDesignGallery.Controls)
            {
                var combo = card.Controls.OfType<ComboBox>().FirstOrDefault();
                if (combo?.Tag is not string imagePath) continue;

                Guid? linkedOrderId = await _galleryService.GetLinkedOrderIdAsync(imagePath);
                PopulateGalleryOrderCombo(combo, options, linkedOrderId);
            }
        }

        private static void PopulateGalleryOrderCombo(
            ComboBox combo,
            List<GalleryOrderOption> options,
            Guid? linkedOrderId)
        {
            combo.BeginUpdate();
            try
            {
                combo.Items.Clear();
                combo.Items.AddRange(options.Cast<object>().ToArray());
                SelectGalleryOrder(combo, linkedOrderId);
            }
            finally
            {
                combo.EndUpdate();
            }
        }

        private async Task<List<GalleryOrderOption>> LoadGalleryOrderOptionsAsync()
        {
            var options = new List<GalleryOrderOption>
            {
                new GalleryOrderOption(null, "No linked order")
            };

            using var db = new SewingDbContext();
            var orders = await db.Measurements
                .OrderByDescending(m => m.DateCreated)
                .ToListAsync();

            options.AddRange(orders.Select(m =>
                new GalleryOrderOption(
                    m.Id,
                    $"{m.CustomerName} ({m.Status}) - {m.DateCreated:MM/dd/yy}")));

            return options;
        }

        private static void SelectGalleryOrder(ComboBox combo, Guid? linkedOrderId)
        {
            foreach (object item in combo.Items)
            {
                if (item is GalleryOrderOption option && option.Id == linkedOrderId)
                {
                    combo.SelectedItem = item;
                    return;
                }
            }

            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }

      
    }
}
