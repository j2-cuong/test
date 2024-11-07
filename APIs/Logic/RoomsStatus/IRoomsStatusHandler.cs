#pragma warning disable

using CommonServices;
using static CommonServices.EnumsTableName;

namespace APIs.Logic
{
    public interface IRoomsStatusHandler
    {
        /// <summary>
        /// Tạo tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Response<bool>> CreateStatus(CreateRoomsStatus model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Sửa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> UpdateStatus(UpdateRoomsStatus model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> DeleteStatus(DeleteRoomsStatus model, string IpConnect, string controller, string usersId, string language);
    }
}
