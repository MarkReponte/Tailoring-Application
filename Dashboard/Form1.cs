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


namespace Dashboard
{
    public partial class Form1 : MaterialForm
    {
        public List<OrderCard> GlobalHistoryList = new List<OrderCard>();

        public Form1()
        {
            InitializeComponent();
            LoadOrdersFromDatabase();


            var materialSkinManager = ReaLTaiizor.Manager.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = ReaLTaiizor.Manager.MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ReaLTaiizor.Colors.MaterialColorScheme(
               primary: System.Drawing.Color.FromArgb(141, 182, 0),
               darkPrimary: System.Drawing.Color.FromArgb(110, 145, 0),
               lightPrimary: System.Drawing.Color.FromArgb(180, 215, 60),
               accent: System.Drawing.Color.FromArgb(255, 204, 0),
               textShade: ReaLTaiizor.Util.MaterialTextShade.WHITE
            );
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadActiveOrderAsync();
        }

        private async Task LoadActiveOrderAsync()
        {
            flpOrderList.Controls.Clear();

            using (var db = new SewingDbContext())
            {
                var activeOrders = await db.Measurements
                                           .Where(m => m.Status != "Completed")
                                           .ToListAsync();

                foreach (var m in activeOrders)
                {
                    OrderCard card = new OrderCard
                    {
                        CustomerName = m.CustomerName,
                        Gender = m.Gender,
                        Deadline = m.OrderDeadline.ToString("MM/dd/yy"),
                        OrderDate = DateTime.Now.ToString("MM/dd/yy"),
                        AllMeasurements = MeasurementFormatter.ToDisplayString(m)
                    };

                    flpOrderList.Controls.Add(card);
                }

            }
        }

        private double GetValue(string text)
        {
            return double.TryParse(text, out double result) ? result : 0;
        }

        private void ClearForm()
        {
            txtName.Clear();
            hcbGender.SelectedIndex = -1;
            pdtOrderDeadline.Value = DateTime.Now;

            foreach (Control c in mcMeasurement.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.Clear();
                }
            }
        }

