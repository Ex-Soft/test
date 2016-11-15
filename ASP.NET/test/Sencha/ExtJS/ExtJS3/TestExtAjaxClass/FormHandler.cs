using System.Collections.Generic;
using System.Web;

using Jayrock.Json;

namespace TestExtAjaxClass
{
	public class FormHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			System.Threading.Thread.Sleep(3000);

			string
				GenerateStatusCode,
				StatusCodeStr,
				WriteToResponse;

			int
				StatusCode;

			if (!string.IsNullOrEmpty(GenerateStatusCode = context.Request.Form["GenerateStatusCode"])
				&& GenerateStatusCode.Trim().ToLower() == "true"
				&& !string.IsNullOrEmpty(StatusCodeStr = context.Request.Form["StatusCode"])
				&& int.TryParse(StatusCodeStr, out StatusCode))
			{
				context.Response.StatusCode = StatusCode;

				if (!string.IsNullOrEmpty(WriteToResponse = context.Request.Form["WriteToResponse"])
					&& WriteToResponse.Trim().ToLower() == "true")
					context.Response.Write("blah-blah-blah");

				context.Response.End();

				return;
			}

			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonObject
				tmpJsonObject = new JsonObject(new Dictionary<string, object> { { "success", true } });

			string
				type;

			if (!string.IsNullOrEmpty(type = context.Request.Form["type"])
				&& type.Trim().ToLower() == "load")
				tmpJsonObject.Accumulate("data", new JsonObject(new Dictionary<string, object> { { "TextField", "TextField" } }));

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

			tmpJsonObject.Export(tmpJsonTextWriter);
			tmpJsonTextWriter.Flush();
			tmpJsonTextWriter.Close();
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
