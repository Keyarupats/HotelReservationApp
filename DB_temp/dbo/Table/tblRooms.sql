CREATE TABLE tblRooms (
        RoomId INT PRIMARY KEY NOT NULL, -- 4-digit room numbers: 1001-1010, 2001-2010, 3001-3010
        RoomTypeId INT FOREIGN KEY REFERENCES tblRoomTypes(RoomTypeId) NOT NULL,
        BedCount INT NOT NULL CHECK (BedCount >= 1),
        MaxAdults INT NOT NULL CHECK (MaxAdults >= 1),
        MaxChildren INT NOT NULL DEFAULT 0 CHECK (MaxChildren >= 0),
        Status NVARCHAR(20) NOT NULL DEFAULT 'Available' CHECK (Status IN ('Available', 'Reserved', 'Occupied', 'Cleaning', 'Maintenance'))
    );
GO