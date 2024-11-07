#pragma warning disable

namespace CommonServices
{
    public class CreateSelectQuery
    {
        /// <summary>
        /// Tạo câu query truy vấn tự động
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excludeColumns"></param>
        /// <returns></returns>
        public static string GenerateSelectQuery<T>(params string[] excludeColumns)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => !excludeColumns.Contains(p.Name))
                .ToList();
            var columns = string.Join(", ", properties.Select(p => p.Name));
            return columns;
        }
    }
}
