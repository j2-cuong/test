#pragma warning disable

using APIs.Helper;
using CommonServices;
using DapperServices;

namespace APIs.Logic
{
    public class UsersGroupMembershipHandler : IUsersGroupMembershipHandler
    {
        private readonly ILogger<UsersGroupMembershipHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        BaseUsers baseUsers = new BaseUsers();
        BaseUsersGroupMembership baseStatus = new BaseUsersGroupMembership();

        public UsersGroupMembershipHandler(ILogger<UsersGroupMembershipHandler> logger, IDapperUnitOfWork dapperUnitOfWork)
        {
            _logger = logger;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        /// <summary>
        /// Gán nhóm quyền cho người dùng, sử dụng IpConnect để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        public async Task<Response<bool>> CreateUsersGroupMembership(CreateUsersGroupMembership model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                param.Add("@CreateBy", usersId);
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("CreateUsersGroupMembership", param, null);
                ConvertLog.WriteLogAddPermission(_logger, usersId, model.FullName, model.UsersGroupName);
                return GetStatusFunction.HandleCheckResponse(StatusResult.CREATE_SUCCESS_CODE, language);
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpConnect);
                return GetStatusFunction.HandleCheckResponse(StatusResult.ERROR_FAIL_CODE, language);
            }
        }

        /// <summary>
        /// Chỉnh sửa nhóm quyền cho người dùng, sử dụng IpConnect để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        public async Task<Response<bool>> UpdateUsersGroupMembership(UpdateUsersGroupMembership model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                param.Add("@UpdateBy", usersId);
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("UpdateUsersGroupMembership", param, null);
                ConvertLog.WriteLogEditPermission(_logger, usersId, model.FullName, model.UsersGroupName);
                return GetStatusFunction.HandleCheckResponse(StatusResult.EDIT_SUCCESS_CODE, language);
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpConnect);
                return GetStatusFunction.HandleCheckResponseError(StatusResult.ERROR_FAIL_CODE, language);
            }
        }

        /// <summary>
        /// Xóa nhóm quyền cho người dùng, sử dụng IpConnect để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        public async Task<Response<bool>> DeleteUsersGroupMembership(DeleteUsersGroupMembership model, string IpConnect, string controller, string usersId, string language, InfoOfUsersGroupMembership oldData)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("DeleteUsersGroupMembership", param, null);
                ConvertLog.WriteLogDeletePermission(_logger, usersId, oldData.FullName, oldData.UsersGroupName);
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
