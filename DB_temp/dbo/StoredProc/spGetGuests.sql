CREATE PROCEDURE spGetGuests
    @IncludeInactive BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        GuestId,
        GuestCode,
        ContactNo,
        FirstName,
        LastName,
        MI,
        (FirstName + ' ' + ISNULL(MI + '. ', '') + LastName) AS FullName,
        Age,
        Address,
        Email,
        IDType,
        IDNum,
        IsActive,
        CreatedAt
    FROM tblGuests
    WHERE (@IncludeInactive = 1 OR IsActive = 1)
    ORDER BY GuestId DESC;
END
GO