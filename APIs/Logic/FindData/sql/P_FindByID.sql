-- Kiểm tra và xóa stored procedure FindByID nếu tồn tại
IF OBJECT_ID('dbo.FindByID', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.FindByID;
END
GO

-- Tạo stored procedure FindByID mới
CREATE PROCEDURE [dbo].[FindByID]
(
    @TableName NVARCHAR(50),
    @Columns NVARCHAR(MAX), -- Danh sách cột dạng string
    @Id UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TableID NVARCHAR(250) = (SELECT CONCAT(@TableName, 'Id'));
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = N'SELECT ' + @Columns + N' FROM ' + QUOTENAME(@TableName) + N' WHERE ' + QUOTENAME(@TableID) + N' = @Id';
    EXEC sp_executesql @sql, N'@Id UNIQUEIDENTIFIER', @Id = @Id;
END
GO