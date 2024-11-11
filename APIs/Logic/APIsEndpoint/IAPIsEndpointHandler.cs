#pragma warning disable

using CommonServices;
using static CommonServices.EnumsTableName;

namespace APIs.Logic
{
    public interface IAPIsEndpointHandler
    {
        /// <summary>
        /// Tạo tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Response<bool>> CreateAPIsEndpoint(CreateAPIsEndpoint model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Sửa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> UpdateAPIsEndpoint(UpdateAPIsEndpoint model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> DeleteAPIsEndpoint(DeleteAPIsEndpoint model, string IpConnect, string controller, string usersId, string language);
    }
}
