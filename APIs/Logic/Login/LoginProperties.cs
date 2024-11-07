#pragma warning disable

namespace APIs.Logic
{
    /// <summary>
    /// Token
    /// </summary>
    public class Token 
    { 
        public string AccessToken { get; set; } 
        public string RefreshToken { get; set; } 
    }
 
    /// <summary>
    /// Thông tin Users
    /// </summary>
    public class Users 
    {
        public Guid UsersId { get; set; }
        public string UrlAvatar { get; set; }
        public string LanguageConfig { get; set; }
    }
 
    /// <summary>
    /// Logo chung của app
    /// </summary>
    public class Logo 
    { 
        public string UrlLogo { get; set; } 
    }
 
    /// <summary>
    /// Phân quyền của tài khoản
    /// </summary>
    public class Role 
    { 
        public Guid RoleId { get; set; } 
        public string RoleName { get; set; } 
    }
 
    /// <summary>
    /// Bảng trả kết quả
    /// </summary>
    public class UserInfo 
    {
        public Token Token {get; set;}
        public Users Users { get; set; } 
        public Logo Logo { get; set; } 
        public Role Role { get; set; } 
    }
 
    public class LoginInfo
    {
        public string UsersName { get; set; }
        public string UsersPassword { get; set; }
    }
 
}
