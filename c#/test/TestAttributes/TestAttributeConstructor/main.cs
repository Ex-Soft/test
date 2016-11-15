using System;
using System.Reflection;

namespace TestAttributeConstructor
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomAttribute : Attribute
    {
        public string SmthValueI { get; private set; }
        public string SmthValueII { get; private set; }

        public CustomAttribute() : this(string.Empty, string.Empty)
        {
            System.Diagnostics.Debug.WriteLine("CustomAttribute.CustomAttribute()");
        }

        public CustomAttribute(string smthValueI) : this(smthValueI, string.Empty)
        {
            System.Diagnostics.Debug.WriteLine("CustomAttribute.CustomAttribute(string)");
        }

        public CustomAttribute(string smthValueI, string smthValueII)
        {
            SmthValueI = smthValueI;
            SmthValueII = smthValueII;

            System.Diagnostics.Debug.WriteLine("CustomAttribute.CustomAttribute(string, string)");
        }
    }

    public class ClassWithAttributes
    {
        [CustomAttribute]
        public string FStringI { get; set; }

        [CustomAttribute("valueI")]
        public string FStringII { get; set; }

        [CustomAttribute("valueI","valueII")]
        public string FStringIII { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var victim = new ClassWithAttributes();

            ShowPropertyAttributes(typeof(ClassWithAttributes), "FStringI");
            ShowPropertyAttributes(typeof(ClassWithAttributes), "FStringII");
            ShowPropertyAttributes(typeof(ClassWithAttributes), "FStringIII");
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
        }

    }
}
