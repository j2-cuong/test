-- Kiểm tra và xóa stored procedure BlockUsers nếu tồn tại
IF OBJECT_ID('dbo.BlockUsers', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.BlockUsers;
END
GO

-- Tạo stored procedure BlockUsers mới
CREATE PROCEDURE [dbo].[BlockUsers]
(
    @UsersId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    Update Users SET IsBlock = 1 WHERE UsersId = @UsersId
END
GO