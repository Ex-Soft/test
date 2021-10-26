using System;
using System.Diagnostics;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

namespace KafkaWinFormsApp
{
    public class KafkaConsumer<T> : IDisposable
    {
        private readonly CachedSchemaRegistryClient _schemaRegistry;
        private readonly IConsumer<string, T> _consumer;

        public KafkaConsumer()
        {
            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = Common.SchemaRegistryUrl
            };

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = Common.BootstrapServers,
                GroupId = $"{Common.Topic}-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);

            _consumer = new ConsumerBuilder<string, T>(consumerConfig)
                    .SetKeyDeserializer(new AvroDeserializer<string>(_schemaRegistry).AsSyncOverAsync())
                    .SetValueDeserializer(new AvroDeserializer<T>(_schemaRegistry).AsSyncOverAsync())
                    .SetErrorHandler(ErrorHandler)
                    .Build();

            _consumer.Subscribe(Common.Topic);
        }

        public T Consume()
        {
            T result = default;

            try
            {
                var consumeResult = _consumer.Consume();
                result = consumeResult.Message.Value;
            }
            catch (ConsumeException e)
            {
                Debug.WriteLine($"{e.GetType().FullName}: {e.Message}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.GetType().FullName}: {e.Message}");
            }

            return result;
        }

        public void ErrorHandler(IConsumer<string, T> consumer, Confluent.Kafka.Error error)
        {
            Debug.WriteLine($"Error: {error.Reason}");
        }

        public void Dispose()
        {
            _schemaRegistry?.Dispose();
            _consumer?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
