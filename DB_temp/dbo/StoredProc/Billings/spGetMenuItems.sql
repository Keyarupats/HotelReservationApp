CREATE PROCEDURE spGetMenuItems
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MenuItemId, ItemCode, ItemName, Category, UnitPrice
    FROM tblMenuItems
    WHERE IsAvailable = 1
    ORDER BY Category ASC, ItemName ASC;
END
GO