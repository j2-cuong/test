﻿-- Kiểm tra và xóa stored procedure FindAllrs nếu tồn tại
IF OBJECT_ID('dbo.FindAllrs', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.FindAllrs;
END
GO

-- Tạo stored procedure FindAllrs mới
CREATE PROCEDURE [dbo].[FindAllrs]
(
    @PageSize INT, 
    @PageIndex INT,
    @Url NVARCHAR(max)
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @urlNull NVARCHAR(max) = (CONCAT(@Url , N'//Images/Default.jpg'))

    SELECT rsName as rsName, FullName as FullName, Address, NumberPhone as NumberPhone,
        StateIDCard as StateIDCard, Email as Email, rsLanguage as rsLanguage, 
        CASE WHEN ISNULL(AvatarPublicUrl,'')<>'' THEN AvatarPublicUrl ELSE @urlNull END as AvatarUrl,
        IsLock as IsLock, IsBlock as IsBlock, IsActive as IsActive, 
        CreateTime as CreateTime, UpdateTime as UpdateTime
    FROM rs
    ORDER BY CreateTime
    OFFSET (@PageIndex - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY
END
GO