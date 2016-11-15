using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.App_Start;
using SportsStore.WebUI.Infrastructure.Binders;

namespace SportsStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
