#pragma warning disable

using APIs.Logic;
using CommonServices;
using Dapper;
using DapperServices;
using System.Data.SqlClient;
using static APIs.Middleware.ServiceCollection;

namespace APIs.Helper
{
    public static class FindDuplicateRoomsStatusInfo
    {
        private static string _connect = ConnectionStringProvider.PortalConnection;

        /// <summary>
        /// Tìm kiếm các giá trị trùng lặp trong bảng Status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int FindDuplicateRoomsStatus(CheckRoomsStatusDataProperties model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                {
                    var fieldsToCheck = new Dictionary<string, (string value, int errorCode)>
                    {
                        { "RoomsStatusCode", (model.RoomsStatusCode, StatusResult.ERROR_DUPPLICATE_ROOMS_STATUS_CODE_CODE) },
                        { "RoomsStatusName", (model.RoomsStatusName, StatusResult.ERROR_DUPPLICATE_ROOMS_STATUS_NAME_CODE) },
                        { "RoomsStatusColor", (model.RoomsStatusColor, StatusResult.ERROR_DUPPLICATE_ROOMS_STATUS_COLOR_CODE) },
                    };
                    foreach (var field in fieldsToCheck)
                    {
                        if (string.IsNullOrEmpty(field.Value.value)) continue;
                        var query = $@"
                            SELECT COUNT(1) FROM [RoomsStatus] 
                            WHERE RoomsStatusId != @StatusId AND {field.Key} = @Value";
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
        public static int FindRecordIsUsed(BaseRoomsStatus model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                { 
                    var query = $@"
                            SELECT COUNT(1) FROM [RoomsRooms] 
                            WHERE RoomsStatusId = @StatusId";
                    var id = model.RoomsStatusId;
                    param.Add("@StatusId", id);
                    var count = connection.ExecuteScalarAsync<int>(query,param);
                    if (count.Result > 0) return StatusResult.ERROR_IS_USING_ROOMS_STATUS_CODE;
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
