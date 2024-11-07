#pragma warning disable

using DapperServices;
using Dapper;
using System.Data.SqlClient;
using System.Reflection;

namespace APIs.Logic
{
    public class PermissionHandler : IPermissionHandler
    {
        private readonly ILogger<PermissionHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        public PermissionHandler(ILogger<PermissionHandler> logger, IDapperUnitOfWork dapperUnitOfWork)
        {
            _logger = logger;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        public async Task<bool> HasPermission(Guid userId, string route)
        {
            var permissions = await GetUserPermissions(userId);
            return permissions.Any(p => p.Equals(route, StringComparison.OrdinalIgnoreCase));
        }

        private async Task<List<string>> GetUserPermissions(Guid userId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", userId);
            var routers = await _dapperUnitOfWork.GetRepository().ExecuteData<string>("FindAll", param, null);
            return routers.ToList();
        }

        public async Task<bool> NeedLogin(Guid userId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UsersId", userId);
            var query = $@"
                            SELECT UsersId FROM Users 
                            WHERE UsersId = @UsersId AND UserChangeInfo = 1";
            var res = _dapperUnitOfWork.GetRepository().ExecuteToTable(query, param);
            if(res.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
