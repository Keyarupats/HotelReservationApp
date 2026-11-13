CREATE PROCEDURE spGetRoomsByDate
    @TargetDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        r.RoomId,
        r.RoomTypeId,
        rt.TypeName,
        r.BedCount,
        r.MaxAdults,
        r.MaxChildren,
        rt.RatePerAdult,
        CASE 
            WHEN @TargetDate = CAST(GETDATE() AS DATE) AND r.Status IN ('Cleaning', 'Maintenance') 
                THEN r.Status

            WHEN EXISTS (
                SELECT 1 
                FROM tblReservations res
                WHERE res.RoomId = r.RoomId
                  AND res.Status IN ('Reserved', 'Occupied')
                  AND @TargetDate >= CAST(res.CheckInDateTime AS DATE)
                  AND @TargetDate < CAST(ISNULL(res.ExpectedCheckOutDateTime, DATEADD(DAY, 1, res.CheckInDateTime)) AS DATE)
            )
                THEN (
                    SELECT TOP 1 res.Status
                    FROM tblReservations res
                    WHERE res.RoomId = r.RoomId
                      AND res.Status IN ('Reserved', 'Occupied')
                      AND @TargetDate >= CAST(res.CheckInDateTime AS DATE)
                      AND @TargetDate < CAST(ISNULL(res.ExpectedCheckOutDateTime, DATEADD(DAY, 1, res.CheckInDateTime)) AS DATE)
                    ORDER BY CASE WHEN res.Status = 'Occupied' THEN 1 ELSE 2 END
                )

            WHEN @TargetDate > CAST(GETDATE() AS DATE) AND r.Status = 'Cleaning'
                THEN 'Available'

            ELSE r.Status
        END AS Status
    FROM [HotelDB].[dbo].[tblRooms] r
    INNER JOIN [HotelDB].[dbo].[tblRoomTypes] rt ON r.RoomTypeId = rt.RoomTypeId
    ORDER BY r.RoomId ASC;
END
GO