using System.Web;
using Jayrock.Json;

namespace ExtJSI
{
	public class TestJsonReaderHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.AppendHeader("Pragma", "no-cache");
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonArray
				tmpJsonArraj = new JsonArray();

			int
				Max = 3;

			for (int i = 0; i < Max; ++i)
			{
				JsonObject
					tmpJsonObject = new JsonObject();

				tmpJsonObject.Accumulate("ContragentId", i+1);
				tmpJsonObject.Accumulate("Name", "Name" + (i+1));
				tmpJsonObject.Accumulate("Job", "Job" + (i+1));

				tmpJsonArraj.Add(tmpJsonObject);
			}

			JsonObject
				RootJsonObject = new JsonObject();

			//RootJsonObject.Accumulate("success", true);
			//RootJsonObject.Accumulate("results", Max);
			RootJsonObject.Accumulate("rows", tmpJsonArraj);

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

			RootJsonObject.Export(tmpJsonTextWriter);

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
