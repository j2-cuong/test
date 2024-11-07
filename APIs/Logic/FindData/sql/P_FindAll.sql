-- Kiểm tra và xóa stored procedure FindAll nếu tồn tại
IF OBJECT_ID('dbo.FindAll', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.FindAll;
END
GO

-- Tạo stored procedure FindAll mới
CREATE PROCEDURE [dbo].[FindAll]
(
    @TableName NVARCHAR(50), -- Tên bảng
    @Columns NVARCHAR(MAX), -- Danh sách cột dạng string
    @PageSize INT, 
    @PageIndex INT
)
AS
BEGIN
SET NOCOUNT ON;
    
    DECLARE @sql NVARCHAR(MAX);
    
    SET @sql = N'
        SELECT ' + @Columns + N'
        FROM ' + QUOTENAME(@TableName) + N'
        ORDER BY (SELECT NULL)
        OFFSET (@PageIndex - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY
    ';
    
    EXEC sp_executesql @sql, N'@PageSize INT, @PageIndex INT', @PageSize, @PageIndex;
    
END
GO