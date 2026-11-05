CREATE TABLE [dbo].[tblRoomTypes]
(
    [RoomTypeId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [TypeName] NVARCHAR(30) NOT NULL UNIQUE,
    [RatePerAdult] DECIMAL(10,2) NOT NULL,
    [OverstayRatePerHour] DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    [StayHours] INT NOT NULL DEFAULT 22
);