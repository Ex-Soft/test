using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExceptionAwaitConApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new TaskFactory();

            try
            {
                await factory.StartNew(() => MethodWithException());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        static void MethodWithException()
        {
            throw new Exception("Tadam!!!");
        }
    }
}
