using System;

namespace TestObfuscation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomAttribute : Attribute
    {
        public string SmthValue { get; private set; }

        public CustomAttribute(string smthValue)
        {
            SmthValue = smthValue;
        }
    }
}
