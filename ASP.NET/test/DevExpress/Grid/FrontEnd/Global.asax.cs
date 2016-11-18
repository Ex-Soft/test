using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DevExpress.Web.Mvc;

namespace FrontEnd
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.DefaultBinder = new DevExpressEditorsBinder();
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            DevExpressHelper.Theme = "Aqua";
        }
    }
}
