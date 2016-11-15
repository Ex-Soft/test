using System;
using System.Collections.Generic;
using System.Threading;

namespace TestVictimServiceDirect
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxThread = 3;

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < maxThread; ++i)
            {
                Thread thread = new Thread(RunVicimMethod);
                thread.Name = string.Format("Thread#{0}", i);
                threads.Add(thread);
                thread.Start(i);
            }

            Console.ReadLine();
        }

        static void RunVicimMethod(object data)
        {
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            int paramCount = (int)data * rnd.Next(10);
            string paramStr = string.Empty;

            if (paramCount <= 0)
                paramCount = 1;

            for (int i = 0; i < paramCount; ++i)
            {
                if (!string.IsNullOrWhiteSpace(paramStr))
                    paramStr += ";";

                paramStr += ((int)data * rnd.Next(10)).ToString();
            }

            try
            {
                VictimService.Victim.IVictim victim = new VictimService.Victim.Victim();
                var result = victim.VictimMethod(paramStr);
                System.Diagnostics.Debug.WriteLine("result = {0} {1}", result, result == paramCount ? "oB!" : "Tampax");
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
