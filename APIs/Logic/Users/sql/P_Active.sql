-- Kiểm tra và xóa stored procedure ActiveUsers nếu tồn tại
IF OBJECT_ID('dbo.ActiveUsers', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.ActiveUsers;
END
GO

-- Tạo stored procedure ActiveUsers mới
CREATE PROCEDURE [dbo].[ActiveUsers]
(
    @UsersId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    Update Users SET IsActive = 1 WHERE UsersId = @UsersId
END
GO