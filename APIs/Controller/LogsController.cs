using APIs.Logic;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class LogsController : BaseApiController
    {
        private readonly ILogsHandler _ILogsHandler;
        public LogsController
        (
            ILogsHandler ILogsHandler,
            IFindDataHandler IFindDataHandler
        )
        {
            _ILogsHandler = ILogsHandler;
        }

        /// <summary>
        /// Đọc logs
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> ViewLog()
        {
            return await _ILogsHandler.ViewLogs(GetServerIp());
        }
    }
}
