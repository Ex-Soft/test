using System.Web;

namespace TestHttpModuleHttpHandler
{
	public class TestHttpModuleII : IHttpModule
	{
		public void Dispose()
		{ }

		public void Init(HttpApplication context)
		{
			context.BeginRequest += new System.EventHandler(context_BeginRequest);
			context.EndRequest += new System.EventHandler(context_EndRequest);
		}

		void context_BeginRequest(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			if (app.Context.Request.Url.Segments[app.Context.Request.Url.Segments.Length - 1].ToLower() == "default.aspx")
				return;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />BeginRequest (HttpModule II)");
			response.Write("<br />");

			string
				q;

			if (!string.IsNullOrEmpty(q = app.Context.Request.QueryString["q"])
				&& q == "2")
			{
				response.Flush();
				response.End();
			}
		}

		void context_EndRequest(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			if (app.Context.Request.Url.Segments[app.Context.Request.Url.Segments.Length - 1].ToLower() == "default.aspx")
				return;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />EndRequest  (HttpModule II)");
		}
	}
}
