CREATE PROCEDURE spCreateReservation
    @GuestId INT,
    @RoomId INT,
    @Adults INT,
    @Children INT,
    @CheckInDateTime DATETIME,
    @ExpectedCheckOutDateTime DATETIME,
    @RatePerAdult DECIMAL(10,2),
    @TotalAmount DECIMAL(10,2),
    @Status NVARCHAR(20) = 'Pending'
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tblReservations (GuestId, RoomId, Adults, Children, CheckInDateTime, ExpectedCheckOutDateTime, RatePerAdult, TotalAmount, Status)
    VALUES (@GuestId, @RoomId, @Adults, @Children, @CheckInDateTime, @ExpectedCheckOutDateTime, @RatePerAdult, @TotalAmount, @Status);

    SELECT SCOPE_IDENTITY() AS NewReservationId;
END
GO