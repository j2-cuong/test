#pragma warning disable

using CommonServices;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace APIs.Logic
{
    public class LogsHandler : ILogsHandler
    {
        private readonly IWebHostEnvironment _env;
        private const string LOG_PATTERN = @"\*------ StartRequest ------\*(.*?)\*------ EndRequest ------\*";

        public LogsHandler(IWebHostEnvironment env)
        {
            _env = env;
        }

        /// <summary>
        /// Đọc logs
        /// </summary>
        /// <returns></returns>
        public async Task<string> ViewLogs(string url)
        {
            var date = DateTime.Now;
            var logFile = Path.Combine("C:", "Logs", $"APIs_{date:yyyy-MM-dd}.txt");

            if (!File.Exists(logFile))
            {
                return "Chưa có logs trong ngày";
            }

            var content = await File.ReadAllTextAsync(logFile);
            var logEntries = ParseLogEntries(content);

            var htmlFolder = Path.Combine(_env.WebRootPath, "Logs", "Html");
            Directory.CreateDirectory(htmlFolder);

            // Xóa file cũ nếu vượt quá 30 file
            var htmlFiles = Directory.GetFiles(htmlFolder, "*.html")
                                    .Select(f => new FileInfo(f))
                                    .OrderByDescending(f => f.CreationTime)
                                    .ToList();

            if (htmlFiles.Count > 30)
            {
                foreach (var file in htmlFiles.Skip(30))
                {
                    try
                    {
                        File.Delete(file.FullName);
                    }
                    catch
                    {
                        // Bỏ qua nếu không xóa được file
                        continue;
                    }
                }
            }

            var htmlFile = Path.Combine(htmlFolder, $"{date:yyyy-MM-dd}.html");
            var html = GenerateHtml(logEntries);
            await File.WriteAllTextAsync(htmlFile, html);

            return url + Path.GetRelativePath(_env.WebRootPath, htmlFile).Replace("\\", "/");
        }

        private List<LogEntry> ParseLogEntries(string content)
        {
            var entries = new List<LogEntry>();
            var matches = Regex.Matches(content, LOG_PATTERN, RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                var entry = new LogEntry();
                var logContent = match.Groups[1].Value;
                
                // Tách các phần thông tin bằng regex patterns cụ thể
                var controllerMatch = Regex.Match(logContent, @"Controller\s*:\s*([^\r\n]+)");
                var messageMatch = Regex.Match(logContent, @"Thông báo\s*:\s*([^\r\n]+)");
                var timeMatch = Regex.Match(logContent, @"Thời gian\s*:\s*([^\r\n]+)");
                var ipMatch = Regex.Match(logContent, @"Địa chỉ IP\s*:\s*([^\r\n]+)");

                if (controllerMatch.Success)
                    entry.Controller = controllerMatch.Groups[1].Value.Trim();
                if (messageMatch.Success)
                    entry.Message = messageMatch.Groups[1].Value.Trim();
                if (timeMatch.Success)
                    entry.Timestamp = timeMatch.Groups[1].Value.Trim();
                if (ipMatch.Success)
                    entry.IpAddress = ipMatch.Groups[1].Value.Trim();

                if (entry.IsValid())
                    entries.Add(entry);
            }

            return entries;
        }

        private string GenerateHtml(List<LogEntry> entries)
        {
            var sb = new StringBuilder();
            sb.AppendLine(@"<!DOCTYPE html>
            <html lang='vi'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Logs</title>
                <style>
                    body { font-family: Arial; margin: 20px; background: #f4f4f4; }
                    table { width: 100%; border-collapse: collapse; }
                    th { background: #4CAF50; color: white; }
                    th, td { padding: 8px; border: 1px solid #ddd; text-align: left; }
                    tr:nth-child(even) { background: #f9f9f9; }
                </style>
            </head>
            <body>
                <h2>Logs</h2>
                <table>
                    <thead>
                        <tr>
                            <th>Controller</th>
                            <th>Thông báo</th>
                            <th>Thời gian</th>
                            <th>Địa chỉ IP</th>
                        </tr>
                    </thead>
            <tbody>");

            foreach (var entry in entries)
            {
                sb.AppendLine($@"<tr>
                    <td>{HttpUtility.HtmlEncode(entry.Controller)}</td>
                    <td>{HttpUtility.HtmlEncode(entry.Message)}</td>
                    <td>{HttpUtility.HtmlEncode(entry.Timestamp)}</td>
                    <td>{HttpUtility.HtmlEncode(entry.IpAddress)}</td>
                </tr>");
            }

            sb.AppendLine(@"</tbody></table></body></html>");
            return sb.ToString();
        }

        private class LogEntry
        {
            public string Controller { get; set; }
            public string Message { get; set; }
            public string Timestamp { get; set; }
            public string IpAddress { get; set; }

            public bool IsValid() =>
                !string.IsNullOrEmpty(Controller) &&
                !string.IsNullOrEmpty(Message) &&
                !string.IsNullOrEmpty(Timestamp) &&
                !string.IsNullOrEmpty(IpAddress);
        }
    }
}
