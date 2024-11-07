-- Kiểm tra và xóa stored procedure DeleteUsers nếu tồn tại
IF OBJECT_ID('dbo.DeleteUsers', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.DeleteUsers;
END
GO

-- Tạo stored procedure DeleteUsers mới
CREATE PROCEDURE [dbo].[DeleteUsers]
(
    @UsersId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    DELETE FROM Users WHERE UsersId = @UsersId
END
GO