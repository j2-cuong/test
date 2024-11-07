-- Kiểm tra và xóa bảng Users nếu tồn tại
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Users;
END
GO

-- Tạo bảng Users mới
CREATE TABLE dbo.Users (
    [UsersId] [uniqueidentifier] NOT NULL PRIMARY KEY,
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