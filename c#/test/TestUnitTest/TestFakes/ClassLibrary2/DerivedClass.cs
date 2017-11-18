using System.Reflection;

namespace ClassLibrary2
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

        protected override void BaseProtectedVirtualMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
            base.BaseProtectedVirtualMethod();
        }

        public override void BasePublicVirtualMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
            base.BasePublicVirtualMethod();
        }
    }
}
