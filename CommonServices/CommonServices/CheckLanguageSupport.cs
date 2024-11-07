using static CommonServices.EnumsTableName;

namespace CommonServices
{
    public class CheckLanguageSupport
    {
        /// <summary>
        /// Check ngôn ngữ đã chọn
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static string CheckLanguage (string language)
        {
            if (!Enum.TryParse(language, out Language selectedLanguage) || !Enum.IsDefined(typeof(Language), selectedLanguage))
            {
                return "Ngôn ngữ không hợp lệ. Vui lòng chọn EN, CN, KR, hoặc JP.";
            }
            return string.Empty;
        }
    }
}
