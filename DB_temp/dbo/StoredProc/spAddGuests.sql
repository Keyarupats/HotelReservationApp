CREATE PROCEDURE spAddGuests
    @ContactNo NVARCHAR(20),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @MI NVARCHAR(5),
    @Age INT,
    @Address NVARCHAR(255),
    @Email NVARCHAR(100),
    @IDType NVARCHAR(50),
    @IDNum NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM tblGuests WHERE ContactNo = @ContactNo)
    BEGIN
        SELECT -1 AS NewGuestId;
        RETURN;
    END

    INSERT INTO tblGuests (ContactNo, FirstName, LastName, MI, Age, Address, Email, IDType, IDNum)
    VALUES (@ContactNo, @FirstName, @LastName, @MI, @Age, @Address, @Email, @IDType, @IDNum);

    SELECT SCOPE_IDENTITY() AS NewGuestId;
END
GO