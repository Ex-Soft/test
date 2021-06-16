// https://jack-vanlightly.com/blog/2018/4/17/processing-pipelines-series-introduction
// https://jack-vanlightly.com/blog/2018/4/18/processing-pipelines-series-tpl-dataflow
// https://jack-vanlightly.com/blog/2018/4/19/processing-pipelines-series-tpl-dataflow-alternate-scenario

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks.Dataflow;

namespace TestDataflow
{
    class Program
    {
        private const int BufferSize = 16384;

        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            using (var inputStream = File.OpenRead(@"c:\temp\test.txt"))
            {
                using (var outputStream = File.Create(@"c:\temp\test.gz"))
                {
                    Compress(inputStream, outputStream);
                }
            }
            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalSeconds}s");
            Console.ReadKey();
        }

        public static void Compress(Stream inputStream, Stream outputStream)
        {
            var buffer = new BufferBlock<byte[]>(new DataflowBlockOptions { BoundedCapacity = 100 });
            var compressorOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = 4,
                BoundedCapacity = 100
            };
            var compressor = new TransformBlock<byte[], byte[]>(bytes => Compress(bytes), compressorOptions);
            var writerOptions = new ExecutionDataflowBlockOptions
            {
                BoundedCapacity = 100,
                SingleProducerConstrained = true
            };
            var writer = new ActionBlock<byte[]>(bytes => outputStream.Write(bytes, 0, bytes.Length), writerOptions);

            buffer.LinkTo(compressor);
            buffer.Completion.ContinueWith(task => compressor.Complete());
            compressor.LinkTo(writer);
            compressor.Completion.ContinueWith(task => writer.Complete());

            var readBuffer = new byte[BufferSize];
            while (true)
            {
                int readCount = inputStream.Read(readBuffer, 0, BufferSize);
                if (readCount > 0)
                {
                    var postData = new byte[readCount];
                    Buffer.BlockCopy(readBuffer, 0, postData, 0, readCount);
                    while (!buffer.Post(postData))
                    {
                    }
                }
                if (readCount != BufferSize)
                {
                    buffer.Complete();
                    break;
                }
            }

            writer.Completion.Wait();
        }

        private static byte[] Compress(byte[] bytes)
        {
            using (var resultStream = new MemoryStream())
            {
                using (var zipStream = new GZipStream(resultStream, CompressionMode.Compress))
                {
                    using (var writer = new BinaryWriter(zipStream))
                    {
                        writer.Write(bytes);
                        return resultStream.ToArray();
                    }
                }
            }
        }
    }
}
