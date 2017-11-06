using System.Reflection;

namespace TestReflection
{
    public class DerivedClass : BaseClass
    {
        public string DerivedProperty { get; set; }

        public DerivedClass(string derivedProperty, string baseProperty) : base(baseProperty)
        {
            DerivedProperty = derivedProperty;
        }

        void DerivedPrivateMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}() {{DerivedProperty: \"{DerivedProperty}\", BaseProperty: \"{BaseProperty}\"}}");
        }

        protected void DerivedProtectedMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
        }

        public void DerivedPublicMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
        }
    }
}
