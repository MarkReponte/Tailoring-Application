using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Dashboard.CostumizeTools
{
    public class NotificationPopup : Form
    {
        private System.Windows.Forms.Timer animationTimer;
        private bool isOpening;
        private int finalY;
        private int startY;

        public NotificationPopup()
        {
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
            header.Size = new Size(this.Width, 70);
            header.Location = new Point(0, 0);
            header.BackColor = Color.White;

            Label title = new Label();
            title.Text = "Notifications";
            title.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(30, 30, 30);
            title.AutoSize = true;
            title.Location = new Point(35, 25);
            title.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            LinkLabel markRead = new LinkLabel();
            markRead.Text = "Mark all as read";
            markRead.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            markRead.LinkColor = Color.FromArgb(38, 132, 255);
            markRead.ActiveLinkColor = Color.FromArgb(38, 132, 255);
            markRead.VisitedLinkColor = Color.FromArgb(38, 132, 255);
            markRead.AutoSize = true;
            markRead.Location = new Point(100, 28);
            markRead.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            header.Controls.Add(title);
            header.Controls.Add(markRead);

            FlowLayoutPanel notificationList = new FlowLayoutPanel();
            notificationList.Location = new Point(0, 70);
            notificationList.Size = new Size(this.Width, 405);
            notificationList.FlowDirection = FlowDirection.TopDown;
            notificationList.WrapContents = false;
            notificationList.AutoScroll = false;
            notificationList.BackColor = Color.White;

            

            Panel footer = new Panel();
            footer.Size = new Size(this.Width, 70);
            footer.Location = new Point(0, 475);
            footer.BackColor = Color.White;

            LinkLabel viewAll = new LinkLabel();
            viewAll.Text = "View all notifications";
            viewAll.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            viewAll.LinkColor = Color.FromArgb(38, 132, 255);
            viewAll.ActiveLinkColor = Color.FromArgb(38, 132, 255);
            viewAll.VisitedLinkColor = Color.FromArgb(38, 132, 255);
            viewAll.AutoSize = true;
            viewAll.Location = new Point((footer.Width - 135) / 2, 25);
            viewAll.Anchor = AnchorStyles.Top;

            footer.Controls.Add(viewAll);

            this.Controls.Add(header);
            this.Controls.Add(notificationList);
            this.Controls.Add(footer);
        }

        private Panel CreateNotificationItem(string initials, string message, string time, bool highlighted)
        {
            Panel row = new Panel();
            row.Size = new Size(this.Width, 95);
            row.BackColor = highlighted ? Color.FromArgb(245, 250, 255) : Color.White;

            row.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(235, 235, 235)))
                {
                    e.Graphics.DrawLine(pen, 0, row.Height - 1, row.Width, row.Height - 1);
                }
            };

            Label avatar = CreateAvatar(initials);
            avatar.Location = new Point(35, 25);

            Panel onlineDot = new Panel();
            onlineDot.Size = new Size(9, 9);
            onlineDot.Location = new Point(73, 58);
            onlineDot.BackColor = Color.FromArgb(39, 219, 96);
            MakeRound(onlineDot, 9);

            Label messageLabel = new Label();
            messageLabel.Text = message;
            messageLabel.Font = new Font("Segoe UI", 9);
            messageLabel.ForeColor = Color.FromArgb(70, 70, 70);
            messageLabel.Size = new Size(260, 50);
            messageLabel.Location = new Point(105, 25);

            Label timeLabel = new Label();
            timeLabel.Text = time;
            timeLabel.Font = new Font("Segoe UI", 8);
            timeLabel.ForeColor = Color.FromArgb(180, 180, 180);
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(380, 28);

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
        }

        public void ShowPopup(Form owner, Control anchorButton)
        {
            if (this.Visible)
            {
                HidePopup();
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

        private void AnimationTimer_Tick(object sender, EventArgs e)
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