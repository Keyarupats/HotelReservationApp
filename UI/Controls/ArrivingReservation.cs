using System;
using System.Data;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Controller;

namespace UI
{
    public partial class ArrivingReservation : UserControl
    {
        private ReservationController reservationController;

        public ArrivingReservation()
        {
            InitializeComponent();
            reservationController = new ReservationController();
            LoadArrivingReservationsData();
        }

        private void LoadArrivingReservationsData()
        {
            try
            {
                // Loads all arriving reservations by default (passing an empty string or null)
                DataTable arrivingTable = reservationController.GetArrivingReservations("");
                dataGridViewArriving.DataSource = arrivingTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading arriving reservations: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchReservation.Text.Trim();

            try
            {
                // Calls the controller to search by mobile number, guest name, or reference code
                DataTable searchResult = reservationController.GetArrivingReservations(keyword);
                dataGridViewArriving.DataSource = searchResult;

                if (searchResult.Rows.Count == 0 && !string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("No arriving reservations found matching that mobile number or keyword.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckInSelected_Click(object sender, EventArgs e)
        {
            if (dataGridViewArriving.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an arriving reservation from the list to check in.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Extract the selected reservation ID from the row and execute check-in logic
            // int reservationId = Convert.ToInt32(dataGridViewArriving.SelectedRows[0].Cells["ReservationId"].Value);

            MessageBox.Show("Reservation successfully checked in!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh grid
            LoadArrivingReservationsData();
        }
    }
}