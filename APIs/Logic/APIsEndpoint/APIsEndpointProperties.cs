#pragma warning disable

namespace APIs.Logic
{
    /// <summary>
    /// Bản thiết kế của bảng APIsEndpoint ( Quản lý Url APIsEndpoint )
    /// </summary>
    /// 
    public class BaseAPIsEndpoint
    {
        public Guid APIsEndpointId { get; set; }
    }

    /// <summary>
    /// Info dữ liệu trả ra toàn bộ, sử dụng cho GetAll hoặc GetByID
    /// </summary>
    public class InfoOfAPIsEndpoint : BaseAPIsEndpoint
    {
        public string APIsEndpointCode { get; set; }
        public string APIsEndpointName { get; set; }
        public string APIsEndpointUrl { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action tạo mới
    /// </summary>
    public class CreateAPIsEndpoint : BaseAPIsEndpoint
    {
        public CreateAPIsEndpoint()
        {
            APIsEndpointId = Guid.NewGuid();
        }
        public string APIsEndpointCode { get; set; }
        public string APIsEndpointName { get; set; }
        public string APIsEndpointUrl { get; set; }

    }

    /// <summary>
    /// Sử dụng cho action chỉnh sửa
    /// </summary>
    public class UpdateAPIsEndpoint
    {
        public Guid APIsEndpointId { get; set; }
        public string APIsEndpointCode { get; set; }
        public string APIsEndpointName { get; set; }
        public string APIsEndpointUrl { get; set; }

    }

    /// <summary>
    /// Sử dụng cho action xóa
    /// </summary>
    public class DeleteAPIsEndpoint : BaseAPIsEndpoint
    {
    }

    /// <summary>
    /// Sử dụng để check cái filed không được phép trùng trong database
    /// </summary>
    public class CheckAPIsEndpointDataProperties
    {   
        public Guid Id { get; set; }
        public string APIsEndpointCode { get; set; }
        public string APIsEndpointName { get; set; }
        public string APIsEndpointUrl { get; set; }
    }
}
