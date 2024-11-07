#pragma warning disable

using APIs.Helper;
using CommonServices;
using DapperServices;

namespace APIs.Logic
{
    public class RoomsStatusHandler : IRoomsStatusHandler
    {
        private readonly ILogger<RoomsStatusHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        BaseUsers baseUsers = new BaseUsers();
        BaseRoomsStatus baseStatus = new BaseRoomsStatus();

        public RoomsStatusHandler(ILogger<RoomsStatusHandler> logger, IDapperUnitOfWork dapperUnitOfWork)
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
        public async Task<Response<bool>> CreateStatus(CreateRoomsStatus model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                var paramCheck = new CheckRoomsStatusDataProperties
                {
                    Id = model.RoomsStatusId,
                    RoomsStatusCode = model.RoomsStatusCode,
                    RoomsStatusName = model.RoomsStatusName,
                    RoomsStatusColor = model.RoomsStatusColor
                };
                int flg = FindDuplicateRoomsStatusInfo.FindDuplicateRoomsStatus(paramCheck);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("CreateRoomsStatus", param, null);
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
        public async Task<Response<bool>> UpdateStatus(UpdateRoomsStatus model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                var paramCheck = new CheckRoomsStatusDataProperties
                {
                    Id = model.RoomsStatusId,
                    RoomsStatusCode = model.RoomsStatusCode,
                    RoomsStatusName = model.RoomsStatusName,
                    RoomsStatusColor = model.RoomsStatusColor
                };
                int flg = FindDuplicateRoomsStatusInfo.FindDuplicateRoomsStatus(paramCheck);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }

                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("UpdateRoomsStatus", param, null);
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
        public async Task<Response<bool>> DeleteStatus(DeleteRoomsStatus model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                int flg = FindDuplicateRoomsStatusInfo.FindRecordIsUsed(baseStatus);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("DeleteRoomsStatus", param, null);
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
