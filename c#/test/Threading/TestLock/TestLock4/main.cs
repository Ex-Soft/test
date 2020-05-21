using System.Reflection;
using System.Threading;

using static System.Console;

namespace TestLock4
{
    class Lock
    {
        int _fInt;

        public int PInt
        {
            get
            {
                Thread.Sleep(500);
                return _fInt;
            }
            set
            {
                Thread.Sleep(1000);
                _fInt = value;
            }
        }

        public Lock(int pInt)
        {
            _fInt = pInt;
        }

        public override string ToString()
        {
            return $"{{PInt: {PInt}}}";
        }
    }

    class Program
    {
        static Lock _lock = new Lock(13);

        static AutoResetEvent lockerAutoResetEvent = new AutoResetEvent(false);

        static void Main()
        {
            Thread
                lockerThread = new Thread(SetLock),
                violatorThread = new Thread(Violate);

            lockerThread.Start();
            Thread.Sleep(1000);
            violatorThread.Start();
            Thread.Sleep(2000);

            lockerThread.Join();
            violatorThread.Join();

            ReadKey();
        }

        static void SetLock()
        {
            lock (_lock)
            {
                WriteLine($"{MethodBase.GetCurrentMethod().Name}() after lock()");
                WriteLine($"{MethodBase.GetCurrentMethod().Name}() {_lock}");
                lockerAutoResetEvent.WaitOne();
                WriteLine($"{MethodBase.GetCurrentMethod().Name}() after WaitOne()");
                WriteLine($"{MethodBase.GetCurrentMethod().Name}() {_lock}");
            }
        }

        static void Violate()
        {
            WriteLine($"{MethodBase.GetCurrentMethod().Name}() {_lock}");
            _lock.PInt *= _lock.PInt;
            WriteLine($"{MethodBase.GetCurrentMethod().Name}() {_lock}");
            lockerAutoResetEvent.Set();
        }
    }
}
