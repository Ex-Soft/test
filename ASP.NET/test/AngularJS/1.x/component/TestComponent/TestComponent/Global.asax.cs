/*
    https://developerhandbook.com/typescript/writing-angularjs-1-x-with-typescript/

    install-package angularjs.core
    install-package angularjs.TypeScript.DefinitelyTyped
    update-package jquery.TypeScript.DefinitelyTyped
    install-package Microsoft.AspNet.Web.Optimization

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TestComponent
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
