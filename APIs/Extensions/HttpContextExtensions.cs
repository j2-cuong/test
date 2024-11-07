#pragma warning disable

using System.Net;

public static class HttpContextExtensions
{
    /// <summary>
    /// Hàm xử lý IP từ header
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static string GetClientIpAddress(this HttpContext context)
    {
        try
        {
            // Kiểm tra null
            if (context?.Connection?.RemoteIpAddress == null)
                return "UnknownIP";

            // Kiểm tra các header phổ biến từ proxy
            var headers = new[]
            {
                "X-Forwarded-For",
                "X-Real-IP",
                "CF-Connecting-IP", // Cloudflare
                "HTTP_X_FORWARDED_FOR"
            };

            foreach (var header in headers)
            {
                var ip = context.Request.Headers[header].FirstOrDefault();
                if (!string.IsNullOrEmpty(ip))
                {
                    // Lấy IP đầu tiên nếu có nhiều IP (X-Forwarded-For có thể chứa nhiều IP)
                    return ip.Split(',')[0].Trim();
                }
            }

            // Xử lý IP localhost
            var remoteIp = context.Connection.RemoteIpAddress.ToString();
            if (remoteIp == "::1" || remoteIp == "127.0.0.1")
                return "DevIP";

            // Validate IP format
            if (IPAddress.TryParse(remoteIp, out _))
                return remoteIp;

            return "InvalidIP";
        }
        catch (Exception)
        {
            return "ErrorIP";
        }
    }

    /// <summary>
    /// Hàm xử lý url
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static string GetClientPath(this HttpContext context)
    {
        return context.Request.Path;
    }

    /// <summary>
    /// Hàm lấy IP trên IIS
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static string GetServerIp(this HttpContext context)
    {
        return context.Connection.RemoteIpAddress.ToString();
    }
} 