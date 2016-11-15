using System.Collections.Generic;
using System.Web;

using Jayrock.Json;

namespace TestFormAuthentication
{
	public class DefaultFormHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonObject
				tmpJsonObject = new JsonObject(new Dictionary<string, object> { { "success", true } });

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
