-- Kiểm tra và xóa stored procedure CreateRolePermission nếu tồn tại
IF OBJECT_ID('dbo.CreateRolePermission', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.CreateRolePermission;
END
GO

-- Tạo stored procedure CreateRolePermission mới
CREATE PROCEDURE [dbo].[CreateRolePermission]
(
    @RolePermissionId UNIQUEIDENTIFIER ,
    @UsersGroupId UNIQUEIDENTIFIER NOT NULL,
	@UsersGroupName NVARCHAR(100) NOT NULL,
    @APIsEndpointId UNIQUEIDENTIFIER NOT NULL,
	@APIsEndpointName NVARCHAR(100) NOT NULL,
	@APIsEndpointUrl NVARCHAR(100) NOT NULL,
    @isAccess BIT,
    @UpdateBy UNIQUEIDENTIFIER NOT NULL,
    @UpdateTime DATETIME NOT NULL
)
AS
SET NOCOUNT ON;
BEGIN
    INSERT INTO [RolePermission] 
    (
        RolePermissionId, 
        UsersGroupId, 
        UsersGroupName, 
        APIsEndpointId, 
        APIsEndpointName, 
        APIsEndpointUrl,
        isAccess,
        CreateBy,
        CreateTime,
        UpdateBy,
        UpdateTime
    )
    VALUES 
    (
        RolePermissionId, 
        UsersGroupId, 
        UsersGroupName, 
        APIsEndpointId, 
        APIsEndpointName, 
        APIsEndpointUrl,
        isAccess,
        CreateBy,
        GETDATE(),
        '00000000-0000-0000-0000-000000000000',
        GETDATE()
    )
END
GO