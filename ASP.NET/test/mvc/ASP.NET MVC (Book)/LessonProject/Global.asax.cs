using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LessonProject.App_Start;
using LessonProject.Areas.Admin;
using LessonProject.Areas.Default;
using LessonProject.Models;

namespace LessonProject
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private Thread mailThread { get; set; }

        protected void Application_Start()
        {
            PreStartApp.logger.Info("Application Start");

            var adminArea = new AdminAreaRegistration();
            var adminAreaContext = new AreaRegistrationContext(adminArea.AreaName, RouteTable.Routes);
            adminArea.RegisterArea(adminAreaContext);

            var defaultArea = new DefaultAreaRegistration();
            var defaultAreaContext = new AreaRegistrationContext(defaultArea.AreaName, RouteTable.Routes);
            defaultArea.RegisterArea(defaultAreaContext);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            mailThread = new Thread(new ThreadStart(ThreadFunc));
            mailThread.Start();

            DefaultModelBinder.ResourceClassKey = "Messages";
        }

        private static void ThreadFunc()
        {
            while (true)
            {
                try
                {
                    var mailThread = new Thread(new ThreadStart(MailThread));
                    mailThread.Start();
                    PreStartApp.logger.Info("Wait for end mail thread");
                    mailThread.Join();
                    PreStartApp.logger.Info("Sleep 60 seconds");
                }
                catch (Exception ex)
                {
                    PreStartApp.logger.Error(ex, "Thread period error");
                }
                Thread.Sleep(60000);
            }
        }

        private static void MailThread()
        {
            var repository = DependencyResolver.Current.GetService<IRepository>();
            /*while (MailProcessor.SendNextMail(repository)) { };*/
        }

        public void Init()
        {
            PreStartApp.logger.Info("Application Init");
        }

        public void Dispose()
        {
            PreStartApp.logger.Info("Application Dispose");
        }

        protected void Application_Error()
        {
            PreStartApp.logger.Info("Application Error");
        }

        protected void Application_End()
        {
            PreStartApp.logger.Info("Application End");
        }
    }
}