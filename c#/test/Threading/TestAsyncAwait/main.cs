//#define TEST_MSDN // https://msdn.microsoft.com/en-us/library/hh191443.aspx
//#define TEST_TEPLYAKOV // http://sergeyteplyakov.blogspot.com/2010/12/c-5.html
//#define TEST_TEPLYAKOV_ASYNC_VER
//#define TEST_TEPLYAKOV_ASYNC_VER_2
#define TEST_FILE_STREAM

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TestAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            #if TEST_FILE_STREAM
                string x = string.Empty;

                Task.Run(async () => {
                    x = await GetMD5("results.txt");
                }).Wait();

                Console.WriteLine(x);
            #endif

            #if TEST_MSDN
                TestAsyncAwaitMethods();
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            #endif

            #if TEST_TEPLYAKOV
                try
                {
                    Console.WriteLine("Main thread id: {0}", Thread.CurrentThread.ManagedThreadId);

                    var task = Task.Factory.StartNew(
                        #if !TEST_TEPLYAKOV_ASYNC_VER_2
                            AsyncVersion
                        #else
                            AsyncVersion2
                        #endif
                        );
                    
                
                    Console.WriteLine("Right after AsyncVersion() method call");

                    task.Wait();
                    Console.WriteLine("Asyncronous task finished!");
                }
                catch (AggregateException e)
                {
                    Console.WriteLine("AggregateException: {0}", e.InnerException.Message);
                }
                Console.ReadLine();
            #endif
        }

        #if TEST_FILE_STREAM

            static async Task<string> GetMD5(string fullName)
            {
                Debug.WriteLine("GetMD5(string fullName) starting...");

                var md5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] fileFirstBytes = await GetFirstBytes(fullName);
                byte[] md5 = md5CryptoServiceProvider.ComputeHash(fileFirstBytes);
                var stringBuilder = new StringBuilder();

			    foreach (byte b in md5)
				    stringBuilder.Append(b.ToString("x2").ToLower());

                Debug.WriteLine("GetMD5(string fullName) finished");

                return stringBuilder.ToString();
            }

            static async Task<byte[]> GetFirstBytes(string fullName)
            {
                Debug.WriteLine("GetFirstBytes(string fullName) starting...");

                const int FirstBytesCount = 100;

                byte[] result;

                using (var fileStream = File.Open(fullName, FileMode.Open))
                {
                    int bytesCount = (int)(fileStream.Length < FirstBytesCount ? fileStream.Length : FirstBytesCount);
                    result = new byte[bytesCount];
                    await fileStream.ReadAsync(result, 0, bytesCount);
                }

                Debug.WriteLine("GetFirstBytes(string fullName) finished");

                return result;
            }

        #endif

        #if TEST_MSDN
            public static async void TestAsyncAwaitMethods()
            {
                await LongRunningMethod();
            }

            public static async Task<int> LongRunningMethod()
            {
                Console.WriteLine("Starting Long Running method...");
                await Task.Delay(5000);
                Console.WriteLine("End Long Running method...");
                return 1;
            }
        #endif

        #if TEST_TEPLYAKOV
            #if TEST_TEPLYAKOV_ASYNC_VER
                static async void AsyncVersion()
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    string url1 = "http://rsdn.ru";
                    string url2 = "http://gotdotnet.ru";
                    string url3 = "http://blogs.msdn.com";

                    var webRequest1 = WebRequest.Create(url1);
                    Console.WriteLine("Before webRequest1.GetResponseAsync(). Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);

                    var webResponse1 = await webRequest1.GetResponseAsync();
                    Console.WriteLine("{0} : {1}, elapsed {2}ms. Thread Id: {3}", url1, webResponse1.ContentLength, sw.ElapsedMilliseconds, Thread.CurrentThread.ManagedThreadId);

                    var webRequest2 = WebRequest.Create(url2);
                    Console.WriteLine("Before webRequest2.GetResponseAsync(). Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);

                    var webResponse2 = await webRequest2.GetResponseAsync();
                    Console.WriteLine("{0} : {1}, elapsed {2}ms. Thread Id: {3}", url2, webResponse2.ContentLength, sw.ElapsedMilliseconds, Thread.CurrentThread.ManagedThreadId);

                    var webRequest3 = WebRequest.Create(url3);
                    Console.WriteLine("Before webRequest3.GetResponseAsync(). Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
                    var webResponse3 = await webRequest3.GetResponseAsync();
                    Console.WriteLine("{0} : {1}, elapsed {2}ms. Thread Id: {3}", url3, webResponse3.ContentLength, sw.ElapsedMilliseconds, Thread.CurrentThread.ManagedThreadId);
                }
            #endif

            #if TEST_TEPLYAKOV_ASYNC_VER_2
                public static async void AsyncVersion2()
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    var urls = new[] {"http://rsdn.ru", "http://gotdotnet.ru", "http://blogs.msdn.com"};
                    var tasks = (from url in urls 
                        let webRequest = WebRequest.Create(url)
                        select new {Url = url, Response = webRequest.GetResponseAsync()})
                        .ToList();
                    var data = await Task.WhenAll(tasks.Select(t=>t.Response));
                    var sb = new StringBuilder();
                    foreach(var s in tasks)
                    {
                        sb.AppendFormat("{0}: {1}, elapsed {2}ms. Thread Id: {3}", s.Url, 
                            s.Response.Result.ContentLength,
                            sw.ElapsedMilliseconds, Thread.CurrentThread.ManagedThreadId)
                            .AppendLine();
                    }
                    var outputText = sb.ToString();
                    Console.WriteLine("Web request results: {0}", outputText);
            
                    using (var fs = new FileStream("results.txt", FileMode.Create, FileAccess.Write, FileShare.Write))
                    {
                        await
                        fs.WriteAsync(Encoding.Default.GetBytes(outputText), 0, Encoding.Default.GetByteCount(outputText));
                    }
                }
            #endif
        #endif
    }
}
