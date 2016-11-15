using System.Web;
using System.Web.Services;

namespace AnyTestII
{
	/// <summary>
	/// Summary description for $codebehindclassname$
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class GenerateDataJSONHandler : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			string
				Param = HttpUtility.HtmlEncode(context.Request.QueryString["q"]);

			context.Response.ContentType = "application/json";
			context.Response.Write(string.IsNullOrEmpty(Param) ? "{\"id\": \"id1\", \"name\": \"name1\"}" : "[{\"id\": \"id1\", \"name\": \"name1\"},{\"id\": \"id2\", \"name\": \"name2\"}]");
			context.Response.Flush();
			context.Response.End();
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
