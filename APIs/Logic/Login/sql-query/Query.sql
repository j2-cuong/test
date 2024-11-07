CREATE PROCEDURE GetUserInfo
    @UsersName NVARCHAR(100) = null,
    @UsersPassword  NVARCHAR(100) = null
AS
BEGIN
    SET NOCOUNT ON;

    -- Biến để lưu JSON kết quả
    DECLARE @json NVARCHAR(MAX);

    DECLARE @UsersId UNIQUEIDENTIFIER = (SELECT CAST(UsersId AS UNIQUEIDENTIFIER ) AS UsersId  FROM Users WHERE UsersName = @UsersName AND UsersPassword = @UsersPassword)
    -- Select dữ liệu cần thiết và chuyển đổi thành JSON
    SELECT 
        (
            SELECT 
                u.UsersId AS [users.usersId],
                u.UsersAvatar AS [users.urlAvatar],
                u.UsersLanguage AS [users.language-config],
                (
                    SELECT 
                        COUNT(*) AS [users.toast.count],
                        (
                            SELECT 
                                t.ToastUserSend AS [users.toast.detail.usersSend],
                                t.ToastContent AS [users.toast.detail.content]
                            FROM Toast t
                            WHERE t.UsersId = u.UsersId
                            FOR JSON PATH
                        ) AS [users.toast.detail]
                    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
                ) AS toast,
                (
                    SELECT 
                        a.AppConfigsLogo AS [logo.urlLogo]
                    FROM AppConfigs a
                    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
                ) AS logo,
                (
                    SELECT 
                        r.RolesId AS [role.role-id],
                        r.RolesName AS [role.role-name]
                    FROM Roles r
                    WHERE r.UsersId = u.UsersId
                    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
                ) AS role
            FROM Users u
            WHERE u.UsersId = @UsersId
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
        ) AS JsonResult
    INTO @json;

    -- Trả về kết quả JSON
    SELECT @json AS JsonResult;
END;
