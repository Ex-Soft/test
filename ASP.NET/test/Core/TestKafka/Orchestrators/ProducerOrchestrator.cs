using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using org.example;
using TestKafka.Kafka;

namespace TestKafka.Orchestrators
{
    public class ProducerOrchestrator : IProducerOrchestrator
    {
        public async Task Produce(TestTypes testTypes)
        {
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

            var result = await producer.ProduceAsync(Common.Topic, new Message<string, TestTypes> { Key = Guid.NewGuid().ToString(), Value = testTypes })
                .ContinueWith(task => task.IsFaulted
                    ? $"error producing message: {task.Exception.Message}"
                    : $"produced to: {task.Result.TopicPartitionOffset}");

            producer.Flush(TimeSpan.FromSeconds(30));

            Debug.WriteLine(result);
        }
    }
}
