CREATE PROCEDURE spGetOccupiedStaysForBilling
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        res.ReservationId,
        res.ReservationCode,
        res.GuestId,
        (g.FirstName + ' ' + ISNULL(g.MI + '. ', '') + g.LastName) AS GuestName,
        g.ContactNo,
        res.RoomId,
        rt.TypeName,
        res.Adults,
        res.Children,
        ISNULL(res.ActualCheckInDateTime, res.CheckInDateTime) AS EffectiveCheckIn,
        res.ExpectedCheckOutDateTime,
        res.RatePerAdult,
        rt.OverstayRatePerHour,
        res.TotalAmount AS BaseRoomCharge
    FROM tblReservations res
    INNER JOIN tblGuests g ON res.GuestId = g.GuestId
    INNER JOIN tblRooms r ON res.RoomId = r.RoomId
    INNER JOIN tblRoomTypes rt ON r.RoomTypeId = rt.RoomTypeId
    WHERE res.Status = 'Occupied'
    ORDER BY EffectiveCheckIn ASC, res.ReservationId ASC;
END
GO