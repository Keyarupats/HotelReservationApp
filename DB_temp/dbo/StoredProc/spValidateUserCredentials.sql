CREATE PROCEDURE spValidateUserCredentials
    @Username NVARCHAR(50),
    @Password NVARCHAR(100),
    @Role NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        UserId,
        UserCode,
        Username,
        Role,
        IsActive
    FROM tblUsers
    WHERE Username = @Username 
      AND Password = @Password 
      AND Role = @Role
      AND IsActive = 1;
END