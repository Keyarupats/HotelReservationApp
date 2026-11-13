CREATE PROCEDURE spGetRoomTypes
AS
BEGIN
    SELECT RoomTypeId, TypeName, RatePerAdult, OverstayRatePerHour, StayHours
    FROM tblRoomTypes
    ORDER BY RoomTypeId ASC;
END
GO