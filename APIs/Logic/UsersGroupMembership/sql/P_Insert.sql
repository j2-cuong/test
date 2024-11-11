-- Kiểm tra và xóa stored procedure CreateUsersGroupMembership nếu tồn tại
IF OBJECT_ID('dbo.CreateUsersGroupMembership', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.CreateUsersGroupMembership;
END
GO

-- Tạo stored procedure CreateUsersGroupMembership mới
CREATE PROCEDURE [dbo].[CreateUsersGroupMembership]
(
    @UsersGroupMembershipId UNIQUEIDENTIFIER ,
    @UsersGroupId UNIQUEIDENTIFIER,
    @UsersId UNIQUEIDENTIFIER,
    @CreateBy UNIQUEIDENTIFIER,
    @UsersGroupName NVARCHAR(100) = NULL,
    @UsersName NVARCHAR(100) = NULL,
    @FullName NVARCHAR(100) = NULL
)
AS
SET NOCOUNT ON;
BEGIN
    INSERT INTO [UsersGroupMembership] 
    (
        UsersGroupMembershipId, 
        UsersGroupId, 
        UsersGroupName,
        UsersId, 
        UsersName,
        FullName,
        CreateBy,
        CreateTime,
        UpdateBy,
        UpdateTime
    )
    VALUES 
    (
        @UsersGroupMembershipId, 
        @UsersGroupId, 
        @UsersGroupName,
        @UsersId, 
        @UsersName,
        @FullName,
        @CreateBy,
        GETDATE(),
        '00000000-0000-0000-0000-000000000000',
        GETDATE()
    )
END
GO