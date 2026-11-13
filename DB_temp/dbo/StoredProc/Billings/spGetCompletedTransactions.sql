CREATE PROCEDURE spGetCompletedTransactions
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        res.ReservationId,
        res.ReservationCode,
        (g.FirstName + ' ' + ISNULL(g.MI + '. ', '') + g.LastName) AS GuestName,
        g.ContactNo,
        res.RoomId,
        res.CheckInDateTime,
        res.ActualCheckOutDateTime,
        res.PaymentMethod,
        ISNULL(res.PaymentReference, 'N/A') AS PaymentReference,
        res.AmountPaid,
        res.ChangeDue,
        res.TotalAmount AS GrandTotal
    FROM tblReservations res
    INNER JOIN tblGuests g ON res.GuestId = g.GuestId
    WHERE res.Status = 'Completed'
      AND (@StartDate IS NULL OR CAST(res.ActualCheckOutDateTime AS DATE) >= @StartDate)
      AND (@EndDate IS NULL OR CAST(res.ActualCheckOutDateTime AS DATE) <= @EndDate)
    ORDER BY res.ActualCheckOutDateTime DESC;
END
GO