// https://github.com/snmslavk/kafka-net-core
// https://www.nuget.org/packages/kafka-net-core/

using System;
using System.Collections.Generic;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new KafkaOptions(new Uri("http://localhost:9092"));
            var router = new BrokerRouter(options);
            
            using (KafkaNet.Producer client = new KafkaNet.Producer(router))
            {
                client.SendMessageAsync("Simple", new List<Message> { new Message("Welcome to Kafka!") }).Wait();
            }

            Console.ReadLine();
        }
    }
}
