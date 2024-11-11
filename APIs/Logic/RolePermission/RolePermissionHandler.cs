#pragma warning disable

using APIs.Helper;
using CommonServices;
using DapperServices;

namespace APIs.Logic
{
    public class RolePermissionHandler : IRolePermissionHandler
    {
        private readonly ILogger<RolePermissionHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        BaseUsers baseUsers = new BaseUsers();
        BaseRolePermission baseStatus = new BaseRolePermission();

        public RolePermissionHandler(ILogger<RolePermissionHandler> logger, IDapperUnitOfWork dapperUnitOfWork)
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
        public async Task<Response<bool>> CreateRolePermission(CreateRolePermission model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                param.Add("@CreateBy", usersId);
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("CreateRolePermission", param, null);
                ConvertLog.WriteLogAddRolePermission(_logger, usersId,model.UsersGroupName, model.APIsEndpointUrl, model.isAccess);
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
        public async Task<Response<bool>> UpdateRolePermission(UpdateRolePermission model, string IpConnect, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                param.Add("@UpdateBy", usersId);
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("UpdateRolePermission", param, null);
                ConvertLog.WriteLogAddRolePermission(_logger, usersId, model.UsersGroupName, model.APIsEndpointUrl, model.isAccess);
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
        public async Task<Response<bool>> DeleteRolePermission(DeleteRolePermission model, string IpConnect, string controller, string usersId, string language, InfoOfRolePermission oldData)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("DeleteRolePermission", param, null);
                ConvertLog.WriteLogAddRolePermission(_logger, usersId, oldData.UsersGroupName, oldData.APIsEndpointUrl, oldData.isAccess);
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
