#pragma warning disable

using APIs.Logic;
using CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class UsersController : BaseApiController
    {
        private readonly IUsersHandler _IUsersHandler;
        private readonly IFindDataHandler _IFindDataHandler;

        public UsersController
        (
            IUsersHandler IAccountHandler,
            IFindDataHandler IFindDataHandler
        )
        {
            _IUsersHandler = IAccountHandler;
            _IFindDataHandler = IFindDataHandler;
        }

        /// <summary>
        /// Tạo tài khoản.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : FormData
        /// 
        /// 
        /// II, Tham số bỏ qua
        /// 
        ///     AvatarPublicUrl : "1"
        ///         
        ///     AvatarFileSave : "1"
        /// 
        /// </remarks>

        [HttpPost]

        public async Task<Response<bool>> Create(CreateUsersModel entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersHandler.CreateUsers(entity, GetClientIp(), GetPath(), GetServerIp(), GetUsersId(), language);
        }


        /// <summary>
        /// Sửa thông tin tài khoản.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : FormData
        /// 
        /// II, Tham số bỏ qua
        /// 
        ///     AvatarPublicUrl : "1"
        ///         
        ///     AvatarFileSave : "1
        /// 
        /// </remarks>

        [HttpPost]
        //[ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Update(UpdateUsersModel entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersHandler.UpdateUsers(entity, GetClientIp(), GetPath(), GetServerIp(), GetUsersId(), language);
        }

        /// <summary>
        /// Xóa tài khoản.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : application/json
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {        
        ///         "UserId": "DBA96C30-5A03-40C8-95F0-184C0390B92C"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Delete(DeleteUser entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersHandler.DeleteUsers(entity, GetClientIp(), GetPath(), GetUsersId(), language);
        }

        /// <summary>
        /// Block tài khoản.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : application/json
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {
        ///         "UserId": "DBA96C30-5A03-40C8-95F0-184C0390B92C"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Block(BlockUser entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersHandler.BlockUsers(entity, GetClientIp(), GetPath(), GetUsersId(), language);
        }

        /// <summary>
        /// Kích hoạt tài khoản.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : application/json
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {
        ///         "UserId": "DBA96C30-5A03-40C8-95F0-184C0390B92C"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Active(ActiveUser entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersHandler.ActiveUsers(entity, GetClientIp(), GetPath(), GetUsersId(), language);
        }

        /// <summary>
        /// Tìm kiếm theo Id.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : application/json
        /// 
        /// thêm vào trong header 1 tùy chọn : 'X-UsersId-Header': IdUserLogin
        /// thêm vào trong header 1 tùy chọn : 'X-RolesId-Header': IdRoles
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {
        ///         "IdSearch": "DBA96C30-5A03-40C8-95F0-184C0390B92C"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<InfoOfUsers>> FindById(FindById entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersHandler.FindById(entity, GetClientIp(), GetPath(), GetUsersId(), GetServerIp(), language);
        }

        /// <summary>
        /// Search All.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : application/json
        /// 
        /// thêm vào trong header 1 tùy chọn : 'X-UsersId-Header': IdUserLogin
        /// thêm vào trong header 1 tùy chọn : 'X-RolesId-Header': IdRoles
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {
        ///         "PageSize": 10,
        ///         "PageIndex" : 1
        ///     }
        /// 
        /// </remarks>
        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<ResponseTable<InfoOfUsers>> FindAll(FindAll entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersHandler.FindAll(entity, GetClientIp(), GetPath(), GetUsersId(), GetServerIp(), language);
        }
    }
}
