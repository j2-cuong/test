-- Kiểm tra và xóa bảng RoomsStatus nếu tồn tại
IF OBJECT_ID('dbo.RoomsStatus', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.RoomsStatus;
END
GO

-- Tạo bảng RoomsStatus mới
CREATE TABLE dbo.RoomsStatus (
    [RoomsStatusId] [uniqueidentifier]PRIMARY KEY CONSTRAINT PK_RoomsStatus_RoomsStatusId DEFAULT NEWID(),
	[RoomsStatusCode] [nvarchar](100) NOT NULL,
	[RoomsStatusName] [nvarchar](100) NOT NULL,
	[RoomsStatusColor] [nvarchar](200) NOT NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
);
GO

-- Tạo chỉ số duy nhất cho full-text search
CREATE UNIQUE INDEX UIX_RoomsStatus_RoomsStatusId ON RoomsStatus(RoomsStatusId);
GO


--CONSTRAINT PK_RoomsStatus_RoomsStatusId DEFAULT NEWID()
-- Tạo full-text index (Cấu trúc Tên bảng + FTCatalog)
CREATE FULLTEXT CATALOG RoomsStatusFTCatalog AS DEFAULT;

-- Tạo Full Text-Search ( những cột where like N'%%' )
CREATE FULLTEXT INDEX ON RoomsStatus
(
    [RoomsStatusCode] LANGUAGE 0,    -- Ngôn ngữ neutral
    [RoomsStatusName] LANGUAGE 0,         -- Ngôn ngữ neutral
    [RoomsStatusColor] LANGUAGE 0           -- Ngôn ngữ neutral
)
KEY INDEX PK_RoomsStatus_RoomsStatusId -- Tên của khóa chính đã tạo bên trên
ON RoomsStatusFTCatalog;

