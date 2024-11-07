#pragma warning disable

using CommonServices;

namespace APIs.Logic
{
    public interface IFindDataHandler
    {
        /// <summary>
        /// Tìm kiếm tất cả các bản ghi của tableName truyền vào, có phân trang và sử dụng IpConnect để ghi log
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseTable<T>> FindAll<T>(FindAll model, string IpConnect, string tableName, string controller, string usersId, string language);

        /// <summary>
        /// Tìm kiếm 1 bản ghi theo tableName truyền vào, có phân trang và sử dụng IpConnect để ghi log
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="IpConnect"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        Task<Response<T>> FindById<T>(FindById model, string IpConnect, string tableName, string controller, string usersId, string language);
    }
}
