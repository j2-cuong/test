#pragma warning disable

using APIs.Helper;
using CommonServices;
using DapperServices;

namespace APIs.Logic
{
    public class UsersGroupHandler : IUsersGroupHandler
    {
        private readonly ILogger<UsersGroupHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        BaseUsers baseUsers = new BaseUsers();
        BaseUsersGroup baseStatus = new BaseUsersGroup();

        public UsersGroupHandler(ILogger<UsersGroupHandler> logger, IDapperUnitOfWork dapperUnitOfWork)
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
        public async Task<Response<bool>> CreateUsersGroup(CreateUsersGroup model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                var paramCheck = new CheckUsersGroupDataProperties
                {
                    Id = model.UsersGroupId,
                    UsersGroupCode = model.UsersGroupCode,
                    UsersGroupName = model.UsersGroupName
                };
                int flg = FindDuplicateUsersGroupInfo.FindDuplicateUsersGroup(paramCheck);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("CreateUsersGroup", param, null);
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
        public async Task<Response<bool>> UpdateUsersGroup(UpdateUsersGroup model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                var paramCheck = new CheckUsersGroupDataProperties
                {
                    Id = model.UsersGroupId,
                    UsersGroupCode = model.UsersGroupCode,
                    UsersGroupName = model.UsersGroupName
                };
                int flg = FindDuplicateUsersGroupInfo.FindDuplicateUsersGroup(paramCheck);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }

                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("UpdateUsersGroup", param, null);
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
        public async Task<Response<bool>> DeleteUsersGroup(DeleteUsersGroup model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                int flg = FindDuplicateUsersGroupInfo.FindRecordIsUsed(baseStatus);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language);
                    if (response != null) return response;
                }
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("DeleteUsersGroup", param, null);
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
