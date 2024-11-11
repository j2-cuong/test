-- Kiểm tra và xóa bảng Users nếu tồn tại
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Users;
END
GO

-- Tạo bảng Users mới
CREATE TABLE dbo.Users (
    [UsersId] [uniqueidentifier] PRIMARY KEY CONSTRAINT PK_Users_UsersId DEFAULT NEWID(),
	[UsersName] [nvarchar](100) NOT NULL,
	[UsersPassword] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[NumberPhone] [nvarchar](200) NOT NULL,
	[StateIDCard] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[UsersLanguage] [nvarchar](200) NOT NULL,
	[AvatarPublicUrl] [nvarchar](200) NULL,
	[AvatarFileSave] [nvarchar](200) NULL,
	[IsLock] [bit] NULL,
	[IsBlock] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreateTime] [datetime] NULL,
	[UpdateTime] [datetime] NULL,
);
GO

-- Tạo chỉ số duy nhất cho full-text search
CREATE UNIQUE INDEX UIX_Users_UsersId ON Users(UsersId);
GO

-- Tạo full-text index (Cấu trúc Tên bảng + FTCatalog)
CREATE FULLTEXT CATALOG UsersFTCatalog AS DEFAULT;

-- Tạo Full Text-Search ( những cột where like N'%%' )
CREATE FULLTEXT INDEX ON Users
(
    [UsersName] LANGUAGE 0,    -- Ngôn ngữ neutral
    [FullName] LANGUAGE 0,         -- Ngôn ngữ neutral
    [Address] LANGUAGE 0,           -- Ngôn ngữ neutral
    [NumberPhone] LANGUAGE 0,           -- Ngôn ngữ neutral
    [StateIDCard] LANGUAGE 0,           -- Ngôn ngữ neutral
    [Email] LANGUAGE 0          -- Ngôn ngữ neutral
)
KEY INDEX PK_Users_UsersId -- Tên của khóa chính đã tạo bên trên
ON UsersFTCatalog;