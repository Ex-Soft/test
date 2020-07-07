//#define TEST_SIMPLE
#define TEST_AVRO

using System;
using System.Diagnostics;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
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
            string
                topic,
                bootstrapServers = "localhost:9092",
                schemaRegistryUrl = "localhost:8081";

            #if TEST_AVRO
                topic = "customer-avro";

                var schemaRegistryConfig = new SchemaRegistryConfig
                {
                    Url = schemaRegistryUrl
                };

                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = bootstrapServers,
                    GroupId = "avro-specific-example-group",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using (var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig))
                {
                    var keyDeserializer = new AvroDeserializerWrapper<string>(new AvroDeserializer<string>(schemaRegistry));
                    var valueDeserializer = new AvroDeserializerWrapper<Customer>(new AvroDeserializer<Customer>(schemaRegistry));

                    using (var consumer =
                        new ConsumerBuilder<string, Customer>(consumerConfig)
                            .SetKeyDeserializer(keyDeserializer)
                            .SetValueDeserializer(valueDeserializer)
                            .SetErrorHandler((_, e) => WriteLine($"Error: {e.Reason}"))
                            .Build())
                    {
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
                }
            #endif
        }
    }
}
