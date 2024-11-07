--Table: PaymentStatus
-- Lưu trữ thông tin về trạng thái thanh toán trong hệ thống
CREATE TABLE [PaymentStatus] (
    PaymentStatusId UNIQUEIDENTIFIER PRIMARY KEY,                       -- ID
    PaymentStatusCode  NVARCHAR(100) NOT NULL,                          -- Mã status
    PaymentStatusName  NVARCHAR(100) NOT NULL,                          -- Tên status
    PaymentStatusColor  NVARCHAR(200) NOT NULL,                         -- Màu hiển thị
    CreateTime DATETIME,                                                -- Thời gian tạo
    UpdateTime DATETIME                                                 -- Thời gian sửa
)

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
