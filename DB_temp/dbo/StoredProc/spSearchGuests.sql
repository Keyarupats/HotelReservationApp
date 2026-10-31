CREATE PROCEDURE spSearchGuests
    @SearchText NVARCHAR(100),
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
      AND (
          GuestCode LIKE '%' + @SearchText + '%' OR
          ContactNo LIKE '%' + @SearchText + '%' OR
          FirstName LIKE '%' + @SearchText + '%' OR
          LastName LIKE '%' + @SearchText + '%' OR
          Email LIKE '%' + @SearchText + '%'
      )
    ORDER BY GuestId DESC;
END
GO