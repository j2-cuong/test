#pragma warning disable

using APIs.Logic;
using CommonServices;
using Dapper;
using System.Data.SqlClient;
using static APIs.Middleware.ServiceCollection;

namespace APIs.Helper
{
    public static class FindDuplicateUsersGroupInfo
    {
        private static string _connect = ConnectionStringProvider.PortalConnection;

        /// <summary>
        /// Tìm kiếm các giá trị trùng lặp trong bảng Status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int FindDuplicateUsersGroup(CheckUsersGroupDataProperties model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                {
                    var fieldsToCheck = new Dictionary<string, (string value, int errorCode)>
                    {
                        { "UsersGroupCode", (model.UsersGroupCode, StatusResult.ERROR_DUPPLICATE_USERGROUP_CODE) },
                        { "UsersGroupName", (model.UsersGroupName, StatusResult.ERROR_DUPPLICATE_USERGROUP_NAME_CODE) }
                    };
                    foreach (var field in fieldsToCheck)
                    {
                        if (string.IsNullOrEmpty(field.Value.value)) continue;
                        var query = $@"
                            SELECT COUNT(1) FROM [UsersGroup] 
                            WHERE UsersGroupId != @StatusId AND {field.Key} = @Value";
                        var count = connection.ExecuteScalarAsync<int>(
                            query,
                            new { StatusId = model.Id, Value = field.Value.value }
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

        /// <summary>
        /// Tìm kiếm các giá trị của status đang được sử dụng trong Rooms
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int FindRecordIsUsed(BaseUsersGroup model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                { 
                    var query = $@"
                            SELECT COUNT(1) FROM [RolePermission] 
                            WHERE UsersGroupId = @StatusId";
                    var id = model.UsersGroupId;
                    param.Add("@StatusId", id);
                    var count = connection.ExecuteScalarAsync<int>(query,param);
                    if(count.Result == 0)
                    {
                        query = $@"
                            SELECT COUNT(1) FROM [UsersGroupMembership] 
                            WHERE UsersGroupId = @StatusId";
                        id = model.UsersGroupId;
                        param.Add("@StatusId", id);
                        count = connection.ExecuteScalarAsync<int>(query, param);
                    }
                    if (count.Result > 0) return StatusResult.ERROR_IS_USING_USERGROUP_CODE;
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
