#pragma warning disable
using CommonServices;
using static CommonServices.EnumsTableName;

namespace APIs.Logic
{
    public interface IUsersHandler
    {
        /// <summary>
        /// Tạo tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Response<bool>> CreateUsers(CreateUsersModel model, string IpClient, string controller, string urlServer, string usersId, string language);

        /// <summary>
        /// Sửa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        Task<Response<bool>> UpdateUsers(UpdateUsersModel model, string IpClient, string controller, string urlServer, string usersId, string language);

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        Task<Response<bool>> DeleteUsers(DeleteUser model, string IpClient, string controller, string usersId, string language);

        /// <summary>
        /// Block khỏi hệ thống
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        Task<Response<bool>> BlockUsers(BlockUser model, string IpClient, string controller, string usersId, string language);

        /// <summary>
        /// Active tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        Task<Response<bool>> ActiveUsers(ActiveUser model, string IpClient, string controller, string usersId, string language);

        /// <summary>
        /// Active tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        Task<ResponseTable<InfoOfUsers>> FindAll(FindAll model, string IpClient, string controller, string usersId, string urlServer, string language);

        /// <summary>
        /// Active tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        Task<Response<InfoOfUsers>> FindById(FindById model, string IpClient, string controller, string usersId, string urlServer, string language);
    }
}
