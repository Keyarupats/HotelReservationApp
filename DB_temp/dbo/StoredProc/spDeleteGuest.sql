CREATE PROCEDURE spDeleteGuest
    @ContactNo NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tblGuests
    SET IsActive = 0
    WHERE ContactNo = @ContactNo;
END
GO