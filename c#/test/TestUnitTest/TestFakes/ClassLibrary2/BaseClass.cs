using System.Reflection;

namespace ClassLibrary2
{
    public class BaseClass
    {
        public string BaseProperty { get; set; }

        public BaseClass(string baseProperty)
        {
            BaseProperty = baseProperty;
        }

        void BasePrivateMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}() {{BaseProperty: \"{BaseProperty}\"}}");
        }

        protected void BaseProtectedMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
        }

        protected virtual bool BaseProtectedVirtualMethod(object param)
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}(object)");
            return param != null;
        }

        public void BasePublicMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
        }

        public virtual void BasePublicVirtualMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
        }
    }
}
