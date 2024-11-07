using CommonServices;

namespace APIs.Logic
{
    public interface ILoginHandler
    {
        /// <summary>
        /// Tạo tài khoản
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Response<UserInfo>> Login(LoginInfo model, string IpConnect, string controller);
    }
}
