-- Kiểm tra và xóa stored procedure UpdateAPIsEndpoint nếu tồn tại
IF OBJECT_ID('dbo.UpdateAPIsEndpoint', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.UpdateAPIsEndpoint;
END
GO

-- Tạo stored procedure UpdateAPIsEndpoint mới
CREATE PROCEDURE [dbo].[UpdateAPIsEndpoint]
(
    @APIsEndpointId UNIQUEIDENTIFIER,
    @APIsEndpointCode varchar(100) = null,
    @APIsEndpointName nvarchar(100) = null,
    @APIsEndpointUrl NVARCHAR(255) NOT NULL
)
AS
SET NOCOUNT ON;
BEGIN
    UPDATE [APIsEndpoint] SET
        APIsEndpointCode = @APIsEndpointCode , 
        APIsEndpointName = @APIsEndpointName, 
        APIsEndpointUrl = @APIsEndpointUrl,
        UpdateTime = GETDATE()
    WHERE APIsEndpointId = @APIsEndpointId
END
GO