CREATE PROCEDURE spUpdateGuest
    @GuestId INT,
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
    UPDATE tblGuests
    SET ContactNo = @ContactNo,
        FirstName = @FirstName,
        LastName = @LastName,
        MI = @MI,
        Age = @Age,
        Address = @Address,
        Email = @Email,
        IDType = @IDType,
        IDNum = @IDNum
    WHERE GuestId = @GuestId;
END
GO