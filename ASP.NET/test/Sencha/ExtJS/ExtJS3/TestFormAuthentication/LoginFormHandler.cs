using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

using Jayrock.Json;

namespace TestFormAuthentication
{
	public class LoginFormHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.CacheControl = "no-cache";
			context.Response.Expires = -1;
			context.Response.ContentType = "application/json";

			string
				loginUserName = context.Request.Form["loginUsername"],
				loginPassword = context.Request.Form["loginPassword"];

			bool
				IsAuthenticationSuccess;

			JsonObject
				tmpJsonObject = (IsAuthenticationSuccess = (loginUserName == "igor" && loginPassword == "1")) ? new JsonObject(new Dictionary<string, object> { { "success", true } }) : new JsonObject(new Dictionary<string, object> { { "success", false }, { "errors", new Dictionary<string, object> { { "reason", "Login failed. Try again." } } } });

			if (IsAuthenticationSuccess)
				FormsAuthentication.SetAuthCookie(loginUserName, false);

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
