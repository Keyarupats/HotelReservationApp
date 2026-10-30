CREATE PROCEDURE spGetAllRooms
    @TypeNameFilter NVARCHAR(30) = 'ALL'
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        r.RoomId,
        rt.RoomTypeId,
        rt.TypeName,
        rt.RatePerAdult,
        r.BedCount,
        r.MaxAdults,
        r.MaxChildren,
        r.Status
    FROM tblRooms r
    INNER JOIN tblRoomTypes rt ON r.RoomTypeId = rt.RoomTypeId
    WHERE (@TypeNameFilter = 'ALL' OR rt.TypeName = @TypeNameFilter)
    ORDER BY r.RoomId ASC;
END
GO