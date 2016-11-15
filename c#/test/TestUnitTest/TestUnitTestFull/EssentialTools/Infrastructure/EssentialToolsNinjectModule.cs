using Ninject.Modules;
using EssentialTools.Models;

namespace EssentialTools.Infrastructure
{
    public class EssentialToolsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IValueCalculator>().To<LinqValueCalculator>();
            this.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);
            this.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
        }
    }
}
