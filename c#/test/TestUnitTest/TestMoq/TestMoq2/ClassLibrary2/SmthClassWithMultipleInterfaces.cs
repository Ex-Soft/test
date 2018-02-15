using System.Diagnostics;
using System.Reflection;

namespace ClassLibrary2
{
    public interface I1
    {
        string Foo();
    }

    public interface I2
    {
        string Foo();
    }

    public interface I3
    {
        string Foo();
    }

    public class SmthClassWithInterface1 : I1
    {
        string I1.Foo()
        {
            string result;
            Debug.WriteLine(result = $"SmthClassWithInterface1.{MethodBase.GetCurrentMethod().Name}()");
            return result;
        }
    }

    public class SmthClassWithInterface12 : SmthClassWithInterface1, I2
    {
        string I2.Foo()
        {
            string result;
            Debug.WriteLine(result = $"SmthClassWithInterface12.{MethodBase.GetCurrentMethod().Name}()");
            return result;
        }
    }

    public class SmthClassWithInterface123 : SmthClassWithInterface12, I3
    {
        string I3.Foo()
        {
            string result;
            Debug.WriteLine(result = $"SmthClassWithInterface123.{MethodBase.GetCurrentMethod().Name}()");
            return result;
        }
    }

    public class SmthClassWithMultipleInterfaces
    {
        public string Run(object instance)
        {
            string result = string.Empty;

            if (instance is I1 i1)
                result += i1.Foo();
            if (instance is I2 i2)
                result += i2.Foo();
            if (instance is I3 i3)
                result += i3.Foo();

            return result;
        }
    }
}
