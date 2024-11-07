#pragma warning disable

namespace APIs.Logic
{
    /// <summary>
    /// Bản thiết kế của bảng Status ( Quản lý trạng thái )
    /// </summary>
    /// 
    public class BaseRoomsStatus
    {
        public Guid RoomsStatusId { get; set; }
    }

    /// <summary>
    /// Info dữ liệu trả ra toàn bộ, sử dụng cho GetAll hoặc GetByID
    /// </summary>
    public class InfoOfRoomsStatus : BaseRoomsStatus
    {
        public string RoomsStatusCode { get; set; }
        public string RoomsStatusName { get; set; }
        public string RoomsStatusColor { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action tạo mới
    /// </summary>
    public class CreateRoomsStatus : BaseRoomsStatus
    {
        public CreateRoomsStatus()
        {
            RoomsStatusId = Guid.NewGuid();
        }
        public string RoomsStatusCode { get; set; }
        public string RoomsStatusName { get; set; }
        public string RoomsStatusColor { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action chỉnh sửa
    /// </summary>
    public class UpdateRoomsStatus
    {
        public Guid RoomsStatusId { get; set; }
        public string RoomsStatusCode { get; set; }
        public string RoomsStatusName { get; set; }
        public string RoomsStatusColor { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action xóa
    /// </summary>
    public class DeleteRoomsStatus : BaseRoomsStatus
    {
    }

    /// <summary>
    /// Sử dụng để check cái filed không được phép trùng trong database
    /// </summary>
    public class CheckRoomsStatusDataProperties
    {   
        public Guid Id { get; set; }
        public string RoomsStatusCode { get; set; }
        public string RoomsStatusName { get; set; }
        public string RoomsStatusColor { get; set; }
    }
}
