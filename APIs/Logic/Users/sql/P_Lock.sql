-- Kiểm tra và xóa stored procedure LockUsers nếu tồn tại
IF OBJECT_ID('dbo.LockUsers', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.LockUsers;
END
GO

-- Tạo stored procedure LockUsers mới
CREATE PROCEDURE [dbo].[LockUsers]
(
    @UsersId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    Update Users SET IsLock = 1 WHERE UsersId = @UsersId
END
GO