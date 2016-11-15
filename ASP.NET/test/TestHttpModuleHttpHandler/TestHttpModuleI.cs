using System.Web;
using System.Web.SessionState;

namespace TestHttpModuleHttpHandler
{
	public class TestHttpModuleI : IHttpModule
	{
		public void Dispose()
		{}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += new System.EventHandler(context_BeginRequest);
			context.EndRequest += new System.EventHandler(context_EndRequest);

			//http://www.sql.ru/forum/actualthread.aspx?tid=784304
			//http://msdn.microsoft.com/ru-ru/library/ms379557%28VS.80%29.aspx
			//http://www.eggheadcafe.com/community/aspnet/7/84848/refresh-detect-using-httphandler.aspx
			context.AcquireRequestState += new System.EventHandler(context_AcquireRequestState);
		}

		void context_AcquireRequestState(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpContext
				ctx = app.Context;
		}

		void context_BeginRequest(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			if (app.Context.Request.Url.Segments[app.Context.Request.Url.Segments.Length - 1].ToLower() == "default.aspx")
				return;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />BeginRequest (HttpModule I)");
			response.Write("<br />");

			string
				q;

			if(!string.IsNullOrEmpty(q=app.Context.Request.QueryString["q"])
				&& q=="1")
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

			response.Write("<hr />EndRequest  (HttpModule I)");
		}
	}
}
