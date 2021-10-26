// https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/dataflow-task-parallel-library

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

using static System.Console;

namespace TestDataflowSimple
{
    class Program
    {
        public static void Processor(int message)
        {
            if (message % 2 == 0)
            {
                throw new Exception(message.ToString());
            }
        }

        public static void OnOk(int message)
        {
            WriteLine($"OnOk: {message}");
        }

        public static void OnError(int message)
        {
            WriteLine($"OnError: {message}");
        }

        static void Main(string[] args)
        {
            DataflowBlockEncapsulate.Run();
            SlidingWindow.Run();

            var consumer = new Builder<int>()
                .SetProcessor(Processor)
                .SetOnOk(OnOk)
                .SetOnError(OnError)
                .Build();

            for (var i = 0; i < 10; ++i)
            {
                consumer.Post(i);
            }

            DataflowProducerConsumer.Run();

            #region Dataflow Block Completion
            
            var throwIfNegative = new ActionBlock<int>(n =>
            {
                WriteLine($"n = {n}");
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            });

            throwIfNegative.Completion.ContinueWith(task =>
            {
                WriteLine($"The status of the completion task is '{task.Status}'.");
            });

            throwIfNegative.Post(0);
            throwIfNegative.Post(-1);
            throwIfNegative.Post(1);
            throwIfNegative.Post(-2);
            throwIfNegative.Complete();

            try
            {
                throwIfNegative.Completion.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    WriteLine($"Encountered {e.GetType().Name}: {e.Message}");
                    return true;
                });
            }

            #endregion

            #region Predefined Dataflow Block Types

            #region BufferBlock
            var bufferBlock = new BufferBlock<int>();
            for (var i = 0; i < 3; i++)
            {
                bufferBlock.Post(i);
            }
            for (var i = 0; i < 3; i++)
            {
                WriteLine(bufferBlock.Receive());
            }
            
            for (var i = 0; i < 3; i++)
            {
                bufferBlock.Post(i);
            }
            while (bufferBlock.TryReceive(out var value))
            {
                WriteLine(value);
            }

            var post01 = Task.Run(() =>
            {
                bufferBlock.Post(0);
                bufferBlock.Post(1);
            });
            var receive = Task.Run(() =>
            {
                for (var i = 0; i < 3; i++)
                {
                    WriteLine(bufferBlock.Receive());
                }
            });
            var post2 = Task.Run(() =>
            {
                bufferBlock.Post(2);
            });

            Task.WhenAll(post01, receive, post2).Wait();
            #endregion

            var broadcastBlock = new BroadcastBlock<double>(null);
            broadcastBlock.Post(Math.PI);
            for (var i = 0; i < 3; i++)
            {
                WriteLine(broadcastBlock.Receive());
            }

            var writeOnceBlock = new WriteOnceBlock<string>(null);
            Parallel.Invoke(
                () => writeOnceBlock.Post("Message 1"),
                () => writeOnceBlock.Post("Message 2"),
                () => writeOnceBlock.Post("Message 3"));
            WriteLine(writeOnceBlock.Receive());

            #endregion

            #region Execution Blocks

            var actionBlock = new ActionBlock<int>(WriteLine);
            for (var i = 0; i < 3; i++)
            {
                actionBlock.Post(i * 10);
            }
            actionBlock.Complete();
            actionBlock.Completion.Wait();

            var transformBlock = new TransformBlock<int, double>(n => Math.Sqrt(n));
            transformBlock.Post(10);
            transformBlock.Post(20);
            transformBlock.Post(30);
            for (var i = 0; i < 3; i++)
            {
                WriteLine(transformBlock.Receive());
            }

            var transformManyBlock = new TransformManyBlock<string, char>(s => s.ToCharArray());
            transformManyBlock.Post("Hello");
            transformManyBlock.Post("World");
            for (var i = 0; i < ("Hello" + "World").Length; i++)
            {
                WriteLine(transformManyBlock.Receive());
            }

            #endregion

            #region Grouping Blocks

            var batchBlock = new BatchBlock<int>(10);
            for (var i = 0; i < 13; i++)
            {
                batchBlock.Post(i);
            }
            batchBlock.Complete();
            WriteLine($"The sum of the elements in batch 1 is {batchBlock.Receive().Sum()}.");
            WriteLine($"The sum of the elements in batch 2 is {batchBlock.Receive().Sum()}.");

            var joinBlock = new JoinBlock<int, int, char>();

            joinBlock.Target1.Post(3);
            joinBlock.Target1.Post(6);

            joinBlock.Target2.Post(5);
            joinBlock.Target2.Post(4);

            joinBlock.Target3.Post('+');
            joinBlock.Target3.Post('-');

            for (var i = 0; i < 2; i++)
            {
                var data = joinBlock.Receive();
                switch (data.Item3)
                {
                    case '+':
                        WriteLine($"{data.Item1} {data.Item3} {data.Item2} = {data.Item1 + data.Item2}"); // 3 + 5 = 8
                        break;
                    case '-':
                        WriteLine($"{data.Item1} {data.Item3} {data.Item2} = {data.Item1 - data.Item2}"); // 6 - 4 = 2
                        break;
                    default:
                        WriteLine($"Unknown operator '{data.Item3}'.");
                        break;
                }
            }

            Func<int, int> DoWork = n =>
            {
                if (n < 0)
                    throw new ArgumentOutOfRangeException();
                return n;
            };

            var batchedJoinBlock = new BatchedJoinBlock<int, Exception>(7);

            foreach (var i in new int[] { 5, 6, -7, -22, 13, 55, 0 })
            {
                try
                {
                    batchedJoinBlock.Target1.Post(DoWork(i));
                }
                catch (ArgumentOutOfRangeException e)
                {
                    batchedJoinBlock.Target2.Post(e);
                }
            }

            var results = batchedJoinBlock.Receive();
            foreach (var n in results.Item1)
            {
                WriteLine(n);
            }
            foreach (Exception e in results.Item2)
            {
                WriteLine(e.Message);
            }
            
            #endregion
        }
    }
}
