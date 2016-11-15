using System;
using System.Diagnostics;

namespace TestUsing
{
    class A : IDisposable
    {
        bool _disposed = false;

        public A()
        {
            Debug.WriteLine("A.A()");
        }

        ~A()
        {
            Debug.WriteLine("A.~A()");

            Dispose(false);
        }

        public void Dispose()
        {
            Debug.WriteLine("A.Dispose()");

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine("A::Dispose({0})", disposing);

            if (!_disposed)
            {
                if (disposing)
                {

                }

                _disposed = true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 1; ++i)
            {
                using (var a = new A())
                {
                    if (i == 0)
                        break;

                    Debug.WriteLine(a.ToString());
                }
            }

            MethodWithReturn(true);

            try
            {
                MethodWithThrow(true);
            }
            catch (Exception)
            {
            }
        }

        static void MethodWithReturn(bool @return)
        {
            using (var a = new A())
            {
                if (@return)
                    return;

                Debug.WriteLine(a.ToString());
            }
        }

        static void MethodWithThrow(bool @throw)
        {
            using (var a = new A())
            {
                if (@throw)
                    throw new Exception();

                Debug.WriteLine(a.ToString());
            }
        }
    }
}
