using System;
using System.IO;
using System.Text;

namespace Core
{
    public class Security
    {
        public static string Encode(string input)
        {
            File.WriteAllText($"{DateTime.Now.Ticks}_Encode", $"{nameof(Encode)}(\"{input}\")");
            return Revert(input);
        }

        public static string Decode(string input)
        {
            File.WriteAllText($"{DateTime.Now.Ticks}_Decode", $"{nameof(Decode)}(\"{input}\")");
            return Revert(input);
        }

        private static string Revert(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var stringBuilder = new StringBuilder();
            for (var i = input.Length - 1; i >= 0; --i)
                stringBuilder.Append(input[i]);

            return stringBuilder.ToString();
        }
    }
}
