using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace DapperServices
{
    public static class DataProcessServiceCollection
    {
        private static string appConnection = $@"Server = 123.30.50.177,1409\SQLPublic; Database = StudentsManagement; User Id = sa; Password = #fcJl&4O;Encrypt=True;TrustServerCertificate=True; Min Pool Size=5;Max Pool Size=100;Connection Timeout=30";

        public static void AddDataProcessServices(this IServiceCollection services)
        {
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(appConnection));
            services.AddScoped<IDapperUnitOfWork, DapperUnitOfWork>();
        }

        public static string GetConnect()
        {
            return appConnection;
        }
    }
}
