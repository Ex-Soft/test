using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;
using Pfz.Collections;
using Pfz.Threading;
using Pfz;
using System.Runtime.InteropServices;

namespace DictionaryAndLocksSample
{
    public delegate void ForEachDelegate(int threadIndex, IGetOrCreateValueSample sample);

	class Program
	{
		private const int _COUNT_ITERATIONS_FASTCREATOR = 1000000;
        private static readonly int _COUNT_MANY_THREADS = Environment.ProcessorCount*2;
		internal const int _COUNT_LOSETIME = 1000000;
		static void Main(string[] args)
		{
			Console.Clear();
			Console.WriteLine("Before starting, be sure you compile the application in release mode");
			Console.WriteLine("and that you execute it OUTSIDE Visual Studio. If you run inside");
			Console.WriteLine("the application code will be slower than the .Net base libraries,");
			Console.WriteLine("as the base libraries are never debugable and the application is,");
			Console.WriteLine("even if optimizations are \"active\".");
			Console.WriteLine();
			Console.WriteLine("Also, if the sample crashes with OutOfMemoryExceptions, you will need");
			Console.WriteLine("to change its constants. Sorry for that, but I wanted an extreme");
			Console.WriteLine("situation, which can be too extreme.");
			Console.WriteLine();
			Console.WriteLine("Press enter to start the tests.");
			Console.ReadLine();

			while(true)
			{
                Console.Clear();
                Console.WriteLine("First test: We will put " + _COUNT_ITERATIONS_FASTCREATOR + " values on the dictionaries, without");
                Console.WriteLine("any concurrency and using a really fast creator. This one usually gives the");
                Console.WriteLine("best performance to normal dictionaries with the simplest locks. But, as you");
                Console.WriteLine("can see, it is pretty fast for all of them.");
                Console.WriteLine();

                var allSamples = new AllSamples(false, _FastResultCreator);
                allSamples.Run(1, _FastForEach);

                Console.WriteLine();
                Console.WriteLine("Press enter to execute the second test.");
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Now we will simple read those dictionaries, without any concurrency.");
                Console.WriteLine("Here the concurrent dictionaries are usually faster as they were");
                Console.WriteLine("created to use lock-Free techniques for reading (they were slower ");
                Console.WriteLine("in the first test exactly because this lock-free support) while normal");
                Console.WriteLine("dictionaries have to use at least read locks. Also, if everything is running");
                Console.WriteLine("as expected, the ReaderWriterLockSlim should be the worst in both tests.");
                Console.WriteLine("This means, the .Net ReaderWriterLockSlim is not that slim.");
				Console.WriteLine("Note that a difference between the dictionaries of the same type");
				Console.WriteLine("that allow duplicates or not is simple luck, as they never create the value.");
                Console.WriteLine();

                allSamples.Run(1, _FastForEach);

                Console.WriteLine();
                Console.WriteLine("Press enter to execute the third test.");
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("In this third test we will do what it is supposed to do with ");
                Console.WriteLine("concurrent dictionaries or dictionaries + locks. We will access");
                Console.WriteLine("those dictionaries from many threads (ProcessorCount threads*2).");
                Console.WriteLine("In this test the multi-threaded dictionaries should be the winners,");
                Console.WriteLine("usually having very near performance values, while the");
                Console.WriteLine("Normal dictionaries should be ordered from the fastest to the slowest as:");
                Console.WriteLine("SpinReaderWriterLockSlim (my lock), full lock and .Net ReaderWriterLockSlim.");
                Console.WriteLine("Note that the dictionaries are already filled, so it will be no parallel");
                Console.WriteLine("writes. Only parallel reads, and differences on the time of dictionaries");
				Console.WriteLine("that create values in parallel or not are simple luck.");
                Console.WriteLine();

                allSamples.Run(Environment.ProcessorCount*2, _FastForEach);
                allSamples = null;

                Console.WriteLine("Press enter to execute the fourth test.");
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Now we will recreate the dictionaries. So, we will execute many threads");
                Console.WriteLine("in parallel, but the fastest threads will not find a value there");
                Console.WriteLine("and will create them. Other threads will use those created values.");
                Console.WriteLine("Here we will see the difference of creating values in parallel or not.");
                Console.WriteLine();

                allSamples = new AllSamples(true, _FastResultCreator);
                allSamples.Run(Environment.ProcessorCount*2, _FastForEach);
                allSamples = null;

                Console.WriteLine("Press enter to execute the fifth test.");
                Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Until now we had one kind of extreme situations. All threads were getting");
				Console.WriteLine("or creating the same values at the same time.");
                Console.WriteLine("But what about threads creating different values and putting them");
                Console.WriteLine("at the same time into the dictionary?");
                Console.WriteLine("This is where I believed ConcurrentDictionaries will do much");
                Console.WriteLine("better, but the reality is: They didn't. They are the worst.");
                Console.WriteLine("But wait for some explanations on the next test.");
				Console.WriteLine();

                allSamples = new AllSamples(true, _FastResultCreator);
                allSamples.Run(Environment.ProcessorCount*2, _FastNonCollidingForEach);
                allSamples = null;

                Console.WriteLine("Press enter to see the sixth test.");
                Console.ReadLine();

				_WaitTenMilliseconds();
                Console.Clear();
                Console.WriteLine("Finally we will have a little reality here (only a little).");
                Console.WriteLine("Our create values until now where really fast. Instantaneous.");
                Console.WriteLine("Why would we use a dictionary to cache results if we can call the");
                Console.WriteLine("delegate that creates the value directly and it will be faster?");
				Console.WriteLine("Ok, there are some cases (like singletons) that you may need, but");
                Console.WriteLine("one of the biggest points of dictionaries is to store data that is");
                Console.WriteLine("slow to create. So, let's create a slow creator. It takes 3 milliseconds");
				Console.WriteLine(" to do its work. That means: " + _iterationsFor3Milliseconds + " unused iterations.");
				Console.WriteLine();

                allSamples = new AllSamples(true, _SlowResultCreator);
                allSamples.Run(_COUNT_MANY_THREADS, _SlowNonCollidingForEach);
                allSamples = null;

                Console.WriteLine("Press enter to go to the final test.");
                Console.ReadLine();

                Console.Clear();
				Console.WriteLine("Now we will have a mix. All the creations will be slow, but some threads");
				Console.WriteLine("will be adding different values while others may be trying to get or create");
				Console.WriteLine("the same values in parallel.");
				Console.WriteLine();

                allSamples = new AllSamples(true, _SlowResultCreator);
                allSamples.Run(_COUNT_MANY_THREADS, _SlowSomeCollisionsForEach);
                allSamples = null;

                Console.WriteLine("Press enter to restart the tests.");
                Console.ReadLine();

				Console.Clear();
				Console.WriteLine("I lied to you. We will not restart the tests yet.");
				Console.WriteLine("But if you really want to do it, it is better. The tests at");
				Console.WriteLine("the second execution usually have a difference, that starts");
				Console.WriteLine("to become a constant. That is, the more you use it, the");
				Console.WriteLine("the results will be nearer the last result.");
				Console.WriteLine();
				Console.WriteLine("My personal conclusion is that normal dictionaries are the fastest");
				Console.WriteLine("ones for insertion. If you can get many values, use a single lock and add");
				Console.WriteLine("them into the dictionary, do it. It is safe and faster than any");
				Console.WriteLine("concurrent alternative.");
				Console.WriteLine();
				Console.WriteLine("But if you need to write from many threads, well, think about");
				Console.WriteLine("probability and constraints. I usually write only a little");
				Console.WriteLine("and read a lot into dictionaries. So, the fastest reader, the better.");
				Console.WriteLine();
                Console.WriteLine("Now, I will stop talking. Press enter to restart the tests.");
                Console.ReadLine();
			}
		}

