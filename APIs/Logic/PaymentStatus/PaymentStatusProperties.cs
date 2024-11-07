#pragma warning disable

namespace APIs.Logic
{
    /// <summary>
    /// Bản thiết kế của bảng Status ( Quản lý trạng thái )
    /// </summary>
    /// 
    public class BasePaymentStatus
    {
        public Guid PaymentStatusId { get; set; }
    }

    /// <summary>
    /// Info dữ liệu trả ra toàn bộ, sử dụng cho GetAll hoặc GetByID
    /// </summary>
    public class InfoOfPaymentStatus : BasePaymentStatus
    {
        public string PaymentStatusCode { get; set; }
        public string PaymentStatusName { get; set; }
        public string PaymentStatusColor { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action tạo mới
    /// </summary>
    public class CreatePaymentStatus : BasePaymentStatus
    {
        public CreatePaymentStatus()
        {
            PaymentStatusId = Guid.NewGuid();
        }
        public string PaymentStatusCode { get; set; }
        public string PaymentStatusName { get; set; }
        public string PaymentStatusColor { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action chỉnh sửa
    /// </summary>
    public class UpdatePaymentStatus
    {
        public Guid PaymentStatusId { get; set; }
        public string PaymentStatusCode { get; set; }
        public string PaymentStatusName { get; set; }
        public string PaymentStatusColor { get; set; }
    }

    /// <summary>
    /// Sử dụng cho action xóa
    /// </summary>
    public class DeletePaymentStatus : BasePaymentStatus
    {
    }

    /// <summary>
    /// Sử dụng để check cái filed không được phép trùng trong database
    /// </summary>
    public class CheckPaymentStatusDataProperties
    {
        public Guid PaymentStatusId { get; set; }
        public string PaymentStatusCode { get; set; }
        public string PaymentStatusName { get; set; }
        public string PaymentStatusColor { get; set; }
    }
}
