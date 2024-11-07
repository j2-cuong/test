
namespace CommonServices
{
    public static class StatusResult
    {
        #region 20xx Trạng thái thành công

        public const int LOGIN_SUCCESS_CODE = 2001;
        public const string LOGIN_SUCCESS_MESS_VN = "Đăng nhập thành công!";
        public const string LOGIN_SUCCESS_MESS_EN = "Login successful!";
        public const string LOGIN_SUCCESS_MESS_CN = "登录成功!";
        public const string LOGIN_SUCCESS_MESS_KR = "로그인 성공!";
        public const string LOGIN_SUCCESS_MESS_JP = "ログイン成功!";

        public const int CREATE_SUCCESS_CODE = 2002;
        public const string CREATE_SUCCESS_MESS_VN = "Thêm mới bản ghi thành công!";
        public const string CREATE_SUCCESS_MESS_EN = "Record created successfully!";
        public const string CREATE_SUCCESS_MESS_CN = "记录创建成功!";
        public const string CREATE_SUCCESS_MESS_KR = "기록 생성 성공!";
        public const string CREATE_SUCCESS_MESS_JP = "レコードが正常に作成されました!";

        public const int EDIT_SUCCESS_CODE = 2003;
        public const string EDIT_SUCCESS_MESS_VN = "Sửa thông tin bản ghi thành công!";
        public const string EDIT_SUCCESS_MESS_EN = "Record edited successfully!";
        public const string EDIT_SUCCESS_MESS_CN = "记录编辑成功!";
        public const string EDIT_SUCCESS_MESS_KR = "기록 편집 성공!";
        public const string EDIT_SUCCESS_MESS_JP = "レコードが正常に編集されました!";

        public const int DELETE_SUCCESS_CODE = 2004;
        public const string DELETE_SUCCESS_MESS_VN = "Xóa bản ghi thành công!";
        public const string DELETE_SUCCESS_MESS_EN = "Record deleted successfully!";
        public const string DELETE_SUCCESS_MESS_CN = "记录删除成功!";
        public const string DELETE_SUCCESS_MESS_KR = "기록 삭제 성공!";
        public const string DELETE_SUCCESS_MESS_JP = "レコードが正常に削除されました!";

        public const int GETDATA_SUCCESS_CODE = 2005;
        public const string GETDATA_SUCCESS_MESS_VN = "Tải dữ liệu thành công!";
        public const string GETDATA_SUCCESS_MESS_EN = "Data loaded successfully!";
        public const string GETDATA_SUCCESS_MESS_CN = "数据加载成功!";
        public const string GETDATA_SUCCESS_MESS_KR = "데이터 로드 성공!";
        public const string GETDATA_SUCCESS_MESS_JP = "データが正常に読み込まれました!";

        public const int BLOCK_SUCCESS_CODE = 2006;
        public const string BLOCK_SUCCESS_MESS_VN = "Khóa toàn bộ chức năng của người dùng thành công!";
        public const string BLOCK_SUCCESS_MESS_EN = "User's functions locked successfully!";
        public const string BLOCK_SUCCESS_MESS_CN = "用户功能锁定成功!";
        public const string BLOCK_SUCCESS_MESS_KR = "사용자 기능 잠금 성공!";
        public const string BLOCK_SUCCESS_MESS_JP = "ユーザーの機能が正常にロックされました!";

        public const int ACTIVE_SUCCESS_CODE = 2007;
        public const string ACTIVE_SUCCESS_MESS_VN = "Kích hoạt người dùng thành công!";
        public const string ACTIVE_SUCCESS_MESS_EN = "User activated successfully!";
        public const string ACTIVE_SUCCESS_MESS_CN = "用户激活成功!";
        public const string ACTIVE_SUCCESS_MESS_KR = "사용자 활성화 성공!";
        public const string ACTIVE_SUCCESS_MESS_JP = "ユーザーが正常にアクティブ化されました!";

