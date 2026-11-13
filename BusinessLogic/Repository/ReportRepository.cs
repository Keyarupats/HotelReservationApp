using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // Switch to System.Data.SqlClient if needed
using Model;

namespace HotelReservation.BusinessLogic.Repository
{
    public class ReportRepository
    {
        private readonly string connectionString;

        public ReportRepository()
        {
            connectionString = DatabaseConfig.ConnectionString;
        }

        public List<RoomTypeReportRow> GetRevenueAndStaysByRoomType(DateTime startDate, DateTime endDate)
        {
            var rows = new List<RoomTypeReportRow>();

            string query = @"
                SELECT 
                    rt.TypeName AS RoomType,
                    COUNT(res.ReservationId) AS StaysCompleted,
                    ISNULL(SUM(
                        CASE 
                            WHEN res.AmountPaid > 0 THEN (res.AmountPaid - res.ChangeDue)
                            ELSE res.TotalAmount 
                        END
                    ), 0.00) AS TotalGeneratedRevenue
                FROM tblRoomTypes rt
                LEFT JOIN tblRooms r ON rt.RoomTypeId = r.RoomTypeId
                LEFT JOIN tblReservations res 
                    ON r.RoomId = res.RoomId
                    AND res.Status = 'Completed'
                    AND CAST(ISNULL(res.ActualCheckOutDateTime, res.ExpectedCheckOutDateTime) AS DATE) >= @StartDate
                    AND CAST(ISNULL(res.ActualCheckOutDateTime, res.ExpectedCheckOutDateTime) AS DATE) <= @EndDate
                GROUP BY rt.RoomTypeId, rt.TypeName
                ORDER BY rt.RoomTypeId ASC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate.Date;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate.Date;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rows.Add(new RoomTypeReportRow
                        {
                            RoomType = reader["RoomType"].ToString(),
                            StaysCompleted = Convert.ToInt32(reader["StaysCompleted"]),
                            TotalGeneratedRevenue = Convert.ToDecimal(reader["TotalGeneratedRevenue"])
                        });
                    }
                }
            }

            return rows;
        }

        public decimal GetOccupancyRate(DateTime startDate, DateTime endDate)
        {
            string query = @"
                DECLARE @TotalDays INT = DATEDIFF(DAY, @StartDate, @EndDate) + 1;
                DECLARE @ActiveRooms INT = (SELECT COUNT(*) FROM tblRooms WHERE Status <> 'Maintenance');

                IF (@TotalDays <= 0 OR @ActiveRooms <= 0)
                BEGIN
                    SELECT CAST(0.00 AS DECIMAL(5,2));
                    RETURN;
                END

                ;WITH DateSeries AS (
                    SELECT @StartDate AS ReportDate
                    UNION ALL
                    SELECT DATEADD(DAY, 1, ReportDate)
                    FROM DateSeries
                    WHERE ReportDate < @EndDate
                )
                SELECT 
                    CAST(
                        (COUNT(DISTINCT CONCAT(res.RoomId, '_', CONVERT(VARCHAR(10), ds.ReportDate, 120))) * 100.0) 
                        / (@ActiveRooms * @TotalDays)
                    AS DECIMAL(5,2))
                FROM DateSeries ds
                LEFT JOIN tblReservations res
                    ON res.Status IN ('Confirmed', 'Occupied', 'Completed')
                    AND CAST(ISNULL(res.ActualCheckInDateTime, res.CheckInDateTime) AS DATE) <= ds.ReportDate
                    AND CAST(ISNULL(res.ActualCheckOutDateTime, res.ExpectedCheckOutDateTime) AS DATE) >= ds.ReportDate
                OPTION (MAXRECURSION 3660);";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate.Date;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate.Date;

                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    decimal rate = Convert.ToDecimal(result);
                    return rate > 100m ? 100m : rate;
                }
                return 0m;
            }
        }
    }
}