// http://csharpindepth.com/Articles/Chapter6/IteratorBlockImplementation.aspx
// http://csharpindepth.com/Articles/Chapter11/StreamingAndIterators.aspx
// http://www.dotnetperls.com/yield
//#define SHOW_TRACE
#define TEST_SIMPLE
//#define TEST_SIMPLE_SIMPLE
//#define TEST_I //http://www.programminginterviews.info/2012/05/explain-c-yield-keyword-with-example.html
//#define TEST_II //http://blogs.microsoft.co.il/arnona/2010/12/21/traversing-binary-tree-using-an-iterator/
//#define TEST_III

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestYield
{
    class Program
    {
        static void Main(string[] args)
        {
            #if TEST_SIMPLE_SIMPLE
                var listInt = new List<int> { 1, 3 };

                listInt.AddRange(Power(2, 8));

                var listEven = listInt.Where(item => item % 2 == 0).ToList();
            #endif

            #if TEST_SIMPLE
                foreach (var i in Power(2, 8))
                {
                    Console.WriteLine("{0}", i);
                    Console.WriteLine();
                }

                Console.WriteLine();
            #endif

            #if TEST_I
                
                var dataset = new List<string>
                    {
                        "aaa",
                        "bbb",
                        "ccc",
                        "ddd",
                        "eee",
                        "fff",
                        "ggg",
                        "hhh",
                        "iii"
                    };

                foreach (List<string> chunks in GetChunk(dataset, 2))
                {
                    Console.WriteLine("Processing batch...size of " + chunks.Count);
                    chunks.ForEach(Console.WriteLine);
                }
                Console.WriteLine();
            #endif

            #if TEST_II
                foreach (string element in Enumerate2()) 
                { 
                    Console.WriteLine("element = '{0}'", element); 
                } 
            #endif

            #if TEST_III
                foreach (var element in Enumerate3()) 
                { 
                    Console.WriteLine("element = {0}", element); 
                } 
            #endif
        }

        #if TEST_SIMPLE || TEST_SIMPLE_SIMPLE
            public static IEnumerable<int> Power(int number, int exponent)
            {
                #if SHOW_TRACE
                    Console.WriteLine("b4 var result = 1;");
                #endif

                var result = 1;

                #if SHOW_TRACE
                    Console.WriteLine("after var result = 1;");
                #endif

                #if SHOW_TRACE
                    Console.WriteLine("b4 for (var i = 0; i < exponent; i++)");
                #endif

                for (var i = 0; i < exponent; i++)
                {
                    #if SHOW_TRACE
                        Console.WriteLine("for (var i = 0; i < exponent; i++) {{ (i = {0}, exponent = {1})", i, exponent);
                    #endif

                    #if SHOW_TRACE
                        Console.WriteLine("b4 result = result * number; (result = {0}, number = {1})", result, number);
                    #endif

                    result = result * number;

                    #if SHOW_TRACE
                        Console.WriteLine("after result = result * number; (result = {0}, number = {1})", result, number);
                    #endif

                    #if SHOW_TRACE
                        Console.WriteLine("b4 yield return result; (result = {0})", result);
                    #endif

                    yield return result;

                    #if SHOW_TRACE
                        Console.WriteLine("after yield return result; (result = {0})", result);
                    #endif

                    #if SHOW_TRACE
                        Console.WriteLine("for (var i = 0; i < exponent; i++) }} (i = {0}, exponent = {1})", i, exponent);
                    #endif
                }

                #if SHOW_TRACE
                    Console.WriteLine("after for (var i = 0; i < exponent; i++)");
                #endif
            }
        #endif

        #if TEST_I
            public static IEnumerable GetChunk(List<string> data, int chunkSize)
            {
                Console.WriteLine("GetChunk() enter");
                int currentChunkStart = 0;
                
                Console.WriteLine("GetChunk() b4 while (currentChunkStart < data.Count) (currentChunkStart={0})", currentChunkStart);
                while (currentChunkStart < data.Count)
                {
                    Console.WriteLine("GetChunk() after while (currentChunkStart < data.Count) (currentChunkStart={0})", currentChunkStart);

                    var currentChunk = data
                        .Skip(currentChunkStart)
                        .Take(chunkSize)
                        .ToList();

                    Console.WriteLine("GetChunk() b4 currentChunkStart += chunkSize; (currentChunkStart={0})", currentChunkStart);
                    currentChunkStart += chunkSize;
                    Console.WriteLine("GetChunk() after currentChunkStart += chunkSize; (currentChunkStart={0})", currentChunkStart);

                    Console.WriteLine("GetChunk() after b4 yield return currentChunk; (currentChunkStart={0})", currentChunkStart);
                    yield return currentChunk;
                    Console.WriteLine("GetChunk() after yield return currentChunk; (currentChunkStart={0})", currentChunkStart);
                }
            }
        #endif

        #if TEST_II
            static IEnumerable<string> Enumerate2()
            {
                Console.WriteLine("yield return \"this\"");
                yield return "This";
                Console.WriteLine("yield return \"is\"");
                yield return "is";
                Console.WriteLine("yield return \"a\"");
                yield return "a";
                Console.WriteLine("yield return \"very\"");
                yield return "very";
                Console.WriteLine("yield return \"simple\"");
                yield return "simple";
                Console.WriteLine("yield return \"iterator\"");
                yield return "iterator.";
            }
        #endif

        #if TEST_III
            static IEnumerable<int> Enumerate3()
            {
                for (var i = 0; i < 10; ++i)
                {
                    switch (i)
                    {
                        case 3:
                            continue;
                        case 8:
                            yield break;
                        default:
                            yield return i;
                            break;
                    }
                }
            }
        #endif

    }
}
