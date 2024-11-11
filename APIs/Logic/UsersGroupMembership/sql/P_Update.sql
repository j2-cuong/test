-- Kiểm tra và xóa stored procedure UpdateUsersGroupMembership nếu tồn tại
IF OBJECT_ID('dbo.UpdateUsersGroupMembership', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.UpdateUsersGroupMembership;
END
GO

-- Tạo stored procedure UpdateUsersGroupMembership mới
CREATE PROCEDURE [dbo].[UpdateUsersGroupMembership]
(
    @UsersGroupMembershipId UNIQUEIDENTIFIER ,
    @UsersGroupId UNIQUEIDENTIFIER,
    @UsersId UNIQUEIDENTIFIER,
    @UpdateBy UNIQUEIDENTIFIER,
    @UsersGroupName NVARCHAR(100) = NULL,
    @UsersName NVARCHAR(100) = NULL,
    @FullName NVARCHAR(100) = NULL
)
AS
SET NOCOUNT ON;
BEGIN
    UPDATE [UsersGroupMembership] SET
        UsersGroupMembershipId = @UsersGroupMembershipId , 
        UsersGroupId = @UsersGroupId , 
        UsersGroupName = @UsersGroupName , 
        UsersId = @UsersId , 
        UsersName = @UsersName, 
        FullName = @FullName, 
        UpdateBy = @UpdateBy, 
        UpdateTime = GETDATE()
    WHERE UsersGroupMembershipId = @UsersGroupMembershipId
END
GO