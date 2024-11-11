
namespace CommonServices
{
    public class EnumsTableName
    {
        public enum Table
        {
            Users, // Tài khoản
            Status, // Bảng trạng thái
            PaymentStatus, // Bảng trạng thái thanh toán
            APIsEndpoint, // Chứa thông tin router APIs
            UsersGroup, // Nhóm quyền
            UsersGroupMembership, // Lưu thông tin user join với nhóm quyền bằng UsersId
            RolePermission, // Phân quyền chi tiết Join với UserGroupMembership bằng UsersGroupId
        }

        public enum Language
        {
            VN,
            EN,
            CN,
            KR,
            JP
        }
    }
}
