#pragma warning disable

namespace APIs.Logic
{
    /// <summary>
    /// Bản thiết kế của bảng Add User vào nhóm quyền ( Quản lý trạng thái )
    /// </summary>
    /// 
    public class BaseUsersGroupMembership
    {
        public Guid UsersGroupMembershipId { get; set; }
    }

    /// <summary>
    /// Info dữ liệu trả ra toàn bộ, sử dụng cho GetAll hoặc GetByID
    /// </summary>
    public class InfoOfUsersGroupMembership : BaseUsersGroupMembership
    {
        public Guid UsersGroupId { get; set; }
        public string UsersGroupName { get; set; }
        public Guid UsersId { get; set; }
        public string UsersName { get; set; }
        public string FullName { get; set; }
        public Guid CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action tạo mới
    /// </summary>
    public class CreateUsersGroupMembership : BaseUsersGroupMembership
    {
        public CreateUsersGroupMembership()
        {
            UsersGroupMembershipId = Guid.NewGuid();
        }
        public Guid UsersGroupId { get; set; }
        public string UsersGroupName { get; set; }
        public Guid UsersId { get; set; }
        public string UsersName { get; set; }
        public string FullName { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action chỉnh sửa
    /// </summary>
    public class UpdateUsersGroupMembership
    {
        public Guid UsersGroupMembershipId { get; set; }
        public Guid UsersGroupId { get; set; }
        public string UsersGroupName { get; set; }
        public Guid UsersId { get; set; }
        public string UsersName { get; set; }
        public string FullName { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action xóa
    /// </summary>
    public class DeleteUsersGroupMembership : BaseUsersGroupMembership
    {
    }

    /// <summary>
    /// Sử dụng để check cái filed không được phép trùng trong database
    /// </summary>
    public class CheckUsersGroupMembershipDataProperties
    {
        public Guid UsersId { get; set; }
    }
}
