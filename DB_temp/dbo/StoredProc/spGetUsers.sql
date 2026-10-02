CREATE PROCEDURE [dbo].[spGetUsers]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id, 
        UserId, 
        Username, 
        Role, 
        IsActive, 
        CreatedAt
    FROM dbo.tblUsers
    WHERE IsActive = 1
    ORDER BY Id ASC;
END;
GO