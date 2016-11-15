using System;

namespace TestFormAuthentication
{
	public class Global : System.Web.HttpApplication
	{
		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
			string
				XRequestedWithSignature = "X-Requested-With",
				GenerateStatusCodeSignature = "CheckBoxGenerateStatusCode",
				StatusCodeSignature = "TextFieldStatusCode",
				WriteToResponseSignature = "CheckBoxWriteToResponse";

			int
				StatusCode;

			if ((Context.User == null || !Context.User.Identity.IsAuthenticated)
				&& Context.Request.Headers[XRequestedWithSignature] != null
				&& Context.Request.Headers[XRequestedWithSignature].Trim().ToLower() == "xmlhttprequest"
				&& Context.Request.Form[GenerateStatusCodeSignature] != null
				&& Context.Request.Form[GenerateStatusCodeSignature].Trim().ToLower() == "on"
				&& Context.Request.Form[StatusCodeSignature] != null
				&& int.TryParse(Context.Request.Form[StatusCodeSignature], out StatusCode))
			{
				Context.Response.StatusCode = StatusCode;
				if (Context.Request.Form[WriteToResponseSignature] != null
					&& Context.Request.Form[WriteToResponseSignature].Trim().ToLower() == "on")
					Context.Response.Write("blah-blah-blah");
				Context.Response.End();
			}
		}
	}
}