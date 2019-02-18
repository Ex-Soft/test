// https://www.codementor.io/copperstarconsulting/getting-started-with-dependency-injection-using-castle-windsor-4meqzcsvh

using System;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace TestSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            // Register the CompositionRoot type with the container
            container.Register(Component.For<ICompositionRoot>().ImplementedBy<CompositionRoot>());
            container.Register(Component.For<IConsoleWriter>().ImplementedBy<ConsoleWriter>());

            //container.Register(Component.For<ISingletonDemo>().ImplementedBy<SingletonDemo>());
            container.Register(Component.For<ISingletonDemo>().ImplementedBy<SingletonDemo>().LifestyleTransient());

            container.Register(Component.For<IClassWithCtorWithParameters>().ImplementedBy<ClassWithCtorWithParameters>()
                .LifestyleTransient()
                .DynamicParameters((kernel, parameters) =>
                {
                    parameters["pInt"] = 13;
                    parameters["pString"] = "SmthString";
                }));

            container.Register(Component.For<IClassWithCtorWithParameters2>().ImplementedBy<ClassWithCtorWithParameters2>()
                .LifestyleTransient()
                .DependsOn(Property.ForKey<int>().Eq(13), Property.ForKey<string>().Eq("SmthString")));

            // Resolve an object of type ICompositionRoot (ask the container for an instance)
            // This is analagous to calling new() in a non-IoC application.
            var root = container.Resolve<ICompositionRoot>();

            root.LogMessage("Hello from my very first resolved class!");

            IClassWithCtorWithParameters
                classWithCtorWithParameters1 = container.Resolve<IClassWithCtorWithParameters>(),
                classWithCtorWithParameters2 = container.Resolve<IClassWithCtorWithParameters>(new { pInt = 26, pString = "SmthStringSmthString" }),
                classWithCtorWithParameters3 = container.Resolve<IClassWithCtorWithParameters>(new Arguments(new { pInt = 39, pString = "SmthStringSmthStringSmthString" }));

            Console.WriteLine(new String('-', 60));
            root.LogMessage(classWithCtorWithParameters1.ToString()); // {pInt:13, pString:"SmthString"}
            root.LogMessage(classWithCtorWithParameters2.ToString()); // {pInt:13, pString:"SmthString"}
            root.LogMessage(classWithCtorWithParameters3.ToString()); // {pInt:13, pString:"SmthString"}

            IClassWithCtorWithParameters2
                classWithCtorWithParameters21 = container.Resolve<IClassWithCtorWithParameters2>(),
                classWithCtorWithParameters22 = container.Resolve<IClassWithCtorWithParameters2>(new { pInt = 26, pString = "SmthStringSmthString" }),
                classWithCtorWithParameters23 = container.Resolve<IClassWithCtorWithParameters2>(new Arguments(new { pInt = 39, pString = "SmthStringSmthStringSmthString" }));

            Console.WriteLine(new string('-', 60));
            root.LogMessage(classWithCtorWithParameters21.ToString()); // {pInt:13, pString:"SmthString"}
            root.LogMessage(classWithCtorWithParameters22.ToString()); // {pInt:26, pString:"SmthStringSmthString"}
            root.LogMessage(classWithCtorWithParameters23.ToString()); // {pInt:39, pString:"SmthStringSmthStringSmthString"}

            // Wait for user input so they can check the program's output.
            Console.ReadLine();
        }
    }
}
