using System;
using System.Diagnostics;
using System.Reflection;

namespace ClassLibrary1
{
    public class ClassWithMethods : IInterfaceWithMethods
    {
        public void FooVoidVoid()
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
        }

        public void FooVoidVoidException()
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");

            throw new NullReferenceException();
        }

        public int FooIntIntInt(int a, int b)
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");

            return a + b;
        }

        public int FooIntIntIntException(int a, int b)
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");

            throw new ArgumentNullException();
        }
    }
}
