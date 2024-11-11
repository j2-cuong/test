#pragma warning disable

namespace APIs.Logic
{
    /// <summary>
    /// Bản thiết kế của bảng Status ( Quản lý trạng thái )
    /// </summary>
    /// 
    public class BaseUsersGroup
    {
        public Guid UsersGroupId { get; set; }
    }

    /// <summary>
    /// Info dữ liệu trả ra toàn bộ, sử dụng cho GetAll hoặc GetByID
    /// </summary>
    public class InfoOfUsersGroup : BaseUsersGroup
    {
        public string UsersGroupCode { get; set; }
        public string UsersGroupName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action tạo mới
    /// </summary>
    public class CreateUsersGroup : BaseUsersGroup
    {
        public CreateUsersGroup()
        {
            UsersGroupId = Guid.NewGuid();
        }
        public string UsersGroupCode { get; set; }
        public string UsersGroupName { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action chỉnh sửa
    /// </summary>
    public class UpdateUsersGroup
    {
        public Guid UsersGroupId { get; set; }
        public string UsersGroupCode { get; set; }
        public string UsersGroupName { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action xóa
    /// </summary>
    public class DeleteUsersGroup : BaseUsersGroup
    {
    }

    /// <summary>
    /// Sử dụng để check cái filed không được phép trùng trong database
    /// </summary>
    public class CheckUsersGroupDataProperties
    {   
        public Guid Id { get; set; }
        public string UsersGroupCode { get; set; }
        public string UsersGroupName { get; set; }
    }
}
