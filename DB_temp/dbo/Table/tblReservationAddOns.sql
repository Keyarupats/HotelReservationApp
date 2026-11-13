CREATE TABLE tblReservationAddOns (
    AddOnId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    ReservationId INT FOREIGN KEY REFERENCES tblReservations(ReservationId) NOT NULL,
    MenuItemId INT FOREIGN KEY REFERENCES tblMenuItems(MenuItemId) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity >= 1),
    UnitPrice DECIMAL(10,2) NOT NULL,
    SubTotal AS (CAST(Quantity * UnitPrice AS DECIMAL(10,2))) PERSISTED NOT NULL,
    OrderedAt DATETIME NOT NULL DEFAULT GETDATE()
);
GO