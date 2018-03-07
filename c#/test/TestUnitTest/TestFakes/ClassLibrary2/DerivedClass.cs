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

        protected bool DerivedProtectedMethod(object param)
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}(object)");
            return param != null;
        }

        public void DerivedPublicMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
        }

        protected override bool BaseProtectedVirtualMethod(object param)
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}(object)");
            return base.BaseProtectedVirtualMethod(param);
        }

        public override void BasePublicVirtualMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
            base.BasePublicVirtualMethod();
        }
    }
}
