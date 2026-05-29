using ReaLTaiizor.Controls;
using AppDomain.Models;
using AppInfrastructure.Data;
using Dashboard.Classes;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace Dashboard
{
    public partial class Form1
    {
        private const string DashboardActionColumnName = "Action";
        private const string DashboardSelectColumnName = "SelectRow";
        private bool _dashboardReportStyled;
        private Label? _monthlyCostCaption;
        private Label? _monthlyRevenueCaption;
        private Label? _customersCaption;

        private void ConfigureSmoothDashboard()
        {
            Color pageBack = Color.FromArgb(247, 249, 252);
            Color ink = Color.FromArgb(31, 41, 55);
            Color muted = Color.FromArgb(100, 116, 139);
            Color accent = Color.FromArgb(95, 91, 235);

            MainDashboard.BackColor = pageBack;
            materialCard1.BackColor = Color.White;
            materialCard1.BorderStyle = BorderStyle.None;
            materialCard7.BackColor = pageBack;
            materialCard7.BorderStyle = BorderStyle.None;
            materialCard7.Padding = new Padding(24, 18, 24, 24);

            hopeGroupBox5.BackColor = pageBack;
            hopeGroupBox5.ThemeColor = pageBack;
            hopeGroupBox5.LineColor = pageBack;
            styledPanel9.BackColor = Color.White;
            styledPanel9.BorderColor = Color.FromArgb(231, 235, 244);
            styledPanel9.BorderWidth = 1;
            styledPanel9.CornerRadius = 8;
            styledPanel9.ShowShadow = true;

            materialLabel1.ForeColor = accent;
            materialLabel1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            materialLabel7.ForeColor = ink;
            materialLabel7.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            materialLabel9.ForeColor = ink;
            materialLabel9.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            panel1.BackColor = pageBack;
            panel1.Location = new Point(21, 56);
            panel1.Size = new Size(materialCard7.Width - 42, 130);
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            tableLayoutPanel1.BackColor = pageBack;
            tableLayoutPanel1.Padding = new Padding(0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Location = Point.Empty;
            tableLayoutPanel1.Size = new Size(panel1.Width, 124);
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            StyleMetricPanel(pgpMonthlyCost, Color.FromArgb(219, 249, 224), Color.FromArgb(17, 126, 52));
            StyleMetricPanel(pgpProfit, Color.FromArgb(220, 240, 255), Color.FromArgb(37, 99, 235));
            StyleMetricPanel(pgpNewCustomer, Color.FromArgb(239, 249, 222), Color.FromArgb(63, 125, 34));

            StyleMetricText(moonLabel1, lblMonthlyCost, ref _monthlyCostCaption, pgpMonthlyCost, "Monthly Cost", "current month total");
            StyleMetricText(moonLabel2, lblMonthlyRevenue, ref _monthlyRevenueCaption, pgpProfit, "Monthly Revenue", "paid labor income");
            StyleMetricText(moonLabel3, lblCustomers, ref _customersCaption, pgpNewCustomer, "Total Customers", "active customer count");

            StyleMetricIcon(pictureBox11, Color.FromArgb(178, 241, 191));
            StyleMetricIcon(pictureBox12, Color.FromArgb(179, 221, 252));
            StyleMetricIcon(pictureBox13, Color.FromArgb(218, 241, 178));

            StyleSectionIcon(pictureBox1, new Point(28, 23));
            StyleSectionIcon(pictureBox2, new Point(28, 218));
            materialLabel7.Location = new Point(52, 23);
            materialLabel9.Location = new Point(52, 218);

            LayoutDashboardReport();
            hopeGroupBox5.SendToBack();
            styledPanel9.SendToBack();
            panel1.BringToFront();
            pictureBox1.BringToFront();
            materialLabel7.BringToFront();
            pictureBox2.BringToFront();
            materialLabel9.BringToFront();
            dgvReport.BringToFront();

            ConfigureDashboardReportGrid();

            materialCard7.SizeChanged -= DashboardCard_SizeChanged;
            materialCard7.SizeChanged += DashboardCard_SizeChanged;
            btnNotification.BackColor = Color.Transparent;
        }

        private void DashboardCard_SizeChanged(object? sender, EventArgs e)
        {
            panel1.Width = materialCard7.Width - 42;
            tableLayoutPanel1.Width = panel1.Width;
            LayoutDashboardReport();
        }

        private void LayoutDashboardReport()
        {
            const int reportPanelX = 24;
            const int reportPanelY = 244;
            const int reportPanelSidePadding = 20;
            const int gridTopPadding = 44;
            const int gridBottomPadding = 24;

            int reportPanelWidth = Math.Max(320, materialCard7.ClientSize.Width - (reportPanelX * 2));
            int reportPanelHeight = Math.Max(260, materialCard7.ClientSize.Height - reportPanelY - 22);

            styledPanel9.Location = new Point(
                reportPanelX - hopeGroupBox5.Left,
                reportPanelY - hopeGroupBox5.Top);
            styledPanel9.Size = new Size(reportPanelWidth, reportPanelHeight);
            styledPanel9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            dgvReport.Location = new Point(reportPanelX + reportPanelSidePadding, reportPanelY + gridTopPadding);
            dgvReport.Size = new Size(
                reportPanelWidth - (reportPanelSidePadding * 2),
                Math.Max(160, reportPanelHeight - gridTopPadding - gridBottomPadding));
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        private static void StyleMetricPanel(ParrotGradientPanel panel, Color fill, Color primer)
        {
            panel.TopLeft = fill;
            panel.TopRight = fill;
            panel.BottomLeft = fill;
            panel.BottomRight = fill;
            panel.PrimerColor = primer;
            panel.Margin = new Padding(9, 0, 9, 10);
            panel.Padding = new Padding(18, 14, 18, 12);
            panel.Paint -= MetricPanel_Paint;
            panel.Paint += MetricPanel_Paint;
            panel.SizeChanged -= MetricPanel_SizeChanged;
            panel.SizeChanged += MetricPanel_SizeChanged;
            ApplyRoundedRegion(panel, 8);
        }

        private static void MetricPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Control control) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(1, 1, control.Width - 3, control.Height - 3);

            using GraphicsPath border = RoundedRect(rect, 8);
            using Pen pen = new Pen(Color.FromArgb(214, 223, 235), 1);
            e.Graphics.DrawPath(pen, border);
        }

        private static void MetricPanel_SizeChanged(object? sender, EventArgs e)
        {
            if (sender is Control control)
            {
                ApplyRoundedRegion(control, 8);
            }
        }

        private static void ApplyRoundedRegion(Control control, int radius)
        {
            control.Region?.Dispose();
            control.Region = CreateRoundedRegion(control.Width, control.Height, radius);
        }

        private static void StyleMetricText(
            MoonLabel title,
            MoonLabel value,
            ref Label? caption,
            Control parent,
            string titleText,
            string captionText)
        {
            title.Text = titleText;
            title.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(15, 23, 42);
            title.Location = new Point(122, 23);

            value.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            value.Location = new Point(122, 48);
            value.ForeColor = titleText.Contains("Revenue")
                ? Color.FromArgb(37, 99, 235)
                : Color.FromArgb(22, 128, 59);

            caption ??= new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8F, FontStyle.Regular),
                ForeColor = Color.FromArgb(75, 85, 99)
            };

            caption.Text = captionText;
            caption.Location = new Point(124, 84);
            if (!parent.Controls.Contains(caption))
            {
                parent.Controls.Add(caption);
            }
            caption.BringToFront();
        }

        private static void StyleMetricIcon(PictureBox icon, Color backColor)
        {
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.BackColor = backColor;
            icon.Location = new Point(25, 27);
            icon.Size = new Size(72, 72);
            icon.Padding = new Padding(14);
            icon.Region = CreateRoundedRegion(icon.Width, icon.Height, 36);
        }

        private static void StyleSectionIcon(PictureBox icon, Point location)
        {
            icon.Location = location;
            icon.Size = new Size(18, 18);
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.BackColor = Color.Transparent;
        }

        private void ConfigureDashboardReportGrid()
        {
            DataGridView grid = dgvReport;
            grid.SuspendLayout();

            EnableDoubleBuffering(grid);
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.RowHeadersVisible = false;
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;
            grid.GridColor = Color.FromArgb(242, 245, 249);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.EnableHeadersVisualStyles = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 46;
            grid.RowTemplate.Height = 48;
            grid.ReadOnly = false;
            LayoutDashboardReport();

            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = Color.FromArgb(71, 85, 105),
                SelectionBackColor = Color.FromArgb(248, 250, 252),
                SelectionForeColor = Color.FromArgb(71, 85, 105),
                Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 8, 0),
                WrapMode = DataGridViewTriState.False
            };

            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 65, 85),
                SelectionBackColor = Color.FromArgb(242, 247, 255),
                SelectionForeColor = Color.FromArgb(15, 23, 42),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                Padding = new Padding(8, 0, 8, 0),
                WrapMode = DataGridViewTriState.False
            };

            grid.Columns.Clear();
            grid.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = DashboardSelectColumnName,
                HeaderText = string.Empty,
                Width = 42,
                FillWeight = 34,
                ReadOnly = false
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CustomerName",
                DataPropertyName = "CustomerName",
                HeaderText = "CUSTOMER NAME",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 170,
                ReadOnly = true
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OrderValue",
                DataPropertyName = "OrderValue",
                HeaderText = "ORDER VALUE",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 90,
                ReadOnly = true
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OrderDeadline",
                DataPropertyName = "OrderDeadline",
                HeaderText = "ORDER DATE",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 95,
                ReadOnly = true
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                DataPropertyName = "Status",
                HeaderText = "STATUS",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 90,
                ReadOnly = true
            });
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = DashboardActionColumnName,
                HeaderText = string.Empty,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 64,
                ReadOnly = true
            });
            if (grid.Columns[DashboardActionColumnName] is DataGridViewColumn actionColumn)
            {
                actionColumn.ToolTipText = "Edit order";
            }

            if (!_dashboardReportStyled)
            {
                grid.CellPainting += DashboardReport_CellPainting;
                grid.CellFormatting += DashboardReport_CellFormatting;
                grid.DataBindingComplete += DashboardReport_DataBindingComplete;
                grid.CellClick += DashboardReport_CellClick;
                grid.CellMouseEnter += DashboardReport_CellMouseEnter;
                grid.CellMouseLeave += DashboardReport_CellMouseLeave;
                _dashboardReportStyled = true;
            }

            grid.ResumeLayout();
        }

        private static void DashboardReport_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender is not DataGridView grid || e.RowIndex < 0) return;

            grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = e.RowIndex % 2 == 0
                ? Color.White
                : Color.FromArgb(252, 253, 255);
        }

        private static void DashboardReport_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is not DataGridView grid) return;

            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Height = 48;
            }
        }

        private async void DashboardReport_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is not DataGridView grid || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (grid.Columns[e.ColumnIndex].Name != DashboardActionColumnName) return;
            if (grid.Rows[e.RowIndex].DataBoundItem is not DetailedReportRow row) return;

            await LoadMeasurementForEditAsync(row.MeasurementId);
        }

        private static void DashboardReport_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is not DataGridView grid || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (grid.Columns[e.ColumnIndex].Name == DashboardActionColumnName)
            {
                grid.Cursor = Cursors.Hand;
            }
        }

        private static void DashboardReport_CellMouseLeave(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView grid)
            {
                grid.Cursor = Cursors.Default;
            }
        }

        private async Task LoadMeasurementForEditAsync(Guid measurementId)
        {
            try
            {
                using var db = new SewingDbContext();
                Measurements? measurement = await db.Measurements
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == measurementId);

                if (measurement == null)
                {
                    MessageBox.Show("This order could not be found. It may have been deleted.", "Order Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PopulateMeasurementForm(measurement);
                mtcSelectionControl.SelectedTab = BodyMeasurement;
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open this order for editing: {ex.Message}", "Edit Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateMeasurementForm(Measurements measurement)
        {
            _editingMeasurementId = measurement.Id;
            SetCyberText(txtName, measurement.CustomerName);
            hcbGender.SelectedItem = measurement.Gender;
            pdtOrderDeadline.Value = measurement.OrderDeadline;
            btnSubmit.Text = "Update";

            SetCyberValue(txtShoulder, measurement.Shoulder);
            SetCyberValue(txtArmCircumference, measurement.ArmCircumference);
            SetCyberValue(txtFrontFigure, measurement.FrontFigure);
            SetCyberValue(txtUpperBust, measurement.UpperBust);
            SetCyberValue(txtBust, measurement.Bust);
            SetCyberValue(txtLowerBust, measurement.LowerBust);
            SetCyberValue(txtBackFigure, measurement.BackFigure);
            SetCyberValue(txtFrontChest, measurement.FrontChest);
            SetCyberValue(txtBackChest, measurement.BackChest);
            SetCyberValue(txtUpperHips, measurement.UpperHips);
            SetCyberValue(txtWaistline, measurement.Waistline);
            SetCyberValue(txtNeckDip, measurement.NeckDip);
            SetCyberValue(txtArmHole, measurement.ArmHole);
            SetCyberValue(txtSleeveLength, measurement.SleeveLength);
            SetCyberValue(txtLowerHips, measurement.LowerHips);
            SetCyberValue(txtCrotch, measurement.Crotch);
            SetCyberValue(txtThigh, measurement.Thigh);
            SetCyberValue(txtCalfCircumference, measurement.CalfCircumference);
            SetCyberValue(txtLength, measurement.Length);
        }

        private static void SetCyberValue(CyberTextBox field, double value)
        {
            string text = value == 0 ? string.Empty : value.ToString("0.##");

            foreach (Control control in field.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = text;
                    break;
                }
            }

            field.Text = text;
            field.Invalidate();
        }

        private static void DashboardReport_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (sender is not DataGridView grid || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = grid.Columns[e.ColumnIndex].Name;
            if (columnName == "CustomerName")
            {
                PaintCustomerCell(e);
                return;
            }

            if (columnName == "Status")
            {
                PaintStatusCell(e);
                return;
            }

            if (columnName == DashboardActionColumnName)
            {
                PaintEditCell(e);
            }
        }

        private static void PaintCustomerCell(DataGridViewCellPaintingEventArgs e)
        {
            e.PaintBackground(e.ClipBounds, true);

            string text = Convert.ToString(e.FormattedValue) ?? string.Empty;
            Rectangle bounds = e.CellBounds;
            Rectangle avatar = new Rectangle(bounds.Left + 16, bounds.Top + 10, 28, 28);
            Graphics graphics = e.Graphics!;

            Color avatarBack = AvatarColor(text);
            using (GraphicsPath path = new GraphicsPath())
            using (SolidBrush avatarBrush = new SolidBrush(avatarBack))
            using (Font initialFont = new Font("Segoe UI Semibold", 8F, FontStyle.Bold))
            using (Font nameFont = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddEllipse(avatar);
                graphics.FillPath(avatarBrush, path);

                string initials = GetInitials(text);
                TextRenderer.DrawText(graphics, initials, initialFont, avatar, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                Rectangle textBounds = new Rectangle(bounds.Left + 55, bounds.Top, bounds.Width - 60, bounds.Height);
                TextRenderer.DrawText(graphics, text, nameFont, textBounds, Color.FromArgb(15, 23, 42),
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }

            e.Handled = true;
        }

        private static void PaintStatusCell(DataGridViewCellPaintingEventArgs e)
        {
            e.PaintBackground(e.ClipBounds, true);

            string status = Convert.ToString(e.FormattedValue) ?? string.Empty;
            (Color back, Color fore) = StatusColors(status);
            Font font = e.CellStyle?.Font ?? Control.DefaultFont;
            Graphics graphics = e.Graphics!;
            Size textSize = TextRenderer.MeasureText(status, font);
            Rectangle pill = new Rectangle(
                e.CellBounds.Left + 14,
                e.CellBounds.Top + (e.CellBounds.Height - 24) / 2,
                Math.Min(textSize.Width + 20, e.CellBounds.Width - 24),
                24);

            using GraphicsPath path = RoundedRect(pill, 12);
            using SolidBrush backBrush = new SolidBrush(back);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(backBrush, path);
            TextRenderer.DrawText(graphics, status, font, pill, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            e.Handled = true;
        }

        private static void PaintEditCell(DataGridViewCellPaintingEventArgs e)
        {
            e.PaintBackground(e.ClipBounds, true);

            Rectangle icon = new Rectangle(
                e.CellBounds.Left + (e.CellBounds.Width - 22) / 2,
                e.CellBounds.Top + (e.CellBounds.Height - 22) / 2,
                22,
                22);

            Graphics graphics = e.Graphics!;

            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(Properties.Resources.edit, icon);

            e.Handled = true;
        }

        private static (Color Back, Color Fore) StatusColors(string status)
        {
            string normalized = status.Trim().ToLowerInvariant();

            if (normalized.Contains("progress"))
            {
                return (Color.FromArgb(255, 247, 224), Color.FromArgb(180, 83, 9));
            }

            if (normalized.Contains("complete") || normalized.Contains("done"))
            {
                return (Color.FromArgb(226, 252, 236), Color.FromArgb(22, 101, 52));
            }

            return (Color.FromArgb(232, 242, 255), Color.FromArgb(37, 99, 235));
        }

        private static string GetInitials(string value)
        {
            string[] parts = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return "?";
            if (parts.Length == 1) return parts[0][0].ToString().ToUpperInvariant();

            return string.Concat(parts[0][0], parts[^1][0]).ToUpperInvariant();
        }

        private static Color AvatarColor(string value)
        {
            Color[] colors =
            {
                Color.FromArgb(96, 165, 250),
                Color.FromArgb(52, 211, 153),
                Color.FromArgb(251, 146, 60),
                Color.FromArgb(167, 139, 250),
                Color.FromArgb(244, 114, 182)
            };

            int hash = Math.Abs(value.GetHashCode());
            return colors[hash % colors.Length];
        }

        private static GraphicsPath RoundedRect(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.Left, rect.Top, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Top, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static Region CreateRoundedRegion(int width, int height, int radius)
        {
            return new Region(RoundedRect(new Rectangle(0, 0, width, height), radius));
        }

        private static void EnableDoubleBuffering(DataGridView grid)
        {
            typeof(DataGridView)
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(grid, true, null);
        }
    }
}
