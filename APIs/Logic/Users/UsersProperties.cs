#pragma warning disable

using Newtonsoft.Json;

namespace APIs.Logic
{
    /// <summary>
    /// Bản thiết kế của bảng Users ( Quản lý tài khoản )
    /// </summary>
    /// 
    public class BaseUsers
    {
        public Guid UsersId { get; set; }
    }

    /// <summary>
    /// Info dữ liệu trả ra toàn bộ, sử dụng cho GetAll hoặc GetByID
    /// </summary>
    public class InfoOfUsers : BaseUsers
    {
        public string UsersName { get; set; }
        public string UsersPassword { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public string StateIDCard { get; set; }
        public string Email { get; set; }
        public string UsersLanguage { get; set; }
        public string AvatarPublicUrl { get; set; }
        public string AvatarFileSave { get; set; }
        public bool IsLock { get; set; }
        public bool IsBlock { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action tạo mới
    /// </summary>
    public class CreateUsers : BaseUsers
    {
        public CreateUsers()
        {
            UsersId = Guid.NewGuid();
        }
        public string UsersName { get; set; }
        public string UsersPassword { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public string StateIDCard { get; set; }
        public string Email { get; set; }
        public string UsersLanguage { get; set; }
        [JsonIgnore]
        public string AvatarPublicUrl { get; set; }
        [JsonIgnore]
        public string AvatarFileSave { get; set; }
    }

    public class CreateUsersModel : CreateUsers
    {
        public IFormFile ImagesFiles { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action chỉnh sửa
    /// </summary>
    public class UpdateUsers 
    {
        public Guid UsersId { get; set; }
        public string UsersPassword { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public string StateIDCard { get; set; }
        public string Email { get; set; }
        public string UsersLanguage { get; set; }
        [JsonIgnore]
        public string AvatarPublicUrl { get; set; }
        [JsonIgnore]
        public string AvatarFileSave { get; set; }
        public int UserChangeInfo { get; set; }
    }

    public class UpdateUsersModel : UpdateUsers
    {
        public IFormFile ImagesFiles { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action xóa
    /// </summary>
    public class DeleteUser : BaseUsers
    {
    }

    /// <summary>
    /// Sử dụng cho action khóa do đăng nhập nhiều lần bị sai
    /// </summary>
    public class LockUser : BaseUsers
    {
        public bool IsLock { get; set; } = true;
    }

    /// <summary>
    /// Sử dụng cho action block khỏi hệ thống
    /// </summary>
    public class BlockUser : BaseUsers
    {
        public bool IsBlock { get; set; } = true;

    }

    /// <summary>
    /// Sử dụng cho active tài khoản
    /// </summary>
    public class ActiveUser : BaseUsers
    {
        public bool IsActive { get; set; } = true;
    }

    /// <summary>
    /// Sử dụng cho action đăng nhập lại
    /// </summary>
    public class NeedLogin : BaseUsers
    {
    }

    /// <summary>
    /// Sử dụng để check cái filed không được phép trùng trong database
    /// </summary>
    public class CheckUsersDataProperties
    {
        public Guid Id { get; set; }
        public string UsersName { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string StateIdCard { get; set; }
    }
}