		internal static void _Measure(int threadCount, ForEachDelegate forEachDelegate, IGetOrCreateValueSample sample)
		{
			Console.Write(sample.Message);

			using(var startCountdown = new CountdownEvent(threadCount))
			{
				using(var canStartProcessingEvent = new ManualResetEvent(false))
				{
					using(var finishCountdown = new CountdownEvent(threadCount))
					{
						for(int threadIndex=0; threadIndex<threadCount; threadIndex++)
						{
							var thread = 
								new Thread
								(
									(p) =>
									{
                                        int i = (int)p;
										startCountdown.Signal();
										canStartProcessingEvent.WaitOne();
                                        // tell that the thread is ready and wait for all threads to be ready
                                        // before starting. We should not start before all threads are created
                                        // and we should not consider the time to create the thread on our results.

                                        forEachDelegate(i, sample);

										finishCountdown.Signal();
									}	
								);

							thread.Start(threadIndex);
						}

                        // wait until all threads are created to start the stopwatch.
						startCountdown.Wait();
						var stopwatch = new Stopwatch();
						stopwatch.Start();
						canStartProcessingEvent.Set();
                        // now we let all threads run. We should wait until all of them
                        // finish to know the real result.
						finishCountdown.Wait();
						stopwatch.Stop();

						Console.WriteLine(stopwatch.Elapsed);
					}
				}
			}
		}

        private static void _FastForEach(int threadIndex, IGetOrCreateValueSample sample)
        {
            for(int i=0; i<_COUNT_ITERATIONS_FASTCREATOR; i++)
                if (sample.GetOrCreate(i*7) != -i*7)
                    throw new Exception("An invalid result was got.");
        }
        private static void _FastNonCollidingForEach(int threadIndex, IGetOrCreateValueSample sample)
        {
            int min = threadIndex * _COUNT_ITERATIONS_FASTCREATOR;
            int max = min + _COUNT_ITERATIONS_FASTCREATOR;

            for(int i=min; i<max; i++)
            {
                if (sample.GetOrCreate(i) != -i)
                    throw new Exception("An invalid result was got.");
            }
        }
        private static void _SlowNonCollidingForEach(int threadIndex, IGetOrCreateValueSample sample)
        {
            int multiplier = _COUNT_MANY_THREADS;

            for(long i=0; i<_iterationsFor3Milliseconds; i++)
            {
                int value = (int)((i * multiplier) + threadIndex);
                if (sample.GetOrCreate(value) != -value)
                    throw new Exception("An invalid result was got.");
            }
        }
        private static void _SlowSomeCollisionsForEach(int threadIndex, IGetOrCreateValueSample sample)
        {
            int multiplier = _COUNT_MANY_THREADS;

            for(long i=0; i<_iterationsFor3Milliseconds; i++)
            {
                int value = (int)i*threadIndex;
                if (sample.GetOrCreate(value) != -value)
                    throw new Exception("An invalid result was got.");
            }
        }

		private static readonly TimeSpan _3Milliseconds = TimeSpan.FromMilliseconds(3);
		private static long _iterationsFor3Milliseconds;
		private static void _WaitTenMilliseconds()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			while(stopwatch.Elapsed < _3Milliseconds)
				_iterationsFor3Milliseconds++;
		}

		private static int _SlowResultCreator(int value)
		{
            // lose some time to simulate a slow creation.
			for(long i=0; i<_iterationsFor3Milliseconds; i++)
			{
				// yeah, a for to do nothing.
			}

			return -value;
		}
		private static int _FastResultCreator(int value)
		{
			return -value;
		}
    }
}
