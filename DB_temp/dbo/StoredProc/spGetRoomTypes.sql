CREATE PROCEDURE spGetRoomTypes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT RoomTypeId, TypeName, RatePerAdult, OverstayRatePerHour, StayHours
    FROM tblRoomTypes
    ORDER BY RoomTypeId ASC;
END
GO