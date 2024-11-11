-- Kiểm tra và xóa stored procedure CreateAPIsEndpoint nếu tồn tại
IF OBJECT_ID('dbo.CreateAPIsEndpoint', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.CreateAPIsEndpoint;
END
GO

-- Tạo stored procedure CreateAPIsEndpoint mới
CREATE PROCEDURE [dbo].[CreateAPIsEndpoint]
(
    @APIsEndpointId UNIQUEIDENTIFIER,
    @APIsEndpointCode varchar(100) = null,
    @APIsEndpointName nvarchar(100) = null,
    @APIsEndpointUrl NVARCHAR(255) NOT NULL
)
AS
SET NOCOUNT ON;
BEGIN
    INSERT INTO [APIsEndpoint] 
    (
        APIsEndpointId, 
        APIsEndpointCode, 
        APIsEndpointName,
        APIsEndpointUrl,
        CreateTime,
        UpdateTime
    )
    VALUES 
    (
        @APIsEndpointId, 
        @APIsEndpointCode, 
        @APIsEndpointName, 
        @APIsEndpointUrl, 
        GETDATE(),
        GETDATE()
    )
END
GO