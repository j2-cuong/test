-- Kiểm tra và xóa bảng UsersGroupMembership nếu tồn tại
IF OBJECT_ID('dbo.UsersGroupMembership', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.UsersGroupMembership;
END
GO

-- Tạo bảng UsersGroupMembership
CREATE TABLE UsersGroupMembership (
    UsersGroupMembershipId UNIQUEIDENTIFIER PRIMARY KEY CONSTRAINT PK_UsersGroupMembership_UsersGroupMembershipId DEFAULT NEWID(),
    UsersGroupId UNIQUEIDENTIFIER NOT NULL CONSTRAINT FK_UsersGroupMembership_UsersGroup FOREIGN KEY REFERENCES UsersGroup(UsersGroupId),
    UsersGroupName NVARCHAR(100) NOT NULL,
    UsersId UNIQUEIDENTIFIER NOT NULL CONSTRAINT FK_UsersGroupMembership_Users FOREIGN KEY REFERENCES Users(UsersId),
    UsersName NVARCHAR(100) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    CreateBy UNIQUEIDENTIFIER NOT NULL,
    CreateTime DATETIME,
    UpdateBy UNIQUEIDENTIFIER NOT NULL,
    UpdateTime DATETIME NOT NULL
);
