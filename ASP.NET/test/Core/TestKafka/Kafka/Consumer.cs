using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Microsoft.Extensions.Hosting;
using org.example;

namespace TestKafka.Kafka
{
    public class Consumer : BackgroundService
    {
        private const string Topic = Common.Topic;
        private readonly CachedSchemaRegistryClient _schemaRegistry;
        private readonly IConsumer<string, TestTypes> _consumer;

        public Consumer()
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = Common.BootstrapServers,
                GroupId = $"{Topic}-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = Common.SchemaRegistryUrl
            };

            _schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
            _consumer = new ConsumerBuilder<string, TestTypes>(consumerConfig)
                .SetKeyDeserializer(new AvroDeserializer<string>(_schemaRegistry).AsSyncOverAsync())
                .SetValueDeserializer(new AvroDeserializer<TestTypes>(_schemaRegistry).AsSyncOverAsync())
                .SetErrorHandler((_, e) => Debug.WriteLine($"Error: {e.Reason}"))
                .Build();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            new Thread(() => StartConsumerLoop(stoppingToken)).Start();

            return Task.CompletedTask;
        }

        private void StartConsumerLoop(CancellationToken cancellationToken)
        {
            _consumer.Subscribe(Topic);

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var result = _consumer.Consume(cancellationToken);
                    Debug.WriteLine($"Topic: {result.Topic} Partition: {result.Partition} Offset: {result.Offset} TopicPartition: {result.TopicPartition} TopicPartitionOffset: {result.TopicPartitionOffset} IsPartitionEOF: {result.IsPartitionEOF} Key: {result.Message.Key} Value: {result.Message.Value}");
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (ConsumeException e)
                {
                    Debug.WriteLine($"Consume error: {e.Error.Reason}");

                    if (e.Error.IsFatal)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Unexpected error: {e}");
                    break;
                }
            }
        }

        public override void Dispose()
        {
            _consumer.Close();
            _consumer.Dispose();
            _schemaRegistry.Dispose();

            base.Dispose();
        }
    }
}
