using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;

namespace TestJQueryAJAX
{
    public class TestPromiseHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest
                request = context.Request;

            string data = null;

            switch (request.HttpMethod)
            {
                case "POST":
                {
                    using(var requestStream = request.InputStream)
                    using (var streamReader = new StreamReader(requestStream, Encoding.UTF8))
                    {
                        data = streamReader.ReadToEnd();
                    }
                    break;
                }
            }

            JavaScriptSerializer
                serializer = new JavaScriptSerializer();

            TestAjaxRequest
                testAjaxRequest = null;

            if (!string.IsNullOrWhiteSpace(data))
                testAjaxRequest = serializer.Deserialize<TestAjaxRequest>(data);

            if(testAjaxRequest!=null && testAjaxRequest.delay.HasValue)
                Thread.Sleep(testAjaxRequest.delay.Value);

            HttpResponse
                response = context.Response;

            response.ClearContent();
            response.CacheControl = "no-cache";
            response.Expires = -1;

            if ((response.StatusCode = testAjaxRequest != null && testAjaxRequest.statusCode.HasValue ? testAjaxRequest.statusCode.Value : 200) == 200)
                response.ContentType = "application/json";

            response.Write(string.Format("{{\"success\":{0}}}", (response.StatusCode == 200).ToString().ToLower()));

            response.Flush();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}