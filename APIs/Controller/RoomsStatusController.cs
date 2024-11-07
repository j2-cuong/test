﻿#pragma warning disable

using APIs.Logic;
using CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class RoomsStatusController : BaseApiController
    {
        private readonly IRoomsStatusHandler _IStatusHandler;
        private readonly IFindDataHandler _IFindDataHandler;

        public RoomsStatusController
        (
            IRoomsStatusHandler IStatusHandler,
            IFindDataHandler IFindDataHandler
        )
        {
            _IStatusHandler = IStatusHandler;
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
        ///         "StatusCode": "admmin",
        ///         "StatusName":"123456",
        ///         "StatusColor":"CuongNH"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Create(CreateRoomsStatus entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IStatusHandler.CreateStatus(entity, GetClientIp(), GetPath(), GetUsersId(), language);
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
        ///         "StatusId": "DBA96C30-5A03-40C8-95F0-184C0390B92C",
        ///         "StatusCode": "admmin",
        ///         "StatusName":"123456",
        ///         "StatusColor":"CuongNH"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Update(UpdateRoomsStatus entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IStatusHandler.UpdateStatus(entity, GetClientIp(), GetPath(), GetUsersId(), language);
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
        ///         "StatusId": "DBA96C30-5A03-40C8-95F0-184C0390B92C"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Delete(DeleteRoomsStatus entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IStatusHandler.DeleteStatus(entity, GetClientIp(), GetPath(), GetUsersId(), language);
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
        public async Task<Response<InfoOfRoomsStatus>> FindById(FindById entity)
        {
            string tableName = EnumsTableName.Table.Status.ToString();
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IFindDataHandler.FindById<InfoOfRoomsStatus>(entity, GetClientIp(), tableName, GetPath(), GetUsersId(), language);
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
        ///         "IdLogin" : "7004E920-892A-45AE-BBE2-C3E485C370AB",
        ///         "PageSize": 10,
        ///         "PageIndex" : 1
        ///     }
        /// 
        /// </remarks>
        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<ResponseTable<InfoOfRoomsStatus>> FindAll(FindAll entity)
        {
            string tableName = EnumsTableName.Table.Status.ToString();
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IFindDataHandler.FindAll<InfoOfRoomsStatus>(entity, GetClientIp(), tableName, GetPath(), GetUsersId(), language);
        }
    }
}
