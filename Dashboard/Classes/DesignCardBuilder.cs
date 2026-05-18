using Dashboard.CostumizeTools;
using Dashboard.Logics;
using ReaLTaiizor.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace Dashboard.Classes
{
    public static class DesignCardBuilder
    {
        public class DesignCard
        {
            public MaterialCard Card { get; set; }
            public PictureBox PicBox { get; set; }
            public HopeButton RemoveBtn { get; set; }
        }

        public static DesignCard Build()
        {
            var card = new MaterialCard
            {
                Size = new Size(160, 160),
                BackColor = Color.FromArgb(142, 188, 30),
                Padding = new Padding(5),
                Margin = new Padding(10)
            };
            card.HandleCreated += (s, e) => RoundedItem.MakeRounded(card, 30);

            var pb = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            var btnRemove = new HopeButton
            {
                Text = "✕",
                Size = new Size(30, 30),
                Location = new Point(card.Width - 35, 5),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                PrimaryColor = Color.FromArgb(255, 80, 80),
                ForeColor = Color.White
            };
            btnRemove.HandleCreated += (s, e) => RoundedItem.MakeRounded(btnRemove, 10);

            card.Controls.Add(pb);
            card.Controls.Add(btnRemove);
            btnRemove.BringToFront();

            return new DesignCard { Card = card, PicBox = pb, RemoveBtn = btnRemove };
        }
    }
}