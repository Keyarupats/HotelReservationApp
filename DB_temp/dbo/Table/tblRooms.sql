CREATE TABLE [dbo].[tblRooms] (
    [RoomId]       INT           IDENTITY (1, 1) NOT NULL,
    [RoomNumber]   NVARCHAR (20) NOT NULL,
    [RoomType]     NVARCHAR (50) NOT NULL,
    [RatePerNight] DECIMAL (18, 2) NOT NULL,
    [Status]       NVARCHAR (20) DEFAULT ('Available') NOT NULL,
    PRIMARY KEY CLUSTERED ([RoomId] ASC),
    CONSTRAINT [UQ_RoomNumber] UNIQUE NONCLUSTERED ([RoomNumber] ASC)
);
GO