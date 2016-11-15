#define USE_LOAD_ASSEMBLY

using System.Reflection;
using Ninject;
using EssentialTools.Infrastructure;
using EssentialTools.Models;
using EssentialTools.Controllers;

namespace EssentialTools
{
    class Program
    {
        public static IKernel AppKernel;

        static void Main(string[] args)
        {
            #if USE_LOAD_ASSEMBLY
                AppKernel = new StandardKernel();
                AppKernel.Load(Assembly.GetExecutingAssembly());
            #else
                AppKernel = new StandardKernel(new EssentialToolsNinjectModule());
            #endif

            var homeController = new HomeController(AppKernel.Get<IValueCalculator>());

            System.Diagnostics.Debug.WriteLine(homeController.GetTotalValue());
        }
    }
}
