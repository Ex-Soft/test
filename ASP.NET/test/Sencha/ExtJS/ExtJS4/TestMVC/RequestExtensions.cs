using System.Text;
using System.IO;
using System.Web;

namespace TestMVC
{
    public static class RequestExtensions
    {
        public static string GetJSON(this HttpRequest request)
        {
            string
                result = string.Empty;

            if (request.ContentType.ToLower() == "application/json")
            {
                request.InputStream.Seek(0, SeekOrigin.Begin);

                StreamReader
                    streamReader = new StreamReader(request.InputStream, Encoding.UTF8);

                result = streamReader.ReadToEnd().Trim();
            }

            return result;
        }
    }
}