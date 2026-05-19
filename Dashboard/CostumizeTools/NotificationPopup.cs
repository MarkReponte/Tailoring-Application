using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Dashboard.Classes;

namespace Dashboard.CostumizeTools
{
    public class NotificationPopup : Form
    {
        private System.Windows.Forms.Timer animationTimer;
        private bool isOpening;
        private int finalY;
        private int startY;
        private FlowLayoutPanel notificationList = null!;
        private Label emptyStateLabel = null!;

        public NotificationPopup()
        {
            this.BackColor = Color.Red;
            this.Size = new Size(400, 500);
            NotificationManager.NotificationChanged += () =>
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => LoadNotifications()));
                }
                else
                {
                    LoadNotifications();
                }
            };
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(375, 450);
            this.BackColor = Color.White;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Opacity = 0;
            this.DoubleBuffered = true;

            BuildNotificationUI();

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10;
            animationTimer.Tick += AnimationTimer_Tick;

            this.Deactivate += (s, e) =>
            {
                if (this.Visible)
                {
                    HidePopup();
                }
            };
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000;
                return cp;
            }
        }

        private void BuildNotificationUI()
        {
            Panel header = new Panel();
            header.Size = new Size(this.Width, 64);
            header.Location = new Point(0, 0);
            header.BackColor = Color.White;

            Label title = new Label();
            title.Text = "Notifications";
            title.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(30, 30, 30);
            title.AutoSize = true;
            title.Location = new Point(24, 22);
            title.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            LinkLabel markRead = new LinkLabel();
            markRead.Text = "Mark all as read";
            markRead.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            markRead.LinkColor = Color.FromArgb(38, 132, 255);
            markRead.ActiveLinkColor = Color.FromArgb(38, 132, 255);
            markRead.VisitedLinkColor = Color.FromArgb(38, 132, 255);
            markRead.AutoSize = true;
            markRead.Location = new Point(255, 25);
            markRead.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            markRead.Click += (s, e) =>
            {
                NotificationManager.MarkAllAsRead();
                LoadNotifications();
            };

            header.Controls.Add(title);
            header.Controls.Add(markRead);

            notificationList = new FlowLayoutPanel();
            notificationList.Location = new Point(0, 64);
            notificationList.Size = new Size(this.Width, this.Height - 64);
            notificationList.FlowDirection = FlowDirection.TopDown;
            notificationList.WrapContents = false;
            notificationList.AutoScroll = true;
            notificationList.BackColor = Color.White;

            emptyStateLabel = new Label();
            emptyStateLabel.Text = "No notifications yet";
            emptyStateLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            emptyStateLabel.ForeColor = Color.FromArgb(120, 120, 120);
            emptyStateLabel.TextAlign = ContentAlignment.MiddleCenter;
            emptyStateLabel.Size = notificationList.Size;
            emptyStateLabel.Location = notificationList.Location;
            emptyStateLabel.Visible = false;

            this.Controls.Add(header);
            this.Controls.Add(notificationList);
            this.Controls.Add(emptyStateLabel);
        }

        private Panel CreateNotificationItem(string initials, string message, string time, bool highlighted)
        {
            Panel row = new Panel();
            int rowWidth = Math.Max(320, notificationList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 4);
            row.Size = new Size(rowWidth, 86);
            row.BackColor = highlighted ? Color.FromArgb(245, 250, 255) : Color.White;
            row.Cursor = Cursors.Hand;

            row.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(235, 235, 235)))
                {
                    e.Graphics.DrawLine(pen, 0, row.Height - 1, row.Width, row.Height - 1);
                }
            };

            Label avatar = CreateAvatar(initials);
            avatar.Location = new Point(24, 20);

            Panel onlineDot = new Panel();
            onlineDot.Size = new Size(9, 9);
            onlineDot.Location = new Point(62, 53);
            onlineDot.BackColor = highlighted ? Color.FromArgb(220, 20, 60) : Color.FromArgb(39, 219, 96);
            MakeRound(onlineDot, 9);

            Label messageLabel = new Label();
            messageLabel.Text = message;
            messageLabel.Font = new Font("Segoe UI", 9);
            messageLabel.ForeColor = Color.FromArgb(70, 70, 70);
            messageLabel.Size = new Size(row.Width - 160, 50);
            messageLabel.Location = new Point(82, 19);
            messageLabel.Cursor = Cursors.Hand;

            Label timeLabel = new Label();
            timeLabel.Text = time;
            timeLabel.Font = new Font("Segoe UI", 8);
            timeLabel.ForeColor = Color.FromArgb(180, 180, 180);
            timeLabel.TextAlign = ContentAlignment.TopRight;
            timeLabel.Size = new Size(68, 18);
            timeLabel.Location = new Point(row.Width - timeLabel.Width - 8, 21);
            timeLabel.Cursor = Cursors.Hand;

            row.Controls.Add(avatar);
            row.Controls.Add(onlineDot);
            row.Controls.Add(messageLabel);
            row.Controls.Add(timeLabel);

            return row;
        }

        private Panel CreateRequestItem(string initials, string message, string time)
        {
            Panel row = CreateNotificationItem(initials, message, time, false);

            Button acceptButton = new Button();
            acceptButton.Text = "Accept";
            acceptButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            acceptButton.ForeColor = Color.White;
            acceptButton.BackColor = Color.FromArgb(38, 132, 255);
            acceptButton.FlatStyle = FlatStyle.Flat;
            acceptButton.FlatAppearance.BorderSize = 0;
            acceptButton.Size = new Size(80, 30);
            acceptButton.Location = new Point(105, 58);

            Button declineButton = new Button();
            declineButton.Text = "Decline";
            declineButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            declineButton.ForeColor = Color.FromArgb(38, 132, 255);
            declineButton.BackColor = Color.White;
            declineButton.FlatStyle = FlatStyle.Flat;
            declineButton.FlatAppearance.BorderColor = Color.FromArgb(38, 132, 255);
            declineButton.Size = new Size(80, 30);
            declineButton.Location = new Point(195, 58);

            row.Controls.Add(acceptButton);
            row.Controls.Add(declineButton);

            return row;
        }

        private Label CreateAvatar(string initials)
        {
            Label avatar = new Label();
            avatar.Text = initials;
            avatar.TextAlign = ContentAlignment.MiddleCenter;
            avatar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            avatar.ForeColor = Color.White;
            avatar.BackColor = Color.FromArgb(38, 132, 255);
            avatar.Size = new Size(44, 44);

            avatar.Resize += (s, e) =>
            {
                MakeRound(avatar, avatar.Width);
            };

            MakeRound(avatar, avatar.Width);

            return avatar;
        }

        private void MakeRound(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, radius, radius);
            control.Region = new Region(path);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);

            if (notificationList != null)
            {
                notificationList.Size = new Size(this.Width, this.Height - notificationList.Top);
            }

            if (emptyStateLabel != null)
            {
                emptyStateLabel.Size = new Size(this.Width, this.Height - emptyStateLabel.Top);
            }
        }
        public void LoadNotifications()
        {
            notificationList.Controls.Clear();
            emptyStateLabel.Visible = !NotificationManager.Notifications.Any();
            notificationList.Visible = !emptyStateLabel.Visible;

            foreach (var notif in NotificationManager.Notifications)
            {
                Panel item = CreateNotificationItem(
                    "RE",
                    notif.Title + "\n" + notif.Message,
                    notif.Time.ToString("hh:mm tt"),
                    !notif.IsRead
                );

                AttachReadClick(item, notif);
                notificationList.Controls.Add(item);
            }

            notificationList.HorizontalScroll.Enabled = false;
            notificationList.HorizontalScroll.Visible = false;
            notificationList.AutoScrollMinSize = new Size(0, 0);
        }

        private void AttachReadClick(Control control, AppNotification notification)
        {
            control.Click += (s, e) => NotificationManager.MarkAsRead(notification);

            foreach (Control child in control.Controls)
            {
                child.Cursor = Cursors.Hand;
                AttachReadClick(child, notification);
            }
        }
        public void ShowPopup(Form owner, Control anchorButton)
        {
            if (this.Visible)
            {
                LoadNotifications();
                this.BringToFront();
                return;
            }

            Point buttonScreenLocation = anchorButton.PointToScreen(Point.Empty);

            int x = buttonScreenLocation.X + anchorButton.Width - this.Width;
            int y = buttonScreenLocation.Y + anchorButton.Height + 12;

            Rectangle screen = Screen.FromControl(owner).WorkingArea;

            if (x < screen.Left + 10)
                x = screen.Left + 10;

            if (x + this.Width > screen.Right - 10)
                x = screen.Right - this.Width - 10;

            if (y + this.Height > screen.Bottom - 10)
                y = screen.Bottom - this.Height - 10;

            finalY = y;
            startY = y - 20;

            this.Location = new Point(x, startY);
            this.Opacity = 0;
            this.isOpening = true;

            this.Show(owner);
            this.BringToFront();

            animationTimer.Start();
        }

        public void HidePopup()
        {
            if (!this.Visible)
                return;

            isOpening = false;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (isOpening)
            {
                this.Opacity += 0.08;

                if (this.Top < finalY)
                    this.Top += 3;

                if (this.Opacity >= 0.98)
                {
                    this.Opacity = 0.98;
                    this.Top = finalY;
                    animationTimer.Stop();
                }
            }
            else
            {
                this.Opacity -= 0.08;
                this.Top -= 3;

                if (this.Opacity <= 0)
                {
                    animationTimer.Stop();
                    this.Hide();
                }
            }
        }
    }
}
