#pragma warning disable

using APIs.Helper;
using CommonServices;
using Dapper;
using DapperServices;
using Newtonsoft.Json.Linq;

namespace APIs.Logic
{
    public class UsersHandler : IUsersHandler
    {
        private readonly ILogger<UsersHandler> _logger;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;
        private readonly IWebHostEnvironment _env;
        BaseUsers baseUsers = new BaseUsers();

        public UsersHandler(ILogger<UsersHandler> logger, IDapperUnitOfWork dapperUnitOfWork, IWebHostEnvironment env)
        {
            _logger = logger;
            _dapperUnitOfWork = dapperUnitOfWork;
            _env = env;
        }

        /// <summary>
        /// Tạo tài khoản, sử dụng IpClient để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        public async Task<Response<bool>> CreateUsers(CreateUsersModel model, string IpClient, string controller, string urlServer, string usersId, string language)
        {
            byte[] imageContents;
            CreateUsers createUsers = model;
            try
            {
                if (model.ImagesFiles.FileName != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        var extension = Path.GetExtension(model.ImagesFiles.FileName);
                        DateTime time = DateTime.Now;
                        var fileName = time.ToString("ddMMyyyyHHmmss") + $@"_{(Guid.NewGuid()).ToString().Replace("-", "")}";
                        await model.ImagesFiles.CopyToAsync(memoryStream);
                        imageContents = memoryStream.ToArray();
                        string imagePath = GetImagesFolderPath("PathSave") + fileName + $@"{extension}";
                        var linkFile = GetImagesFolderPath("FolderName").Replace($@"\", $@"/");
                        using (var fileStream = new FileStream(imagePath, FileMode.Create))
                        {
                            fileStream.Write(imageContents, 0, imageContents.Length);
                        }
                        createUsers.AvatarFileSave = linkFile;
                        createUsers.AvatarPublicUrl = urlServer + linkFile;
                    }
                }
                var param = CreateParam.InitializeParameters(createUsers);
                var paramCheck = new CheckUsersDataProperties
                {
                    Id = model.UsersId,
                    UsersName = model.UsersName,
                    Email = model.Email,
                    NumberPhone = model.NumberPhone,
                    StateIdCard = model.StateIDCard
                };

                var check = CheckLanguageSupport.CheckLanguage(model.UsersLanguage);
                if (!string.IsNullOrEmpty(check))
                {
                    return new Response<bool>(StatusResult.ERROR_LANGUAGE_DONT_SUPPORT_CODE, StatusResult.ERROR_LANGUAGE_DONT_SUPPORT_MESS_EN);
                }

                int flg = FindDuplicateUsersInfo.FindUplicateInfoOfUsers(paramCheck);
                if(flg != 0)
                {
                    /// trả về ngôn ngữ của người đang thao tác
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language ?? "VN");
                    if (response != null) return response;
                }

                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("CreateUsers", param, null);
                /// trả về ngôn ngữ của người đang thao tác
                return GetStatusFunction.HandleCheckResponse(StatusResult.CREATE_SUCCESS_CODE, language ?? "VN");
            }
            catch (Exception ex)
            {
                if (File.Exists(createUsers.AvatarFileSave))
                {
                    File.Delete(createUsers.AvatarFileSave);
                }
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpClient);
                /// trả về ngôn ngữ của người đang thao tác
                return GetStatusFunction.HandleCheckResponse(StatusResult.ERROR_FAIL_CODE, language ?? "VN");
            }
        }

        /// <summary>
        /// Chỉnh sửa tài khoản, sử dụng IpClient để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        public async Task<Response<bool>> UpdateUsers(UpdateUsersModel model, string IpClient, string controller, string urlServer, string usersId, string language)
        {
            byte[] imageContents;
            UpdateUsers updateUsers = model;
            try
            {
                if (model.ImagesFiles.FileName != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        var extension = Path.GetExtension(model.ImagesFiles.FileName);
                        DateTime time = DateTime.Now;
                        var fileName = time.ToString("ddMMyyyyHHmmss") + $@"_{(Guid.NewGuid()).ToString().Replace("-", "")}";
                        await model.ImagesFiles.CopyToAsync(memoryStream);
                        imageContents = memoryStream.ToArray();
                        string imagePath = GetImagesFolderPath("PathSave") + fileName + $@"{extension}";
                        var linkFile = GetImagesFolderPath("FolderName").Replace($@"\", $@"/");
                        using (var fileStream = new FileStream(imagePath, FileMode.Create))
                        {
                            fileStream.Write(imageContents, 0, imageContents.Length);
                        }
                        updateUsers.AvatarFileSave = linkFile;
                        updateUsers.AvatarPublicUrl = urlServer + linkFile;
                    }
                }
                var param = CreateParam.InitializeParameters(updateUsers);
                var paramCheck = new CheckUsersDataProperties
                {
                    Id = model.UsersId,
                    Email = model.Email,
                    NumberPhone = model.NumberPhone,
                    StateIdCard = model.StateIDCard
                };

                var check = CheckLanguageSupport.CheckLanguage(model.UsersLanguage);
                if (!string.IsNullOrEmpty(check))
                {
                    return new Response<bool>(StatusResult.ERROR_LANGUAGE_DONT_SUPPORT_CODE, StatusResult.ERROR_LANGUAGE_DONT_SUPPORT_MESS_EN);
                }

                int flg = FindDuplicateUsersInfo.FindUplicateInfoOfUsers(paramCheck);
                if (flg != 0)
                {
                    var response = GetStatusFunction.HandleCheckResponseError(flg, language ?? "VN");
                    if (response != null) return response;
                }

                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("UpdateUsers", param, null);
                return GetStatusFunction.HandleCheckResponse(StatusResult.EDIT_SUCCESS_CODE, language ?? "VN");
            }
            catch (Exception ex)
            {
                if (File.Exists(updateUsers.AvatarFileSave))
                {
                    File.Delete(updateUsers.AvatarFileSave);
                }
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpClient);
                return GetStatusFunction.HandleCheckResponseError(StatusResult.ERROR_FAIL_CODE, language ?? "VN");
            }
        }

        /// <summary>
        /// Xóa tài khoản, sử dụng IpClient để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        public async Task<Response<bool>> DeleteUsers(DeleteUser model, string IpClient, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("DeleteUsers", param, null);
                return GetStatusFunction.HandleCheckResponse(StatusResult.DELETE_SUCCESS_CODE, language);
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpClient);
                return GetStatusFunction.HandleCheckResponseError(StatusResult.ERROR_FAIL_CODE, language);
            }
        }

        /// <summary>
        /// Block tài khoản, sử dụng IpClient để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        public async Task<Response<bool>> BlockUsers(BlockUser model, string IpClient, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("BlockUsers", param, null);
                return GetStatusFunction.HandleCheckResponse(StatusResult.BLOCK_SUCCESS_CODE, language);
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpClient);
                return GetStatusFunction.HandleCheckResponseError(StatusResult.ERROR_FAIL_CODE, language);

            }
        }

        /// <summary>
        /// Active tài khoản, sử dụng IpClient để ghi log nếu có lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <returns></returns>
        public async Task<Response<bool>> ActiveUsers(ActiveUser model, string IpClient, string controller, string usersId, string language)
        {
            try
            {
                var param = CreateParam.InitializeParameters(model);
                await _dapperUnitOfWork.GetRepository().ExecuteScalarAsync<int>("ActiveUsers", param, null);
                return GetStatusFunction.HandleCheckResponse(StatusResult.ACTIVE_SUCCESS_CODE, language);
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpClient);
                return GetStatusFunction.HandleCheckResponseError(StatusResult.ERROR_FAIL_CODE, language);
            }
        }

        /// <summary>
        /// Tìm tất cả có phân trang, tableName dạng dynamic do người sử dụng truyền vào, IpClient để ghi log
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public async Task<ResponseTable<InfoOfUsers>> FindAll(FindAll model, string IpClient, string controller, string usersId, string urlServer, string language)
        {
            ResponseTable<InfoOfUsers> result = null;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@PageSize", model.PageSize == 0 ? 10 : model.PageSize);
                param.Add("@PageIndex", model.PageIndex == 0 ? 1 : model.PageIndex);
                param.Add("@Url", urlServer ?? "https://localhost:7223");

                var res = await _dapperUnitOfWork.GetRepository().ExecuteData<InfoOfUsers>("FindAllUsers", param, null);
                var data = res.ToArray();
                if (data.Length > 0)
                {
                    result = GetStatusFunction.HandleCheckResponseWithTable<InfoOfUsers>(StatusResult.GETDATA_SUCCESS_CODE, language, data);
                }
                else
                {
                    result = GetStatusFunction.HandleCheckResponseWithTable<InfoOfUsers>(StatusResult.ERROR_NOTFOUND_CODE, language, null);
                }
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpClient);
                result = GetStatusFunction.HandleCheckResponseWithTable<InfoOfUsers>(StatusResult.ERROR_FAIL_CODE, language, null);
            }
            return result;
        }

        /// <summary>
        /// Tìm theo Id, tableName dạng dynamic do người sử dụng truyền vào, IpClient để ghi log
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="IpClient"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public async Task<Response<InfoOfUsers>> FindById(FindById model, string IpClient, string controller, string usersId, string urlServer, string language)
        {
            Response<InfoOfUsers> result = null;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@urlServer", urlServer);
                param.Add("@Id", model.IdSearch);
                var res = await _dapperUnitOfWork.GetRepository().ExecuteData<InfoOfUsers>("FindByUsersId", param, null);
                var data = res.ToArray();
                if (data.Length > 0)
                {
                    result = GetStatusFunction.HandleCheckResponseWithT<InfoOfUsers>(StatusResult.GETDATA_SUCCESS_CODE, language, data);
                }
                else
                {
                    result = GetStatusFunction.HandleCheckResponseWithT<InfoOfUsers>(StatusResult.ERROR_NOTFOUND_CODE, language, data);
                }
            }
            catch (Exception ex)
            {
                ConvertLog.WriteLog(_logger, controller, ex.Message, IpClient);
                result = GetStatusFunction.HandleCheckResponseWithT<InfoOfUsers>(StatusResult.ERROR_FAIL_CODE, language, null);
            }
            return result;
        }

        /// <summary>
        /// Tạo folder lưu ảnh
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetImagesFolderPath(string key)
        {
            DateTime date = DateTime.Now;
            var dd = date.ToString("dd");
            var mm = date.ToString("MM");
            var yyyy = date.ToString("yyyy");

            var imagesFolderName = $@"Images\";
            var contentRootPath = _env.WebRootPath;
            var imagesFolderPath = Path.Combine(contentRootPath, imagesFolderName);
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }
            JObject result = new JObject() {
                new JProperty("PathSave",imagesFolderPath),
                new JProperty("FolderName",imagesFolderName),

            }; ;
            JToken nameValue = result.GetValue(key);
            return nameValue.ToString();
        }
    }
}
