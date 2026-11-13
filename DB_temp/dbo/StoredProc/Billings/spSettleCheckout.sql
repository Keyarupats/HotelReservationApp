CREATE PROCEDURE spSettleCheckout
    @ReservationIdsCsv NVARCHAR(200), -- Supports single ("7") or multi-room ("7,8")
    @PrimaryReservationId INT,
    @PaymentMethod NVARCHAR(30),
    @PaymentReference NVARCHAR(50) = NULL,
    @AmountPaid DECIMAL(10,2),
    @ChangeDue DECIMAL(10,2),
    @FinalGrandTotal DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Now DATETIME = GETDATE();

        -- 1. Update all linked reservations in this stay to 'Completed'
        UPDATE res
        SET res.Status = 'Completed',
            res.ActualCheckOutDateTime = @Now,
            res.PaymentMethod = @PaymentMethod,
            res.PaymentReference = @PaymentReference,
            res.AmountPaid = CASE WHEN res.ReservationId = @PrimaryReservationId THEN @AmountPaid ELSE 0.00 END,
            res.ChangeDue = CASE WHEN res.ReservationId = @PrimaryReservationId THEN @ChangeDue ELSE 0.00 END,
            res.TotalAmount = CASE WHEN res.ReservationId = @PrimaryReservationId THEN @FinalGrandTotal ELSE res.TotalAmount END
        FROM tblReservations res
        INNER JOIN STRING_SPLIT(@ReservationIdsCsv, ',') s ON res.ReservationId = CAST(LTRIM(RTRIM(s.value)) AS INT);

        -- 2. Transition assigned rooms from 'Occupied' to 'Cleaning'
        UPDATE r
        SET r.Status = 'Cleaning'
        FROM tblRooms r
        INNER JOIN tblReservations res ON r.RoomId = res.RoomId
        INNER JOIN STRING_SPLIT(@ReservationIdsCsv, ',') s ON res.ReservationId = CAST(LTRIM(RTRIM(s.value)) AS INT);

        COMMIT TRANSACTION;
        SELECT 1 AS Result;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO