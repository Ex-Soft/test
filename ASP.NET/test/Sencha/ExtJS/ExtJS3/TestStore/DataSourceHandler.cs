//#define TEST_ERROR

using System.Collections.Generic;
using System.Web;
using Jayrock.Json;

namespace TestStore
{
	public class DataSourceHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ClearHeaders();
			context.Response.ClearContent();
			context.Response.ContentType = "application/json";

			#if TEST_ERROR
				//context.Response.StatusCode = 333;
				//context.Response.StatusDescription = "Ашипка";
				// equ
				context.Response.Status = "333 Ашипка";

				string
					Message = "\"Message\" \\/ \'Message\'";

				//context.Response.Write(Message.Replace("\\","\\\\").Replace("\"","\\\"").Replace("\'","\\\'"));
				context.Response.Write("{\"Message\": \"" + Message.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\'", "\\\'") + "\"}");

				context.Response.Flush();
				return;
			#endif


			JsonObject
				RootJsonObject = new JsonObject(new Dictionary<string, object> { { "success", true }, { "count", 2 }, { "rows", new JsonArray(new JsonObject[] { new JsonObject(new string[] { "Id", "Name" }, new object[] { 1, "Иванов Иван Иванович" }), new JsonObject(new string[] { "Id", "Name" }, new object[] { 2, "Петров Петр Петрович" }) }) } });

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
