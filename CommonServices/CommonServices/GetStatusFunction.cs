#pragma warning disable

using static CommonServices.EnumsTableName;

namespace CommonServices
{
    public class GetStatusFunction
    {
        /// <summary>
        /// Lấy mã và thông báo lỗi
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static Response<bool> HandleCheckResponseError(int flag, string language)
        {
            var messageFieldName = $"{GetMessagePrefix(flag)}_MESS_{language.ToUpper()}";
            var messageField = typeof(StatusResult).GetField(messageFieldName);

            if (messageField == null )
            {
                return new Response<bool>(StatusResult.ERROR_FAIL_CODE, StatusResult.ERROR_FAIL_MESS_VN);
            }

            var message = messageField.GetValue(null)?.ToString();
            return new Response<bool>(flag, message);
        }

        /// <summary>
        /// Lấy mã và thông báo khác ngoài lỗi
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static Response<bool> HandleCheckResponse(int mode, string language)
        {
            var messageFieldName = $"{GetMessagePrefix(mode)}_MESS_{language.ToUpper()}";
            var messageField = typeof(StatusResult).GetField(messageFieldName);

            if (messageField == null)
            {
                return new Response<bool>(StatusResult.ERROR_FAIL_CODE, StatusResult.ERROR_FAIL_MESS_VN);
            }

            var message = messageField.GetValue(null)?.ToString();
            return new Response<bool>(mode, message);
        }
        
        /// <summary>
        /// Lấy mã và thông báo kèm dữ liệu kiểu T trả về
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mode"></param>
        /// <param name="language"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Response<T> HandleCheckResponseWithT<T>(int mode, string language, T?[] data)
        {
            var messageFieldName = $"{GetMessagePrefix(mode)}_MESS_{language.ToUpper()}";
            var messageField = typeof(StatusResult).GetField(messageFieldName);

            if (messageField == null)
            {
                var messageFieldNameErr = $"FAIL_CODE_MESS_{language.ToUpper()}";
                var messageFieldErr = typeof(StatusResult).GetField(messageFieldNameErr);
                return new Response<T>(StatusResult.ERROR_FAIL_CODE, messageFieldErr.GetValue(null)?.ToString(), data);
            }

            var message = messageField.GetValue(null)?.ToString();
            return new Response<T>(mode, message, data);
        }

        /// <summary>
        /// Lấy mã và thông báo kèm dữ liệu kiểu bảng trả về
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mode"></param>
        /// <param name="language"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponseTable<T> HandleCheckResponseWithTable<T>(int mode, string language, T?[] data)
        {
            var messageFieldName = $"{GetMessagePrefix(mode)}_MESS_{language.ToUpper()}";
            var messageField = typeof(StatusResult).GetField(messageFieldName);

            if (messageField == null)
            {
                var messageFieldNameErr = $"FAIL_CODE_MESS_{language.ToUpper()}";
                var messageFieldErr = typeof(StatusResult).GetField(messageFieldNameErr);
                return new ResponseTable<T>(StatusResult.ERROR_FAIL_CODE, messageFieldErr.GetValue(null)?.ToString(), data, 0);
            }

            var message = messageField.GetValue(null)?.ToString();
            return new ResponseTable<T>(mode, message, data, data.Length);
        }

        /// <summary>
        /// Lấy mã thông báo
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetMessagePrefix(int code)
        {
            var codeField = typeof(StatusResult)
                .GetFields()
                .FirstOrDefault(f => f.Name.EndsWith("_CODE") && (int)f.GetValue(null) == code);
            return codeField?.Name.Replace("_CODE", "") ?? "ERROR_FAIL"; ;
        }
    }
}
