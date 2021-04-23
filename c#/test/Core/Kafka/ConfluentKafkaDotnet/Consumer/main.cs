#define TEST_SIMPLE
//#define TEST_CUSTOMER
//#define TEST_TYPES_BY_SPECIFIC_RECORD
//#define TEST_TYPES_BY_GENERIC_RECORD

using System;
using System.Diagnostics;
using Avro.Generic;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using ConfluentKafkaDotnet.Common;
using org.example;

using static System.Console;

namespace Consumer
{
    class Program
    {
        public static void Main(string[] args)
        {
            #if TEST_TYPES_BY_GENERIC_RECORD
                var schemaRegistryConfig = new SchemaRegistryConfig
                {
                    Url = Common.SchemaRegistryUrl
                };

                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = Common.BootstrapServers,
                    GroupId = "test-types-group",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
                var schemaId = schemaRegistry.GetSchemaIdAsync($"{Common.TopicTestTypes}-value", TestTypes._SCHEMA.ToString()).Result;

                using var consumer =
                    new ConsumerBuilder<string, GenericRecord>(consumerConfig)
                        .SetKeyDeserializer(new AvroDeserializer<string>(schemaRegistry).AsSyncOverAsync())
                        .SetValueDeserializer(new AvroDeserializer<GenericRecord>(schemaRegistry).AsSyncOverAsync())
                        .SetErrorHandler((_, e) => WriteLine($"Error: {e.Reason}"))
                        .Build();
                try
                {
                    consumer.Subscribe(Common.TopicTestTypes);
                    ConsumeResult<string, GenericRecord> result = consumer.Consume();
                    WriteLine($"Topic: {result.Topic} Offset: {result.Offset} Key: {result.Message.Key} Value: {result.Message.Value}");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    WriteLine(e.Message);
                    consumer.Close();
                }
            #endif

            #if TEST_TYPES_BY_SPECIFIC_RECORD
                var schemaRegistryConfig = new SchemaRegistryConfig
                {
                    Url = Common.SchemaRegistryUrl
                };

                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = Common.BootstrapServers,
                    GroupId = "test-types-group",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);

                using var consumer =
                    new ConsumerBuilder<string, TestTypes>(consumerConfig)
                        .SetKeyDeserializer(new AvroDeserializer<string>(schemaRegistry).AsSyncOverAsync())
                        .SetValueDeserializer(new AvroDeserializer<TestTypes>(schemaRegistry).AsSyncOverAsync())
                        .SetErrorHandler((_, e) => WriteLine($"Error: {e.Reason}"))
                        .Build();
                try
                {
                    consumer.Subscribe(Common.TopicTestTypes);
                    var result = consumer.Consume();
                    WriteLine($"Topic: {result.Topic} Offset: {result.Offset} Key: {result.Message.Key} Value: {result.Message.Value}");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    WriteLine(e.Message);
                    consumer.Close();
                }
            #endif

            #if TEST_CUSTOMER
                var schemaRegistryConfig = new SchemaRegistryConfig
                {
                    Url = Common.SchemaRegistryUrl
                };

                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = Common.BootstrapServers,
                    GroupId = "customer-group",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);

                using var consumer =
                    new ConsumerBuilder<string, Customer>(consumerConfig)
                        .SetKeyDeserializer(new AvroDeserializer<string>(schemaRegistry).AsSyncOverAsync())
                        .SetValueDeserializer(ew AvroDeserializer<Customer>(schemaRegistry).AsSyncOverAsync())
                        .SetErrorHandler((_, e) => WriteLine($"Error: {e.Reason}"))
                        .Build();
                try
                {
                    consumer.Subscribe(Common.TopicCustomer);
                    var result = consumer.Consume();
                    WriteLine($"Topic: {result.Topic} Offset: {result.Offset} Key: {result.Message.Key} Value: {result.Message.Value}");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    WriteLine(e.Message);
                    consumer.Close();
                }
            #endif

            #if TEST_SIMPLE
                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = Common.BootstrapServers,
                    GroupId = "simple-group",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
                try
                {
                    consumer.Subscribe(Common.TopicSimple);
                    var result = consumer.Consume();
                    WriteLine($"Topic: {result.Topic} Offset: {result.Offset} Key: {result.Message?.Key} Value: {result.Message?.Value}");
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    WriteLine(e.Message);
                    consumer.Close();
                }
            #endif
        }
    }
}
