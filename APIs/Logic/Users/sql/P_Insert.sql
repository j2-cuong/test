-- Kiểm tra và xóa stored procedure CreateUsers nếu tồn tại
IF OBJECT_ID('dbo.CreateUsers', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.CreateUsers;
END
GO

-- Tạo stored procedure CreateUsers mới
CREATE PROCEDURE [dbo].[CreateUsers]
(
    @UsersId UNIQUEIDENTIFIER,
    @UsersName varchar(100) = null,
    @UsersPassword nvarchar(100) = null,
    @FullName nvarchar(200) = null, 
    @Address nvarchar(200) = null, 
    @NumberPhone nvarchar(200) = null,
    @StateIDCard nvarchar(200) = null,
    @Email nvarchar(200) = NULL,
    @UsersLanguage NVARCHAR(10) = NULL,
	@AvatarPublicUrl NVARCHAR(200) NULL,
	@AvatarFileSave NVARCHAR(200) NULL
)
AS
SET NOCOUNT ON;
BEGIN
    INSERT INTO Users 
        (
            UsersId, UsersName, UsersPassword, FullName, 
			Address, NumberPhone, StateIDCard, Email,
			UsersLanguage, AvatarPublicUrl, AvatarFileSave,
			IsLock,IsBlock,IsActive,
            CreateTime,UpdateTime
        )
    VALUES 
        (
            @UsersId, @UsersName, @UsersPassword, @FullName, 
            @Address, @NumberPhone, @StateIDCard, @Email,
            @UsersLanguage, @AvatarPublicUrl, @AvatarFileSave,
			0,0,0,
            GETDATE(),GETDATE()
        )
END
GO