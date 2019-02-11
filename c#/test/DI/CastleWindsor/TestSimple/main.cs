// https://www.codementor.io/copperstarconsulting/getting-started-with-dependency-injection-using-castle-windsor-4meqzcsvh

using System;
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

            container.Register(Component.For<IClassWithCtorWithParameters>().ImplementedBy<ClassWithCtorWithParameters>().DynamicParameters((kernel, parameters) => { parameters["pInt"] = 13; parameters["pString"] = "SmthString"; }));

            // Resolve an object of type ICompositionRoot (ask the container for an instance)
            // This is analagous to calling new() in a non-IoC application.
            var root = container.Resolve<ICompositionRoot>();

            root.LogMessage("Hello from my very first resolved class!");

            IClassWithCtorWithParameters
                classWithCtorWithParameters1 = container.Resolve<IClassWithCtorWithParameters>(),
                classWithCtorWithParameters2 = container.Resolve<IClassWithCtorWithParameters>(new { pInt = 26, pString = "SmthStringSmthString" });

            root.LogMessage(classWithCtorWithParameters1.ToString());
            root.LogMessage(classWithCtorWithParameters2.ToString());

            // Wait for user input so they can check the program's output.
            Console.ReadLine();
        }
    }
}
