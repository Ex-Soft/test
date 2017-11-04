// https://stackoverflow.com/questions/46962507/why-does-a-lambda-expression-in-c-sharp-cause-a-memory-leak

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLambdaIL
{
    public class Test
    {
        public Test()
        {
            // this line causes a leak
            Func<object, bool> t = _ => true;
        }

        public void WriteFirstLine()
        {
            Console.WriteLine("Object allocated...");
        }

        public void WriteSecondLine()
        {
            Console.WriteLine("Object deallocated. Press any button to exit.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var t = new Test();
            t.WriteFirstLine();
            Console.ReadLine();
            t.WriteSecondLine();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.ReadLine();
        }
    }
}
