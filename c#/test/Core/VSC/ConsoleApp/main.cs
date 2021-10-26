using System;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;

using static System.Console;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string tmpString;
            WriteLine(tmpString = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            WriteLine(tmpString = Assembly.GetExecutingAssembly().Location);
            WriteLine(tmpString = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            WriteLine(ParseLanguage());
            WriteLine(ParseLanguage(null));
            WriteLine(ParseLanguage(string.Empty));
            WriteLine(ParseLanguage("   en   "));
            WriteLine(ParseLanguage("eng"));
            WriteLine(ParseLanguage("   en-gb   "));
            WriteLine(ParseLanguage("   eng-gb   "));
        }

        public static (string LanguageCode, string Country) ParseLanguage(string language = "")
        {
            const string TwoChars = "[a-zA-Z]{2}";

            Regex
                reLanguageCodeCountry = new Regex($"^({TwoChars})-({TwoChars})$"),
                reLanguageCode = new Regex($"^{TwoChars}$");

            var result = (LanguageCode: string.Empty, Country: string.Empty);

            if (language == null || (language = language.Trim()).Length == 0)
                return result;

            var match = reLanguageCodeCountry.Match(language);
            if (match.Success && match.Groups.Count == 3)
                return (LanguageCode: match.Groups[1].Value.ToLower(), Country: match.Groups[2].Value.ToUpper());

            match = reLanguageCode.Match(language);

            return match.Success ? (LanguageCode: match.Value.ToLower(), Country: string.Empty) : result;
        }
    }
}
