#pragma warning disable

using APIs.Logic;
using CommonServices;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    [ControllerDescription("Phân quyền nhóm người sử dụng")]
    public class UsersGroupMembershipController : BaseApiController
    {
        private readonly IUsersGroupMembershipHandler _IUsersGroupMembershipHandler;
        private readonly IFindDataHandler _IFindDataHandler;

        public UsersGroupMembershipController
        (
            IUsersGroupMembershipHandler IUsersGroupMembershipHandler,
            IFindDataHandler IFindDataHandler
        )
        {
            _IUsersGroupMembershipHandler = IUsersGroupMembershipHandler;
            _IFindDataHandler = IFindDataHandler;
        }

        /// <summary>
        /// Thêm người dùng vào nhóm quyền
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
        ///          "UsersGroupId" : "DBA96C30-5A03-40C8-95F0-184C0390B92C",
        ///          "UsersGroupName": "Tên nhóm quyền", 
        ///          "UsersId" : "DBA96C30-5A03-40C8-95F0-184C0390B92C",
        ///          "UsersName" : "Tên tài khoản",
        ///          "FullName" : "Tên người dùng"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Create(CreateUsersGroupMembership entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersGroupMembershipHandler.CreateUsersGroupMembership(entity, GetClientIp(), GetPath(), GetUsersId(), GetLanguage() ?? "EN");
        }


        /// <summary>
        /// Đổi người dùng trong nhóm quyền
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
        ///             "UsersGroupId" : "DBA96C30-5A03-40C8-95F0-184C0390B92C",
        ///             "UsersGroupName": "Tên nhóm quyền", 
        ///             "UsersId" : "DBA96C30-5A03-40C8-95F0-184C0390B92C",
        ///             "UsersName" : "Tên tài khoản",
        ///             "FullName" : "Tên người dùng"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Update(UpdateUsersGroupMembership entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IUsersGroupMembershipHandler.UpdateUsersGroupMembership(entity, GetClientIp(), GetPath(), GetUsersId(), GetLanguage() ?? "EN");
        }

        /// <summary>
        /// Xóa người dùng khỏi nhóm quyền
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
        ///         "UsersGroupMembershipId": "DBA96C30-5A03-40C8-95F0-184C0390B92C"
        ///     }
        /// 
        /// </remarks>

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        public async Task<Response<bool>> Delete(DeleteUsersGroupMembership entity)
        {
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            string tableName = EnumsTableName.Table.UsersGroupMembership.ToString();
            FindById findById = new FindById();
            findById.IdSearch = entity.UsersGroupMembershipId;
            var oldData = await _IFindDataHandler.FindById<InfoOfUsersGroupMembership>(findById, GetClientIp(), tableName, GetPath(), GetUsersId(), GetLanguage() ?? "EN");
            return await _IUsersGroupMembershipHandler.DeleteUsersGroupMembership(entity, GetClientIp(), GetPath(), GetUsersId(), GetLanguage() ?? "EN", oldData.Data[0]);
        }

        /// <summary>
        /// Tìm kiếm nhóm quyền Id. ( Cần sửa lại )
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
        public async Task<Response<InfoOfUsersGroupMembership>> FindById(FindById entity)
        {
            string tableName = EnumsTableName.Table.UsersGroupMembership.ToString();
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IFindDataHandler.FindById<InfoOfUsersGroupMembership>(entity, GetClientIp(), tableName, GetPath(), GetUsersId(), GetLanguage() ?? "EN");
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
        public async Task<ResponseTable<InfoOfUsersGroupMembership>> FindAll(FindAll entity)
        {
            string tableName = EnumsTableName.Table.UsersGroupMembership.ToString();
            var language = HttpContext.Items["UserLanguage"]?.ToString();
            return await _IFindDataHandler.FindAll<InfoOfUsersGroupMembership>(entity, GetClientIp(), tableName, GetPath(), GetUsersId(), GetLanguage() ?? "EN");
        }
    }
}
