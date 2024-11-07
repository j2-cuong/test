

namespace APIs.Logic
{
    /// <summary>
    /// Bộ lọc trước khi truy cập vào router
    /// </summary>
    public interface IPermissionHandler
    {
        /// <summary>
        /// Check quyền truy cập router
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        Task<bool> HasPermission(Guid userId, string route);

        /// <summary>
        /// Check có phải đăng nhập lại hay không
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> NeedLogin(Guid userId);
    }
}
