IF NOT EXISTS (SELECT 1 FROM dbo.tblUsers WHERE Username = 'admin_user')
BEGIN
    INSERT INTO dbo.tblUsers (UserId, Username, Password, Role, IsActive)
    VALUES ('USR-001', 'admin_user', 'admin123', 'Admin', 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.tblUsers WHERE Username = 'frontdesk_user')
BEGIN
    INSERT INTO dbo.tblUsers (UserId, Username, Password, Role, IsActive)
    VALUES ('USR-002', 'frontdesk_user', 'user123', 'Front Desk Staff', 1);
END
GO