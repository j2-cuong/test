#pragma warning disable

using Microsoft.AspNetCore.Mvc;

public abstract class BaseApiController : ControllerBase
{
    /// <summary>
    /// Lấy Ip đang sử dụng endpoint
    /// </summary>
    /// <returns></returns>
    /// 
    [NonAction]
    public string GetClientIp()
    {
        return HttpContext.GetClientIpAddress();
    }

    /// <summary>
    /// Lấy endpoint khi truy cập vào controller
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public string GetPath()
    {
        var controllerName = ControllerContext.ActionDescriptor.ControllerName;
        var actionName = ControllerContext.ActionDescriptor.ActionName;
        return $"{controllerName}/{actionName}";
    }

    /// <summary>
    /// Lấy UserId khi truy cập vào controller
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public string GetUsersId()
    {
        string customHeaderValue = Request.Headers["X-UsersId-Header"];
        return customHeaderValue;
    }

    /// <summary>
    /// Lấy RolesId khi truy cập vào controller
    /// </summary>
    /// <returns></returns>
    [NonAction]
    public string GetUsersRoles()
    {
        string customHeaderValue = Request.Headers["X-RolesId-Header"];
        return customHeaderValue;
    }

    /// <summary>
    /// Lấy RolesId khi truy cập vào controller
    /// </summary>
    /// <returns></returns>
    [NonAction]
    protected string GetServerIp()
    {
        return HttpContext.GetServerIp();
    }
} 