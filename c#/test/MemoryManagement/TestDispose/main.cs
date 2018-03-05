using System;
using System.Diagnostics;

namespace TestDispose
{
    class DisposableA : IDisposable
    {
        bool _disposed = false;

        public DisposableA()
        {
            Debug.WriteLine("DisposableA::DisposableA()");
        }

        ~DisposableA()
        {
            Debug.WriteLine("DisposableA::~DisposableA()");

            Dispose(false);
        }

        public void Dispose()
        {
            Debug.WriteLine("DisposableA::Dispose()");

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine(string.Format("DisposableA::Dispose({0})", disposing));

            if (!_disposed)
            {
                if (disposing)
                {

                }

                _disposed = true;
            }
        }
    }

    class DisposableB : IDisposable
    {
        bool _disposed = false;

        DisposableA
            disposableA;

        public DisposableB()
        {
            Debug.WriteLine("DisposableB::DisposableB()");

            disposableA = new DisposableA();

            throw new Exception("OOPS!");
        }

        ~DisposableB()
        {
            Debug.WriteLine("DisposableB::~DisposableB()");

            Dispose(false);
        }

        public void Dispose()
        {
            Debug.WriteLine("DisposableB::Dispose()");

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine(string.Format("DisposableB::Dispose({0})", disposing));

            if (!_disposed)
            {
                if (disposing)
                {
                    if (disposableA != null)
                        disposableA.Dispose();
                }

                _disposed = true;
            }
        }
    }

    class DisposableC : IDisposable
    {
        bool _disposed = false;

        public DisposableC()
        {
            Debug.WriteLine("DisposableC::DisposableC()");
        }

        ~DisposableC()
        {
            Debug.WriteLine("DisposableC::~DisposableC()");

            Dispose(false);
        }

        public void Dispose()
        {
            Debug.WriteLine("DisposableC::Dispose()");

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine($"DisposableC::Dispose({disposing})");

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
			var c = new DisposableC();
            var cc = c;
			c.Dispose();
            Debug.WriteLine($"c {(c != null ? "!" : "=")}= null");
            Debug.WriteLine($"cc {(cc != null ? "!" : "=")}= null");

            Foo(1);
            Foo(2);

            using (var disposable = new DisposableB())
            {
                // Упс! Метод Dispose не будет вызван ни для
                // DisposableB, ни для DisposableA
            }

            try
            {
                using (var disposable = new DisposableB())
                {
                }
            }
            catch (Exception eException)
            {
                ;
            }
        }

        static int Foo(int param = 0)
        {
            using (var disposable = new DisposableC())
            {
                if (param%2 == 0)
                    return 0;
            }

            return 1;
        }
    }
}
