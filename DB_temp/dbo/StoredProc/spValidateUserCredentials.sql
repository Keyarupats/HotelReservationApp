CREATE PROCEDURE [dbo].[spValidateUserCredentials]
    @Username NVARCHAR(50),
    @Password NVARCHAR(100),
    @Role NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id, 
        UserId, 
        Username, 
        Password, 
        Role, 
        IsActive 
    FROM dbo.tblUsers 
    WHERE Username = @Username 
      AND Password = @Password 
      AND Role = @Role 
      AND IsActive = 1;
END
GO