        public const int UPLOAD_SUCCESS_CODE = 2008;
        public const string UPLOAD_SUCCESS_MESS_VN = "Tải dữ liệu lên máy chủ thành công!";
        public const string UPLOAD_SUCCESS_MESS_EN = "Image Upload successfully!";
        public const string UPLOAD_SUCCESS_MESS_CN = "Chưa có mess!";
        public const string UPLOAD_SUCCESS_MESS_KR = "Chưa có mess!";
        public const string UPLOAD_SUCCESS_MESS_JP = "Chưa có mess!";

        #endregion

        #region -20xx trạng thái lỗi
                public const int ERROR_NOTFOUND_CODE = -2001;
        public const string ERROR_NOTFOUND_MESS_VN = "Không tìm thấy bản ghi!";
        public const string ERROR_NOTFOUND_MESS_EN = "Record not found!";
        public const string ERROR_NOTFOUND_MESS_CN = "未找到记录!";
        public const string ERROR_NOTFOUND_MESS_KR = "기록을 찾을 수 없음!";
        public const string ERROR_NOTFOUND_MESS_JP = "レコードが見つかりません！";

        public const int ERROR_DUPPLICATE_USER_NAME_CODE = -2002;
        public const string ERROR_DUPPLICATE_USER_NAME_MESS_VN = "Tên đăng nhập đã tồn tại!";
        public const string ERROR_DUPPLICATE_USER_NAME_MESS_EN = "Username already exists!";
        public const string ERROR_DUPPLICATE_USER_NAME_MESS_CN = "用户名已存在!";
        public const string ERROR_DUPPLICATE_USER_NAME_MESS_KR = "사용자 이름이 이미 존재합니다!";
        public const string ERROR_DUPPLICATE_USER_NAME_MESS_JP = "ユーザー名はすでに存在します！";

        public const int ERROR_DUPPLICATE_EMAIL_CODE = -2003;
        public const string ERROR_DUPPLICATE_EMAIL_MESS_VN = "Email đã tồn tại!";
        public const string ERROR_DUPPLICATE_EMAIL_MESS_EN = "Email already exists!";
        public const string ERROR_DUPPLICATE_EMAIL_MESS_CN = "邮箱已存在!";
        public const string ERROR_DUPPLICATE_EMAIL_MESS_KR = "이메일이 이미 존재합니다!";
        public const string ERROR_DUPPLICATE_EMAIL_MESS_JP = "メールアドレスはすでに存在します！";

        public const int ERROR_DUPPLICATE_PHONE_CODE = -2004;
        public const string ERROR_DUPPLICATE_PHONE_MESS_VN = "Số điện thoại đã tồn tại!";
        public const string ERROR_DUPPLICATE_PHONE_MESS_EN = "Phone number already exists!";
        public const string ERROR_DUPPLICATE_PHONE_MESS_CN = "电话号码已存在!";
        public const string ERROR_DUPPLICATE_PHONE_MESS_KR = "전화번호가 이미 존재합니다!";
        public const string ERROR_DUPPLICATE_PHONE_MESS_JP = "電話番号はすでに存在します！";

        public const int ERROR_DUPPLICATE_STATEIDCARD_CODE = -2005;
        public const string ERROR_DUPPLICATE_STATEIDCARD_MESS_VN = "Số căn cước đã tồn tại!";
        public const string ERROR_DUPPLICATE_STATEIDCARD_MESS_EN = "Identity card number already exists!";
        public const string ERROR_DUPPLICATE_STATEIDCARD_MESS_CN = "身份证号码已存在!";
        public const string ERROR_DUPPLICATE_STATEIDCARD_MESS_KR = "주민등록번호가 이미 존재합니다!";
        public const string ERROR_DUPPLICATE_STATEIDCARD_MESS_JP = "身分証明書番号はすでに存在します！";

        public const int ERROR_DUPPLICATE_ROOMS_STATUS_CODE_CODE = -2006;
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_CODE_MESS_VN = "Mã trạng thái này đã tồn tại!";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_CODE_MESS_EN = "This status code already exists!";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_CODE_MESS_CN = "此状态码已存在！";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_CODE_MESS_KR = "이 상태 코드는 이미 존재합니다!";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_CODE_MESS_JP = "このステータスコードは既に存在します！";

