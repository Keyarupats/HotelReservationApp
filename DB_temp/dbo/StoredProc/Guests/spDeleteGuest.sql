CREATE PROCEDURE spDeleteGuest
    @ContactNo NVARCHAR(20)
AS
BEGIN
    UPDATE tblGuests
    SET IsActive = 0
    WHERE ContactNo = @ContactNo;
END
GO