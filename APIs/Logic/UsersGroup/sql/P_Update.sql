-- Kiểm tra và xóa stored procedure UpdateUsersGroup nếu tồn tại
IF OBJECT_ID('dbo.UpdateUsersGroup', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.UpdateUsersGroup;
END
GO

-- Tạo stored procedure UpdateUsersGroup mới
CREATE PROCEDURE [dbo].[UpdateUsersGroup]
(
    @UsersGroupId UNIQUEIDENTIFIER,
    @UsersGroupCode varchar(100) = null,
    @UsersGroupName nvarchar(100) = null
)
AS
SET NOCOUNT ON;
BEGIN
    UPDATE [UsersGroup] SET
        UsersGroupCode = @UsersGroupCode , 
        UsersGroupName = @UsersGroupName, 
        UpdateTime = GETDATE()
    WHERE UsersGroupId = @UsersGroupId
END
GO