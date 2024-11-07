#pragma warning disable

using APIs.Logic;
using DapperServices;
using APIs.Middleware;

namespace APIs.Middleware
{
    public static class ServiceCollection
    {
        /// <summary>
        /// Đăng ký các services khi khởi tạo
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void RegisterIoCs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddDataProcessServices();
            services.AddScoped<IPermissionHandler, PermissionHandler>();
            services.AddScoped<IUsersHandler, UsersHandler>();
            services.AddScoped<IRoomsStatusHandler, RoomsStatusHandler>();
            services.AddScoped<IFindDataHandler, FindDataHandler>();
            services.AddScoped<ILogsHandler, LogsHandler>();
            services.AddScoped<ILoginHandler, LoginHandler>();
            services.AddScoped<IPaymentStatusHandler, PaymentStatusHandler>();
        }
    }
}
