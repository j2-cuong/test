#pragma warning disable

using APIs.Logic;
using CommonServices;
using Dapper;
using DapperServices;
using System.Data.SqlClient;

namespace APIs.Helper
{
    public static class FindDuplicateUsersInfo
    {
        private static string _connect = DataProcessServiceCollection.GetConnect();

        /// <summary>
        /// Tìm kiếm các giá trị trùng lặp trong bảng Users
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int FindUplicateInfoOfUsers(CheckUsersDataProperties model)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                {
                    var fieldsToCheck = new Dictionary<string, (string value, int errorCode)>
                    {
                        { "UsersName", (model.UsersName, StatusResult.ERROR_DUPPLICATE_USER_NAME_CODE) },
                        { "Email", (model.Email, StatusResult.ERROR_DUPPLICATE_EMAIL_CODE) },
                        { "NumberPhone", (model.NumberPhone, StatusResult.ERROR_DUPPLICATE_PHONE_CODE) },
                        { "StateIdCard", (model.StateIdCard, StatusResult.ERROR_DUPPLICATE_STATEIDCARD_CODE) }
                    };

                    foreach (var field in fieldsToCheck)
                    {
                        if (string.IsNullOrEmpty(field.Value.value)) continue;

                        var query = $@"
                            SELECT COUNT(1) FROM Users 
                            WHERE UsersId != @UsersId AND {field.Key} = @Value";

                        var count = connection.ExecuteScalarAsync<int>(
                            query,
                            new { UsersId = model.Id, Value = field.Value.value }
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
        /// Lấy ngôn ngữ của Users được setup trong hệ thống
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GetLanguageOfUser(BaseUsers model)
        {
            try
            {
                var res = string.Empty;
                DynamicParameters param = new DynamicParameters();
                using (SqlConnection connection = new SqlConnection(_connect))
                {
                    param.Add("@UsersId", model.UsersId);

                    var query = $@"
                            SELECT UsersLanguage FROM Users 
                            WHERE UsersId = @UsersId";
                    res = connection.QuerySingleOrDefault<string>(query, param);
                    return string.IsNullOrWhiteSpace(res) == true ? "EN" : res;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                return "VN";
            }
        }
    }
}
