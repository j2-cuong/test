#pragma warning disable

using APIs.Helper;
using CommonServices;
using DapperServices;

namespace APIs.Logic
{
    public class APIsEndpointHandler : IAPIsEndpointHandler
    {
        private readonly ILogger<APIsEndpointHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        BaseUsers baseUsers = new BaseUsers();
        BaseAPIsEndpoint baseStatus = new BaseAPIsEndpoint();

        public APIsEndpointHandler(ILogger<APIsEndpointHandler> logger, IDapperUnitOfWork dapperUnitOfWork)
        {
            _logger = logger;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        /// <summary>
        /// Tạo danh mục trạng thái, sử dụng IpConnect để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        public async Task<Response<bool>> CreateAPIsEndpoint(CreateAPIsEndpoint model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                var paramCheck = new CheckAPIsEndpointDataProperties
                {
                    Id = model.APIsEndpointId,
                    APIsEndpointCode = model.APIsEndpointCode,
                    APIsEndpointName = model.APIsEndpointName
                };
                int flg = FindDuplicateAPIsEndpointInfo.FindDuplicateAPIsEndpoint(paramCheck);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("CreateAPIsEndpoint", param, null);
                return GetStatusFunction.HandleCheckResponse(StatusResult.CREATE_SUCCESS_CODE, language);
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpConnect);
                return GetStatusFunction.HandleCheckResponse(StatusResult.ERROR_FAIL_CODE, language);
            }
        }

        /// <summary>
        /// Chỉnh sửa danh mục trạng thái, sử dụng IpConnect để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        public async Task<Response<bool>> UpdateAPIsEndpoint(UpdateAPIsEndpoint model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                var paramCheck = new CheckAPIsEndpointDataProperties
                {
                    Id = model.APIsEndpointId,
                    APIsEndpointCode = model.APIsEndpointCode,
                    APIsEndpointName = model.APIsEndpointName
                };
                int flg = FindDuplicateAPIsEndpointInfo.FindDuplicateAPIsEndpoint(paramCheck);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }

                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("UpdateAPIsEndpoint", param, null);
                return GetStatusFunction.HandleCheckResponse(StatusResult.EDIT_SUCCESS_CODE, language);
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpConnect);
                return GetStatusFunction.HandleCheckResponseError(StatusResult.ERROR_FAIL_CODE, language);
            }
        }

        /// <summary>
        /// Xóa danh mục trạng thái, sử dụng IpConnect để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        public async Task<Response<bool>> DeleteAPIsEndpoint(DeleteAPIsEndpoint model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                int flg = FindDuplicateAPIsEndpointInfo.FindRecordIsUsed(baseStatus);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("DeleteAPIsEndpoint", param, null);
                return GetStatusFunction.HandleCheckResponse(StatusResult.DELETE_SUCCESS_CODE, language);
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpConnect);
                return GetStatusFunction.HandleCheckResponseError(StatusResult.ERROR_FAIL_CODE, language);
            }
        }
    }
}
