using System.Web;

namespace TestShowException
{
	public class ExceptionSourceHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			HttpResponse
				response = context.Response;

			string
				Subject = "subject",
				Body1 = "Body1 \" \' \\\\||// \' \"\n\r\' \" \\\\||// \" \' Body1",
				Body2 = "Body2 \" \' \\\\||// \' \"\n\r\' \" \\\\||// \" \' Body2",
				Message = "<a href=\"mailto:anonymous@mail.ru?subject=" + Subject + "&body=" + Body1.Replace("\"", "&#x22;") + " " + Body2.Replace("\"", "&#x22;") + "\">link</a><br/>Line# 1\nLine# 2\rLine# 3\r\nLine# 4\n\rLine# 5\r\n\" \' \\\\||// \' \"\n\r\' \" \\\\||// \" \'";

			response.ClearContent();
			response.CacheControl = "no-cache";
			response.Expires = -1;
			response.ContentType = "application/json";
			response.Status = "599 Error";
			response.Write("{\"message\": \"" + Message.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\'", "\\\'").Replace("\r\n", "<br/>").Replace("\n\r", "<br/>").Replace("\r", "<br/>").Replace("\n", "<br/>").Trim() + "\"}");
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
