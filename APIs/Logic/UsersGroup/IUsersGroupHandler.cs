#pragma warning disable

using CommonServices;
using static CommonServices.EnumsTableName;

namespace APIs.Logic
{
    public interface IUsersGroupHandler
    {
        /// <summary>
        /// Tạo tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Response<bool>> CreateUsersGroup(CreateUsersGroup model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Sửa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> UpdateUsersGroup(UpdateUsersGroup model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> DeleteUsersGroup(DeleteUsersGroup model, string IpConnect, string controller, string usersId, string language);
    }
}
