-- Kiểm tra và xóa stored procedure DeleteAPIsEndpoint nếu tồn tại
IF OBJECT_ID('dbo.DeleteAPIsEndpoint', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.DeleteAPIsEndpoint;
END
GO

-- Tạo stored procedure DeleteAPIsEndpoint mới
CREATE PROCEDURE [dbo].[DeleteAPIsEndpoint]
(
    @APIsEndpointId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON;
BEGIN
    DELETE FROM [APIsEndpoint] WHERE APIsEndpointId = @APIsEndpointId
END
GO