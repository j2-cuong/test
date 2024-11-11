#pragma warning disable

using APIs.Logic;
using CommonServices;
using Dapper;
using System.Data.SqlClient;
using static APIs.Middleware.ServiceCollection;

namespace APIs.Helper
{
    public static class FindDuplicateAPIsEndpointInfo
    {
        private static string _connect = ConnectionStringProvider.PortalConnection;

        /// <summary>
        /// Tìm kiếm các giá trị trùng lặp trong bảng Status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int FindDuplicateAPIsEndpoint(CheckAPIsEndpointDataProperties model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                {
                    var fieldsToCheck = new Dictionary<string, (string value, int errorCode)>
                    {
                        { "APIsEndpointUrl", (model.APIsEndpointCode, StatusResult.ERROR_DUPPLICATE_APISENDPOINT_URL_CODE) },
                        { "APIsEndpointName", (model.APIsEndpointName, StatusResult.ERROR_DUPPLICATE_APISENDPOINT_NAME_CODE) }
                    };
                    foreach (var field in fieldsToCheck)
                    {
                        if (string.IsNullOrEmpty(field.Value.value)) continue;
                        var query = $@"
                            SELECT COUNT(1) FROM [APIsEndpoint] 
                            WHERE APIsEndpointId != @StatusId AND {field.Key} = @Value";
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
        public static int FindRecordIsUsed(BaseAPIsEndpoint model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                { 
                    var query = $@"
                            SELECT COUNT(1) FROM [RolePermission] 
                            WHERE APIsEndpointId = @StatusId";
                    var id = model.APIsEndpointId;
                    param.Add("@StatusId", id);
                    var count = connection.ExecuteScalarAsync<int>(query,param);
                    if (count.Result > 0) return StatusResult.ERROR_DUPPLICATE_APISENDPOINT_NAME_CODE;
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
