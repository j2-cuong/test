-- Kiểm tra và xóa stored procedure DeleteRolePermission nếu tồn tại
IF OBJECT_ID('dbo.DeleteRolePermission', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.DeleteRolePermission;
END
GO

-- Tạo stored procedure DeleteRolePermission mới
CREATE PROCEDURE [dbo].[DeleteRolePermission]
(
    @RolePermissionId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    DELETE FROM [RolePermission] WHERE RolePermissionId = @RolePermissionId
END
GO