#pragma warning disable

using Dapper;
using System.Data.SqlTypes;
using System.Reflection;

namespace CommonServices
{
    public class CreateParam
    {
        /// <summary>
        /// Tạo param tự động để truy vấn
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DynamicParameters InitializeParameters<T>(T model)
        {
            var param = new DynamicParameters();

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                var propValue = prop.GetValue(model);
                if (prop.Name == "UsersPassword" && propValue is string password)
                {
                    propValue = AesEncryption.Encrypt(password);
                }
                param.Add($"@{prop.Name}", propValue);
            }
            return param;
        }
    }
}
