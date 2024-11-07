using APIs.Helper;
using CommonServices;
using Dapper;
using DapperServices;
using Jwt;

namespace APIs.Logic
{
    /// <summary>
    /// Xử lý đăng nhập
    /// </summary>
    public class LoginHandler : ILoginHandler
    {
        private readonly ILogger<LoginHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dapperUnitOfWork"></param>
        public LoginHandler(ILogger<LoginHandler> logger, IDapperUnitOfWork dapperUnitOfWork)
        {
            _logger = logger;
            _dapperUnitOfWork = dapperUnitOfWork;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <returns></returns>
        public async Task<Response<UserInfo>> Login(LoginInfo model, string IpConnect, string controller)
        {
            Response<UserInfo> result = null;
            try
            {
                DynamicParameters param = new DynamicParameters();
                model.UsersPassword = AesEncryption.Encrypt(model.UsersPassword);
                param.Add("@UsersName", model.UsersName);
                param.Add("@UsersPassword", model.UsersPassword);
                var res = await _dapperUnitOfWork.GetRepository().ExecuteData<UserInfo>("GetUserInfo", param, null);
                var data = res.ToArray();
                if(data.Length > 0)
                {
                    var id = GetUserId(model);
                    NeedLogin needLogin = new NeedLogin();
                    needLogin.UsersId = Guid.Parse(id.ToString());
                    TryAgain(needLogin, IpConnect, controller);

                    BaseUsers baseUsers = new BaseUsers();
                    baseUsers.UsersId = needLogin.UsersId;
                    var language = FindDuplicateUsersInfo.GetLanguageOfUser(baseUsers);

                    TokenServices token = new TokenServices();
                    var _token = token.GenerateToken(model.UsersName);
                    result=  GetStatusFunction.HandleCheckResponseWithT<UserInfo>(StatusResult.EDIT_SUCCESS_CODE, language , null);

                }
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpConnect);
                result = null;
            }
            return result;
        }


        /// <summary>
        /// Relogin tài khoản, sử dụng IpClient để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        public async Task<int> TryAgain(NeedLogin model, string IpClient, string controller)
        {
            BaseUsers baseUsers = new BaseUsers();
            baseUsers.UsersId = model.UsersId;
            var language = FindDuplicateUsersInfo.GetLanguageOfUser(baseUsers);
            try
            {
                var param = CreateParam.InitializeParameters(model);
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("TryAgain", param, null);
                return 1;
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpClient);
                return 0;
            }
        }

        /// <summary>
        /// Relogin tài khoản, sử dụng IpClient để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        public async Task<string> GetUserId(LoginInfo model)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                var data = await _dapperUnitOfWork.GetRepository().ExecuteToDataTable("GetUserId", param);
                if(data.Rows.Count > 0)
                {
                    return data.Rows[0]["UsersId"].ToString();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
