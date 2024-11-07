using System.Text.Json.Serialization;

namespace CommonServices
{
    /// <summary>
    /// kiểu dữ liệu trả về chỉ có status và thông báo
    /// </summary>
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public Response(int status, string? message = null)
        {
            Status = status;
            Message = message ?? string.Empty;
        }
    }

    /// <summary>
    /// kiểu dữ liệu trả về  có status, thông báo và dữ liệu kiểu T trả về
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : Response
    {
        public T?[] Data { get; set; }

        [JsonConstructor]
        public Response(
            int status, string? message = null, T?[] data = default)
            : base(status, message)
        {
            Data = data;
        }
    }

    /// <summary>
    /// kiểu dữ liệu trả về  có status, thông báo và dữ liệu dạng bảng T trả về
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseTable<T> : Response<T>
    {
        public int TotalRecords { get; set; }
        public ResponseTable(
            int status, string? message = null, T?[] data = default, int totalRecords = 0)
            : base(status, message, data)
        {
            TotalRecords = totalRecords;
        }
    }
}
