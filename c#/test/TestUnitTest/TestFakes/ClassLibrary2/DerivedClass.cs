namespace ClassLibrary2
{
    public class DerivedClass : BaseClass
    {
        public string DerivedProperty { get; set; }

        public DerivedClass(string derivedProperty, string baseProperty) : base(baseProperty)
        {
            DerivedProperty = derivedProperty;
        }
    }
}
