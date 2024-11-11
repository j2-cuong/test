#pragma warning disable

using APIs.Logic;
using CommonServices;
using Dapper;
using System.Data.SqlClient;
using static APIs.Middleware.ServiceCollection;

namespace APIs.Helper
{
    public static class FindDuplicateUsersGroupMembershipInfo
    {
        private static string _connect = ConnectionStringProvider.PortalConnection;

        /// <summary>
        /// Tìm kiếm các giá trị trùng lặp trong bảng Status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int FindDuplicateUsersGroupMembership(CheckUsersGroupMembershipDataProperties model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                {
                    var fieldsToCheck = new Dictionary<string, (string value, int errorCode)>
                    {
                        { "UsersId", (model.UsersId.ToString(), StatusResult.ERROR_DUPLICATE_USERID_BE_CODE) }
                    };
                    foreach (var field in fieldsToCheck)
                    {
                        if (string.IsNullOrEmpty(field.Value.value)) continue;
                        var query = $@"
                            SELECT COUNT(1) FROM [UsersGroupMembership] 
                            WHERE UsersId != @StatusId AND {field.Key} = @Value";
                        var count = connection.ExecuteScalarAsync<int>(
                            query,
                            new { StatusId = model.UsersId, Value = field.Value.value }
                        );
                        if (count.Result > 0) return field.Value.errorCode;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                return StatusResult.ERROR_SERVER_CODE;
            }
        }
    }
}
