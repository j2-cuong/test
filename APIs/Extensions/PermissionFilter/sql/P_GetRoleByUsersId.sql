-- Kiểm tra và xóa stored procedure GetRoleByUsersId nếu tồn tại
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.GetRoleByUsersId') AND type in (N'P', N'PC'))
BEGIN
    DROP PROCEDURE dbo.GetRoleByUsersId;
END
GO

-- Tạo stored procedure GetRoleByUsersId mới
CREATE PROCEDURE [dbo].[GetRoleByUsersId]
(
    @UsersId UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT rp.APIsEndpointUrl
    FROM RolePermission rp
    INNER JOIN UsersGroupMembership ugm ON rp.UsersGroupId = ugm.UsersGroupId
    WHERE ugm.UsersId = @UsersId;
END
GO
