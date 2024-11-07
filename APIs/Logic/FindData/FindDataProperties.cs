#pragma warning disable

using System.ComponentModel.DataAnnotations;

namespace APIs.Logic
{
    /// <summary>
    /// model để sử dụng cho action tìm kiếm tất cả
    /// </summary>
    public class FindAll
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }

    /// <summary>
    /// model để sử dụng cho action tìm kiếm theo Id
    /// </summary>
    public class FindById
    {
        public Guid IdSearch { get; set; }
    }

}
