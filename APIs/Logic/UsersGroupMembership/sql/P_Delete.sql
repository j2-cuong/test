-- Kiểm tra và xóa stored procedure DeleteUsersGroupMembership nếu tồn tại
IF OBJECT_ID('dbo.DeleteUsersGroupMembership', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.DeleteUsersGroupMembership;
END
GO

-- Tạo stored procedure DeleteUsersGroupMembership mới
CREATE PROCEDURE [dbo].[DeleteUsersGroupMembership]
(
    @UsersGroupMembershipId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    DELETE FROM [UsersGroupMembership] WHERE UsersGroupMembershipId = @UsersGroupMembershipId
END
GO