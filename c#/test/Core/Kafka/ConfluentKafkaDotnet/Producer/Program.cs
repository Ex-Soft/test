//#define TEST_SIMPLE
#define TEST_AVRO

using System;
using System.Collections.Generic;
using Avro.Generic;
using Confluent.Kafka;
using Confluent.SchemaRegistry.Serdes;

namespace Producer
{
    class Program
    {
        public static void Main(string[] args)
        {
            string
                topic,
                bootstrapServer = "localhost:9092";

            #if TEST_SIMPLE
                topic = "test";

                var conf = new ProducerConfig { BootstrapServers = bootstrapServer };

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
            #endif

            #if TEST_AVRO
                topic = "customer-avro";

                var config = new Dictionary<string, object>
                {
                    {"bootstrap.servers", bootstrapServer},
                    {"schema.registry.url", "localhost:8081"}
                };

                Action<DeliveryReport<Null, string>> handler = r =>
                    Console.WriteLine(!r.Error.IsError
                        ? $"Delivered message to {r.TopicPartitionOffset}"
                        : $"Delivery Error: {r.Error.Reason}");

                var customer = new Customer { first_name = "FirstName", last_name = "LastName", age = 13, payment = PaymentTypes.Mastercard, height = 13, weight = 13, automated_email = false };
            #endif
        }
    }
}
