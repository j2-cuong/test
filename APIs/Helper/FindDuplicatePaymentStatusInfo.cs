using APIs.Logic;
using CommonServices;
using Dapper;
using DapperServices;
using System.Data.SqlClient;

namespace APIs.Helper
{
    public static class FindDuplicatePaymentStatusInfo
    {
        private static string _connect = DataProcessServiceCollection.GetConnect();

        /// <summary>
        /// Tìm kiếm các giá trị trùng lặp trong bảng Status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int FindDuplicatePaymentStatus(CheckPaymentStatusDataProperties model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                {
                    var fieldsToCheck = new Dictionary<string, (string value, int errorCode)>
                    {
                        { "PaymentStatusCode", (model.PaymentStatusCode, StatusResult.ERROR_DUPPLICATE_PAYMENTSTATUS_CODE_CODE) },
                        { "PaymentStatusName", (model.PaymentStatusName, StatusResult.ERROR_DUPPLICATE_PAYMENTSTATUS_NAME_CODE) },
                        { "PaymentStatusColor", (model.PaymentStatusColor, StatusResult.ERROR_DUPPLICATE_PAYMENTSTATUS_COLOR_CODE) },
                    };
                    foreach (var field in fieldsToCheck)
                    {
                        if (string.IsNullOrEmpty(field.Value.value)) continue;
                        var query = $@"
                            SELECT COUNT(1) FROM [PaymentStatus] 
                            WHERE PaymentStatusId != @PaymentStatusId AND {field.Key} = @Value";
                        var count = connection.ExecuteScalarAsync<int>(
                            query,
                            new { PaymentStatusId = model.PaymentStatusId, Value = field.Value.value }
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
        public static int FindRecordIsUsed(BasePaymentStatus model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                {
                    //Check sửa bảng liên kết

                    var query = $@"
                            SELECT COUNT(1) FROM [Rooms] 
                            WHERE PaymentStatusId = @PaymentStatusId";
                    var id = model.PaymentStatusId;
                    param.Add("@PaymentStatusId", id);
                    var count = connection.ExecuteScalarAsync<int>(query, param);
                    if (count.Result > 0) return StatusResult.ERROR_IS_USING_PAYMENTSTATUS_CODE;
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