        public const int ERROR_DUPPLICATE_ROOMS_STATUS_NAME_CODE = -2007;
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_NAME_MESS_VN = "Tên trạng thái này đã tồn tại!";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_NAME_MESS_EN = "This status name already exists!";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_NAME_MESS_CN = "此状态名称已存在！";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_NAME_MESS_KR = "이 상태 이름은 이미 존재합니다!";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_NAME_MESS_JP = "このステータス名は既に存在します！";

        public const int ERROR_DUPPLICATE_ROOMS_STATUS_COLOR_CODE = -2008;
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_COLOR_MESS_VN = "Mã màu này đã được sử dụng!";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_COLOR_MESS_EN = "This color code is already in use!";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_COLOR_MESS_CN = "此颜色代码已被使用！";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_COLOR_MESS_KR = "이 색상 코드는 이미 사용 중입니다!";
        public const string ERROR_DUPPLICATE_ROOMS_STATUS_COLOR_MESS_JP = "このカラーコードは既に使用されています！";

        public const int ERROR_IS_USING_ROOMS_STATUS_CODE = -2009;
        public const string ERROR_IS_USING_ROOMS_STATUS_MESS_VN = "Trạng thái đang được sử dụng ở 1 bản ghi khác, vui lòng kiểm tra lại!";
        public const string ERROR_IS_USING_ROOMS_STATUS_MESS_EN = "The status is being used in another record, please check again!";
        public const string ERROR_IS_USING_ROOMS_STATUS_MESS_CN = "状态正在另一个记录中使用，请再次检查。！";
        public const string ERROR_IS_USING_ROOMS_STATUS_MESS_KR = "상태가 다른 기록에서 사용 중입니다. 다시 확인해 주세요!";
        public const string ERROR_IS_USING_ROOMS_STATUS_MESS_JP = "このステータスは別のレコードで使用されています。もう一度確認してください。！";
        
        public const int ERROR_DUPPLICATE_PAYMENTSTATUS_CODE_CODE = -2010;
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_CODE_MESS_VN = "Mã trạng thái thanh toán này đã tồn tại!";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_CODE_MESS_EN = "This payment status code already exists!";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_CODE_MESS_CN = "此状态码已存在！";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_CODE_MESS_KR = "이 상태 코드는 이미 존재합니다!";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_CODE_MESS_JP = "このステータスコードは既に存在します！";

        public const int ERROR_DUPPLICATE_PAYMENTSTATUS_NAME_CODE = -2011;
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_NAME_MESS_VN = "Tên trạng thái thanh toán này đã tồn tại!";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_NAME_MESS_EN = "This payment status name already exists!";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_NAME_MESS_CN = "此状态名称已存在！";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_NAME_MESS_KR = "이 상태 이름은 이미 존재합니다!";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_NAME_MESS_JP = "このステータス名は既に存在します！";

        public const int ERROR_DUPPLICATE_PAYMENTSTATUS_COLOR_CODE = -2012;
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_COLOR_MESS_VN = "Mã màu thanh toán này đã được sử dụng!";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_COLOR_MESS_EN = "This color payment code is already in use!";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_COLOR_MESS_CN = "此颜色代码已被使用！";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_COLOR_MESS_KR = "이 색상 코드는 이미 사용 중입니다!";
        public const string ERROR_DUPPLICATE_PAYMENTSTATUS_COLOR_MESS_JP = "このカラーコードは既に使用されています！";

        public const int ERROR_IS_USING_PAYMENTSTATUS_CODE = -2013;
        public const string ERROR_IS_USING_PAYMENTSTATUS_MESS_VN = "Trạng thái thanh toán đang được sử dụng ở 1 bản ghi khác, vui lòng kiểm tra lại!";
        public const string ERROR_IS_USING_PAYMENTSTATUS_MESS_EN = "The payment status is being used in another record, please check again!";
        public const string ERROR_IS_USING_PAYMENTSTATUS_MESS_CN = "状态正在另一个记录中使用，请再次检查。！";
        public const string ERROR_IS_USING_PAYMENTSTATUS_MESS_KR = "상태가 다른 기록에서 사용 중입니다. 다시 확인해 주세요!";
        public const string ERROR_IS_USING_PAYMENTSTATUS_MESS_JP = "このステータスは別のレコードで使用されています。もう一度確認してください。！";

