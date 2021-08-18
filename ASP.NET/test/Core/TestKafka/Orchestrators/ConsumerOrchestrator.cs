using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using org.example;
using System;
using System.Diagnostics;
using TestKafka.Kafka;

namespace TestKafka.Orchestrators
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

    public class ConsumerOrchestrator : IConsumerOrchestrator
    {
        public TestTypes Consume()
        {
            ConsumeResult<string, TestTypes> result = null;

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = Common.BootstrapServers,
                GroupId = "victim-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = Common.SchemaRegistryUrl
            };

            using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
            var keyDeserializer = new AvroDeserializerWrapper<string>(new AvroDeserializer<string>(schemaRegistry));
            var valueDeserializer = new AvroDeserializerWrapper<TestTypes>(new AvroDeserializer<TestTypes>(schemaRegistry));

            using var consumer =
                new ConsumerBuilder<string, TestTypes>(consumerConfig)
                    .SetKeyDeserializer(keyDeserializer)
                    .SetValueDeserializer(valueDeserializer)
                    .SetErrorHandler((_, e) => Debug.WriteLine($"Error: {e.Reason}"))
                    .Build();
            try
            {
                consumer.Subscribe(Common.Topic);
                result = consumer.Consume();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                Debug.WriteLine(e.Message);
                consumer.Close();
            }

            return result?.Message?.Value;
        }
    }
}
