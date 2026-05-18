using AppDomain.Models;
using AppInfrastructure.Data;
using Dashboard.Formatter;
using Dashboard.Logics;
using ReaLTaiizor.Colors;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using MyResources = Dashboard.Properties.Resources;
using Microsoft.EntityFrameworkCore;
using Dashboard.CostumizeTools;
using System.IO;
using AppInfrastructure.Repository;


namespace Dashboard
{
    public partial class Form1 : MaterialForm
    {
        private readonly MeasurementRepository _measurementRepo;
        private readonly CostRepository _costRepo;
        private FormWindowState _lastWindowState;
        private static readonly Color CostConsumptionBackgroundColor = Color.FromArgb(249, 250, 252);

        private void ShowWarning(string msg) => MessageBox.Show(msg, "Input Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowError(string msg) => MessageBox.Show(msg, "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public Form1()
        {
            InitializeComponent();



            notificationPopup = new NotificationPopup();
            var sewingDb = new SewingDbContext();
            var costDb = new CostDBContext();

            _measurementRepo = new MeasurementRepository(sewingDb);
            _costRepo = new CostRepository(costDb);



            var materialSkinManager = ReaLTaiizor.Manager.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = ReaLTaiizor.Manager.MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ReaLTaiizor.Colors.MaterialColorScheme(
               primary: System.Drawing.Color.FromArgb(141, 182, 0),
               darkPrimary: System.Drawing.Color.FromArgb(70, 95, 0),
               lightPrimary: System.Drawing.Color.FromArgb(215, 235, 150),
               accent: System.Drawing.Color.FromArgb(69, 98, 20),
               textShade: ReaLTaiizor.Util.MaterialTextShade.WHITE
            );
        }

        private void CenterWindowInCurrentScreen()
        {
            Rectangle workingArea = Screen.FromControl(this).WorkingArea;
            Location = new Point(
                workingArea.Left + (workingArea.Width - Width) / 2,
                workingArea.Top + (workingArea.Height - Height) / 2
            );
        }

        
        private async void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1360, 768);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.None;

            materialCard10.Padding = new Padding(0);
            mcMeasurement.Padding = new Padding(0, 17, 0, 0);
            ConfigureCostConsumptionBackground();
            //OrderSummary
            {
                foxLabel1.BackColor = Color.Transparent;
                foxLabel1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
                foxLabel1.ForeColor = Color.FromArgb(102, 140, 48);

                foxLabel1.Name = "foxLabel1";
                foxLabel1.Size = new Size(261, 50);
                foxLabel1.TabIndex = 174;
                foxLabel1.Text = "Order Summary";
            }
            ConfigureInputFonts();
            ConfigureCostButtonPreview();
            ConfigureCostSaveButton();
            btnOrderHistory.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            await LoadActiveOrderAsync();
            await LoadSavedDesignsAsync();
            await LoadOrdersFromDatabaseAsync();

        }

        private void ConfigureCostConsumptionBackground()
        {
            CostConsumption.UseVisualStyleBackColor = true;
            CostConsumption.BackColor = CostConsumptionBackgroundColor;
            if (materialCard10 == null) return;

            materialCard10.BackColor = CostConsumptionBackgroundColor;
            materialCard10.Invalidate();
        }

        private void ConfigureInputFonts()
        {
            Font inputFont = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);

            txtName.UseCustomFont = true;
            txtName.Font = inputFont;

