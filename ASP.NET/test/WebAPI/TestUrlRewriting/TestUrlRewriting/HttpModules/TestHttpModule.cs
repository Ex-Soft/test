using System;
using System.Diagnostics;
using System.Web;

namespace TestUrlRewriting.HttpModules
{
    public class TestHttpModule : IHttpModule
    {
        public void Dispose()
        { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.RequestCompleted += context_RequestCompleted;
        }

        void context_RequestCompleted(object sender, EventArgs e)
        {
            Debug.WriteLine("Module_RequestCompleted event fired.");
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            if(sender is HttpApplication app)
            {
                Debug.WriteLine($"Module_BeginRequest event fired {app.Context.Request.Url}");
            }
        }
    }
}