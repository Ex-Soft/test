using CommonServiceLocator;
using Unity.ServiceLocation;

namespace WinFormsApp
{
    public static class UnityActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start()
        {
            var container = UnityConfig.GetConfiguredContainer();
            var serviceProvider = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceProvider);
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}
