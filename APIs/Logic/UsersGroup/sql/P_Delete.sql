-- Kiểm tra và xóa stored procedure DeleteUsersGroup nếu tồn tại
IF OBJECT_ID('dbo.DeleteUsersGroup', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.DeleteUsersGroup;
END
GO

-- Tạo stored procedure DeleteUsersGroup mới
CREATE PROCEDURE [dbo].[DeleteUsersGroup]
(
    @UsersGroupId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    DELETE FROM [UsersGroup] WHERE UsersGroupId = @UsersGroupId
END
GO