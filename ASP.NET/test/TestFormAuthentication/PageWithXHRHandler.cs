using System.Web;

namespace TestFormAuthentication
{
	public class PageWithXHRHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
		    string
		        statusCodeStr = context.Request.Form["statuscode"],
		        writeToResponseStr = context.Request.Form["writetoresponse"];

			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;

		    int statusCode;

		    if (!string.IsNullOrEmpty(statusCodeStr) && int.TryParse(statusCodeStr, out statusCode))
		        context.Response.StatusCode = statusCode;

		    bool writeToResponse;

            if(!string.IsNullOrEmpty(writeToResponseStr) && bool.TryParse(writeToResponseStr, out writeToResponse) && writeToResponse)
			    context.Response.Write("Helo, word!");
		}

		public bool IsReusable
		{
			get { return false; }
		}
	}
}
