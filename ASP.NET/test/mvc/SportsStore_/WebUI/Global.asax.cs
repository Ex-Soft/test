using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Products", action = "List", id = "" } // Parameter defaults
            );
            */

            routes.MapRoute(
                null,
                "",
                new { controller = "Products", action = "List", page = 1 }
            );
            routes.MapRoute(
                null,
                "Page{page}",
                new { controller = "Products", action = "List" },
                new { page = @"\d+" }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory());
        }
    }
}