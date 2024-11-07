
using Microsoft.Extensions.Logging;

namespace CommonServices
{
    public class ConvertLog
    {
        /// <summary>
        /// Ghi log
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="exception"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static void WriteLog(ILogger logger, string controller, string exception, string ipAddress)
        {
            var date = DateTime.Now;
            var log =
                "\r\r" +
                $@"*------ StartRequest ------*" + "\r\r" +
                $@"      Controller : {controller}      " + "\r" +
                $@"      Thông báo  : {exception}      " + "\r" +
                $@"      Thời gian  : {date.ToString("dd-MM-yyyy HH:mm:ss")}" + "\r" +
                $@"      Địa chỉ IP : {ipAddress}" + "\r\r" +
                $@"*------ EndRequest ------*" + 
                "\r\r";
            logger.LogCritical(log);
        }
    }
}
