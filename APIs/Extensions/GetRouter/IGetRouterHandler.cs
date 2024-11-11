

namespace APIs.Logic
{
    /// <summary>
    /// Bộ lọc trước khi truy cập vào router
    /// </summary>
    public interface IGetRouterHandler
    {
        /// <summary>
        /// Tìm kiếm all router
        /// </summary>
        /// <returns></returns>
        Task<string> GetUrls();
    }
}
