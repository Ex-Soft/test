using System;
using System.Reflection;

namespace TestAttributesInheritance
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SingleBaseAttribute : Attribute
    {
        public string SmthBaseValue { get; private set; }

        public SingleBaseAttribute(string smthBaseValue)
        {
            SmthBaseValue = smthBaseValue;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class SingleDerivedAttribute : SingleBaseAttribute
    {
        public string SmthDerivedValue { get; private set; }

        public SingleDerivedAttribute(string smthBaseValue, string smthDerivedValue) : base(smthBaseValue)
        {
            SmthDerivedValue = smthDerivedValue;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class OverridedAttribute : Attribute
    {
        public string SmthValue { get; private set; }

        public OverridedAttribute(string smthValue)
        {
            SmthValue = smthValue;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class AttributeForBaseClass : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class AttributeForDerivedClass : Attribute
    {
    }

    class Base
    {
        private string _stringField;

        [SingleBaseAttribute("Base")]
        [OverridedAttribute("Base")]
        [AttributeForBaseClass]
        public virtual string StringAutoProperty { get; set; }

        [SingleBaseAttribute("Base")]
        [AttributeForBaseClass]
        public virtual string StringProperty
        {
            get { return GetStringField(); }
            set { SetStringField(value); }
        }

        protected virtual string GetStringField()
        {
            return _stringField;
        }

        protected virtual void SetStringField(string value)
        {
            if (!string.Equals(_stringField, value))
                _stringField = value;
        }

        public Base(Base obj) : this(obj.StringAutoProperty, obj.StringProperty)
        {}

        public Base(string stringAutoProperty = "", string stringProperty = "")
        {
            StringAutoProperty = stringAutoProperty;
            StringProperty = stringProperty;
        }

        public override string ToString()
        {
            return string.Format("{{StringAutoProperty: \"{0}\", StringProperty: \"{1}\"}}", StringAutoProperty, StringProperty);
        }
    }

    class Derived : Base
    {
        [SingleBaseAttribute("Derived")]
        [OverridedAttribute("Derived")]
        [AttributeForDerivedClass]
        public override string StringAutoProperty { get; set; }

        [SingleDerivedAttribute("Derived", "Derived")]
        [AttributeForDerivedClass]
        public override string StringProperty
        {
            get { return GetStringField(); }
            set { SetStringField(value); }
        }

        protected override void SetStringField(string value)
        {
            base.SetStringField(string.Format("Set from Derived \"{0}\"", value));
        }

        protected override string GetStringField()
        {
            return string.Format("Get from Derived \"{0}\"", base.GetStringField());
        }

        public Derived(Derived obj) : this(obj.StringAutoProperty, obj.StringProperty)
        {}

        public Derived(string stringAutoProperty = "", string stringProperty = "") : base(stringAutoProperty, stringProperty)
        {}
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Attribute.IsAssignableFrom(AttributeForBaseClass) (Attribute->AttributeForBaseClass): {0}", typeof(Attribute).IsAssignableFrom(typeof(AttributeForBaseClass)));
            Console.WriteLine("AttributeForBaseClass.IsAssignableFrom(Attribute) (AttributeForBaseClass->Attribute): {0}", typeof(AttributeForBaseClass).IsAssignableFrom(typeof(Attribute)));
            Console.WriteLine("Attribute.IsAssignableFrom(AttributeForDerivedClass) (Attribute->AttributeForDerivedClass): {0}", typeof(Attribute).IsAssignableFrom(typeof(AttributeForDerivedClass)));
            Console.WriteLine("AttributeForDerivedClass.IsAssignableFrom(Attribute) (AttributeForDerivedClass->Attribute): {0}", typeof(AttributeForDerivedClass).IsAssignableFrom(typeof(Attribute)));

            var b = new Base("BaseStringAutoProperty", "BaseStringProperty");
            Console.WriteLine(b);

            var d = new Derived("DerivedStringAutoProperty", "DerivedStringProperty");
            Console.WriteLine(d);

            ShowPropertyAttributes(b.GetType(), "StringAutoProperty");
            ShowPropertyAttributes(d.GetType(), "StringAutoProperty");
            Console.WriteLine();

            ShowPropertyAttributes(b.GetType(), "StringProperty");
            ShowPropertyAttributes(d.GetType(), "StringProperty");
            Console.WriteLine();
        }

        static void ShowPropertyAttributes(Type type, string propertyName)
        {
            PropertyInfo pi;
            if ((pi = type.GetProperty(propertyName)) == null)
                return;

            Console.WriteLine(new string('-', 60));

            foreach(var attribute in Attribute.GetCustomAttributes(pi))
                Console.WriteLine("Type: \"{0}\" Attribute.Type: \"{1}\"{2}", type.Name, attribute.GetType().Name, attribute is SingleBaseAttribute ? string.Format(" SmthBaseValue: \"{0}\"", ((SingleBaseAttribute)attribute).SmthBaseValue) : (attribute is OverridedAttribute ? string.Format(" SmthValue: \"{0}\"", ((OverridedAttribute)attribute).SmthValue) : string.Empty));
            Console.WriteLine();

            var attributeForBaseClass = Attribute.GetCustomAttribute(pi, typeof(AttributeForBaseClass)) as AttributeForBaseClass;
            Console.WriteLine("Type: \"{0}\" Property: \"{1}\" Attribute: \"AttributeForBaseClass\" {2}", type.Name, pi.Name, attributeForBaseClass != null ? "exists" : "doesn't exist");

            var attributeForDerivedClass = Attribute.GetCustomAttribute(pi, typeof(AttributeForDerivedClass)) as AttributeForDerivedClass;
            Console.WriteLine("Type: \"{0}\" Property: \"{1}\" Attribute: \"AttributeForDerivedClass\" {2}", type.Name, pi.Name, attributeForDerivedClass != null ? "exists" : "doesn't exist");

            Console.WriteLine(new string('-', 60));
        }
    }
}
