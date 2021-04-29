//#define TEST_SIMPLE
//#define TEST_CUSTOMER_BY_SPECIFIC_RECORD
#define TEST_CUSTOMER_BY_GENERIC_RECORD
//#define TEST_TYPES_BY_SPECIFIC_RECORD
//#define TEST_TYPES_BY_GENERIC_RECORD
//#define TEST_MULTI_SCHEMA
//#define USE_AVRO_DESERIALIZER_WRAPPER

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Avro.Generic;
using Avro.Specific;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using ConfluentKafkaDotnet.Common;
using org.example;

using static System.Console;

namespace Consumer
{
    public class AvroDeserializerWrapper<T> : IDeserializer<T>
    {
        private readonly AvroDeserializer<T> _avroDeserializer;

        public AvroDeserializerWrapper(AvroDeserializer<T> avroDeserializer)
        {
            _avroDeserializer = avroDeserializer;
        }

        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            var result = _avroDeserializer.DeserializeAsync(new System.ReadOnlyMemory<byte>(data.ToArray()), isNull, context).Result;
            return result;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            #if TEST_MULTI_SCHEMA
                ConsumeSpecificRecord<TestTypes>(Common.MultiSchema);
                ConsumeSpecificRecord<Customer>(Common.MultiSchema);
            #endif

            #if TEST_TYPES_BY_GENERIC_RECORD
                ConsumeGenericRecord(Common.TopicTestTypes);
            #endif

            #if TEST_TYPES_BY_SPECIFIC_RECORD
                ConsumeSpecificRecord<TestTypes>(Common.TopicTestTypes);
            #endif

            #if TEST_CUSTOMER_BY_SPECIFIC_RECORD
                ConsumeSpecificRecord<Customer>(Common.TopicCustomer);
            #endif
            
            #if TEST_CUSTOMER_BY_GENERIC_RECORD
                ConsumeGenericRecord(Common.TopicCustomer);
            #endif

            #if TEST_SIMPLE
                ConsumeSimple();
            #endif
        }

        public static void ConsumeSpecificRecord<T>(string topic)
        {
            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = Common.SchemaRegistryUrl
            };

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = Common.BootstrapServers,
                GroupId = $"{topic}-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);

            var valueDeserializer =
                #if USE_AVRO_DESERIALIZER_WRAPPER
                    new AvroDeserializerWrapper<T>(new AvroDeserializer<T>(schemaRegistry));
                #else
                    new AvroDeserializer<T>(schemaRegistry).AsSyncOverAsync();
                #endif

            using var consumer =
                new ConsumerBuilder<string, T>(consumerConfig)
                    .SetKeyDeserializer(new AvroDeserializer<string>(schemaRegistry).AsSyncOverAsync())
                    .SetValueDeserializer(valueDeserializer)
                    .SetErrorHandler((_, e) => WriteLine($"Error: {e.Reason}"))
                    .Build();
            try
            {
                consumer.Subscribe(topic);
                var result = consumer.Consume();
                WriteLine($"Topic: {result.Topic} Offset: {result.Offset} Key: {result.Message.Key} Value: {result.Message.Value}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                WriteLine(e.Message);
                consumer.Close();
            }
        }

        public static void ConsumeGenericRecord(string topic)
        {
            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = Common.SchemaRegistryUrl
            };

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = Common.BootstrapServers,
                GroupId = $"{topic}-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
            using var consumer =
                new ConsumerBuilder<string, GenericRecord>(consumerConfig)
                    .SetKeyDeserializer(new AvroDeserializer<string>(schemaRegistry).AsSyncOverAsync())
                    .SetValueDeserializer(new AvroDeserializer<GenericRecord>(schemaRegistry).AsSyncOverAsync())
                    .SetErrorHandler((_, e) => WriteLine($"Error: {e.Reason}"))
                    .Build();
            try
            {
                consumer.Subscribe(topic);
                ConsumeResult<string, GenericRecord> result = consumer.Consume();
                WriteLine($"Topic: {result.Topic} Offset: {result.Offset} Key: {result.Message.Key} Value: {result.Message.Value}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                WriteLine(e.Message);
                consumer.Close();
            }
        }

        public static void ConsumeSimple()
        {
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
        }

        public static (Dictionary<Type, Avro.Schema> typeToSchema, Dictionary<Avro.Schema, Type> schemaToType) GetSpecificRecordTypesAndSchemas()
        {
            Dictionary<Type, Avro.Schema> typeToSchema = new();
            Dictionary<Avro.Schema, Type> schemaToType = new();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (!typeof(ISpecificRecord).IsAssignableFrom(type))
                        continue;

                    var schema = (Avro.Schema)type.GetField("_SCHEMA", BindingFlags.Static | BindingFlags.Public)?.GetValue(null);
                    if (schema == null)
                        continue;

                    typeToSchema.Add(type, schema);
                    schemaToType.Add(schema, type);
                }
            }

            return (typeToSchema, schemaToType);
        }
    }
}
