-- Seed 3 Room Tiers
IF NOT EXISTS (SELECT 1 FROM tblRoomTypes WHERE TypeName = 'Economy')
    INSERT INTO tblRoomTypes (TypeName, RatePerAdult, OverstayRatePerHour, StayHours) VALUES ('Economy', 1200.00, 200.00, 22);

IF NOT EXISTS (SELECT 1 FROM tblRoomTypes WHERE TypeName = 'Deluxe')
    INSERT INTO tblRoomTypes (TypeName, RatePerAdult, OverstayRatePerHour, StayHours) VALUES ('Deluxe', 1600.00, 400.00, 22);

IF NOT EXISTS (SELECT 1 FROM tblRoomTypes WHERE TypeName = 'Suite')
    INSERT INTO tblRoomTypes (TypeName, RatePerAdult, OverstayRatePerHour, StayHours) VALUES ('Suite', 2000.00, 600.00, 22);
GO

-- Fetch Type IDs
DECLARE @EconomyTypeId INT = (SELECT RoomTypeId FROM tblRoomTypes WHERE TypeName = 'Economy');
DECLARE @DeluxeTypeId INT = (SELECT RoomTypeId FROM tblRoomTypes WHERE TypeName = 'Deluxe');
DECLARE @SuiteTypeId INT = (SELECT RoomTypeId FROM tblRoomTypes WHERE TypeName = 'Suite');

-- 1001-1010 Economy (1 to 5 beds)
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 1001) INSERT INTO tblRooms VALUES (1001, @EconomyTypeId, 1, 2, 1, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 1002) INSERT INTO tblRooms VALUES (1002, @EconomyTypeId, 1, 2, 1, 'Reserved');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 1003) INSERT INTO tblRooms VALUES (1003, @EconomyTypeId, 2, 3, 2, 'Occupied');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 1004) INSERT INTO tblRooms VALUES (1004, @EconomyTypeId, 2, 3, 2, 'Cleaning');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 1005) INSERT INTO tblRooms VALUES (1005, @EconomyTypeId, 3, 4, 2, 'Maintenance');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 1006) INSERT INTO tblRooms VALUES (1006, @EconomyTypeId, 3, 4, 2, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 1007) INSERT INTO tblRooms VALUES (1007, @EconomyTypeId, 4, 5, 3, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 1008) INSERT INTO tblRooms VALUES (1008, @EconomyTypeId, 4, 5, 3, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 1009) INSERT INTO tblRooms VALUES (1009, @EconomyTypeId, 5, 6, 4, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 1010) INSERT INTO tblRooms VALUES (1010, @EconomyTypeId, 5, 6, 4, 'Available');

-- 2001-2010 Deluxe (1 to 5 beds)
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 2001) INSERT INTO tblRooms VALUES (2001, @DeluxeTypeId, 1, 2, 1, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 2002) INSERT INTO tblRooms VALUES (2002, @DeluxeTypeId, 2, 3, 2, 'Reserved');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 2003) INSERT INTO tblRooms VALUES (2003, @DeluxeTypeId, 2, 3, 2, 'Occupied');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 2004) INSERT INTO tblRooms VALUES (2004, @DeluxeTypeId, 3, 4, 2, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 2005) INSERT INTO tblRooms VALUES (2005, @DeluxeTypeId, 3, 4, 2, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 2006) INSERT INTO tblRooms VALUES (2006, @DeluxeTypeId, 4, 5, 3, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 2007) INSERT INTO tblRooms VALUES (2007, @DeluxeTypeId, 4, 5, 3, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 2008) INSERT INTO tblRooms VALUES (2008, @DeluxeTypeId, 5, 6, 4, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 2009) INSERT INTO tblRooms VALUES (2009, @DeluxeTypeId, 5, 6, 4, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 2010) INSERT INTO tblRooms VALUES (2010, @DeluxeTypeId, 5, 6, 4, 'Available');

-- 3001-3010 Suite (2 to 5 beds)
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 3001) INSERT INTO tblRooms VALUES (3001, @SuiteTypeId, 2, 4, 2, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 3002) INSERT INTO tblRooms VALUES (3002, @SuiteTypeId, 2, 4, 2, 'Reserved');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 3003) INSERT INTO tblRooms VALUES (3003, @SuiteTypeId, 3, 5, 3, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 3004) INSERT INTO tblRooms VALUES (3004, @SuiteTypeId, 3, 5, 3, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 3005) INSERT INTO tblRooms VALUES (3005, @SuiteTypeId, 4, 6, 4, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 3006) INSERT INTO tblRooms VALUES (3006, @SuiteTypeId, 4, 6, 4, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 3007) INSERT INTO tblRooms VALUES (3007, @SuiteTypeId, 4, 6, 4, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 3008) INSERT INTO tblRooms VALUES (3008, @SuiteTypeId, 5, 8, 4, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 3009) INSERT INTO tblRooms VALUES (3009, @SuiteTypeId, 5, 8, 4, 'Available');
IF NOT EXISTS (SELECT 1 FROM tblRooms WHERE RoomId = 3010) INSERT INTO tblRooms VALUES (3010, @SuiteTypeId, 5, 8, 4, 'Available');
GO