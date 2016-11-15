using System.Web;
using Jayrock.Json;

namespace ExtJSIV
{
	public class TestGridDataJsonHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string
				startStr = context.Request.Form["start"],
				limitStr = context.Request.Form["limit"],
				param1Str = context.Request.Form["param1"],
				param2Str = context.Request.Form["param2"],
				param3Str = context.Request.Form["param3"];

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
				tmpJsonObject.Accumulate("title", !string.IsNullOrEmpty(param1Str) ? param1Str : "title"+i);
				tmpJsonObject.Accumulate("release_year", !string.IsNullOrEmpty(param2Str) ? param2Str : (1980 + i).ToString());
				tmpJsonObject.Accumulate("rating", !string.IsNullOrEmpty(param3Str) ? param3Str : (33 + i).ToString());

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
