﻿// https://www.codementor.io/copperstarconsulting/getting-started-with-dependency-injection-using-castle-windsor-4meqzcsvh

using System;
using System.Collections.Generic;
using Castle.MicroKernel;
using Castle.Windsor;

namespace TestSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new WindsorInstaller());

            foreach (var handler in container.Kernel.GetAssignableHandlers(typeof(object)))
            {
                Console.WriteLine("{0} {1}",
                    handler.ComponentModel.Services,
                    handler.ComponentModel.Implementation);
            }

            // Resolve an object of type ICompositionRoot (ask the container for an instance)
            // This is analagous to calling new() in a non-IoC application.
            var root = container.Resolve<ICompositionRoot>();

            root.LogMessage("Hello from my very first resolved class!");

            IClassWithCtorWithParameters
                classWithCtorWithParameters1 = container.Resolve<IClassWithCtorWithParameters>(),
                classWithCtorWithParameters2 = container.Resolve<IClassWithCtorWithParameters>(new [] { new KeyValuePair<string, object>("pInt", 26), new KeyValuePair<string, object>("pString", "SmthStringSmthString") }),
                classWithCtorWithParameters3 = container.Resolve<IClassWithCtorWithParameters>(new Arguments { { "pInt", 39 }, { "pString", "SmthStringSmthStringSmthString" } });

            Console.WriteLine(new String('-', 60));
            root.LogMessage(classWithCtorWithParameters1.ToString()); // {pInt:13, pString:"SmthString"}
            root.LogMessage(classWithCtorWithParameters2.ToString()); // {pInt:13, pString:"SmthString"}
            root.LogMessage(classWithCtorWithParameters3.ToString()); // {pInt:13, pString:"SmthString"}

            IClassWithCtorWithParameters2
                classWithCtorWithParameters21 = container.Resolve<IClassWithCtorWithParameters2>(),
                classWithCtorWithParameters22 = container.Resolve<IClassWithCtorWithParameters2>(new [] { new KeyValuePair<string, object>("pInt", 26), new KeyValuePair<string, object>("pString", "SmthStringSmthString") }),
                classWithCtorWithParameters23 = container.Resolve<IClassWithCtorWithParameters2>(new Arguments { { "pInt", 39}, {"pString", "SmthStringSmthStringSmthString" }});

            Console.WriteLine(new string('-', 60));
            root.LogMessage(classWithCtorWithParameters21.ToString()); // {pInt:13, pString:"SmthString"}
            root.LogMessage(classWithCtorWithParameters22.ToString()); // {pInt:26, pString:"SmthStringSmthString"}
            root.LogMessage(classWithCtorWithParameters23.ToString()); // {pInt:39, pString:"SmthStringSmthStringSmthString"}

            IClassForAppSetting
                classForAppSetting1 = container.Resolve<IClassForAppSetting>(),
                classForAppSetting2 = container.Resolve<IClassForAppSetting>();

            ISmthOuterInterface
                smthOuterInterface = container.Resolve<ISmthOuterInterface>();

            smthOuterInterface.Foo1();

            ILifeStyleDefault
                lifeStyleDefault1 = container.Resolve<ILifeStyleDefault>(),
                lifeStyleDefault2 = container.Resolve<ILifeStyleDefault>();

            lifeStyleDefault1.PString1 = "PString1 from lifeStyleDefault1";
            root.LogMessage(lifeStyleDefault2.PString1);

            ILifestyleTransient
                lifestyleTransient1 = container.Resolve<ILifestyleTransient>(),
                lifestyleTransient2 = container.Resolve<ILifestyleTransient>();

            lifestyleTransient1.PString1 = "PString1 from lifestyleTransient1";
            root.LogMessage(lifestyleTransient2.PString1);

            Console.ReadKey();
        }
    }
}
