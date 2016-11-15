using System.Web;

namespace AnyTest2_1
{
	public class TestHttpHandlerClass : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			HttpResponse
				response = context.Response;

			response.Write("Helo, word!");
		}

		public bool IsReusable
		{
			get { return true; }
		}


	}
}
