CREATE PROCEDURE [dbo].[spAddGuest]
    @ContactNo NVARCHAR(20),
    @FirstName NVARCHAR(50),
    @LastName  NVARCHAR(50),
    @MI        NVARCHAR(50),
    @Age       INT,
    @Address   NVARCHAR(255),
    @Email     NVARCHAR(100),
    @IDType    NVARCHAR(50),
    @IDNum     NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblGuests (ContactNo, FirstName, LastName, MI, Age, Address, Email, IDType, IDNum, IsActive, CreatedAt)
    VALUES (@ContactNo, @FirstName, @LastName, @MI, @Age, @Address, @Email, @IDType, @IDNum, 1, GETDATE());

    SELECT SCOPE_IDENTITY() AS NewGuestId;
END;
GO