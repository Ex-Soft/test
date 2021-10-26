using System;
using System.Reflection;

namespace CreateObjectDynamically
{
    public class A
    {}

    public class B
    {}

    public interface IGenericClass<out T>
    {
        T Foo(string str);
    }

    public class GenericClass<T> : IGenericClass<T>
    {
        private readonly string _field1, _field2;

        public GenericClass(string param1, string param2 = null)
        {
            _field1 = param1;
            _field2 = param2;
        }

        public T Foo(string str)
        {
            T obj = Activator.CreateInstance<T>();
            System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod()?.Name}()");
            return obj;
        }

        public T Foo2(string str)
        {
            T obj = Activator.CreateInstance<T>();
            System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod()?.Name}()");
            return obj;
        }
    }
}
