CREATE VIEW [dbo].[vwUsers]
AS
SELECT 
    Id,
    UserId,
    Username,
    Role,
    IsActive,
    CreatedAt
FROM dbo.tblUsers;
GO