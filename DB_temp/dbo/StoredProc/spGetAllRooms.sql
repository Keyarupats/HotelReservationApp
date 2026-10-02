CREATE PROCEDURE spGetAllRooms
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        RoomId,
        RoomNumber,
        RoomType,
        RatePerNight,
        Status
    FROM tblRooms
    ORDER BY RoomId ASC;
END;
GO