using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class RoomsUserControl : UserControl
    {
        public RoomsUserControl()
        {
            InitializeComponent();
        }

        private void RoomsUserControl_Load(object sender, EventArgs e)
        {
            cmbRoomType.SelectedIndex = 0;
            LoadAllRooms();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        public void LoadAllRooms()
        { 
            flpRooms.Controls.Clear();

            flpRooms.SuspendLayout();

            for (int i = 1; i <= 30; i++)
            {
                var roomCard = new RoomCardControl();
                roomCard.SetRoomDetails(
                    roomNumber: $"Room {i}",
                    roomTier: "Standard",
                    status: i % 2 == 0 ? "Available" : "Occupied",
                    rate: "$100",
                    beds: "2",
                    totalCapacity: "4",
                    above10: "2",
                    below10: "2"
                );
                flpRooms.Controls.Add(roomCard);
            }
            flpRooms.ResumeLayout();
        }
    }
}
