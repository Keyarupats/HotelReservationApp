CREATE PROCEDURE [dbo].[spGetAvailableRooms]
    @CheckIn DATETIME,
    @CheckOut DATETIME,
    @Adults INT,
    @Children INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        r.RoomId,
        t.TypeName,
        t.RatePerAdult,
        r.BedCount,
        r.MaxAdults,
        r.MaxChildren,
        r.Status
    FROM [dbo].[tblRooms] r
    INNER JOIN [dbo].[tblRoomTypes] t ON r.RoomTypeId = t.RoomTypeId
    WHERE r.Status <> 'Maintenance'
      AND r.MaxAdults >= @Adults
      AND r.MaxChildren >= @Children
      AND r.RoomId NOT IN (
          SELECT res.RoomId 
          FROM [dbo].[tblReservations] res
          WHERE res.Status IN ('Pending', 'Confirmed', 'Occupied')
            AND (res.CheckInDateTime < @CheckOut AND res.ExpectedCheckOutDateTime > @CheckIn)
      )
    ORDER BY r.RoomId ASC;
END