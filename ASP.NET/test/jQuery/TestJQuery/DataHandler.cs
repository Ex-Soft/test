using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace TestJQuery
{
    public class DataHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest
                request = context.Request;

            string
                authorizationStr = request.Headers["Authorization"],
                usernameAndPassword = string.Empty;

            Regex
                regex = new Regex("(?<=Basic\\x20).+");

            Match
                match = regex.Match(authorizationStr);

            if (match.Success)
                usernameAndPassword = context.Request.ContentEncoding.GetString(Convert.FromBase64String(match.Value));

            string[]
                credentials = null;

            if (!string.IsNullOrEmpty(usernameAndPassword))
                credentials = usernameAndPassword.Split(new[] { ':' });

            bool
                authorized = credentials != null
                             && credentials.Length == 2
                             && credentials[0] == "login"
                             && credentials[1] == "1";

            HttpResponse
                response = context.Response;

            response.ClearContent();
            response.CacheControl = "no-cache";
            response.Expires = -1;
            response.ContentType = "application/json";
            response.StatusCode = 401;

            JavaScriptSerializer
                serializer = new JavaScriptSerializer();

            response.Write(serializer.Serialize(new HandlerResponse {success = false, message = "message"}));

            response.Flush();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
