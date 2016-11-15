// http://stackoverflow.com/questions/14127763/dependency-injection-in-winforms-using-ninject-and-entity-framework

using Ninject;
using Ninject.Modules;

namespace WinFormsApp
{
    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}
