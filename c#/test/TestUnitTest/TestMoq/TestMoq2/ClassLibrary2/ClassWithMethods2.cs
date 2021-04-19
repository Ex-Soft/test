using System.Diagnostics;
using System.Reflection;

namespace ClassLibrary2
{
    public class ClassWithMethods2
    {
        public virtual void VoidFooVoid()
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
        }

        public virtual void VoidFooString(string str)
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}({str})");
        }

        public virtual string StringFooString(string str)
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}({str})");
            return str;
        }

        public virtual int IntFooInt(int i)
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}({i})");
            return i;
        }
    }
}