        #endregion

        #region -5xx liên quan tới thông tin bị thay đổi, cần login lại

        public const int ERROR_YOUR_INFOMATION_HAS_CHANGE_CODE = -501;
        public const string ERROR_YOUR_INFOMATION_HAS_CHANGE_MESS_VN = "Thông tin của bạn đã bị Admin thay đổi, vui lòng đăng nhập lại!";
        public const string ERROR_YOUR_INFOMATION_HAS_CHANGE_MESS_EN = "Your information has been changed by the Admin, please log in again!";
        public const string ERROR_YOUR_INFOMATION_HAS_CHANGE_MESS_CN = "您的信息已被管理员更改，请重新登录！";
        public const string ERROR_YOUR_INFOMATION_HAS_CHANGE_MESS_KR = "당신의 정보가 관리자에 의해 변경되었습니다. 다시 로그인해 주세요!";
        public const string ERROR_YOUR_INFOMATION_HAS_CHANGE_MESS_JP = "管理者によって情報が変更されました。再度ログインしてください！";

        #endregion

        #region -6xx liên quan tới Menu FE

        public const int ERROR_NOTHAVE_PERMISSION_FE_CODE = -601;
        public const string ERROR_NOTHAVE_PERMISSION_FE_MESS_VN = "Bạn không có quyền truy cập menu này!";
        public const string ERROR_NOTHAVE_PERMISSION_FE_MESS_EN = "You do not have permission to access this menu!";
        public const string ERROR_NOTHAVE_PERMISSION_FE_MESS_CN = "您没有权限访问此菜单!";
        public const string ERROR_NOTHAVE_PERMISSION_FE_MESS_KR = "이 메뉴에 접근할 권한이 없습니다!";
        public const string ERROR_NOTHAVE_PERMISSION_FE_MESS_JP = "このメニューにアクセスする権限がありません！";

        #endregion

        #region -7xx liên quan tới endpoint APIs

        public const int ERROR_NOTHAVE_PERMISSION_BE_CODE = -701;
        public const string ERROR_NOTHAVE_PERMISSION_BE_MESS_VN = "Bạn không có quyền sử dụng chức năng này!";
        public const string ERROR_NOTHAVE_PERMISSION_BE_MESS_EN = "You do not have permission to use this function!";
        public const string ERROR_NOTHAVE_PERMISSION_BE_MESS_CN = "您没有权限使用此功能!";
        public const string ERROR_NOTHAVE_PERMISSION_BE_MESS_KR = "이 기능을 사용할 권한이 없습니다!";
        public const string ERROR_NOTHAVE_PERMISSION_BE_MESS_JP = "この機能を使用する権限がありません！";

        /// <summary>
        /// Lỗi này xuất hiện khi 1 user A bị Adminstrator thay đổi thông tin, 
        /// Làm cái popup hiển thị là đã bị thay đổi thông tin 
        /// Cần đăng nhập lại, bấm Ok thì clear local stogare xong bắt nó login lại
        /// Mục đích là lấy lại phần ngôn ngữ + thông tin ở phần login response
        /// </summary>
        public const int ERROR_UNAUTHORIZEDRESULT_BE_CODE = -702;
        public const string ERROR_UNAUTHORIZEDRESULT_BE_MESS_VN = "Phiên làm việc đã kết thúc, vui lòng đăng nhập lại!";
        public const string ERROR_UNAUTHORIZEDRESULT_BE_MESS_EN = "The session has ended, please log in again!";
        public const string ERROR_UNAUTHORIZEDRESULT_BE_MESS_CN = "会话已结束，请重新登录。!";
        public const string ERROR_UNAUTHORIZEDRESULT_BE_MESS_KR = "세션이 종료되었습니다. 다시 로그인해 주세요.!";
        public const string ERROR_UNAUTHORIZEDRESULT_BE_MESS_JP = "セッションが終了しました。再度ログインしてください。！";

        #endregion

