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
            string payload = "Welcome to Kafka!";
            string topic = "IDGTestTopic";
            Message msg = new Message(payload);
            Uri uri = new Uri("http://localhost:9092");
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var client = new KafkaNet.Producer(router);
            client.SendMessageAsync(topic, new List<Message> { msg }).Wait();
            Console.ReadLine();
        }
    }
}
