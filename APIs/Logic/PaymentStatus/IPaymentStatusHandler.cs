
using CommonServices;

namespace APIs.Logic
{
    public interface IPaymentStatusHandler
    {
        /// <summary>
        /// Tạo trạng thái thanh toán
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Response<bool>> CreatePaymentStatus(CreatePaymentStatus model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Sửa trạng thái thanh toán
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> UpdatePaymentStatus(UpdatePaymentStatus model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Xóa trạng thái thanh toán
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> DeletePaymentStatus(DeletePaymentStatus model, string IpConnect, string controller, string usersId, string language);
    }
}
