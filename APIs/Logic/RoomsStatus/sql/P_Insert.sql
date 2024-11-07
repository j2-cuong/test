-- Kiểm tra và xóa stored procedure CreateRoomsStatus nếu tồn tại
IF OBJECT_ID('dbo.CreateRoomsStatus', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.CreateRoomsStatus;
END
GO

-- Tạo stored procedure CreateRoomsStatus mới
CREATE PROCEDURE [dbo].[CreateRoomsStatus]
(
    @RoomsStatusId UNIQUEIDENTIFIER,
    @RoomsStatusCode varchar(100) = null,
    @RoomsStatusName nvarchar(100) = null,
    @RoomsStatusColor nvarchar(200) = null
)
AS
SET NOCOUNT ON;
BEGIN
    INSERT INTO [RoomsStatus] 
    (
        RoomsStatusId, 
        RoomsStatusCode, 
        RoomsStatusName, 
        RoomsStatusColor, 
        CreateTime,
        UpdateTime
    )
    VALUES 
    (
        @RoomsStatusId, 
        @RoomsStatusCode, 
        @RoomsStatusName, 
        @RoomsStatusColor,
        GETDATE(),
        GETDATE()
    )
END
GO