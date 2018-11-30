using System.Diagnostics;
using System.Threading;

namespace TestLock2
{
    class Program
    {
        static void Main()
        {
            var lockObject = new object();
            var acquiredLock = false;

            try
            {
                Debug.WriteLine("b4 Monitor.Enter()");
                Monitor.Enter(lockObject, ref acquiredLock);
                Debug.WriteLine("after Monitor.Enter()");
            }
            finally
            {
                if (acquiredLock)
                {
                    Debug.WriteLine("b4 Monitor.Exit()");
                    Monitor.Exit(lockObject);
                    Debug.WriteLine("after Monitor.Exit()");
                }
            }
        }
    }
}
