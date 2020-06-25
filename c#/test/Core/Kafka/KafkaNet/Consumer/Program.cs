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
            string topic = "IDGTestTopic";
            Uri uri = new Uri("http://localhost:9092");
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var consumer = new KafkaNet.Consumer(new ConsumerOptions(topic, router));
            foreach (var message in consumer.Consume())
            {
                Console.WriteLine(Encoding.UTF8.GetString(message.Value));
            }
            Console.ReadLine();
        }
    }
}
