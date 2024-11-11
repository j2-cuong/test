#pragma warning disable

using APIs.Logic;
using CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    [ControllerDescription("Danh sách APIsEndpoint")]
    public class APIsEndpointController : BaseApiController
    {
        private readonly IAPIsEndpointHandler _IAPIsEndpointHandler;
        private readonly IFindDataHandler _IFindDataHandler;

        public APIsEndpointController
        (
            IAPIsEndpointHandler IAPIsEndpointHandler,
            IFindDataHandler IFindDataHandler
        )
        {
            _IAPIsEndpointHandler = IAPIsEndpointHandler;
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
        /// 
        /// thêm vào trong header 1 tùy chọn : 'X-RolesId-Header': IdRoles
        /// 
        /// thêm vào trong header 1 tùy chọn : 'X-UserLanguage-Header': UserLanguage
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {
        ///         "APIsEndpointName":"123456",
        ///         "APIsEndpointUrl": "/User/Create"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Create(CreateAPIsEndpoint entity)
        {
            return await _IAPIsEndpointHandler.CreateAPIsEndpoint(entity, GetClientIp(), GetPath(), GetUsersId(), GetLanguage());
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
        /// thêm vào trong header 1 tùy chọn : 'X-UserLanguage-Header': UserLanguage
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {
        ///         "APIsEndpointId": "DBA96C30-5A03-40C8-95F0-184C0390B92C",
        ///         "APIsEndpointName":"123456",
        ///         "APIsEndpointUrl": "/User/Create"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Update(UpdateAPIsEndpoint entity)
        {
            return await _IAPIsEndpointHandler.UpdateAPIsEndpoint(entity, GetClientIp(), GetPath(), GetUsersId(), GetLanguage());
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
        /// thêm vào trong header 1 tùy chọn : 'X-UserLanguage-Header': UserLanguage
        /// 
        /// II, Thẻ body - raw - đổi text thành Json
        /// 
        /// III, Json mẫu
        /// 
        ///     {        
        ///         "APIsEndpointId": "DBA96C30-5A03-40C8-95F0-184C0390B92C"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Delete(DeleteAPIsEndpoint entity)
        {
            return await _IAPIsEndpointHandler.DeleteAPIsEndpoint(entity, GetClientIp(), GetPath(), GetUsersId(), GetLanguage());
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
        /// thêm vào trong header 1 tùy chọn : 'X-UserLanguage-Header': UserLanguage
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
        public async Task<Response<InfoOfAPIsEndpoint>> FindById(FindById entity)
        {
            string tableName = EnumsTableName.Table.APIsEndpoint.ToString();
            return await _IFindDataHandler.FindById<InfoOfAPIsEndpoint>(entity, GetClientIp(), tableName, GetPath(), GetUsersId(), GetLanguage());
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
        /// thêm vào trong header 1 tùy chọn : 'X-UserLanguage-Header': UserLanguage
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
        public async Task<ResponseTable<InfoOfAPIsEndpoint>> FindAll(FindAll entity)
        {
            string tableName = EnumsTableName.Table.APIsEndpoint.ToString();
            return await _IFindDataHandler.FindAll<InfoOfAPIsEndpoint>(entity, GetClientIp(), tableName, GetPath(), GetUsersId(), GetLanguage());
        }
    }
}
