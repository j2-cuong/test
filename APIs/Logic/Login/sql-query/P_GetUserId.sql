-- Kiểm tra và xóa stored procedure GetUserId nếu tồn tại
IF OBJECT_ID('dbo.GetUserId', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.GetUserId;
END
GO

-- Tạo stored procedure GetUserId mới
CREATE PROCEDURE [dbo].[GetUserId]
(
    @UsersName NVARCHAR(200) = NULL,
    @UsersPassword NVARCHAR(200) = NULL
)
AS
SET NOCOUNT ON;
BEGIN
    SELECT UsersId as UsersId FROM Users WHERE UsersName = @UsersName AND UsersPassword = @UsersPassword
END
GO