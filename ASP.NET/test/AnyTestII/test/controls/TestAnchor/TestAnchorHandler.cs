using System;
using System.Web;

namespace AnyTestII
{
	public class TestAnchorHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.Write("<html><head><title>Test Anchor Handler</title></head><body>");

			string[]
				array1 = context.Request.QueryString.AllKeys,
				array2;

			for (int i = 0; i < array1.Length; ++i)
			{
				context.Response.Write("Key [" + Convert.ToString(i) + "]=" + context.Server.HtmlEncode(array1[i]) + "<br />");
				array2 = context.Request.QueryString.GetValues(array1[i]);
				for (int ii = 0; ii < array2.Length; ++ii)
					context.Response.Write("Value [" + Convert.ToString(ii) + "]=" + context.Server.HtmlEncode(array2[ii]) + " (" + array2[ii] + ")<br />");
			}

			context.Response.Write("</body></html>");
		}

		public bool IsReusable
		{
			get { return false; }
		}
	}
}
