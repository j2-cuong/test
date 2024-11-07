using APIs.Helper;
using CommonServices;
using DapperServices;

namespace APIs.Logic
{
    /// <summary>
    /// Trạng thái thanh toán
    /// </summary>
    public class PaymentStatusHandler : IPaymentStatusHandler
    {
        private readonly ILogger<PaymentStatusHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        BaseUsers baseUsers = new BaseUsers();
        BasePaymentStatus basePaymentStatus = new BasePaymentStatus();

        /// <summary>
        /// tạo contructor trạng thái thanh toán
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dapperUnitOfWork"></param>
        public PaymentStatusHandler(ILogger<PaymentStatusHandler> logger, IDapperUnitOfWork dapperUnitOfWork)
        {
            _logger = logger;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        /// <summary>
        /// Tạo danh mục trạng thái thanh toán, sử dụng IpConnect để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <param name="controller"></param>
        /// <param name="usersId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Response<bool>> CreatePaymentStatus(CreatePaymentStatus model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                var paramCheck = new CheckPaymentStatusDataProperties
                {
                    PaymentStatusId = model.PaymentStatusId,
                    PaymentStatusCode = model.PaymentStatusCode,
                    PaymentStatusName = model.PaymentStatusName,
                    PaymentStatusColor = model.PaymentStatusColor
                };
                int flg = FindDuplicatePaymentStatusInfo.FindDuplicatePaymentStatus(paramCheck);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("CreatePaymentStatus", param, null);
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
        /// <param name="controller"></param>
        /// <param name="usersId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Response<bool>> UpdatePaymentStatus(UpdatePaymentStatus model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                var paramCheck = new CheckPaymentStatusDataProperties
                {
                    PaymentStatusId = model.PaymentStatusId,
                    PaymentStatusCode = model.PaymentStatusCode,
                    PaymentStatusName = model.PaymentStatusName,
                    PaymentStatusColor = model.PaymentStatusColor
                };
                int flg = FindDuplicatePaymentStatusInfo.FindDuplicatePaymentStatus(paramCheck);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }

                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("UpdatePaymentStatus", param, null);
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
        /// <param name="controller"></param>
        /// <param name="usersId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Response<bool>> DeletePaymentStatus(DeletePaymentStatus model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                int flg = FindDuplicatePaymentStatusInfo.FindRecordIsUsed(basePaymentStatus);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("DeletePaymentStatus", param, null);
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
