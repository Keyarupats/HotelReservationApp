using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HotelReservation.BusinessLogic.Repository;
using Model;

namespace HotelReservation.BusinessLogic.Controller
{
    public class BillingController
    {
        private readonly BillingRepository billingRepo = new BillingRepository();

        public List<MenuItemModel> GetAvailableMenuItems()
        {
            return billingRepo.GetMenuItems();
        }

        public List<ActiveStayBillingModel> GetActiveOccupiedStays()
        {
            DataTable dt = billingRepo.GetOccupiedStaysRaw();
            var grouped = new List<ActiveStayBillingModel>();

            // Group rows belonging to the same guest & same check-in minute (handles 2-room bookings)
            var groups = dt.AsEnumerable().GroupBy(r => new
            {
                GuestId = Convert.ToInt32(r["GuestId"]),
                CheckInKey = Convert.ToDateTime(r["EffectiveCheckIn"]).ToString("yyyy-MM-dd HH:mm")
            });

            foreach (var grp in groups)
            {
                var first = grp.First();
                var stay = new ActiveStayBillingModel
                {
                    PrimaryReservationId = Convert.ToInt32(first["ReservationId"]),
                    GuestName = first["GuestName"].ToString(),
                    ContactNo = first["ContactNo"].ToString(),
                    CheckIn = Convert.ToDateTime(first["EffectiveCheckIn"]),
                    ExpectedCheckOut = Convert.ToDateTime(first["ExpectedCheckOutDateTime"])
                };

                var roomParts = new List<string>();
                var rateParts = new List<string>();
                var overstayParts = new List<string>();
                int roomCount = grp.Count();

                foreach (var row in grp)
                {
                    int resId = Convert.ToInt32(row["ReservationId"]);
                    int roomId = Convert.ToInt32(row["RoomId"]);
                    string typeName = row["TypeName"].ToString();
                    int adults = Convert.ToInt32(row["Adults"]);
                    int children = Convert.ToInt32(row["Children"]);
                    decimal rate = Convert.ToDecimal(row["RatePerAdult"]);
                    decimal overstayRate = Convert.ToDecimal(row["OverstayRatePerHour"]);
                    decimal baseCharge = Convert.ToDecimal(row["BaseRoomCharge"]);

                    stay.ReservationIds.Add(resId);
                    stay.Adults += adults;
                    stay.Children += children;
                    stay.RoomChargeTotal += baseCharge;
                    stay.CombinedOverstayHourlyRate += (adults * overstayRate);

                    roomParts.Add($"{roomId} ({typeName})");

                    if (roomCount == 1)
                    {
                        string adultWord = adults == 1 ? "adult" : "adults";
                        rateParts.Add($"{adults} {adultWord} × ₱{rate:N2}");
                        overstayParts.Add($"{adults} {adultWord} × ₱{overstayRate:N2}");
                    }
                    else
                    {
                        rateParts.Add($"{adults}A × ₱{rate:N2}");
                        overstayParts.Add($"{adults}A × ₱{overstayRate:N2}");
                    }
                }

                stay.RoomDisplay = string.Join(" & ", roomParts);
                stay.RateBreakdownLabel = string.Join(" + ", rateParts);
                stay.OverstayBreakdownLabel = string.Join(" + ", overstayParts);
                grouped.Add(stay);
            }

            return grouped;
        }

        public decimal CalculateOverstayCharge(ActiveStayBillingModel stay, int billableHours)
        {
            if (stay == null || billableHours <= 0) return 0m;
            return billableHours * stay.CombinedOverstayHourlyRate;
        }

        public bool CompleteCheckout(CheckoutSettlementModel settlement)
        {
            if (settlement == null || settlement.ReservationIds.Count == 0)
                throw new ArgumentException("No active reservation selected.");

            if (settlement.CashTendered < settlement.GrandTotal)
                throw new InvalidOperationException("Amount tendered is insufficient.");

            return billingRepo.SettleCheckout(settlement);
        }
    }
}