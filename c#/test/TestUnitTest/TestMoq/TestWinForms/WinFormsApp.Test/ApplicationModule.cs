using Ninject.Modules;
using WinFormsApp.Domain;

namespace WinFormsApp.Test
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISmthEntity>().To<SmthEntity>();
            Bind<ISmthEntities>().To<SmthEntities>();
        }
    }
}
