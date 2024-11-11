-- Kiểm tra và xóa bảng UsersGroup nếu tồn tại
IF OBJECT_ID('dbo.UsersGroup', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.UsersGroup;
END
GO

-- Tạo bảng UsersGroup mới
CREATE TABLE UsersGroup (
    UsersGroupId UNIQUEIDENTIFIER PRIMARY KEY CONSTRAINT PK_UsersGroup_UsersGroupId DEFAULT NEWID(),
    UsersGroupName NVARCHAR(100) NOT NULL,
    CreateTime DATETIME,
    UpdateTime DATETIME NOT NULL
);
GO

-- Tạo chỉ số duy nhất cho full-text search
CREATE UNIQUE INDEX UIX_UsersGroup_UsersGroupId ON UsersGroup(UsersGroupId);
GO


-- Tạo full-text index (Cấu trúc Tên bảng + FTCatalog)
CREATE FULLTEXT CATALOG UsersGroupFTCatalog AS DEFAULT;

-- Tạo Full Text-Search ( những cột where like N'%%' )
CREATE FULLTEXT INDEX ON UsersGroup
(
    [UsersGroupName] LANGUAGE 0         -- Ngôn ngữ neutral
)
KEY INDEX PK_UsersGroup_UsersGroupId -- Tên của khóa chính đã tạo bên trên
ON UsersGroupFTCatalog;