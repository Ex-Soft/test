using System;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace AnyTest
{
    public class TestXHRHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string
                utf8Str = context.Request.Form["utf8"],
                statusCodeStr = context.Request.Form["statuscode"],
                authorizationStr = context.Request.Headers["Authorization"],
                usernameAndPassword = string.Empty,
                response = "{ \"text\": \"йцукен\" }";

            Regex
                regex = new Regex("(?<=Basic\\x20).+");

            Match
                match = regex.Match(authorizationStr);

            if (match.Success)
                usernameAndPassword = context.Request.ContentEncoding.GetString(Convert.FromBase64String(match.Value));

            string[]
                credentials = null;

            if (!string.IsNullOrWhiteSpace(usernameAndPassword))
                credentials = usernameAndPassword.Split(new[] { ':' });

            bool
                authorized = credentials != null
                             && credentials.Length == 2
                             && credentials[0] == "login"
                             && credentials[1] == "1";

            bool
                utf8=true;

            bool.TryParse(utf8Str, out utf8);
            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = -1;

            int statusCode;

            if (int.TryParse(statusCodeStr, out statusCode))
                context.Response.StatusCode = statusCode;

            //context.Response.StatusCode = 403;
            //context.Response.Status = "403 Forbidden";
            //context.Response.StatusCode = 401;
            //context.Response.Status = "401 Unauthorized";
            context.Response.ContentType = string.Format("application/json; charset={0}", utf8 ? "utf-8" : "windows-1251");
            context.Response.Charset = utf8 ? "utf-8" : "windows-1251";
            context.Response.ContentEncoding = utf8 ? Encoding.UTF8 : Encoding.GetEncoding(1251);
            byte[] bytes = context.Response.ContentEncoding.GetBytes(response);
            //byte[] bytes = Encoding.UTF8.GetBytes(response);
            //byte[] bytes = Encoding.GetEncoding(1251).GetBytes(response);
            context.Response.AddHeader("Content-Length", bytes.Length.ToString());
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
            context.Response.Flush();
            context.Response.Close();
            context.Response.End();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}