            hcbGender.DrawItem -= hcbGender_DrawItem;
            hcbGender.DrawMode = DrawMode.Normal;
            hcbGender.Font = inputFont;
        }

        private void ConfigureCostButtonPreview()
        {
            if (materialCard10 == null) return;

            System.Windows.Forms.Button? costButton =
                materialCard10.Controls.Find("button1", false).FirstOrDefault() as System.Windows.Forms.Button;
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

        private void ConfigureCostSaveButton()
        {
            ConfigureAccentHoverButton(btnSaveCost);
            ConfigureAccentHoverButton(btnCostHistory);
        }

        private void ConfigureAccentHoverButton(MaterialButton button)
        {
            button.Type = MaterialButton.MaterialButtonType.Contained;
            button.HighEmphasis = true;
            button.NoAccentTextColor = Color.White;
            button.UseAccentColor = false;
            button.UseVisualStyleBackColor = true;

            button.MouseEnter -= CostMaterialButton_MouseEnter;
            button.MouseLeave -= CostMaterialButton_MouseLeave;
            button.MouseEnter += CostMaterialButton_MouseEnter;
            button.MouseLeave += CostMaterialButton_MouseLeave;

            button.Invalidate();
        }

        private void CostMaterialButton_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is MaterialButton button)
            {
                button.UseAccentColor = true;
                button.Invalidate();
            }
        }

        private void CostMaterialButton_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is MaterialButton button)
            {
                button.UseAccentColor = false;
                button.Invalidate();
            }
        }

        private bool ValidateOrderInput()
        {

            if (hcbGender.SelectedItem == null)
            {
                ShowWarning("Select a Gender before submitting.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowWarning("Enter the Customer's Name.");
                return false;
            }

            DateTime selectedDate = pdtOrderDeadline.Value.Date;
            DateTime today = DateTime.Today;

            if (selectedDate < today)
            {
                ShowError("The deadline cannot be a date in the past!");
                return false;
            }

            if (selectedDate == today)
            {
                var result = MessageBox.Show("The deadline is set to Today. Is this correct?",
                    "Confirm Date", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No) return false;
            }

            return true;
        }

        private async Task LoadSavedDesignsAsync()
        {

            flpDesignGallery.Controls.Clear();
            string folderPath = GetGalleryPath();

            if (!Directory.Exists(folderPath)) return;

            string[] files = await Task.Run(() =>
                Directory.GetFiles(folderPath, "*.*")
                         .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".jpeg"))
                         .ToArray()
            );

            foreach (string filePath in files)
            {
                await AddDesignCardToGalleryAsync(filePath);
            }
        }

        private async Task AddDesignCardToGalleryAsync(string imagePath)
        {

            MaterialCard pnlBorder = new MaterialCard
            {
                Size = new Size(160, 160),
                BackColor = Color.FromArgb(142, 188, 30),
                Padding = new Padding(5),
                Margin = new Padding(10)
            };
            pnlBorder.HandleCreated += (s, ev) => RoundedItem.MakeRounded(pnlBorder, 30);

            PictureBox pb = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            try
            {
                byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pb.Image = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }

            HopeButton btnRemove = new HopeButton
            {
                Text = "✕",
                Size = new Size(30, 30),
                Location = new Point(pnlBorder.Width - 35, 5),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                PrimaryColor = Color.FromArgb(255, 80, 80),
                ForeColor = Color.White
            };
            btnRemove.HandleCreated += (s, ev) => RoundedItem.MakeRounded(btnRemove, 10);

            pb.Click += (s, ev) =>
            {
                Form zoomForm = new Form { Size = new Size(800, 600), StartPosition = FormStartPosition.CenterScreen };
                zoomForm.Controls.Add(new PictureBox { Image = pb.Image, Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom });
                zoomForm.ShowDialog();
            };

            btnRemove.Click += (s, ev) =>
            {
                flpDesignGallery.Controls.Remove(pnlBorder);
                pnlBorder.Dispose();

            };

            pnlBorder.Controls.Add(btnRemove);
            pnlBorder.Controls.Add(pb);
            btnRemove.BringToFront();

            flpDesignGallery.Controls.Add(pnlBorder);
        }

        private string GetGalleryPath()
        {
            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "GalleryImages");
        }

        private async Task CreateGalleryFolderAsync()
        {
            await Task.Run(() =>
            {
                string folderPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "GalleryImages");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            });
        }


        private async Task LoadActiveOrderAsync()
        {
            flpOrderList.Controls.Clear();
            try
            {
                var activeOrders = await _measurementRepo.GetActiveOrdersAsync();

                foreach (var m in activeOrders)
                {
                    OrderCard orderCard = new OrderCard
                    {
                        CustomerName = m.CustomerName,
                        Gender = m.Gender,
                        Deadline = m.OrderDeadline.ToString("MM/dd/yy"),
                        OrderDate = m.DateCreated.ToString("MM/dd/yy"),
                        AllMeasurements = MeasurementFormatter.ToDisplayString(m)
                    };

                    flpOrderList.Controls.Add(orderCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading active orders: {ex.Message}");
            }
        }

    

        private void ClearForm()
        {
            txtName.Clear();
            hcbGender.SelectedIndex = -1;
            pdtOrderDeadline.Value = DateTime.Now;

            var cyberFields = new ReaLTaiizor.Controls.CyberTextBox[]
            {
                txtShoulder, txtFrontFigure, txtUpperHips, txtArmCircumference,
                txtUpperBust, txtBackFigure, txtWaistline, txtSleeveLength,
                txtBust, txtFrontChest, txtNeckDip,
                txtLowerBust, txtBackChest, txtArmHole,
                txtLowerHips, txtLength,
                txtCrotch, txtThigh,
                txtCalfCircumference
            };

            foreach (var field in cyberFields)
            {
                if (field == null) continue;


                foreach (Control c in field.Controls)
                {
                    if (c is TextBox tb)
                    {
                        tb.Text = "";
                        break;
                    }
                }


                field.Text = "";
                field.Invalidate();
            }
        }

        private async Task LoadOrdersFromDatabaseAsync()
        {
            flpOrderList.Controls.Clear();

            try
            {
                using (var db = new SewingDbContext())
                {
                    var savedOrders = await db.Measurements.Where(m => m.Status != "Completed").ToListAsync();

                    foreach (var measurements in savedOrders)
                    {
                        OrderCard card = new OrderCard
                        {
                            CustomerName = measurements.CustomerName,
                            Gender = measurements.Gender,
                            Deadline = measurements.OrderDeadline.ToString("MM/dd/yy"),
                            OrderDate = measurements.DateCreated.ToString("MM/dd/yy"),
                            AllMeasurements = MeasurementFormatter.ToDisplayString(measurements)
                        };

                        flpOrderList.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load orders: {ex.Message}");
            }
        }

        private void UpdateGrandTotal()
        {

            decimal materialSum = 0;

            foreach (DataGridViewRow row in dgvMaterialList.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    decimal.TryParse(row.Cells[3].Value.ToString(), out decimal rowVal);
                    materialSum += rowVal;
                }
            }

            decimal.TryParse(txtLaborCost.Text, out decimal labor);
            decimal.TryParse(txtQuantity.Text, out decimal quantity);

            decimal totalLabor = labor * quantity;
            decimal grandTotal = materialSum + totalLabor;

            txtMaterialTotal.Text = materialSum.ToString("N2");
            txtTotalLabor.Text = totalLabor.ToString("N2");
            lblGrandTotalCost.Text = "₱ " + grandTotal.ToString("N2");
        }

        private int targetHeight = 400;
        private NotificationPopup notificationPopup;

       

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (pnlNotification.Height < 410)
            {
                pnlNotification.Height += 50;
            }
            else
            {
                pnlNotification.Height = targetHeight;
                animationTimer.Stop();
            }
        }

        private void dashboardPanel_Load(object sender, EventArgs e)
        {

            hcbSearch.Text = "Search...";
            hcbSearch.ForeColor = Color.FromArgb(150, 150, 150);
            this.ActiveControl = null;


        }

        private void btnCloseNotification_Click(object sender, EventArgs e)
        {
            pnlNotification.Visible = false;
        }

        private void cboSearch_Enter(Object sender, EventArgs e)
        {
            hcbSearch.Select(0, 0);

            if (hcbSearch.Text == "Search...")
            {
                hcbSearch.Text = "";
                hcbSearch.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

       

        private void cboSearch_Leave(Object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hcbSearch.Text))
            {
                hcbSearch.Text = "Search...";
                hcbSearch.ForeColor = Color.FromArgb(150, 150, 150);
            }
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {

            notificationPopup.ShowPopup(this, btnNotificationOrder);

        }

        private void btnNotificationOrder_Click(object sender, EventArgs e)
        {
            notificationPopup.ShowPopup(this, btnNotificationOrder);
        }

        private void btnNotificationBodyMeasurement_Click(object sender, EventArgs e)
        {
            notificationPopup.ShowPopup(this, btnNotificationBodyMeasurement);
        }

        private void btnNotificationCostConsumption_Click(object sender, EventArgs e)
        {
            notificationPopup.ShowPopup(this, btnNotificationCostConsumption);
        }

        private void btnNotificationRevenue_Click(object sender, EventArgs e)
        {
            notificationPopup.ShowPopup(this, btnNotificationDesign);
        }

        private void flwpnlOrderList_MouseEnter(object sender, EventArgs e)
        {
            flpOrderList.Focus();
        }

        private async void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdateGrandTotal();
        }

        private async void txtLaborCost_TextChanged(object sender, EventArgs e)
        {
            UpdateGrandTotal();
        }

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
                string metersText = txtMetersNeed.Text;
                string priceText = txtPrice.Text;

                var result = await Task.Run(() =>
                {
                    decimal.TryParse(metersText, out decimal m);
                    decimal.TryParse(priceText, out decimal p);
                    decimal total = m * p;
                    return new { Meters = m, Price = p, Total = total };
                });

                dgvMaterialList.Rows.Add(item, result.Meters, result.Price, result.Total);

                txtItem.Clear();
                txtMetersNeed.Clear();
                txtPrice.Clear();
                txtItem.Focus();

                UpdateGrandTotal();
            }
            catch
            {
                MessageBox.Show("Please enter valid numbers");
            }
        }

        private async void btnCostClear_Click(object sender, EventArgs e)
        {
            txtItem.Clear();
            txtMetersNeed.Clear();
            txtPrice.Clear();

            dgvMaterialList.Rows.Clear();

            txtMaterialTotal.Clear();
            txtLaborCost.Clear();
            txtQuantity.Clear();
            txtTotalLabor.Clear();

            lblGrandTotalCost.Text = "₱ 0.00";

            txtItem.Focus();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {


            if (!ValidateOrderInput())
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {

                var measurements = new Measurements
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

                await _measurementRepo.AddAsync(measurements);
                await _measurementRepo.SaveAsync();

                OrderCard orderCard = new OrderCard();

                orderCard.CustomerName = txtName.Text;
                orderCard.OrderDate = measurements.DateCreated.ToString("MM/dd/yy");
                orderCard.Deadline = pdtOrderDeadline.Value.ToString("MM/dd/yy");
                orderCard.Gender = hcbGender.SelectedItem.ToString();
                orderCard.AllMeasurements = MeasurementFormatter.ToDisplayString(measurements);

                flpOrderList.Controls.Add(orderCard);
                MessageBox.Show("Order Created and Saved!");

            }
            catch (Exception ex)
            {
                Exception realError = ex;
                while (realError.InnerException != null)
                    realError = realError.InnerException;

                MessageBox.Show($"Actual SQL Error: {realError.Message}");
            }

            ClearForm();
        }

        private async void btnAddDesign_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await CreateGalleryFolderAsync();


                        string extension = Path.GetExtension(ofd.FileName);
                        string uniqueFileName = $"{Guid.NewGuid()}{extension}";
                        string destinationPath = Path.Combine(GetGalleryPath(), uniqueFileName);

                        byte[] imageBytes = await File.ReadAllBytesAsync(ofd.FileName);
                        await File.WriteAllBytesAsync(destinationPath, imageBytes);


                        await AddDesignCardToGalleryAsync(destinationPath);

                        MessageBox.Show("Design added and saved locally!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving design: {ex.Message}");
                    }
                }
            }
        }

        private async void btnOrderHistory_Click(object sender, EventArgs e)
        {
            try
            {
                using (OrderHistoryPopup historyPopup = new OrderHistoryPopup(_measurementRepo))
                {
                    historyPopup.StartPosition = FormStartPosition.CenterScreen;

                    await historyPopup.LoadCompleteOrdersAsync();
                    historyPopup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening history: {ex.Message}", "History Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCostHistory_Click(object sender, EventArgs e)
        {
            try
            {
                ComputationHistoryPopup computationHistoryPopup = new ComputationHistoryPopup();
                computationHistoryPopup.StartPosition = FormStartPosition.CenterScreen;
                computationHistoryPopup.ShowDialog();

                await Task.Delay(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening cost history: {ex.Message}");
            }
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
                GrandTotalCost = decimal.TryParse(lblGrandTotalCost.Text.Replace("₱", "").Trim(), out var gt) ? gt : 0,

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

            using (var costPopup = new CostCostumerNamePopup(summary, _costRepo))
            {
                if (costPopup.ShowDialog() == DialogResult.OK)
                {
                    dgvMaterialList.Rows.Clear();
                    MessageBox.Show("Saved to History successfully!");
                }

                costPopup.StartPosition = FormStartPosition.CenterScreen;
            }


        }
        private void hcbSearch_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            using (var font = new Font("Segoe UI", 18F))
            using (var brush = new SolidBrush(e.ForeColor))
            {
                string text = hcbSearch.Items[e.Index].ToString();
                e.Graphics.DrawString(text, font, brush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private void hcbGender_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Bounds.Width <= 0 || e.Bounds.Height <= 0) return;

            ComboBox? comboBox = sender as ComboBox;
            Font font = comboBox?.Font ?? hcbGender.Font;
            string text = comboBox?.Items[e.Index]?.ToString() ?? string.Empty;
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color backColor = isSelected ? SystemColors.Highlight : hcbGender.BackColor;
            Color foreColor = isSelected ? SystemColors.HighlightText : hcbGender.ForeColor;

            using (var backgroundBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            using (var brush = new SolidBrush(foreColor))
            {
                var textLocation = new PointF(e.Bounds.Left + 4, e.Bounds.Top + (e.Bounds.Height - font.Height) / 2f);
                e.Graphics.DrawString(text, font, brush, textLocation);
            }
        }

        private double GetCyberValue(ReaLTaiizor.Controls.CyberTextBox field)
        {
            foreach (Control c in field.Controls)
            {
                if (c is TextBox tb)
                    return double.TryParse(tb.Text, out double result) ? result : 0;
            }
            return 0;
        }
        private void hcbSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = hcbSearch.Text.Trim().ToLower();


            if (string.IsNullOrWhiteSpace(searchText) || searchText == "search...")
            {
                foreach (Control c in flpOrderList.Controls)
                {
                    c.Visible = true;
                }
                return;
            }


            flpOrderList.SuspendLayout();
            foreach (Control c in flpOrderList.Controls)
            {
                if (c is OrderCard card)
                {
                    bool matches =
                        card.CustomerName?.ToLower().Contains(searchText) == true ||
                        card.Gender?.ToLower().Contains(searchText) == true ||
                        card.Deadline?.ToLower().Contains(searchText) == true ||
                        card.OrderDate?.ToLower().Contains(searchText) == true;

                    c.Visible = matches;
                }
            }
            flpOrderList.ResumeLayout();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

       
    }
}
