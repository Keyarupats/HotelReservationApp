CREATE PROCEDURE [dbo].[spAddRoom]
    @RoomId INT,
    @RoomTypeId INT,
    @BedCount INT,
    @MaxAdults INT,
    @MaxChildren INT,
    @Status NVARCHAR(20) = 'Available'
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[tblRooms] ([RoomId], [RoomTypeId], [BedCount], [MaxAdults], [MaxChildren], [Status])
    VALUES (@RoomId, @RoomTypeId, @BedCount, @MaxAdults, @MaxChildren, @Status);
END