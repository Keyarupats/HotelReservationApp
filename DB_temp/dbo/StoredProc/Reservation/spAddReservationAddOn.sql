CREATE PROCEDURE spAddReservationAddOn
    @ReservationId INT,
    @MenuItemId INT,
    @Quantity INT,
    @UnitPrice DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tblReservationAddOns (ReservationId, MenuItemId, Quantity, UnitPrice)
    VALUES (@ReservationId, @MenuItemId, @Quantity, @UnitPrice);
END
GO