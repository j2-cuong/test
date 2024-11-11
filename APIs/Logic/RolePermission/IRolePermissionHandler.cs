#pragma warning disable

using CommonServices;
using static CommonServices.EnumsTableName;

namespace APIs.Logic
{
    public interface IRolePermissionHandler
    {
        /// <summary>
        /// Tạo tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Response<bool>> CreateRolePermission(CreateRolePermission model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Sửa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> UpdateRolePermission(UpdateRolePermission model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> DeleteRolePermission(DeleteRolePermission model, string IpConnect, string controller, string usersId, string language, InfoOfRolePermission oldData);
    }
}
