-- Kiểm tra và xóa stored procedure UpdatePaymentStatus nếu tồn tại
IF OBJECT_ID('dbo.UpdatePaymentStatus', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.UpdatePaymentStatus;
END
GO

-- [UpdatePaymentStatus]
CREATE PROCEDURE [dbo].[UpdatePaymentStatus]
(
    @PaymentStatusId UNIQUEIDENTIFIER,
    @PaymentStatusCode varchar(100) = null,
    @PaymentStatusName nvarchar(100) = null,
    @PaymentStatusColor nvarchar(200) = null
)
AS
SET NOCOUNT ON;
BEGIN
    UPDATE [Status] SET
        PaymentStatusCode = @PaymentStatusCode , 
        PaymentStatusName = @PaymentStatusName, 
        PaymentStatusColor = @PaymentStatusColor,
        UpdateTime = GETDATE()
    WHERE PaymentStatusId = @PaymentStatusId
END
