using System;
using Confluent.Kafka;

namespace Producer
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string topic = "test"; // "customer-avro";

            var conf = new ProducerConfig { BootstrapServers = "localhost:9092" };

            Action<DeliveryReport<Null, string>> handler = r =>
                Console.WriteLine(!r.Error.IsError
                    ? $"Delivered message to {r.TopicPartitionOffset}"
                    : $"Delivery Error: {r.Error.Reason}");

            using (var p = new ProducerBuilder<Null, string>(conf).Build())
            {
                for (int i = 0; i < 5; ++i)
                {
                    p.Produce(topic, new Message<Null, string> { Value = i.ToString() }, handler);
                }

                p.Flush(TimeSpan.FromSeconds(10));
            }
        }
    }
}
