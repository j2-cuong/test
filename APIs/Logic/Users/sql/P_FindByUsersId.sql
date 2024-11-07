-- Kiểm tra và xóa stored procedure FindByUsersId nếu tồn tại
IF OBJECT_ID('dbo.FindByUsersId', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.FindByUsersId;
END
GO

-- Tạo stored procedure FindByUsersId mới
CREATE PROCEDURE [dbo].FindByUsersId
(
    @Id UNIQUEIDENTIFIER,
	@Url NVARCHAR(max)
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @urlNull NVARCHAR(max) = CONCAT(@Url , N'//Images/Default.jpg')

    SELECT UsersName as UsersName, FullName as FullName, Address, NumberPhone as NumberPhone,
        StateIDCard as StateIDCard, Email as Email, UsersLanguage as UsersLanguage, 
        CASE WHEN ISNULL(AvatarPublicUrl,'')<>'' THEN AvatarPublicUrl ELSE @urlNull END as AvatarUrl,
        IsLock as IsLock, IsBlock as IsBlock, IsActive as IsActive, 
        CreateTime as CreateTime, UpdateTime as UpdateTime
    FROM Users
    WHERE UsersId = @Id
END
GO