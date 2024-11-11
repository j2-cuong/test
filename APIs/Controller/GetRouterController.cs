using APIs.Logic;
using CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class GetRouterController : BaseApiController
    {
        private readonly IGetRouterHandler _IGetRouterHandler;
        public GetRouterController
        (
            IGetRouterHandler IGetRouterHandler,
            IFindDataHandler IFindDataHandler
        )
        {
            _IGetRouterHandler = IGetRouterHandler;
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
        /// </remarks>
        [HttpPost]
        public async Task<string> GetRouter()
        {
            return await _IGetRouterHandler.GetUrls();
        }
    }
}
