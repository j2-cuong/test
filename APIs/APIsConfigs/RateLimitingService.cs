#pragma warning disable

using System.Threading.RateLimiting;

namespace APIs.APIsConfigs
{
    public static class RateLimitingService
    {
        /// <summary>
        /// Giới hạn số lượng request trên 1 phút
        /// </summary>
        /// <param name="services"></param>
        public static void AddRateLimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: context.User.Identity?.Name ?? context.Request.Headers.Host.ToString(),
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = 50,
                            QueueLimit = 0,
                            Window = TimeSpan.FromMinutes(1)
                        }));

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = 429;
                    await context.HttpContext.Response.WriteAsJsonAsync(new
                    {
                        Status = 429,
                        Message = "Too many requests. Please try again later."
                    });
                };
            });
        }
    }
}
