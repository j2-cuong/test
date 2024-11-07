using APIs.Logic;
using CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class LoginController : BaseApiController
    {
        private readonly ILoginHandler _ILoginHandler;
        public LoginController
        (
            ILoginHandler ILoginHandler,
            IFindDataHandler IFindDataHandler
        )
        {
            _ILoginHandler = ILoginHandler;
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : application/json
        /// 
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {
        ///         "UsersName": "UsersName",
        ///         "UsersPassword":"123456"
        ///     }
        /// 
        /// </remarks>
        [HttpPost]
        public async Task<Response<UserInfo>> Login(LoginInfo model)
        {
            return await _ILoginHandler.Login(model, GetClientIp(), GetPath());
        }
    }
}
