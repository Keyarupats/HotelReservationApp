IF NOT EXISTS (SELECT 1 FROM tblUsers WHERE Username = 'admin_user')
BEGIN
    INSERT INTO tblUsers (Username, Password, Role) VALUES ('admin_user', 'admin123', 'Admin');
END

IF NOT EXISTS (SELECT 1 FROM tblUsers WHERE Username = 'frontdesk_user')
BEGIN
    INSERT INTO tblUsers (Username, Password, Role) VALUES ('frontdesk_user', 'user123', 'Front Desk Staff');
END
GO