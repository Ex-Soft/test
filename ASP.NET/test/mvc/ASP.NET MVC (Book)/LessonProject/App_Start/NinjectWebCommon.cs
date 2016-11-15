using System.Web.Configuration;
using LessonProject.Global.Auth;
using LessonProject.Global.Config;
using LessonProject.Mappers;
using LessonProject.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LessonProject.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LessonProject.App_Start.NinjectWebCommon), "Stop")]

namespace LessonProject.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<LessonProjectDbDataContext>().ToMethod(c => new LessonProjectDbDataContext(WebConfigurationManager.ConnectionStrings["LessonProjectConnectionString"].ConnectionString));
            kernel.Bind<IRepository>().To<SqlRepository>().InRequestScope();
            kernel.Bind<IMapper>().To<CommonMapper>().InSingletonScope();
            kernel.Bind<IAuthentication>().To<CustomAuthentication>().InRequestScope();
            kernel.Bind<IConfig>().To<Config>().InSingletonScope();
        }        
    }
}
