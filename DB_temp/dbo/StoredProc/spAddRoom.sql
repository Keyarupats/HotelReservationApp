CREATE PROCEDURE spAddRoom
    @RoomNumber NVARCHAR(20),
    @RoomType NVARCHAR(50),
    @RatePerNight DECIMAL(18,2),
    @Status NVARCHAR(20) = 'Available'
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO tblRooms (RoomNumber, RoomType, RatePerNight, Status)
    VALUES (@RoomNumber, @RoomType, @RatePerNight, @Status);

    -- Returns the newly generated primary key integer
    SELECT SCOPE_IDENTITY() AS NewRoomId;
END;
GO