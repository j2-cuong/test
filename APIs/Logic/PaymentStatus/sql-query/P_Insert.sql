-- Kiểm tra và xóa stored procedure CreatePaymentStatus nếu tồn tại
IF OBJECT_ID('dbo.CreatePaymentStatus', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.CreatePaymentStatus;
END
GO

-- [CreatePaymentStatus]
CREATE PROCEDURE [dbo].[CreatePaymentStatus]
(
    @PaymentStatusId UNIQUEIDENTIFIER,
    @PaymentStatusCode varchar(100) = null,
    @PaymentStatusName nvarchar(100) = null,
    @PaymentStatusColor nvarchar(200) = null
)
AS
SET NOCOUNT ON;
BEGIN
    INSERT INTO [PaymentStatus] 
        (
            PaymentStatusId, PaymentStatusCode, PaymentStatusName, PaymentStatusColor, 
            CreateTime,UpdateTime
        )
    VALUES 
        (
            @PaymentStatusId, @PaymentStatusCode, @PaymentStatusName, @PaymentStatusColor,
            GETDATE(),GETDATE()
        )
END