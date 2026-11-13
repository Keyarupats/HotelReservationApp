using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // Change to System.Data.SqlClient if your project uses System.Data.SqlClient
using Model;

namespace HotelReservation.BusinessLogic.Repository
{
    public class BillingRepository
    {
        public List<MenuItemModel> GetMenuItems()
        {
            var list = new List<MenuItemModel>();
            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("spGetMenuItems", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new MenuItemModel
                        {
                            MenuItemId = Convert.ToInt32(rdr["MenuItemId"]),
                            ItemCode = rdr["ItemCode"].ToString(),
                            ItemName = rdr["ItemName"].ToString(),
                            Category = rdr["Category"].ToString(),
                            UnitPrice = Convert.ToDecimal(rdr["UnitPrice"])
                        });
                    }
                }
            }
            return list;
        }

        public DataTable GetOccupiedStaysRaw()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("spGetOccupiedStaysForBilling", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public bool SettleCheckout(CheckoutSettlementModel settlement)
        {
            string csvIds = string.Join(",", settlement.ReservationIds);

            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                conn.Open();

                foreach (var food in settlement.FoodOrders)
                {
                    using (SqlCommand foodCmd = new SqlCommand("spAddReservationAddOn", conn))
                    {
                        foodCmd.CommandType = CommandType.StoredProcedure;
                        foodCmd.Parameters.AddWithValue("@ReservationId", settlement.PrimaryReservationId);
                        foodCmd.Parameters.AddWithValue("@MenuItemId", food.MenuItemId);
                        foodCmd.Parameters.AddWithValue("@Quantity", food.Quantity);
                        foodCmd.Parameters.AddWithValue("@UnitPrice", food.UnitPrice);
                        foodCmd.ExecuteNonQuery();
                    }
                }

                using (SqlCommand cmd = new SqlCommand("spSettleCheckout", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReservationIdsCsv", csvIds);
                    cmd.Parameters.AddWithValue("@PrimaryReservationId", settlement.PrimaryReservationId);
                    cmd.Parameters.AddWithValue("@PaymentMethod", settlement.PaymentMethod);
                    cmd.Parameters.AddWithValue("@PaymentReference",
                        string.IsNullOrWhiteSpace(settlement.ReferenceNumber) ? (object)DBNull.Value : settlement.ReferenceNumber);
                    cmd.Parameters.AddWithValue("@AmountPaid", settlement.CashTendered);
                    cmd.Parameters.AddWithValue("@ChangeDue", settlement.ChangeDue);
                    cmd.Parameters.AddWithValue("@FinalGrandTotal", settlement.GrandTotal);

                    object res = cmd.ExecuteScalar();
                    return res != null && Convert.ToInt32(res) == 1;
                }
            }
        }

        public DataTable GetCompletedTransactionsRaw()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                string query = @"
                    SELECT 
                        res.ReservationId,
                        (g.FirstName + ' ' + ISNULL(g.MI + '. ', '') + g.LastName) AS GuestName,
                        res.RoomId,
                        res.CheckInDateTime,
                        res.ActualCheckOutDateTime,
                        ISNULL(res.TotalAmount, 0) AS RoomCharge, 
                        0.00 AS OverstayCharge, -- Expand if stored separately in tblReservations
                        0.00 AS FoodCharge,      -- Expand if stored separately
                        ISNULL(res.PaymentMethod, 'Cash') AS PaymentMethod,
                        res.AmountPaid,
                        res.ChangeDue,
                        res.PaymentReference
                    FROM tblReservations res
                    INNER JOIN tblGuests g ON res.GuestId = g.GuestId
                    WHERE res.Status = 'Completed'
                    ORDER BY res.ActualCheckOutDateTime DESC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}