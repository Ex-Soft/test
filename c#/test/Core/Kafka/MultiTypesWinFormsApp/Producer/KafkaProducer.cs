using System;
using System.Threading;
using Avro.Generic;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

namespace MultiTypesWinFormsApp.Producer
{
    public class KafkaProducer : IDisposable
    {
        private readonly CachedSchemaRegistryClient _schemaRegistry;
        private readonly IProducer<string, GenericRecord> _producer;
        private readonly CancellationToken _cancellationToken;

        public KafkaProducer(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = Common.Common.BootstrapServers,
            };

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = Common.Common.SchemaRegistryUrl,
            };

            var avroSerializerConfigKey = new AvroSerializerConfig();
            var avroSerializerConfigValue = new AvroSerializerConfig
            {
                SubjectNameStrategy = SubjectNameStrategy.TopicRecord
            };

            _schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);

            _producer = new ProducerBuilder<string, GenericRecord>(producerConfig)
                .SetKeySerializer(new AvroSerializer<string>(_schemaRegistry, avroSerializerConfigKey))
                .SetValueSerializer(new AvroSerializer<GenericRecord>(_schemaRegistry, avroSerializerConfigValue))
                .Build();
        }

        public DeliveryResult<string, GenericRecord> Produce(GenericRecord obj)
        {
            return _producer.ProduceAsync(Common.Common.TopicMultiSchema, new Message<string, GenericRecord> { Key = Guid.NewGuid().ToString(), Value = obj }, _cancellationToken).Result;
        }

        public int Flush(TimeSpan timeout)
        {
            return _producer.Flush(timeout);
        }

        public void Dispose()
        {
            _schemaRegistry?.Dispose();
            _producer?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
