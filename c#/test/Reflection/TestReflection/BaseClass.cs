using System.Reflection;

namespace TestReflection
{
    public class BaseClass
    {
        private int _pInt;

        public int PInt
        {
            get { return _pInt; }
            set { _pInt = value; }
        }

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

        public void BasePublicMethod()
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
        }
    }
}
