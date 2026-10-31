CREATE PROCEDURE spUpdateRoomStatus
    @RoomId INT,
    @Status NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF @Status NOT IN ('Available', 'Reserved', 'Occupied', 'Cleaning', 'Maintenance')
    BEGIN
        RAISERROR('Invalid room status value.', 16, 1);
        RETURN;
    END

    UPDATE tblRooms
    SET Status = @Status
    WHERE RoomId = @RoomId;
END
GO