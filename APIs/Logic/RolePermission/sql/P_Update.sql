-- Kiểm tra và xóa stored procedure UpdateRolePermission nếu tồn tại
IF OBJECT_ID('dbo.UpdateRolePermission', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.UpdateRolePermission;
END
GO

-- Tạo stored procedure UpdateRolePermission mới
CREATE PROCEDURE [dbo].[UpdateRolePermission]
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
    UPDATE [RolePermission] SET
        UsersGroupId = @UsersGroupId , 
        UsersGroupName = @UsersGroupName , 
        APIsEndpointId = @APIsEndpointId,
        APIsEndpointName = @APIsEndpointName,
        APIsEndpointUrl = @APIsEndpointUrl,
        isAccess = @isAccess , 
        UpdateBy = @UpdateBy, 
        UpdateTime = GETDATE()
    WHERE RolePermissionId = @RolePermissionId
END
GO