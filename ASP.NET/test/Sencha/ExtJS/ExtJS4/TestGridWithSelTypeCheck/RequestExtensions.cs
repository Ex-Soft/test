using System.IO;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace TestGridWithSelTypeCheck
{
    public static class RequestExtensions
    {
        public static string getJson(this HttpRequest request)
        {
            string
                result = string.Empty;

            Regex
                r = new Regex(@"("")(\\\\)(\/Date\(\d+\))(\\\\)(\/"")");

            if (request.ContentType.ToLower().IndexOf("application/json") != -1)
            {
                request.InputStream.Seek(0, SeekOrigin.Begin);
                var streamReader = new StreamReader(request.InputStream, Encoding.UTF8);
                result = streamReader.ReadToEnd().Trim();
            }

            return r.Replace(result, @"$1\$3\$5");
        }
    }
}