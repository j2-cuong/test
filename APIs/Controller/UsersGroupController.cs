#pragma warning disable

using APIs.Logic;
using CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    [ControllerDescription("Danh sách Nhóm tài khoản")]

    public class UsersGroupController : BaseApiController
    {
        private readonly IUsersGroupHandler _IUsersGroupHandler;
        private readonly IFindDataHandler _IFindDataHandler;

        public UsersGroupController
        (
            IUsersGroupHandler IUsersGroupHandler,
            IFindDataHandler IFindDataHandler
        )
        {
            _IUsersGroupHandler = IUsersGroupHandler;
            _IFindDataHandler = IFindDataHandler;
        }

        /// <summary>
        /// Tạo trạng thái.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : application/json
        /// 
        /// thêm vào trong header 1 tùy chọn : 'X-Custom-Header': IdUserLogin
        /// thêm vào trong header 1 tùy chọn : 'X-RolesId-Header': IdRoles
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {
        ///         "UsersGroupCode": "admmin",
        ///         "UsersGroupName":"123456"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Create(CreateUsersGroup entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersGroupHandler.CreateUsersGroup(entity, GetClientIp(), GetPath(), GetUsersId(), language);
        }


        /// <summary>
        /// Sửa thông tin trạng thái.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : application/json
        /// 
        /// thêm vào trong header 1 tùy chọn : 'X-Custom-Header': IdUserLogin
        /// 
        /// thêm vào trong header 1 tùy chọn : 'X-RolesId-Header': IdRoles
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {
        ///         "UsersGroupId": "DBA96C30-5A03-40C8-95F0-184C0390B92C",
        ///         "UsersGroupCode": "admmin",
        ///         "UsersGroupName":"123456"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Update(UpdateUsersGroup entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersGroupHandler.UpdateUsersGroup(entity, GetClientIp(), GetPath(), GetUsersId(), language);
        }

        /// <summary>
        /// Xóa trạng thái.
        /// </summary>
        /// <remarks>
        /// Example: sử dụng Postman
        /// 
        /// METHOD : POST
        /// 
        /// I, Thẻ headers chọn Content-Type : application/json
        /// 
        /// thêm vào trong header 1 tùy chọn : 'X-Custom-Header': IdUserLogin
        /// 
        /// thêm vào trong header 1 tùy chọn : 'X-RolesId-Header': IdRoles
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {        
        ///         "UsersGroupId": "DBA96C30-5A03-40C8-95F0-184C0390B92C"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Delete(DeleteUsersGroup entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersGroupHandler.DeleteUsersGroup(entity, GetClientIp(), GetPath(), GetUsersId(), language);
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
        /// thêm vào trong header 1 tùy chọn : 'X-Custom-Header': IdUserLogin
        /// 
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
        public async Task<Response<InfoOfUsersGroup>> FindById(FindById entity)
        {
            string tableName = EnumsTableName.Table.UsersGroup.ToString();
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IFindDataHandler.FindById<InfoOfUsersGroup>(entity, GetClientIp(), tableName, GetPath(), GetUsersId(), language);
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
        /// thêm vào trong header 1 tùy chọn : 'X-Custom-Header': IdUserLogin
        /// 
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
        public async Task<ResponseTable<InfoOfUsersGroup>> FindAll(FindAll entity)
        {
            string tableName = EnumsTableName.Table.UsersGroup.ToString();
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IFindDataHandler.FindAll<InfoOfUsersGroup>(entity, GetClientIp(), tableName, GetPath(), GetUsersId(), language);
        }
    }
}
