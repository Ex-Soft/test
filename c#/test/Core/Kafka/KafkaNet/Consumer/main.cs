// https://github.com/snmslavk/kafka-net-core
// https://www.nuget.org/packages/kafka-net-core/

using System;
using System.Text;
using KafkaNet;
using KafkaNet.Model;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new KafkaOptions(new Uri("http://localhost:9092"));
            var router = new BrokerRouter(options);

            using (var consumer = new KafkaNet.Consumer(new ConsumerOptions("Simple", router)))
            {
                foreach (var message in consumer.Consume())
                {
                    Console.WriteLine($"Response: P{message.Meta.PartitionId},O{message.Meta.Offset} : {Encoding.UTF8.GetString(message.Value)}");
                }
            }

            Console.ReadLine();
        }
    }
}
