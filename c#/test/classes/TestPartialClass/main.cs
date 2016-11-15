using System;
using System.Reflection;

namespace TestPartialClass
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowPropertyAttributes(typeof(A), "FStringI");
            ShowPropertyAttributes(typeof(A), "FStringII");
        }

        static void ShowPropertyAttributes(Type type, string propertyName)
        {
            PropertyInfo pi;
            if ((pi = type.GetProperty(propertyName)) == null)
                return;

            Console.WriteLine(new string('-', 60));

            foreach (var attribute in Attribute.GetCustomAttributes(pi))
                Console.WriteLine("Type: \"{0}\" Attribute.Type: \"{1}\"{2}", type.Name, attribute.GetType().Name, attribute);
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));

            foreach (var attribute in pi.GetCustomAttributes(typeof(CustomAttribute), true))
                Console.WriteLine("Type: \"{0}\" Attribute.Type: \"{1}\"{2}", type.Name, attribute.GetType().Name, attribute);
            Console.WriteLine();

            Console.WriteLine(new string('-', 60));
        }
    }
}

