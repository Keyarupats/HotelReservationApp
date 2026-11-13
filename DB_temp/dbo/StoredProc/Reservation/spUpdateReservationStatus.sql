CREATE PROCEDURE spUpdateReservationStatus
    @ReservationId INT,
    @NewStatus NVARCHAR(20)
AS
BEGIN
    UPDATE tblReservations
    SET Status = @NewStatus
    WHERE ReservationId = @ReservationId;
END
GO