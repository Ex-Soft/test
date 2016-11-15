using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Authentication;

using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace TestLoginFormAdvanced
{
	public abstract class Worker
	{
		public abstract void ToDo(HttpContext context);

		public void DoIt(HttpContext context)
		{
			string
				IsLoginQueryStr;

			bool
				IsAuthenticated = context.User != null && context.User.Identity.IsAuthenticated,
				IsLoginQuery = !string.IsNullOrEmpty(IsLoginQueryStr = context.Request.Form["loginrequest"]) && IsLoginQueryStr.Trim().ToLower() == "true";

			try
			{
				if (!IsAuthenticated && !IsLoginQuery)
					throw(new Exception("!IsAuthenticated"));

				ToDo(context);
			}
			catch (Exception eException)
			{
				WriteToResponse(new JsonObject(new Dictionary<string, object> {
					{ "success", false },
					{ "message", eException.Message.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\'", "\\\'").Replace("\r\n", " ").Replace("\n", " ").Trim() },
					{ "IsAuthenticated", IsAuthenticated },
					{ "IsInvalidUserOrPasswd", eException.GetType()==typeof(AuthenticationException) }
				}), context);
			}
		}

		public void WriteToResponse(IJsonExportable o, HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = context.Request.Files.Count > 0 ? "text/html" : "application/json";

			JsonTextWriter
				jtw = new JsonTextWriter(context.Response.Output);

			try
			{
				if (o is JsonObject)
					(o as JsonObject).Export(jtw);
				else if (o is JsonArray)
					(o as JsonArray).Export(jtw);
				else if (o == null)
					new JsonObject().Export(jtw);
			}
			catch (Exception ex)
			{
				context.Response.ClearContent();

				JsonObject
					msg = new JsonObject();

				msg.Put("title", "Ошибка");
				msg.Put("text", ex.Message);
				msg.Put("description", ex.StackTrace);
				msg.Put("halt", true);

				JsonObject
					ums = new JsonObject();

				ums.Put("ums", msg);
				ums.Export(jtw);
			}

			jtw.Flush();
			jtw.Close();
		}
	}
}
