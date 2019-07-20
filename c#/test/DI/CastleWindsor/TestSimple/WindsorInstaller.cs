using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace TestSimple
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register the CompositionRoot type with the container
            container.Register(Component.For<ICompositionRoot>().ImplementedBy<CompositionRoot>());
            container.Register(Component.For<IConsoleWriter>().ImplementedBy<ConsoleWriter>());
            container.Register(Component.For<ISmthOuterInterface>().ImplementedBy<SmthOuterClass>().LifestyleTransient());
            container.Register(Component.For<ISmthInnerInterface>().ImplementedBy<SmthInnerClass>().LifestyleTransient());
            container.Register(Component.For<ILifeStyleDefault>().ImplementedBy<LifestyleDefault>());
            container.Register(Component.For<ILifestyleTransient>().ImplementedBy<LifestyleTransient>().LifestyleTransient());

            //container.Register(Component.For<ISingletonDemo>().ImplementedBy<SingletonDemo>());
            container.Register(Component.For<ISingletonDemo>().ImplementedBy<SingletonDemo>().LifestyleTransient());

            container.Register(Component.For<IClassWithCtorWithParameters>().ImplementedBy<ClassWithCtorWithParameters>()
                .LifestyleTransient()
                .DynamicParameters((kernel, parameters) => // !!! reassign container.Resolve<T>(Arguments)
                {
                    parameters["pInt"] = 13;
                    parameters["pString"] = "SmthString";
                }));

            container.Register(Component.For<IClassWithCtorWithParameters2>().ImplementedBy<ClassWithCtorWithParameters2>()
                .LifestyleTransient()
                .DependsOn(Property.ForKey<int>().Eq(13), Property.ForKey<string>().Eq("SmthString")));

            container.Register(Component.For<IClassForAppSetting>().ImplementedBy<ClassForAppSetting>()
                .LifestyleTransient()
                .DependsOn(
                    Dependency.OnValue("value1", ConfigurationManager.AppSettings["appSettingsKey1"]),
                    Dependency.OnValue("value2", ConfigurationManager.AppSettings["appSettingsKey2"])
                ));
        }
    }
}
