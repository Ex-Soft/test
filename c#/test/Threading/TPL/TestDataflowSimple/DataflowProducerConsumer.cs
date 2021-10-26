using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

using static System.Console;

namespace TestDataflowSimple
{
    public class DataflowProducerConsumer
    {
        static void Produce(ITargetBlock<int> target)
        {
            for (var i = 0; i < 100; ++i)
            {
                target.Post(i);
            }

            target.Complete();
        }

        static async Task<List<int>> ConsumeAsync(IReceivableSourceBlock<int> source, int number)
        {
            List<int> result = new();
            
            while (await source.OutputAvailableAsync())
            {
                while (source.TryReceive(out var data))
                {
                    WriteLine($"{number}\t{data}");
                    result.Add(data);
                }
            }

            return result;
        }

        public static void Run()
        {
            var bufferBlock = new BufferBlock<int>();
            var consumer1Task = ConsumeAsync(bufferBlock, 1);
            var consumer2Task = ConsumeAsync(bufferBlock, 2);
            Produce(bufferBlock);

            Task.WaitAll(consumer1Task, consumer2Task);

            List<int>
                result1 = consumer1Task.Result,
                result2 = consumer2Task.Result;

            var result = result1.Intersect(result2).ToArray();
            result = result2.Intersect(result1).ToArray();
        }
    }
}
