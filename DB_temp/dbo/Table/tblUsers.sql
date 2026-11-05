CREATE TABLE tblUsers (
        UserId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
        UserCode AS ('USR-' + RIGHT('0000' + CAST(UserId AS VARCHAR(4)), 4)) PERSISTED NOT NULL,
        Username NVARCHAR(50) UNIQUE NOT NULL,
        Password NVARCHAR(100) NOT NULL,
        Role NVARCHAR(30) NOT NULL CHECK (Role IN ('Admin', 'Front Desk Staff')),
        IsActive BIT NOT NULL DEFAULT 1,
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
    );
GO