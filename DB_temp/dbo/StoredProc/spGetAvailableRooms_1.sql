CREATE PROCEDURE spGetAvailableRooms
    @CheckIn DATETIME,
    @CheckOut DATETIME,
    @Adults INT,
    @Children INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        r.RoomId,
        rt.TypeName,
        rt.RatePerAdult,
        r.BedCount,
        r.MaxAdults,
        r.MaxChildren,
        r.Status
    FROM tblRooms r
    INNER JOIN tblRoomTypes rt ON r.RoomTypeId = rt.RoomTypeId
    WHERE r.MaxAdults >= @Adults 
      AND r.MaxChildren >= @Children
      AND r.Status <> 'Maintenance'
      AND r.RoomId NOT IN (
          SELECT RoomId 
          FROM tblReservations 
          WHERE Status IN ('Pending', 'Confirmed', 'Occupied')
            AND (CheckInDateTime < @CheckOut AND ExpectedCheckOutDateTime > @CheckIn)
      )
    ORDER BY r.RoomId ASC;
END
GO