CREATE PROCEDURE [dbo].[spGetGuests]
    @IncludeInactive BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        GuestId,
        ContactNo,
        FirstName,
        LastName,
        MI,
        Age,
        Address,
        Email,
        IDType,
        IDNum,
        IsActive,
        CreatedAt
    FROM dbo.tblGuests
    WHERE (@IncludeInactive = 1 OR IsActive = 1)
    ORDER BY GuestId DESC;
END;
GO