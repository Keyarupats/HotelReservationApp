CREATE TABLE tblReservations (
        ReservationId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
        ReservationCode AS ('RES-' + RIGHT('0000' + CAST(ReservationId AS VARCHAR(4)), 4)) PERSISTED NOT NULL,
        GuestId INT FOREIGN KEY REFERENCES tblGuests(GuestId) NOT NULL,
        RoomId INT FOREIGN KEY REFERENCES tblRooms(RoomId) NOT NULL,
        Adults INT NOT NULL CHECK (Adults >= 1),
        Children INT NOT NULL DEFAULT 0 CHECK (Children >= 0),
        CheckInDateTime DATETIME NOT NULL,
        ExpectedCheckOutDateTime DATETIME NOT NULL,
        ActualCheckInDateTime DATETIME NULL,
        ActualCheckOutDateTime DATETIME NULL,
        RatePerAdult DECIMAL(10,2) NOT NULL,
        TotalAmount DECIMAL(10,2) NOT NULL,
        PaymentMethod NVARCHAR(30) NULL CHECK (PaymentMethod IS NULL OR PaymentMethod IN ('Cash', 'Card/e-Wallet (QR)')),
        PaymentReference NVARCHAR(50) NULL,
        AmountPaid DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        ChangeDue DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        Status NVARCHAR(20) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Confirmed', 'Occupied', 'Completed', 'Cancelled')),
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
    );
GO