-- Kiểm tra và xóa stored procedure CreateUsersGroup nếu tồn tại
IF OBJECT_ID('dbo.CreateUsersGroup', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.CreateUsersGroup;
END
GO

-- Tạo stored procedure CreateUsersGroup mới
CREATE PROCEDURE [dbo].[CreateUsersGroup]
(
    @UsersGroupId UNIQUEIDENTIFIER,
    @UsersGroupCode varchar(100) = null,
    @UsersGroupName nvarchar(100) = null
)
AS
SET NOCOUNT ON;
BEGIN
    INSERT INTO [UsersGroup] 
    (
        UsersGroupId, 
        UsersGroupCode, 
        UsersGroupName,
        CreateTime,
        UpdateTime
    )
    VALUES 
    (
        @UsersGroupId, 
        @UsersGroupCode, 
        @UsersGroupName, 
        GETDATE(),
        GETDATE()
    )
END
GO