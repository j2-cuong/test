#pragma warning disable

namespace APIs.Logic
{
    /// <summary>
    /// Bản thiết kế của bảng Add User vào nhóm quyền ( Quản lý trạng thái )
    /// </summary>
    /// 
    public class BaseRolePermission
    {
        public Guid RolePermissionId { get; set; }
    }

    /// <summary>
    /// Info dữ liệu trả ra toàn bộ, sử dụng cho GetAll hoặc GetByID
    /// </summary>
    public class InfoOfRolePermission : BaseRolePermission
    {
        public Guid UsersGroupId { get; set; }
        public string UsersGroupName { get; set; }
        public Guid APIsEndpointId { get; set; }
        public string APIsEndpointName { get; set; }
        public string APIsEndpointUrl { get; set; }
        public bool isAccess { get; set; }
        public Guid CreateBy { get; set; }
        public string CreateTime { get; set; }
        public Guid UpdateBy { get; set; }
        public string UpdateTime { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action tạo mới
    /// </summary>
    public class CreateRolePermission : BaseRolePermission
    {
        public CreateRolePermission()
        {
            RolePermissionId = Guid.NewGuid();
        }
        public Guid UsersGroupId { get; set; }
        public string UsersGroupName { get; set; }
        public Guid APIsEndpointId { get; set; }
        public string APIsEndpointName { get; set; }
        public string APIsEndpointUrl { get; set; }
        public bool isAccess { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action chỉnh sửa
    /// </summary>
    public class UpdateRolePermission
    {
        public Guid RolePermissionId { get; set; }
        public Guid UsersGroupId { get; set; }
        public string UsersGroupName { get; set; }
        public Guid APIsEndpointId { get; set; }
        public string APIsEndpointName { get; set; }
        public string APIsEndpointUrl { get; set; }
        public bool isAccess { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action xóa
    /// </summary>
    public class DeleteRolePermission : BaseRolePermission
    {
    }
}
