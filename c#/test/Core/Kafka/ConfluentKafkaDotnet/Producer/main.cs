// https://github.com/confluentinc/confluent-kafka-dotnet/

//#define TEST_SIMPLE
#define TEST_CUSTOMER_BY_SPECIFIC_RECORD
//#define TEST_CUSTOMER_BY_GENERIC_RECORD
//#define TEST_TYPES_BY_SPECIFIC_RECORD
//#define TEST_TYPES_BY_GENERIC_RECORD
//#define TEST_MULTI_SCHEMA

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Avro.Generic;
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
            TestTypes testTypes;
            Customer customer;

            #if TEST_MULTI_SCHEMA
                testTypes = new TestTypes { fBoolean = true, fInt = 13, fLong = 169L, fFloat = 13.13F, fDouble = 169.169, fString = DateTimeOffset.Now.ToString("o"), fEnum = TestEnum.Third };
                await ProduceSpecificRecord(Common.MultiSchema, testTypes);
                customer = new Customer { FirstName = "FirstName", LastName = "LastName", Age = 13, Payment = PaymentTypes.Mastercard, Height = 13, Weight = 13, AutomatedEmail = false };
                await ProduceSpecificRecord(Common.MultiSchema, customer);
            #endif

            #if TEST_TYPES_BY_SPECIFIC_RECORD
                testTypes = new TestTypes { fBoolean = true, fInt = 13, fLong = 169L, fFloat = 13.13F, fDouble = 169.169, fString = DateTimeOffset.Now.ToString("o"), fEnum = TestEnum.Third };
                await ProduceSpecificRecord(Common.TopicTestTypes, testTypes);
            #endif

            #if TEST_TYPES_BY_GENERIC_RECORD
                testTypes = new TestTypes { fBoolean = true, fInt = 13, fLong = 169L, fFloat = 13.13F, fDouble = 169.169, fString = DateTimeOffset.Now.ToString("o"), fEnum = TestEnum.Third };
                await ProduceGenericRecord(Common.TopicTestTypes, testTypes);
            #endif

            #if TEST_CUSTOMER_BY_SPECIFIC_RECORD
                customer = new Customer { FirstName = "FirstName", LastName = "LastName", Age = 13, Payment = PaymentTypes.Mastercard, Height = 13, Weight = 13, AutomatedEmail = false };
                await ProduceSpecificRecord(Common.TopicCustomer, customer);
            #endif
            
            #if TEST_CUSTOMER_BY_GENERIC_RECORD
                customer = new Customer { FirstName = "FirstName", LastName = "LastName", Age = 13, Payment = PaymentTypes.Mastercard, Height = 13, Weight = 13, AutomatedEmail = false };
                await ProduceGenericRecord(Common.TopicCustomer, customer);
            #endif

            #if TEST_SIMPLE
                ProduceSimple();
            #endif
        }

        public static async Task ProduceSpecificRecord<T>(string topic, T obj)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = Common.BootstrapServers, 
            };

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = Common.SchemaRegistryUrl,
            };

            var avroSerializerConfigKey = new AvroSerializerConfig();
            var avroSerializerConfigValue = new AvroSerializerConfig();
            #if TEST_MULTI_SCHEMA
                avroSerializerConfigValue.SubjectNameStrategy = SubjectNameStrategy.TopicRecord;
            #endif
            
            using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
            using var producer = new ProducerBuilder<string, T>(producerConfig)
                .SetKeySerializer(new AvroSerializer<string>(schemaRegistry, avroSerializerConfigKey))
                .SetValueSerializer(new AvroSerializer<T>(schemaRegistry, avroSerializerConfigValue))
                .Build();

            var result = await producer.ProduceAsync(topic, new Message<string, T> { Key = Guid.NewGuid().ToString(), Value = obj })
                .ContinueWith(task => task.IsFaulted
                    ? $"error producing message: {task.Exception?.Message}"
                    : $"produced to: {task.Result.TopicPartitionOffset}");

            producer.Flush(TimeSpan.FromSeconds(30));

            Debug.WriteLine(result);
            WriteLine(result);
        }

        public static async Task ProduceGenericRecord(string topic, object obj)
        {
            var record = Common.SpecificRecordToGenericRecord(obj);
            using var schemaRegistry = new CachedSchemaRegistryClient(new SchemaRegistryConfig { Url = Common.SchemaRegistryUrl });
            using var producer =
                new ProducerBuilder<string, GenericRecord>(new ProducerConfig { BootstrapServers = Common.BootstrapServers })
                    .SetKeySerializer(new AvroSerializer<string>(schemaRegistry))
                    .SetValueSerializer(new AvroSerializer<GenericRecord>(schemaRegistry))
                    .Build();

            try
            {
                var result = await producer.ProduceAsync(topic, new Message<string, GenericRecord> { Key = Guid.NewGuid().ToString(), Value = record });
                WriteLine($"produced to: {result.TopicPartitionOffset}");
            }
            catch (ProduceException<string, GenericRecord> ex)
            {
                WriteLine($"error producing message: {ex}");
            }

            producer.Flush(TimeSpan.FromSeconds(30));
        }

        public static void ProduceSimple()
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = Common.BootstrapServers
            };

            Action<DeliveryReport<Null, string>> handler = r =>
                WriteLine(!r.Error.IsError
                    ? $"Delivered message to {r.TopicPartitionOffset}"
                    : $"Delivery Error: {r.Error.Reason}");

            using var p = new ProducerBuilder<Null, string>(producerConfig).Build();
            for (var i = 0; i < 5; ++i)
            {
                p.Produce(Common.TopicSimple, new Message<Null, string> { Value = i.ToString() }, handler);
            }

            p.Flush(TimeSpan.FromSeconds(10));
        }
    }
}
