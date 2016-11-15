using System;
using System.IO.Compression;
using System.Web;

namespace TestHttpModuleGZip
{
    public class TestHttpModuleGZip : IHttpModule
    {
    	const string
			GZIP = "gzip",
			PageName = "TestHttpModuleGZip.html";

        public void Dispose()
        {}

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
			HttpApplication
				app = (HttpApplication)sender;

        	HttpResponse
        		response = app.Context.Response;

        	string
        		encodings;

			if(!app.Context.Request.Path.Contains(PageName)
				|| app.Context.Request["HTTP_X_MICROSOFTAJAX"] != null
				|| (encodings = app.Context.Request.Headers.Get("Accept-Encoding")) == null
				|| !encodings.ToLower().Contains(GZIP))
				return;

			response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
			response.AppendHeader("Content-Encoding", GZIP);
			response.CacheControl = "no-cache";
        }
    }
}