#pragma warning disable

using CommonServices;
using static CommonServices.EnumsTableName;

namespace APIs.Logic
{
    public interface IUsersGroupMembershipHandler
    {
        /// <summary>
        /// Tạo tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Response<bool>> CreateUsersGroupMembership(CreateUsersGroupMembership model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Sửa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> UpdateUsersGroupMembership(UpdateUsersGroupMembership model, string IpConnect, string controller, string usersId, string language);

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        Task<Response<bool>> DeleteUsersGroupMembership(DeleteUsersGroupMembership model, string IpConnect, string controller, string usersId, string language, InfoOfUsersGroupMembership oldData);
    }
}
