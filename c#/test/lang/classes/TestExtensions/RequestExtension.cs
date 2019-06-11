using System.Text.RegularExpressions;

namespace TestExtensions
{
    public static class RequestExtension
    {
        private const string TwoChars = "[a-zA-Z]{2}";

        private static readonly Regex
            ReLanguageCodeCountry = new Regex($"^({TwoChars})-({TwoChars})$"),
            ReLanguageCode = new Regex($"^{TwoChars}$");

        public static string GetLanguageCode(this Request request)
        {
            if (request == null)
                return string.Empty;

            var (languageCode, _) = ParseLanguage(request.PreferredLanguage);

            return languageCode;
        }

        public static string GetCountry(this Request request)
        {
            if (request == null)
                return string.Empty;

            var (_, country) = ParseLanguage(request.PreferredLanguage);

            return country;
        }

        private static (string LanguageCode, string Country) ParseLanguage(string language = "")
        {
            var result = (LanguageCode: string.Empty, Country: string.Empty);

            if (language == null || (language = language.Trim()).Length == 0)
                return result;

            var match = ReLanguageCodeCountry.Match(language);
            if (match.Success && match.Groups.Count == 3)
                return (LanguageCode: match.Groups[1].Value.ToLower(), Country: match.Groups[2].Value.ToUpper());

            match = ReLanguageCode.Match(language);

            return match.Success ? (LanguageCode: match.Value.ToLower(), Country: string.Empty) : result;
        }
    }
}
