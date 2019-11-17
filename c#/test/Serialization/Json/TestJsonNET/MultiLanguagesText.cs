using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace TestJsonNET
{
    public class MultiLanguagesText
    {
        private static readonly Regex
            NullValue = new Regex("\"[a-zA-Z]{2}\":null,?", RegexOptions.IgnoreCase | RegexOptions.Compiled),
            ExtraComma = new Regex(",(?=})", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("de")]
        public string De { get; set; }

        [JsonProperty("da")]
        public string Da { get; set; }

        [JsonProperty("sv")]
        public string Sv { get; set; }

        public string ToJson()
        {
            return ExtraComma.Replace(NullValue.Replace(JsonConvert.SerializeObject(this), string.Empty), string.Empty);
        }
    }
}
