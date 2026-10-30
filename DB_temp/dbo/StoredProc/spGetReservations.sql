CREATE PROCEDURE spGetReservations
    @StatusFilter NVARCHAR(20) = 'ALL',
    @FilterDate DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        res.ReservationId,
        res.ReservationCode,
        res.GuestId,
        (g.FirstName + ' ' + g.LastName) AS GuestName,
        g.ContactNo,
        res.RoomId,
        rt.TypeName,
        res.Adults,
        res.Children,
        res.CheckInDateTime,
        res.ExpectedCheckOutDateTime,
        res.ActualCheckInDateTime,
        res.ActualCheckOutDateTime,
        res.RatePerAdult,
        res.TotalAmount,
        res.PaymentMethod,
        res.PaymentReference,
        res.AmountPaid,
        res.ChangeDue,
        res.Status
    FROM tblReservations res
    INNER JOIN tblGuests g ON res.GuestId = g.GuestId
    INNER JOIN tblRooms r ON res.RoomId = r.RoomId
    INNER JOIN tblRoomTypes rt ON r.RoomTypeId = rt.RoomTypeId
    WHERE (@StatusFilter = 'ALL' OR res.Status = @StatusFilter)
      AND (@FilterDate IS NULL OR CAST(res.CheckInDateTime AS DATE) = CAST(@FilterDate AS DATE))
    ORDER BY res.ReservationId DESC;
END
GO