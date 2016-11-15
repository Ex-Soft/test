using System.Web;

namespace TestHttpModuleHttpHandler
{
	public class TestHttpHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			HttpResponse
				response = context.Response;

			response.Write("Server.MapPath(null)=\""+context.Server.MapPath(null)+"\"<br />");
			response.Write("Server.MapPath(\"~\")=\"" + context.Server.MapPath("~") + "\"<br />");
			response.Write("Server.MapPath(\"~/\")=\"" + context.Server.MapPath("~/") + "\"<br />");
			response.Write("Helo, word!");
		}

		public bool IsReusable
		{
			get { return true; }
		}


	}
}
