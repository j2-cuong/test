#pragma warning disable

using APIs.Helper;
using CommonServices;
using Dapper;
using DapperServices;

namespace APIs.Logic
{
    public class FindDataHandler : IFindDataHandler
    {
        private readonly ILogger<FindDataHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        BaseUsers baseUsers = new BaseUsers();

        public FindDataHandler(ILogger<FindDataHandler> logger, IDapperUnitOfWork dapperUnitOfWork)
        {
            _logger = logger;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        /// <summary>
        /// Tìm tất cả có phân trang, tableName dạng dynamic do người sử dụng truyền vào, IpConnect để ghi log
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public async Task<ResponseTable<T>> FindAll<T>(FindAll model, string IpConnect, string tableName, string controller, string usersId, string language)
        {
            ResponseTable<T> result = null;
            try
            {
                DynamicParameters param = new DynamicParameters();
                var columns = CreateSelectQuery.GenerateSelectQuery<T>("UsersPassword");
                param.Add("@TableName", tableName);
                param.Add("@Columns", columns);
                param.Add("@PageSize", model.PageSize == 0 ? 10 : model.PageSize);
                param.Add("@PageIndex", model.PageIndex == 0 ? 1 : model.PageIndex);

                var res = await _dapperUnitOfWork.GetRepository().ExecuteData<T>("FindAll", param, null);
                var data = res.ToArray();
                if (data.Length > 0)
                {
                    result = GetStatusFunction.HandleCheckResponseWithTable<T>(StatusResult.GETDATA_SUCCESS_CODE, language, data);
                }
                else
                {
                    result = GetStatusFunction.HandleCheckResponseWithTable<T>(StatusResult.ERROR_NOTFOUND_CODE, language, null);
                }
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpConnect);
                result = GetStatusFunction.HandleCheckResponseWithTable<T>(StatusResult.ERROR_FAIL_CODE, language, null);
            }
            return result;
        }

        /// <summary>
        /// Tìm theo Id, tableName dạng dynamic do người sử dụng truyền vào, IpConnect để ghi log
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public async Task<Response<T>> FindById<T>(FindById model, string IpConnect, string tableName, string controller, string usersId, string language)
        {
            Response<T> result = null;
            try
            {
                DynamicParameters param = new DynamicParameters();
                var columns = CreateSelectQuery.GenerateSelectQuery<T>("UsersPassword");
                param.Add("@TableName", tableName);
                param.Add("@Columns", columns);
                param.Add("@Id", model.IdSearch);
                var res = await _dapperUnitOfWork.GetRepository().ExecuteData<T>("FindByID", param, null);
                var data = res.ToArray();
                if (data.Length > 0)
                {
                    result = GetStatusFunction.HandleCheckResponseWithT<T>(StatusResult.GETDATA_SUCCESS_CODE, language, data);
                }
                else
                {
                    result = GetStatusFunction.HandleCheckResponseWithT<T>(StatusResult.ERROR_NOTFOUND_CODE, language, data);
                }
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpConnect);
                result = GetStatusFunction.HandleCheckResponseWithT<T>(StatusResult.ERROR_FAIL_CODE, language, null );
            }
            return result;
        }
    }
}
