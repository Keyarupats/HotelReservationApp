using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class RoomCardControl : UserControl
    {
        public RoomCardControl()
        {
            InitializeComponent();
        }

        public void SetRoomDetails(string roomNumber, string roomTier, string status, string rate, string beds,
            string totalCapacity, string above10, string below10)
        {
            lblRoomNumber.Text = roomNumber;
            lblRoomTier.Text = roomTier;
            lblStatus.Text = status;
            lblRoomRate.Text = rate;
            lblBeds.Text = beds;
            lblTotalCapacity.Text = totalCapacity;
            lblAbove10.Text = above10;
            lblBelow10.Text = below10;

            ApplyStatusStyling(status);
        }

        private void ApplyStatusStyling(string status)
        {
            if (status == "Available")
            {
                this.BackColor = Color.LightGreen;
            }
            else if (status == "Occupied")
            {
                this.BackColor = Color.LightCoral;
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }

        }
    }
}
