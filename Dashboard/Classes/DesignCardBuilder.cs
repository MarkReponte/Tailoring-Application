using Dashboard.CostumizeTools;
using ReaLTaiizor.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace Dashboard.Classes
{
    public static class DesignCardBuilder
    {
        public class DesignCard
        {
            public MaterialCard Card { get; set; } = null!;
            public PictureBox PicBox { get; set; } = null!;
            public HopeButton RemoveBtn { get; set; } = null!;
            public ComboBox OrderLinkComboBox { get; set; } = null!;
        }

        public static DesignCard Build()
        {
            var card = new MaterialCard
            {
                Size = new Size(220, 245),
                BackColor = Color.FromArgb(142, 188, 30),
                Padding = new Padding(5),
                Margin = new Padding(10)
            };
            card.HandleCreated += (s, e) => RoundedItem.MakeRounded(card, 18);

            var pb = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(5, 5),
                Size = new Size(210, 165),
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

            var lblOrderLink = new Label
            {
                Text = "Linked order",
                Location = new Point(8, 178),
                Size = new Size(204, 18),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 60, 30),
                BackColor = Color.Transparent
            };

            var cboOrderLink = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(8, 200),
                Size = new Size(204, 30),
                Font = new Font("Segoe UI", 9f)
            };

            card.Controls.Add(pb);
            card.Controls.Add(lblOrderLink);
            card.Controls.Add(cboOrderLink);
            card.Controls.Add(btnRemove);
            btnRemove.BringToFront();

            return new DesignCard
            {
                Card = card,
                PicBox = pb,
                RemoveBtn = btnRemove,
                OrderLinkComboBox = cboOrderLink
            };
        }
    }
}
