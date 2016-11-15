/*
http://support.microsoft.com/kb/307985
*/
using System.Web;
using System.Configuration;

namespace TestHttpModule
{
	public class TestHttpModule : IHttpModule
	{
		string
			ApplicationName = string.Empty;

		public void Dispose()
		{}

		public void Init(HttpApplication context)
		{
			ApplicationName = ConfigurationManager.AppSettings["ApplicationName"];

			context.BeginRequest += new System.EventHandler(context_BeginRequest);
			context.AuthenticateRequest += new System.EventHandler(context_AuthenticateRequest);
			context.PostAuthenticateRequest += new System.EventHandler(context_PostAuthenticateRequest);
			context.AuthorizeRequest += new System.EventHandler(context_AuthorizeRequest);
			context.ResolveRequestCache += new System.EventHandler(context_ResolveRequestCache);
			context.PostMapRequestHandler += new System.EventHandler(context_PostMapRequestHandler);
			context.AcquireRequestState += new System.EventHandler(context_AcquireRequestState);
			context.PostAcquireRequestState += new System.EventHandler(context_PostAcquireRequestState);
			context.PreRequestHandlerExecute += new System.EventHandler(context_PreRequestHandlerExecute);
			context.PostRequestHandlerExecute += new System.EventHandler(context_PostRequestHandlerExecute);
			context.ReleaseRequestState += new System.EventHandler(context_ReleaseRequestState);
			context.UpdateRequestCache += new System.EventHandler(context_UpdateRequestCache);
			context.EndRequest += new System.EventHandler(context_EndRequest);
		}

		void context_BeginRequest(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />BeginRequest");
			response.Write("<br />");

			response.Write("ApplicationName="+(!string.IsNullOrEmpty(ApplicationName) ? "\""+ApplicationName+"\"": "null"));
			response.Write("<br />");

			string[]
				keys = app.Context.Request.Headers.AllKeys;

			foreach(string key in keys)
				response.Write("Headers[" + key + "]=\"" + app.Context.Request.Headers[key] + "\"<br />");
		}

		void context_AuthenticateRequest(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />AuthenticateRequest (app.Context.User" + (app.Context.User != null ? "!" : "=") + "=null" + (app.Context.User != null ? " name=\"" + app.Context.User.Identity.Name + "\"" : string.Empty) + ")");
		}

		void context_PostAuthenticateRequest(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />PostAuthenticateRequest (app.Context.User" + (app.Context.User != null ? "!" : "=") + "=null" + (app.Context.User != null ? " name=\"" + app.Context.User.Identity.Name + "\"" : string.Empty) + ")");
		}

		void context_AuthorizeRequest(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />AuthorizeRequest");
		}

		void context_ResolveRequestCache(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />ResolveRequestCache");
		}

		void context_PostMapRequestHandler(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />PostMapRequestHandler");
		}

		void context_AcquireRequestState(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />AcquireRequestState");
		}

		void context_PostAcquireRequestState(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />PostAcquireRequestState");
		}

		void context_PreRequestHandlerExecute(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />PreRequestHandlerExecute");
		}

		void context_PostRequestHandlerExecute(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />PostRequestHandlerExecute");
		}

		void context_ReleaseRequestState(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />ReleaseRequestState");
		}

		void context_UpdateRequestCache(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />UpdateRequestCache");
		}

		void context_EndRequest(object sender, System.EventArgs e)
		{
			HttpApplication
				app = (HttpApplication)sender;

			HttpResponse
				response = app.Context.Response;

			response.Write("<hr />EndRequest");
		}
	}
}