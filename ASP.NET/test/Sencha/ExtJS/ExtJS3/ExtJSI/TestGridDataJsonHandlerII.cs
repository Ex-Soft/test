using System.Web;
using Jayrock.Json;

namespace ExtJSI
{
	public class TestGridDataJsonHandlerII : IHttpHandler
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
				Max = 23;

			for (int i = 0; i < Max; ++i)
			{
				JsonObject
					tmpJsonObject = new JsonObject();

				tmpJsonObject.Accumulate("id", i);
				tmpJsonObject.Accumulate("title", "title" + i);
				tmpJsonObject.Accumulate("release_year", 1980 + i);
				tmpJsonObject.Accumulate("rating", 33 + i);
				tmpJsonObject.Accumulate("genre", Max/(i+1));

				tmpJsonArraj.Add(tmpJsonObject);
			}

			JsonObject
				RootJsonObject = new JsonObject();

			RootJsonObject.Accumulate("success", true);
			RootJsonObject.Accumulate("movies", tmpJsonArraj);

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

