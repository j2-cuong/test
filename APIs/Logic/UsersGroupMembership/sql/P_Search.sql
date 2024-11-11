-- Kiểm tra và xóa stored procedure SearchUsersGroupMembership nếu tồn tại
IF OBJECT_ID('dbo.SearchUsersGroupMembership', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.SearchUsersGroupMembership;
END
GO

-- Tạo stored procedure SearchUsersGroupMembership mới
CREATE PROCEDURE [dbo].[SearchUsersGroupMembership]
(
    @Keys NVARCHAR(100) ,   
    @PageSize INT, 
    @PageIndex INT
)
AS
SET NOCOUNT ON;
BEGIN
    SELECT *
    FROM [UsersGroupMembership]
    WHERE 
        CHARINDEX(@Keys, UsersGroupName COLLATE SQL_Latin1_General_CP1_CI_AI) > 0
        OR CHARINDEX(@Keys, UsersName COLLATE SQL_Latin1_General_CP1_CI_AI) > 0
        OR CHARINDEX(@Keys, FullName COLLATE SQL_Latin1_General_CP1_CI_AI) > 0
    ORDER BY (SELECT NULL)
    OFFSET (@PageIndex - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY
END
GO