#pragma warning disable

using APIs;
using APIs.Helper;
using APIs.Logic;
using CommonServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class PermissionFilter : IAsyncActionFilter
{
    private readonly IPermissionHandler _permissionService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<PermissionFilter> _logger;


    public PermissionFilter(IPermissionHandler permissionService, IHttpContextAccessor httpContextAccessor, ILogger<PermissionFilter> logger)
    {
        _permissionService = permissionService;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Kiểm tra nếu controller kế thừa từ BaseApiController
        if (context.Controller is BaseApiController baseController)
        {
            // Lấy UserId từ header thông qua phương thức GetUsersId
            var userIdString = baseController.GetUsersId();
            BaseUsers baseUsers = new BaseUsers();
            baseUsers.UsersId = Guid.Parse(userIdString);
            var language = FindDuplicateUsersInfo.GetLanguageOfUser(baseUsers);

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
            {
                // Nếu không lấy được UserId hoặc UserId không hợp lệ, trả về Unauthorized
                context.Result = new JsonResult(GetStatusFunction.HandleCheckResponse(StatusResult.ERROR_UNAUTHORIZEDRESULT_BE_CODE, language))
                {
                    StatusCode = StatusResult.ERROR_UNAUTHORIZEDRESULT_BE_CODE
                };
                return;
            }

            // Lấy route hiện tại
            var route = $"{context.HttpContext.Request.Path.Value}";

            // Kiểm tra quyền truy cập
            var hasPermission = await _permissionService.HasPermission(userId, route);

            if (!hasPermission)
            {
                // Nếu không có quyền thì trả về Response với Status 403
                context.Result = new JsonResult(GetStatusFunction.HandleCheckResponse(StatusResult.ERROR_NOTHAVE_PERMISSION_BE_CODE, language))
                {
                    StatusCode = StatusResult.ERROR_NOTHAVE_PERMISSION_BE_CODE
                };
                return;
            }

            // Kiểm tra phiên đăng nhập 
            var hasLogin = await _permissionService.NeedLogin(userId);
            if (!hasLogin) 
            {
                // Bị thay đổi thông tin cần login lại
                context.Result = new JsonResult(GetStatusFunction.HandleCheckResponse(StatusResult.ERROR_YOUR_INFOMATION_HAS_CHANGE_CODE, language))
                {
                    StatusCode = StatusResult.ERROR_YOUR_INFOMATION_HAS_CHANGE_CODE
                };
                return;
            }

            context.HttpContext.Items["UserLanguage"] = language;
            await next();
        }
        else
        {
            ConvertLog.WriteLog
            (
                _logger, 
                "PermissionFilter", 
                "Controller đang thao tác không kế thừa baseController (Vui lòng F12 check network của chức năng đang thao tác và kiểm controller nào đang gọi)",
                "CuongNH"
            );
            // Nếu controller không phải là BaseApiController, trả về lỗi
            context.Result = new JsonResult(GetStatusFunction.HandleCheckResponse(StatusResult.ERROR_ADMINISTATOR_CODE, "EN"))
            {
                StatusCode = StatusResult.ERROR_ADMINISTATOR_CODE
            };
            return;
        }
    }
}