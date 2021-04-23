// https://github.com/confluentinc/confluent-kafka-dotnet/

#define TEST_SIMPLE
//#define TEST_CUSTOMER
//#define TEST_TYPES_BY_SPECIFIC_RECORD

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using ConfluentKafkaDotnet.Common;
using org.example;

using static System.Console;

namespace Producer
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            #if TEST_TYPES_BY_SPECIFIC_RECORD
                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = Common.BootstrapServers
                };

                var schemaRegistryConfig = new SchemaRegistryConfig
                {
                    Url = Common.SchemaRegistryUrl
                };

                var avroSerializerConfig = new AvroSerializerConfig();

                using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
                using var producer = new ProducerBuilder<string, TestTypes>(producerConfig)
                    .SetKeySerializer(new AvroSerializer<string>(schemaRegistry, avroSerializerConfig))
                    .SetValueSerializer(new AvroSerializer<TestTypes>(schemaRegistry, avroSerializerConfig))
                    .Build();

                var o = new TestTypes
                {
                    fBoolean = true,
                    fInt = 13,
                    fLong = 169L,
                    fFloat = 13.13F,
                    fDouble = 169.169,
                    fString = "13string13",
                    fEnum = TestEnum.Third
                };

                var result = await producer.ProduceAsync(Common.TopicTestTypes, new Message<string, TestTypes> { Key = Guid.NewGuid().ToString(), Value = o })
                    .ContinueWith(task => task.IsFaulted
                        ? $"error producing message: {task.Exception?.Message}"
                        : $"produced to: {task.Result.TopicPartitionOffset}");

                producer.Flush(TimeSpan.FromSeconds(30));

                Debug.WriteLine(result);
                WriteLine(result);
            #endif

            #if TEST_SIMPLE
                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = Common.BootstrapServers
                };

                Action<DeliveryReport<Null, string>> handler = r =>
                    Console.WriteLine(!r.Error.IsError
                        ? $"Delivered message to {r.TopicPartitionOffset}"
                        : $"Delivery Error: {r.Error.Reason}");

                using (var p = new ProducerBuilder<Null, string>(producerConfig).Build())
                {
                    for (var i = 0; i < 5; ++i)
                    {
                        p.Produce(Common.TopicSimple, new Message<Null, string> { Value = i.ToString() }, handler);
                    }

                    p.Flush(TimeSpan.FromSeconds(10));
                }
            #endif

            #if TEST_CUSTOMER
                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = Common.BootstrapServers
                };

                var schemaRegistryConfig = new SchemaRegistryConfig
                {
                    Url = Common.SchemaRegistryUrl
                };

                var avroSerializerConfig = new AvroSerializerConfig();

                using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
                using var producer = new ProducerBuilder<string, Customer>(producerConfig)
                    .SetKeySerializer(new AvroSerializer<string>(schemaRegistry, avroSerializerConfig))
                    .SetValueSerializer(new AvroSerializer<Customer>(schemaRegistry, avroSerializerConfig))
                    .Build();
                var customer = new Customer { FirstName = "FirstName", LastName = "LastName", Age = 13, Payment = PaymentTypes.Mastercard, Height = 13, Weight = 13, AutomatedEmail = false };
                var result = await producer.ProduceAsync(Common.TopicCustomer, new Message<string, Customer> { Key = Guid.NewGuid().ToString(), Value = customer })
                    .ContinueWith(task => task.IsFaulted
                        ? $"error producing message: {task.Exception?.Message}"
                        : $"produced to: {task.Result.TopicPartitionOffset}");

                producer.Flush(TimeSpan.FromSeconds(30));

                Debug.WriteLine(result);
                WriteLine(result);
            #endif
        }
    }
}
