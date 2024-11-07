-- Kiểm tra và xóa stored procedure DeleteRoomsStatus nếu tồn tại
IF OBJECT_ID('dbo.DeleteRoomsStatus', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.DeleteRoomsStatus;
END
GO

-- Tạo stored procedure DeleteRoomsStatus mới
CREATE PROCEDURE [dbo].[DeleteRoomsStatus]
(
    @RoomsStatusId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    DELETE FROM [RoomsStatus] WHERE RoomsStatusId = @RoomsStatusId
END
GO