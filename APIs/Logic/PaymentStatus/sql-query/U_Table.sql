--Table: PaymentStatus
-- Lưu trữ thông tin về trạng thái thanh toán trong hệ thống
CREATE TABLE [PaymentStatus] (
    PaymentStatusId UNIQUEIDENTIFIER PRIMARY KEY CONSTRAINT PK_PaymentStatus_PaymentStatusId DEFAULT NEWID(),
    PaymentStatusCode  NVARCHAR(100) NOT NULL,                          -- Mã status
    PaymentStatusName  NVARCHAR(100) NOT NULL,                          -- Tên status
    PaymentStatusColor  NVARCHAR(200) NOT NULL,                         -- Màu hiển thị
    CreateTime DATETIME,                                                -- Thời gian tạo
    UpdateTime DATETIME                                                 -- Thời gian sửa
)

-- Tạo chỉ số duy nhất cho full-text search
CREATE UNIQUE INDEX UIX_PaymentStatus_PaymentStatusId ON PaymentStatus(PaymentStatusId);
GO

-- Tạo full-text index (Cấu trúc Tên bảng + FTCatalog)
CREATE FULLTEXT CATALOG PaymentStatusFTCatalog AS DEFAULT;

-- Tạo Full Text-Search ( những cột where like N'%%' )
CREATE FULLTEXT INDEX ON PaymentStatus
(
    [PaymentStatusCode] LANGUAGE 0,    -- Ngôn ngữ neutral
    [PaymentStatusName] LANGUAGE 0,         -- Ngôn ngữ neutral
    [PaymentStatusColor] LANGUAGE 0           -- Ngôn ngữ neutral
)
KEY INDEX PK_PaymentStatus_PaymentStatusId -- Tên của khóa chính đã tạo bên trên
ON PaymentStatusFTCatalog;

