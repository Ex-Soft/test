using System;
using System.Threading;
using NLog;

namespace VictimService.Victim
{
    public class Victim : IVictim
    {
        public int VictimMethod(string paramString)
        {
            var logger = LogManager.GetCurrentClassLogger();

            logger.Trace("VictimMethod(\"{0}\") started...", paramString);

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(100 * rnd.Next(10));

            var arr = paramString.Split(';');

            Thread.Sleep(100 * rnd.Next(10));

            logger.Trace("arr.Length = {0}", arr.Length);

            Thread.Sleep(100 * rnd.Next(10));

            string tmpStr = string.Empty;

            for (int i = 0; i < arr.Length; ++i)
            {
                if (!string.IsNullOrWhiteSpace(tmpStr))
                    tmpStr += ";";
                
                Thread.Sleep(100 * rnd.Next(10));

                tmpStr += arr[i];
            }

            logger.Trace("{0}: \"{1}\"", tmpStr.Length == paramString.Length ? "oB!" : "Tampax", tmpStr);

            logger.Trace("VictimMethod(\"{0}\") finished", paramString);

            Thread.Sleep(100 * rnd.Next(10));

            return arr.Length;
        }
    }
}
