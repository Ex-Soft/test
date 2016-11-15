using System.IO;
using System.Text;
using System.Web;

namespace TestGrid.remote.app.handlers
{
    public static class RequestExtensions
    {
        public static string GetJson(this HttpRequest request)
        {
            string
                result = string.Empty;

            if (request.ContentType.ToLower().IndexOf("application/json") != -1)
            {
                request.InputStream.Seek(0, SeekOrigin.Begin);
                var streamReader = new StreamReader(request.InputStream, Encoding.UTF8);
                result = streamReader.ReadToEnd().Trim();
            }

            return result;
        }
    }
}