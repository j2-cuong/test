
using APIs.Logic;
using DapperServices;
using System.Data.SqlClient;
using System.Data;
using CommonServices;


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
            var connectionString = configuration.GetConnectionString("PortalConnection");
            ConnectionStringProvider.Initialize(connectionString);
            services.AddHttpContextAccessor();
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(AesEncryption.Decrypt(connectionString)));
            services.AddScoped<IDapperUnitOfWork, DapperUnitOfWork>();
            services.AddScoped<IPermissionHandler, PermissionHandler>();
            services.AddScoped<IUsersHandler, UsersHandler>();
            services.AddScoped<IRoomsStatusHandler, RoomsStatusHandler>();
            services.AddScoped<IFindDataHandler, FindDataHandler>();
            services.AddScoped<ILogsHandler, LogsHandler>();
            services.AddScoped<ILoginHandler, LoginHandler>();
            services.AddScoped<IAPIsEndpointHandler, APIsEndpointHandler>();
            services.AddScoped<IUsersGroupHandler, UsersGroupHandler>();
            services.AddScoped<IGetRouterHandler, GetRouterHandler>();
            services.AddScoped<IPaymentStatusHandler, PaymentStatusHandler>();
            services.AddScoped<IUsersGroupMembershipHandler, UsersGroupMembershipHandler>();
        }

        public static class ConnectionStringProvider
        {
            public static string PortalConnection;
            public static void Initialize(string connectionString)
            {
                PortalConnection = AesEncryption.Decrypt(connectionString);
            }
        }
    }
}
