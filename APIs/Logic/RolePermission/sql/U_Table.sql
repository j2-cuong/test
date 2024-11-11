-- Kiểm tra và xóa bảng RolePermission nếu tồn tại
IF OBJECT_ID('dbo.RolePermission', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.RolePermission;
END
GO

-- Tạo bảng RolePermission
CREATE TABLE RolePermission (
    RolePermissionId UNIQUEIDENTIFIER PRIMARY KEY CONSTRAINT PK_RolePermission_RolePermissionId DEFAULT NEWID(),
    UsersGroupId UNIQUEIDENTIFIER NOT NULL CONSTRAINT FK_RolePermission_UsersGroup FOREIGN KEY REFERENCES UsersGroup(UsersGroupId),
    GroupName NVARCHAR(100) NOT NULL,
    APIsEndpointId UNIQUEIDENTIFIER NOT NULL CONSTRAINT FK_RolePermission_APIsEndpoint FOREIGN KEY REFERENCES APIsEndpoint(APIsEndpointId),
    APIsEndpointName NVARCHAR(100) NOT NULL,
    APIsEndpointUrl NVARCHAR(100) NOT NULL,
    isAccess BIT NOT NULL DEFAULT 0,
    CreateBy UNIQUEIDENTIFIER NOT NULL,
    CreateTime DATETIME,
    UpdateBy UNIQUEIDENTIFIER NOT NULL,
    UpdateTime DATETIME NOT NULL
);

-- Tạo full-text index (Cấu trúc Tên bảng + FTCatalog)
CREATE FULLTEXT CATALOG RolePermissionFTCatalog AS DEFAULT;

-- Tạo Full Text-Search ( những cột where like N'%%' )
CREATE FULLTEXT INDEX ON RolePermission
(
    [UsersGroupName] LANGUAGE 0,         -- Ngôn ngữ neutral
    [APIsEndpointName] LANGUAGE 0,         -- Ngôn ngữ neutral
    [APIsEndpointUrl] LANGUAGE 0         -- Ngôn ngữ neutral
)
KEY INDEX PK_RolePermission_RolePermissionId -- Tên của khóa chính đã tạo bên trên
ON RolePermissionFTCatalog;