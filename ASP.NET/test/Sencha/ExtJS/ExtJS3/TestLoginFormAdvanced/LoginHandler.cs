using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Security.Authentication;

using Jayrock.Json;

namespace TestLoginFormAdvanced
{
	public class LoginHandler : Worker, IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			DoIt(context);
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}

		public override void ToDo(HttpContext context)
		{
			string
				Login = context.Request.Form["login"],
				Passwd = context.Request.Form["passwd"];

			if (Login != null)
				Login = Login.Trim().ToLower();

			if (Passwd != null)
				Passwd = Passwd.Trim();

			bool
				success;

			if (success = !string.IsNullOrEmpty(Login) && Login == "igor" && !string.IsNullOrEmpty(Passwd) && Passwd == "1")
			{
				FormsAuthentication.SetAuthCookie(Login, false);

				WriteToResponse(new JsonObject(new Dictionary<string, object> {
					{"success", success }
				}), context);
			}
			else
				throw (new AuthenticationException("Unknown user or invalid password"));
		}
	}
}
