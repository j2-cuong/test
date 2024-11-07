-- Kiểm tra và xóa stored procedure UpdateUsers nếu tồn tại
IF OBJECT_ID('dbo.UpdateUsers', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.UpdateUsers;
END
GO

-- Tạo stored procedure UpdateUsers mới
CREATE PROCEDURE [dbo].[UpdateUsers]
(
    @UsersId UNIQUEIDENTIFIER,
    @UsersName varchar(100) = null,
    @UsersPassword nvarchar(100) = null,
    @FullName nvarchar(200) = null, 
    @Address nvarchar(200) = null, 
    @NumberPhone nvarchar(200) = null,
    @StateIDCard nvarchar(200) = null,
    @Email nvarchar(200) = null,
    @UsersLanguage nvarchar(10) = NULL,
	@AvatarPublicUrl NVARCHAR(200) NULL,
	@AvatarFileSave NVARCHAR(200) NULL,
	@UserChangeInfo int  = 0
)
AS
SET NOCOUNT ON;
BEGIN
    UPDATE Users SET
        UsersPassword = @UsersPassword , 
        FullName = @FullName, 
        [Address] = @Address, 
        NumberPhone = 
        @NumberPhone, 
        StateIDCard = 
        @StateIDCard, 
        Email = @Email,
        UsersLanguage = @UsersLanguage,
        AvatarPublicUrl = @AvatarPublicUrl,
        AvatarFileSave = @AvatarFileSave,
        UserChangeInfo = 1,
        UpdateTime = GETDATE()
    WHERE UsersId = @UsersId AND UsersName = @UsersName
END
GO