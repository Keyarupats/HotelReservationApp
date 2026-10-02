CREATE TABLE [dbo].[tblGuests] (
    [GuestId]   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ContactNo] NVARCHAR(20)      NOT NULL UNIQUE,
    [FirstName] NVARCHAR(50)      NOT NULL,
    [LastName]  NVARCHAR(50)      NOT NULL,
    [MI]        NVARCHAR(50)      NOT NULL,
    [Age]       INT               NOT NULL,
    [Address]   NVARCHAR(255)     NOT NULL,
    [Email]     NVARCHAR(100)     NOT NULL,
    [IDType]    NVARCHAR(50)      NOT NULL,
    [IDNum]     NVARCHAR(50)      NOT NULL,
    [IsActive]  BIT               NOT NULL DEFAULT 1,
    [CreatedAt] DATETIME          NOT NULL DEFAULT GETDATE()
);
GO