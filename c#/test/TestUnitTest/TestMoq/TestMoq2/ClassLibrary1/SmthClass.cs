using System.Diagnostics;
using System.Reflection;

namespace ClassLibrary1
{
    public class SmthClass
    {
        private readonly IInterfaceWithMethods _worker;
        
        public SmthClass(IInterfaceWithMethods worker)
        {
            _worker = worker;
        }

        public void FooVoidVoid()
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");

            _worker.FooVoidVoid();
        }
        
        public void FooVoidVoidException()
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");

            _worker.FooVoidVoidException();
        }

        public int FooIntIntInt(int a, int b)
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");

            return _worker.FooIntIntInt(a, b);
        }

        public int FooIntIntIntException(int a, int b)
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");

            return _worker.FooIntIntIntException(a, b);
        }

        public void ExtVoidVoid()
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");

            _worker.ExtVoidVoid();
        }

        public int ExtIntIntInt(int a, int b)
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");

            return _worker.ExtIntIntInt(a, b);
        }
    }
}
