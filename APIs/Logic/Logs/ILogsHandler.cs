#pragma warning disable
using CommonServices;

namespace APIs.Logic
{
    public interface ILogsHandler
    {
        /// <summary>
        /// Đọc logs
        /// </summary>
        /// <returns></returns>
        Task<string> ViewLogs(string url);
    }
}
