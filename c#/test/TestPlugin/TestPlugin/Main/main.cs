using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                pluginDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            string[]
                pluginAssemblies = Directory.GetFiles(pluginDir, "*.dll");

            List<Type>
                pluginTypes=new List<Type>();

            foreach (string file in pluginAssemblies)
            {
                Assembly
                    pluginAssembly = Assembly.LoadFrom(file);

                foreach (Type t in pluginAssembly.GetExportedTypes())
                {
                    if(t.IsClass && typeof(IPlugin.IPlugin).IsAssignableFrom(t))
                        pluginTypes.Add(t);
                }
            }

            pluginTypes.ForEach(item =>
                                    {
                                        IPlugin.IPlugin
                                            ai = (IPlugin.IPlugin)Activator.CreateInstance(item);

                                        Console.WriteLine(ai.DoSomething(5));
                                    });
        }
    }
}