        private void LoadOrdersFromDatabase()
        {
            flpOrderList.Controls.Clear();

            try
            {
                using (var db = new SewingDbContext())
                {
                    var savedOrders = db.Measurements.ToList();

                    foreach (var measurements in savedOrders)
                    {
                        OrderCard card = new OrderCard
                        {
                            CustomerName = measurements.CustomerName,
                            Gender = measurements.Gender,
                            Deadline = measurements.OrderDeadline.ToString("MM/dd/yy"),
                            OrderDate = DateTime.Now.ToString("MM/dd/yy"),

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

        private string GenerateMeasurementString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("━━━━━━━━━━━━━━━━━━━━");
            sb.AppendLine("Torso Measurements:");
            sb.AppendLine($"Shoulder: {txtShoulder.Text} cm");
            sb.AppendLine($"Upper Bust: {txtUpperBust.Text} cm");
            sb.AppendLine($"Bust: {txtBust.Text} cm");
            sb.AppendLine($"Lower Bust: {txtLowerBust.Text} cm");
            sb.AppendLine($"Front Figure: {txtFrontFigure.Text} cm");
            sb.AppendLine($"Back Figure: {txtBackFigure.Text} cm");
            sb.AppendLine($"Front Chest: {txtFrontChest.Text} cm");
            sb.AppendLine($"Back Chest: {txtBackChest.Text} cm");
            sb.AppendLine($"Upper Hips: {txtUpperHips.Text} cm");
            sb.AppendLine($"Waistline: {txtWaistline.Text} cm");
            sb.AppendLine($"Neck Dip: {txtNeckDip.Text} cm");
            sb.AppendLine($"Arm Hole: {txtArmHole.Text} cm");
            sb.AppendLine($"Arm Circumference: {txtArmCircumference.Text} cm");
            sb.AppendLine($"Sleeve Length: {txtSleeveLength.Text} cm");

            sb.AppendLine("━━━━━━━━━━━━━━━━━━━━");
            sb.AppendLine("Pants Measurements:");
            sb.AppendLine("━━━━━━━━━━━━━━━━━━━━");
            sb.AppendLine($"Lower Hips: {txtLowerHips.Text} cm");
            sb.AppendLine($"Crotch: {txtCrotch.Text} cm");
            sb.AppendLine($"Thigh: {txtThigh.Text} cm");
            sb.AppendLine($"Calf Circumference: {txtCalfCircumference.Text} cm");
            sb.AppendLine($"Length: {txtLength.Text} cm");

            return sb.ToString();
        }


        private void UpdateGrandTotal()
        {
            double materialSum = 0;

            foreach (DataGridViewRow row in dgvMaterialList.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    materialSum += Convert.ToDouble(row.Cells[3].Value);
                }
            }
            txtMaterialTotal.Text = materialSum.ToString("N2");

            double labor = 0;
            double.TryParse(txtLaborCost.Text, out labor);
            double quantity = 0;
            double.TryParse(txtQuantity.Text, out quantity);

            double totalLabor = labor * quantity;
            txtTotalLabor.Text = totalLabor.ToString("N2");

            double grandTotal = materialSum + totalLabor;
            lblGrandTotalCost.Text = "₱ " + grandTotal.ToString("N2");

        }
        private int targetHeight = 400;

        public void NotificationPanel()
        {
            if (!pnlNotification.Visible)
            {
                int x = this.ClientSize.Width - pnlNotification.Width - 10;
                int y = 60;
                pnlNotification.Location = new Point(x, y);
                pnlNotification.Size = new Size(300, 0);

                pnlNotification.Visible = true;
                pnlNotification.BringToFront();

                animationTimer.Start();
            }
        }

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

        private void cboSearch_TextChanged(object sender, EventArgs e)
        {
            if (hcbSearch.Text != "Search..." && hcbSearch.Text != "")
            {
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

            NotificationPanel();

        }

        private void btnNotificationOrder_Click(object sender, EventArgs e)
        {
            NotificationPanel();
        }

        private void btnNotificationBodyMeasurement_Click(object sender, EventArgs e)
        {
            NotificationPanel();
        }

        private void btnNotificationCostConsumption_Click(object sender, EventArgs e)
        {
            NotificationPanel();
        }

        private void btnNotificationRevenue_Click(object sender, EventArgs e)
        {
            NotificationPanel();
        }

        private void flwpnlOrderList_MouseEnter(object sender, EventArgs e)
        {
            flpOrderList.Focus();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdateGrandTotal();
        }

        private void txtLaborCost_TextChanged(object sender, EventArgs e)
        {
            UpdateGrandTotal();
        }

        private void btnCostAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItem.Text) || string.IsNullOrWhiteSpace(txtMetersNeed.Text))
            {
                MessageBox.Show("Please enter the Item and Meters");
                return;
            }

            try
            {
                double m = Convert.ToDouble(txtMetersNeed.Text);
                double p = Convert.ToDouble(txtPrice.Text);
                double rowTotal = m * p;

                dgvMaterialList.Rows.Add(txtItem.Text, m, p, rowTotal);

                txtItem.Clear();
                txtMetersNeed.Clear();
                txtPrice.Clear();
                txtItem.Focus();

                UpdateGrandTotal();
            }
            catch { MessageBox.Show("Please enter valid number"); }
        }

        private void btnCostClear_Click(object sender, EventArgs e)
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
            if (hcbGender.SelectedItem == null)
            {
                MessageBox.Show("Select a Gender before submitting.",
                                "Input Missing",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Enter the Customer's Name.", "Input Missing");
                return;
            }

            if (pdtOrderDeadline.Value.Date < DateTime.Now)
            {
                DialogResult dialog = MessageBox.Show("The deadline cannot be a date in the past!",
                                                       "Invalid Date",
                                                       MessageBoxButtons.OK,
                                                       MessageBoxIcon.Error);
                return;
            }

            if (pdtOrderDeadline.Value.Date == DateTime.Today)
            {
                DialogResult dialog = MessageBox.Show("The deadline is set to Today. Is this correct?",
                                                      "Confirm Date",
                                                      MessageBoxButtons.YesNo);
                if (dialog == DialogResult.No) return;
            }

            try
            {
                using (var db = new SewingDbContext())
                {
                    var measurements = new Measurements
                    {
                        CustomerName = txtName.Text,
                        Gender = hcbGender.SelectedItem.ToString(),
                        OrderDeadline = pdtOrderDeadline.Value.Date,
                        Status = "In Progress",

                        Shoulder = GetValue(txtShoulder.Text),
                        UpperBust = GetValue(txtUpperBust.Text),
                        Bust = GetValue(txtBust.Text),
                        LowerBust = GetValue(txtLowerBust.Text),
                        FrontFigure = GetValue(txtFrontFigure.Text),
                        BackFigure = GetValue(txtBackFigure.Text),
                        FrontChest = GetValue(txtFrontChest.Text),
                        BackChest = GetValue(txtBackChest.Text),
                        UpperHips = GetValue(txtUpperHips.Text),
                        Waistline = GetValue(txtWaistline.Text),
                        NeckDip = GetValue(txtNeckDip.Text),
                        ArmHole = GetValue(txtArmHole.Text),
                        ArmCircumference = GetValue(txtArmCircumference.Text),
                        SleeveLength = GetValue(txtSleeveLength.Text),

                        LowerHips = GetValue(txtLowerHips.Text),
                        Crotch = GetValue(txtCrotch.Text),
                        Thigh = GetValue(txtThigh.Text),
                        CalfCircumference = GetValue(txtCalfCircumference.Text),
                        Length = GetValue(txtLength.Text)
                    };

                    db.Measurements.Add(measurements);
                    await db.SaveChangesAsync();

                    OrderCard newCard = new OrderCard();

                    newCard.CustomerName = txtName.Text;
                    newCard.OrderDate = DateTime.Now.ToString("MM/dd/yyyy");
                    newCard.Deadline = pdtOrderDeadline.Value.ToString("MM/dd/yyyy");
                    newCard.Gender = hcbGender.SelectedItem.ToString();
                    newCard.AllMeasurements = MeasurementFormatter.ToDisplayString(measurements);

                    flpOrderList.Controls.Add(newCard);
                    MessageBox.Show("Order Created and Saved!");
                }
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

        private void btnAddDesign_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    MaterialCard pnlBorder = new MaterialCard();
                    pnlBorder.Size = new Size(160, 160);
                    pnlBorder.BackColor = Color.FromArgb(142, 188, 30);
                    pnlBorder.Padding = new Padding(5);
                    pnlBorder.Margin = new Padding(10);

                    pnlBorder.HandleCreated += (s, e) => RoundedItem.MakeRounded(pnlBorder, 30);

                    PictureBox pb = new PictureBox();
                    byte[] imageBytes = File.ReadAllBytes(ofd.FileName);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pb.Image = Image.FromStream(ms);
                    }
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Dock = DockStyle.Fill;
                    pb.BackColor = Color.White;
                    pb.Margin = new Padding(10);

                    if (File.Exists(ofd.FileName))
                    {
                        using (var stream = new MemoryStream(File.ReadAllBytes(ofd.FileName)))
                        {
                            pb.Image = Image.FromStream(stream);
                        }
                    }



                    HopeButton btnRemove = new HopeButton();
                    btnRemove.Text = "✕";
                    btnRemove.Size = new Size(30, 30);
                    btnRemove.ButtonType = HopeButtonType.Primary;
                    btnRemove.Location = new Point(pnlBorder.Width - 35, 5);
                    btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    btnRemove.PrimaryColor = Color.FromArgb(255, 80, 80);
                    btnRemove.ForeColor = Color.White;

                    btnRemove.HandleCreated += (s, e) => RoundedItem.MakeRounded(btnRemove, 10);

                    flpDesignGallery.Controls.Add(pb);

                    pb.Click += (s, ev) =>
                    {
                        Form zoomForm = new Form();
                        zoomForm.Size = new Size(800, 600);
                        zoomForm.StartPosition = FormStartPosition.CenterScreen;
                        PictureBox zoomPb = new PictureBox
                        {
                            Image = pb.Image,
                            Dock = DockStyle.Fill,
                            SizeMode = PictureBoxSizeMode.Zoom
                        };
                        zoomForm.Controls.Add(zoomPb);
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

                    MessageBox.Show("Image has been added!");
                }
            }
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            OrderHistoryPopup orderHistoryPopup = new OrderHistoryPopup();

            foreach (OrderCard card in GlobalHistoryList)
            {
                orderHistoryPopup.flpOrderHistory.Controls.Add(card);
                card.Visible = true;
            }

            orderHistoryPopup.StartPosition = FormStartPosition.CenterScreen;
            orderHistoryPopup.ShowDialog();


            orderHistoryPopup.flpOrderHistory.Controls.Clear();
        }

        private void btnCostHistory_Click(object sender, EventArgs e)
        {
            ComputationHistoryPopup computationHistoryPopup = new ComputationHistoryPopup();

            computationHistoryPopup.StartPosition = FormStartPosition.CenterScreen;
            computationHistoryPopup.ShowDialog();
        }

        private void btnSaveCost_Click(object sender, EventArgs e)
        {
            var summary = new MaterialCost
            {
                MaterialTotal = decimal.TryParse(txtMaterialTotal.Text, out var mt) ? mt : 0,

                LaborCost = decimal.TryParse(txtLaborCost.Text, out var lc) ? lc : 0,
                Quantity = double.TryParse(txtQuantity.Text, out var q) ? q : 0,
                TotalLabor = decimal.TryParse(txtTotalLabor.Text, out var tl) ? tl : 0,

                GrandTotalCost = decimal.TryParse(lblGrandTotalCost.Text.Replace("₱", "").Trim(), out var gt) ? gt :0
            };

            CostCustomerNamePopup namePopup = new CostCustomerNamePopup(summary);
            namePopup.StartPosition = FormStartPosition.CenterScreen;
            namePopup.ShowDialog();
        }
    }
}
