using System.Web;

namespace AnyTest2_1
{
	public class TestSendDataByAJAXSaveHttpHandler:IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.Write("<html><body><h1>Rendered by TestSendDataByAJAXSaveHttpHandler");
			context.Response.Write("</h1></body></html>");
		}

		public bool IsReusable
		{
			get
			{
				return(true);
			}
		}
	}
}