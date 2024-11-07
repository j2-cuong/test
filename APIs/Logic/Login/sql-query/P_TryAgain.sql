-- Kiểm tra và xóa stored procedure TryAgain nếu tồn tại
IF OBJECT_ID('dbo.TryAgain', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.TryAgain;
END
GO

-- Tạo stored procedure TryAgain mới
CREATE PROCEDURE [dbo].[TryAgain]
(
    @UsersId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    Update Users SET UserChangeInfo = 0 WHERE UsersId = @UsersId
END
GO