// https://thecsharper.com/?p=277

using System;
using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace TestExceptionDispatchInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var exceptions = new BlockingCollection<ExceptionDispatchInfo>();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    ThrowOne();
                }
                catch (Exception ex)
                {
                    var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);

                    exceptions.Add(exceptionDispatchInfo);
                }
                exceptions.CompleteAdding();
            });

            foreach (var exceptionDispatchInfo in exceptions.GetConsumingEnumerable())
            {
                try
                {
                    exceptionDispatchInfo.Throw();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}", ex);
                }
            }

            Console.ReadKey();
        }

        private static void ThrowOne()
        {
            Console.WriteLine("Throw Not Supported Exception");

            ThrowTwo();

            throw new NotSupportedException();
        }

        private static void ThrowTwo()
        {
            Console.WriteLine("Throw Not Implemented Exception");

            ThrowThree();

            throw new NotImplementedException();
        }

        private static void ThrowThree()
        {
            Console.WriteLine("Throw Argument Null Exception");

            throw new ArgumentNullException();
        }
    }
}
