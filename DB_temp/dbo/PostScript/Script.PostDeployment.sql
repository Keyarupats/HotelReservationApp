/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Seed Rooms Data
IF NOT EXISTS (SELECT 1 FROM dbo.tblRooms)
BEGIN
    INSERT INTO dbo.tblRooms (RoomNumber, RoomType, RatePerNight, Status)
    VALUES 
    ('RM-101', 'Economy', 1200.00, 'Available'),
    ('RM-102', 'Economy', 1200.00, 'Available'),
    ('RM-103', 'Economy', 1200.00, 'Available'),
    ('RM-104', 'Economy', 1200.00, 'Available'),
    ('RM-105', 'Economy', 1200.00, 'Available'),
    ('RM-201', 'Suite', 6000.00, 'Available'),
    ('RM-202', 'Suite', 6000.00, 'Available'),
    ('RM-203', 'Suite', 6000.00, 'Available'),
    ('RM-204', 'Suite', 6000.00, 'Available'),
    ('RM-205', 'Suite', 6000.00, 'Available'),
    ('RM-301', 'Deluxe', 3500.00, 'Available'),
    ('RM-302', 'Deluxe', 3500.00, 'Available'),
    ('RM-303', 'Deluxe', 3500.00, 'Available'),
    ('RM-304', 'Deluxe', 3500.00, 'Available'),
    ('RM-305', 'Deluxe', 3500.00, 'Available');
END;