using System.Web;
using Jayrock.Json;

namespace ExtJSI
{
	public class TestGridDataJsonHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string
				startStr = context.Request.Form["start"],
				limitStr = context.Request.Form["limit"];

			int
				start,
				limit;

			if (!int.TryParse(startStr, out start))
				start = 0;

			if (!int.TryParse(limitStr, out limit))
				limit = 5;

			context.Response.CacheControl = "no-cache";
			context.Response.AppendHeader("Pragma", "no-cache");
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			JsonArray
				tmpJsonArraj=new JsonArray();

			int
				Max = 23;

			for (int i = start; (i<start+limit) && (i < Max); ++i)
			{
				JsonObject
					tmpJsonObject = new JsonObject();

				tmpJsonObject.Accumulate("id", i);
				tmpJsonObject.Accumulate("title", "title"+i);
				tmpJsonObject.Accumulate("release_year", 1980 + i);
				tmpJsonObject.Accumulate("rating", 33 + i);

				tmpJsonArraj.Add(tmpJsonObject);
			}

			JsonObject
				RootJsonObject = new JsonObject();

			RootJsonObject.Accumulate("success", true);
			RootJsonObject.Accumulate("count", Max);
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
