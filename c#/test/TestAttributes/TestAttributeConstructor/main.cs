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

    public class CustomAttributeII : Attribute
    {
        protected string _stringValue;

        public virtual string StringValue
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("CustomAttributeII.get_StringValue()");
                return _stringValue;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine($"CustomAttributeII.set_StringValue({value})");
                _stringValue = value;
            }
        }

        public CustomAttributeII() : this("DefaultStringValue")
        {
            System.Diagnostics.Debug.WriteLine("CustomAttributeII.ctor()");
        }

        public CustomAttributeII(string stringValue)
        {
            System.Diagnostics.Debug.WriteLine($"CustomAttributeII.ctor({stringValue})");
            _stringValue = stringValue;
        }
    }

    public class ClassWithAttributes
    {
        [CustomAttribute]
        [CustomAttributeII]
        public string FStringI { get; set; }

        [CustomAttribute("valueI")]
        [CustomAttributeII("customAttributeIIValueII")]
        public string FStringII { get; set; }

        [CustomAttribute("valueI","valueII")]
        [CustomAttributeII(StringValue = "customAttributeIIValueIII")]
        public string FStringIII { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var victim = new ClassWithAttributes();

            ShowPropertyAttributes(typeof(ClassWithAttributes), "FStringI");
            System.Diagnostics.Debug.WriteLine(new string('-', 10));
            ShowPropertyAttributes(typeof(ClassWithAttributes), "FStringII");
            System.Diagnostics.Debug.WriteLine(new string('-', 10));
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
