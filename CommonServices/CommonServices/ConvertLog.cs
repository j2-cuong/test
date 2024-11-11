
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

        public static void WriteLogAddPermission(ILogger logger, string createBy, string userName, string usersGroupName)
        {
            var date = DateTime.Now;
            var log =
                "\r\r" +
                $@"*------ AddRequest ------*" + "\r\r" +
                $@"      CreateBy : {createBy}      " + "\r" +
                $@"      Thông báo  : Thêm người dùng tên: {userName} vào nhóm quyền {usersGroupName} " + "\r" +
                $@"      Thời gian  : {date.ToString("dd-MM-yyyy HH:mm:ss")}" + "\r" +
                $@"*------ CommitRequest ------*" +
                "\r\r";
            logger.LogCritical(log);
        }

        public static void WriteLogEditPermission(ILogger logger, string updateBy, string userName, string usersGroupName)
        {
            var date = DateTime.Now;
            var log =
                "\r\r" +
                $@"*------ AddRequest ------*" + "\r\r" +
                $@"      updateBy : {updateBy}      " + "\r" +
                $@"      Thông báo  : Sửa người dùng tên: {userName} vào nhóm quyền {usersGroupName} " + "\r" +
                $@"      Thời gian  : {date.ToString("dd-MM-yyyy HH:mm:ss")}" + "\r" +
                $@"*------ CommitRequest ------*" +
                "\r\r";
            logger.LogCritical(log);
        }

        public static void WriteLogDeletePermission(ILogger logger, string usersId, string userName, string usersGroupName)
        {
            var date = DateTime.Now;
            var log =
                "\r\r" +
                $@"*------ AddRequest ------*" + "\r\r" +
                $@"      DeleteBy : {usersId}      " + "\r" +
                $@"      Thông báo  : Xóa người dùng tên: {userName} khỏi nhóm quyền {usersGroupName} " + "\r" +
                $@"      Thời gian  : {date.ToString("dd-MM-yyyy HH:mm:ss")}" + "\r" +
                $@"*------ CommitRequest ------*" +
                "\r\r";
            logger.LogCritical(log);
        }

        public static void WriteLogAddRolePermission(ILogger logger, string createBy, string usersGroupName, string apisEndpointUrl, bool isAccess)
        {
            var date = DateTime.Now;
            var log =
                "\r\r" +
                $@"*------ AddRequest ------*" + "\r\r" +
                $@"      Tạo bởi : {createBy}      " + "\r" +
                $@"      Thông báo  : Thực hiện phân quyền cho nhóm {usersGroupName}  " + "\r" +
                $@"      Với EndpointAPIs : {apisEndpointUrl}  " + "\r" +
                $@"      Giá trị : {isAccess}  " + "\r" +
                $@"      Thời gian  : {date.ToString("dd-MM-yyyy HH:mm:ss")}" + "\r" +
                $@"*------ CommitRequest ------*" +
                "\r\r";
            logger.LogCritical(log);
        }

        public static void WriteLogEditRolePermission(ILogger logger, string createBy, string usersGroupName, string apisEndpointUrl, bool isAccess)
        {
            var date = DateTime.Now;
            var log =
                "\r\r" +
                $@"*------ AddRequest ------*" + "\r\r" +
                $@"      Tạo bởi : {createBy}      " + "\r" +
                $@"      Thông báo  : Thực hiện phân quyền cho nhóm {usersGroupName}  " + "\r" +
                $@"      Với EndpointAPIs : {apisEndpointUrl}  " + "\r" +
                $@"      Giá trị : {isAccess}  " + "\r" +
                $@"      Thời gian  : {date.ToString("dd-MM-yyyy HH:mm:ss")}" + "\r" +
                $@"*------ CommitRequest ------*" +
                "\r\r";
            logger.LogCritical(log);
        }

        public static void WriteLogDeleteRolePermission(ILogger logger, string createBy, string usersGroupName, string apisEndpointUrl, bool isAccess)
        {
            var date = DateTime.Now;
            var log =
                "\r\r" +
                $@"*------ AddRequest ------*" + "\r\r" +
                $@"      Tạo bởi : {createBy}      " + "\r" +
                $@"      Thông báo  : Thực hiện xóa phân quyền cho nhóm {usersGroupName}  " + "\r" +
                $@"      Với EndpointAPIs : {apisEndpointUrl}  " + "\r" +
                $@"      Giá trị : {isAccess}  " + "\r" +
                $@"      Thời gian  : {date.ToString("dd-MM-yyyy HH:mm:ss")}" + "\r" +
                $@"*------ CommitRequest ------*" +
                "\r\r";
            logger.LogCritical(log);
        }
    }
}
