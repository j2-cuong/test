-- Kiểm tra và xóa stored procedure DeletePaymentStatus nếu tồn tại
IF OBJECT_ID('dbo.DeletePaymentStatus', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.DeletePaymentStatus;
END
GO

-- [DeletePaymentStatus]
CREATE PROCEDURE [dbo].[DeletePaymentStatus]
(
    @PaymentStatusId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    DELETE FROM [PaymentStatus] WHERE PaymentStatusId = @PaymentStatusId
END