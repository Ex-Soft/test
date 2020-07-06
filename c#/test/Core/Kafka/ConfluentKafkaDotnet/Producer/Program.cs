//#define TEST_SIMPLE
#define TEST_AVRO

using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

namespace Producer
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string
                topic,
                bootstrapServers = "localhost:9092",
                schemaRegistryUrl = "localhost:8081";

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

                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = bootstrapServers
                };

                var schemaRegistryConfig = new SchemaRegistryConfig
                {
                    Url = schemaRegistryUrl
                };

                var avroSerializerConfig = new AvroSerializerConfig
                {
                    BufferBytes = 100
                };

                using (var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig))
                using (var producer = new ProducerBuilder<string, Customer>(producerConfig)
                    .SetKeySerializer(new AvroSerializer<string>(schemaRegistry, avroSerializerConfig))
                    .SetValueSerializer(new AvroSerializer<Customer>(schemaRegistry, avroSerializerConfig))
                    .Build())
                {
                    var customer = new Customer { first_name = "FirstName", last_name = "LastName", age = 13, payment = PaymentTypes.Mastercard, height = 13, weight = 13, automated_email = false };
                    await producer.ProduceAsync(topic, new Message<string, Customer> { Key = Guid.NewGuid().ToString(), Value = customer })
                        .ContinueWith(task => task.IsFaulted
                            ? $"error producing message: {task.Exception.Message}"
                            : $"produced to: {task.Result.TopicPartitionOffset}");
                }
            #endif
        }
    }
}
