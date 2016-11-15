using System;

namespace TestLock
{
    class A
    {
        int _lock;

        public void Begin()
        {
            Console.WriteLine("Begin() starting... ({0})", _lock);

            if (++_lock != 1)
            {
                Console.WriteLine("Begin() return ({0})", _lock);
                return;
            }

            Console.WriteLine("Begin() finished ({0})", _lock);
        }

        public void End()
        {
            Console.WriteLine("End() starting... ({0})", _lock);

            if (_lock-- > 1)
            {
                Console.WriteLine("End() return ({0})", _lock);
                return;
            }

            Console.WriteLine("End() finished ({0})", _lock);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();

            a.Begin();
            a.Begin();
            a.Begin();
            a.End();
            a.End();
            a.End();
        }
    }
}
