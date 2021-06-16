using System;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

namespace KafkaWinFormsApp
{
    public class KafkaProducer<T> : IDisposable
    {
        private readonly CachedSchemaRegistryClient _schemaRegistry;
        private readonly IProducer<string, T> _producer;

        public KafkaProducer()
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
            avroSerializerConfigValue.SubjectNameStrategy = SubjectNameStrategy.TopicRecord;

            _schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);

            _producer = new ProducerBuilder<string, T>(producerConfig)
                .SetKeySerializer(new AvroSerializer<string>(_schemaRegistry, avroSerializerConfigKey))
                .SetValueSerializer(new AvroSerializer<T>(_schemaRegistry, avroSerializerConfigValue))
                .Build();
        }

        public void Produce(T obj)
        {
            var result = _producer.ProduceAsync(Common.Topic, new Message<string, T> { Key = Guid.NewGuid().ToString(), Value = obj }).Result;
        }

        public void Dispose()
        {
            _schemaRegistry?.Dispose();
            _producer?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
