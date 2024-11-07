-- Kiểm tra và xóa stored procedure UpdateRoomsStatus nếu tồn tại
IF OBJECT_ID('dbo.UpdateRoomsStatus', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.UpdateRoomsStatus;
END
GO

-- Tạo stored procedure UpdateRoomsStatus mới
CREATE PROCEDURE [dbo].[UpdateRoomsStatus]
(
    @RoomsStatusId UNIQUEIDENTIFIER,
    @RoomsStatusCode varchar(100) = null,
    @RoomsStatusName nvarchar(100) = null,
    @RoomsStatusColor nvarchar(200) = null
)
AS
SET NOCOUNT ON;
BEGIN
    UPDATE [RoomsStatus] SET
        RoomsStatusCode = @RoomsStatusCode , 
        RoomsStatusName = @RoomsStatusName, 
        RoomsStatusColor = @RoomsStatusColor,
        UpdateTime = GETDATE()
    WHERE RoomsStatusId = @RoomsStatusId
END
GO