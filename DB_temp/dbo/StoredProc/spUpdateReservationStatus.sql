CREATE PROCEDURE spUpdateReservationStatus
    @ReservationId INT,
    @NewStatus NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tblReservations
    SET Status = @NewStatus
    WHERE ReservationId = @ReservationId;
END
GO