-- Kiểm tra và xóa bảng APIsEndpoint nếu tồn tại
IF OBJECT_ID('dbo.APIsEndpoint', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.APIsEndpoint;
END
GO

-- Tạo bảng APIsEndpoint mới
CREATE TABLE APIsEndpoint (
    APIsEndpointId UNIQUEIDENTIFIER PRIMARY KEY CONSTRAINT PK_APIsEndpoint_APIsEndpointId DEFAULT NEWID(),
    APIsEndpointName NVARCHAR(50) NOT NULL,
    APIsEndpointUrl NVARCHAR(255) NOT NULL,
	CreateBy UNIQUEIDENTIFIER NOT NULL,
    CreateTime DATETIME,
    UpdateBy UNIQUEIDENTIFIER NOT NULL,
    UpdateTime DATETIME NOT NULL
);

-- Tạo chỉ số duy nhất cho full-text search
CREATE UNIQUE INDEX UIX_APIsEndpoint_APIsEndpointId ON APIsEndpoint(APIsEndpointId);
GO

-- Tạo full-text index (Cấu trúc Tên bảng + FTCatalog)
CREATE FULLTEXT CATALOG APIsEndpointFTCatalog AS DEFAULT;

-- Tạo Full Text-Search ( những cột where like N'%%' )
CREATE FULLTEXT INDEX ON APIsEndpoint
(
    [APIsEndpointName] LANGUAGE 0         -- Ngôn ngữ neutral
)
KEY INDEX PK_APIsEndpoint_APIsEndpointId -- Tên của khóa chính đã tạo bên trên
ON APIsEndpointFTCatalog;