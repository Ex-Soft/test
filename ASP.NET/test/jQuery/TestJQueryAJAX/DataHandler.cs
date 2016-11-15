using System.Web;
using System.Web.Script.Serialization;

namespace TestJQueryAJAX
{
    public class DataHandler : IHttpHandler
    {
        #region IHttpHandler Members

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest
                request = context.Request;

			foreach (string key in request.Form.Keys)
			{
				var value = request.Form[key];
			}
	        

            HttpResponse
                response = context.Response;

            response.ClearContent();
            response.CacheControl = "no-cache";
            response.Expires = -1;
            response.ContentType = "application/json";
            response.StatusCode = 200;

	        //response.Headers["Access-Control-Allow-Headers"] = "*";
			response.Headers["Access-Control-Allow-Headers"] = "access-control-allow-headers,access-control-allow-methods,access-control-allow-origin";
			//response.Headers["access-control-allow-headers"] = "*";

			response.Headers["Access-Control-Allow-Methods"] = "POST, GET, OPTIONS";
			
			response.Headers["Access-Control-Allow-Origin"] = "*";

            JavaScriptSerializer
                serializer = new JavaScriptSerializer();

            response.Write(serializer.Serialize(new HandlerResponse { success = true, message = "message" }));

            response.Flush();
        }

        public bool IsReusable
        {
            get { return false; }
        }

        #endregion
    }
}
