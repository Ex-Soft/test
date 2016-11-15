using System;
using System.Collections.Generic;

namespace TestDisposeInSTL
{
    class DisposableA : IDisposable
    {
        bool _disposed = false;

        public DisposableA()
        {
            System.Diagnostics.Debug.WriteLine("DisposableA::DisposableA()");
        }

        ~DisposableA()
        {
            System.Diagnostics.Debug.WriteLine("DisposableA::~DisposableA()");

            Dispose(false);
        }

        public void Dispose()
        {
            System.Diagnostics.Debug.WriteLine("DisposableA::Dispose()");

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("DisposableA::Dispose({0})", disposing));

            if (_disposed)
                return;

            if (disposing)
            {

            }

            _disposed = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<DisposableA>();

            for (var i = 0; i < 3; ++i)
                l.Add(new DisposableA());
        }
    }
}
