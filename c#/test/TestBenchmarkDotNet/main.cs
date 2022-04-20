using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace TestBenchmarkDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchy>();
        }
    }

    [MemoryDiagnoser]
    public class Benchy
    {
        private const string ClearValue = "Pessword123!";

        [Benchmark]
        public string MaskNative()
        {
            var firstChars = ClearValue.Substring(0, 3);
            var length = ClearValue.Length - 3;

            for (var i = 0; i < length; i++)
            {
                firstChars += "*";
            }

            return firstChars;
        }
    }
}

