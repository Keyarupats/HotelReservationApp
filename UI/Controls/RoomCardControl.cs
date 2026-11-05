using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Model;

namespace UI
{
    public partial class RoomCardControl : UserControl
    {
        public RoomModel CurrentRoom { get; private set; }
        public event EventHandler RoomCardClicked;

        public RoomCardControl()
        {
            InitializeComponent();

            this.Click += new EventHandler(Card_Clicked);
            panel1.Click += new EventHandler(Card_Clicked);
            pictureBox1.Click += new EventHandler(Card_Clicked);
        }

        private void Card_Clicked(object sender, EventArgs e)
        {
            if (RoomCardClicked != null)
            {
                RoomCardClicked(this, EventArgs.Empty);
            }
        }

        public void SetRoomData(RoomModel room)
        {
            CurrentRoom = room;

            lblRoomNumber.Text = room.RoomId.ToString();
            lblRoomTier.Text = room.TypeName;
            lblRoomRate.Text = "₱" + room.RatePerAdult.ToString("N2");
            lblStatus.Text = room.Status;

            lblBeds.Text = room.BedCount.ToString();
            lblAbove10.Text = room.MaxAdults.ToString();
            lblBelow10.Text = room.MaxChildren.ToString();
            lblTotalCapacity.Text = (room.MaxAdults + room.MaxChildren).ToString();

            LoadRoomImage(room.TypeName, room.BedCount);

            ApplyStatusColor(room.Status);
        }

        private void LoadRoomImage(string tier, int beds)
        {
            try
            {
                int bedImageIndex = beds;
                if (bedImageIndex > 3)
                {
                    bedImageIndex = 3;
                }
                if (bedImageIndex < 1)
                {
                    bedImageIndex = 1;
                }

                string baseName = tier.Trim() + bedImageIndex.ToString() + "Bed";

                string appDir = AppDomain.CurrentDomain.BaseDirectory;

                string imgPathJpg = Path.Combine(appDir, "Images", baseName + ".jpg");
                string imgPathPng = Path.Combine(appDir, "Images", baseName + ".png");

                if (!File.Exists(imgPathJpg) && !File.Exists(imgPathPng))
                {
                    string projectDir = Path.GetFullPath(Path.Combine(appDir, @"..\..\..\..\Images"));
                    imgPathJpg = Path.Combine(projectDir, baseName + ".jpg");
                    imgPathPng = Path.Combine(projectDir, baseName + ".png");
                }

                if (File.Exists(imgPathJpg))
                {
                    pictureBox1.Image = Image.FromFile(imgPathJpg);
                }
                else if (File.Exists(imgPathPng))
                {
                    pictureBox1.Image = Image.FromFile(imgPathPng);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Image load notice: " + ex.Message);
            }
        }

        public void HighlightSelected(bool isSelected)
        {
            if (isSelected)
            {
                this.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                this.BorderStyle = BorderStyle.None;
            }
        }

        private void ApplyStatusColor(string status)
        {
            if (status == "Available")
            {
                this.BackColor = Color.Green;
                lblStatus.ForeColor = Color.Green;
            }
            else if (status == "Reserved")
            {
                this.BackColor = Color.Blue;
                lblStatus.ForeColor = Color.Blue;
            }
            else if (status == "Occupied")
            {
                this.BackColor = Color.Red;
                lblStatus.ForeColor = Color.Red;
            }
            else if (status == "Cleaning")
            {
                this.BackColor = Color.Gold;
                lblStatus.ForeColor = Color.DarkGoldenrod;
            }
            else if (status == "Maintenance")
            {
                this.BackColor = Color.Gray;
                lblStatus.ForeColor = Color.DimGray;
            }
        }
    }
}