        #region -8xx liên quan tới ngôn ngữ

        public const int ERROR_LANGUAGE_DONT_SUPPORT_CODE = -801;
        public const string ERROR_LANGUAGE_DONT_SUPPORT_MESS_VN = "Ngôn ngữ bạn chọn chưa được hỗ trợ, vui lòng sử dụng ngôn ngữ khác!";
        public const string ERROR_LANGUAGE_DONT_SUPPORT_MESS_EN = "The language you selected is not supported, please use another language!";
        public const string ERROR_LANGUAGE_DONT_SUPPORT_MESS_CN = "您选择的语言不受支持，请使用其他语言。!";
        public const string ERROR_LANGUAGE_DONT_SUPPORT_MESS_KR = "선택한 언어는 지원되지 않습니다. 다른 언어를 사용하십시오.";
        public const string ERROR_LANGUAGE_DONT_SUPPORT_MESS_JP = "選択した言語はサポートされていません。別の言語を使用してください。";

        #endregion

        #region -9xx liên quan tới các lỗi chung
        public const int ERROR_NOTFOUND_USER_NAME_CODE = -97;
        public const string ERROR_NOTFOUND_USER_NAME_MESS_VN = "Không tìm thấy tên đăng nhập hoặc mật khẩu không đúng!";
        public const string ERROR_NOTFOUND_USER_NAME_MESS_EN = "Username not found or password incorrect!";
        public const string ERROR_NOTFOUND_USER_NAME_MESS_CN = "未找到用户名或密码不正确!";
        public const string ERROR_NOTFOUND_USER_NAME_MESS_KR = "사용자 이름을 찾을 수 없거나 비밀번호가 올바르지 않습니다!";
        public const string ERROR_NOTFOUND_USER_NAME_MESS_JP = "ユーザー名が見つからないか、パスワードが間違っています！";

        public const int ERROR_FAIL_CODE = -98;
        public const string ERROR_FAIL_MESS_VN = "Thất bại!";
        public const string ERROR_FAIL_MESS_EN = "Failure!";
        public const string ERROR_FAIL_MESS_CN = "失败!";
        public const string ERROR_FAIL_MESS_KR = "실패!";
        public const string ERROR_FAIL_MESS_JP = "失敗！";

        public const int ERROR_SERVER_CODE = -99;
        public const string ERROR_SERVER_MESS_VN = "Lỗi server!";
        public const string ERROR_SERVER_MESS_EN = "Server error!";
        public const string ERROR_SERVER_MESS_CN = "服务器错误!";
        public const string ERROR_SERVER_MESS_KR = "서버 오류!";
        public const string ERROR_SERVER_MESS_JP = "サーバーエラー！";

        public const int ERROR_BASEAPICONTROLLER_CODE = -96;
        public const string ERROR_BASEAPICONTROLLER_MESS_VN = "Lỗi server!";
        public const string ERROR_BASEAPICONTROLLER_MESS_EN = "The Controller must not inherit from BaseApiController!";
        public const string ERROR_BASEAPICONTROLLER_MESS_CN = "Controller 不能继承自 BaseApiController。";
        public const string ERROR_BASEAPICONTROLLER_MESS_KR = "BaseApiController를 상속받을 수 없습니다.";
        public const string ERROR_BASEAPICONTROLLER_MESS_JP = "コントローラーはBaseApiControllerを継承してはいけません。";

        #endregion

        #region -999 Liên hệ Dev check log 
        public const int ERROR_ADMINISTATOR_CODE = -999;
        public const string ERROR_ADMINISTATOR_MESS_VN = "Liên hệ ADMINISTRATOR để kiểm tra!";
        public const string ERROR_ADMINISTATOR_MESS_EN = "Contact ADMINISTRATOR for assistance!";
        public const string ERROR_ADMINISTATOR_MESS_CN = "请联系管理员检查!";
        public const string ERROR_ADMINISTATOR_MESS_KR = "관리자에게 문의하십시오!";
        public const string ERROR_ADMINISTATOR_MESS_JP = "管理者に連絡して、支援を求めてください！";
        #endregion

    }
}
