using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avro.Specific;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using MultiTypesWinFormsApp.Helpers;

namespace MultiTypesWinFormsApp.Consumer
{
    public class KafkaConsumer : IKafkaConsumer
    {
        private ISchemaRegistryClient _schemaRegistryClient;
        private IConsumer<string, byte[]> _consumer;
        private IDictionary<Avro.Schema, Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>>> _convertersBySchema;
        private readonly ConcurrentDictionary<int, Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>>> _convertersBySchemaId = new();
        private KafkaConsumerConfiguration _kafkaConsumerConfig;

        public KafkaConsumer()
        {
            Debug.WriteLine($"{GetType().Name}.ctor()");
        }

        public void Dispose()
        {
            _schemaRegistryClient?.Dispose();
            _consumer?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Consume()
        {
            try
            {
                while (true)
                {
                    _kafkaConsumerConfig.CancellationToken.ThrowIfCancellationRequested();

                    ConsumeResult<string, byte[]> consumeResult = _consumer.Consume(_kafkaConsumerConfig.CancellationToken);
                    ISpecificRecord result = await Deserialize(consumeResult);
                    if (result != null)
                    {
                        _kafkaConsumerConfig.OnConsume?.Invoke(result);
                    }
                }
            }
            catch (ConsumeException e)
            {
                Debug.WriteLine($"{e.GetType().FullName}: {e.Message}");
            }
            catch (OperationCanceledException e)
            {
                Debug.WriteLine($"{e.GetType().FullName}: {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.GetType().FullName}: {e.Message}");
            }
        }

        public void Configure(KafkaConsumerConfiguration kafkaConsumerConfig)
        {
            _kafkaConsumerConfig = kafkaConsumerConfig;
            _schemaRegistryClient = CreateSchemaRegistry();
            _consumer = CreateKafkaConsumer();
            _convertersBySchema = GetSpecificConverters(_kafkaConsumerConfig.SpecificTypes);
        }

        private ISchemaRegistryClient CreateSchemaRegistry()
        {
            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = Common.Common.SchemaRegistryUrl
            };

            return new CachedSchemaRegistryClient(schemaRegistryConfig);
        }

        private IConsumer<string, byte[]> CreateKafkaConsumer()
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = Common.Common.BootstrapServers,
                GroupId = $"{Common.Common.TopicMultiSchema}-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            IConsumer<string, byte[]> consumer = new ConsumerBuilder<string, byte[]>(consumerConfig)
                .SetErrorHandler(ErrorHandler)
                .SetStatisticsHandler(StatisticsHandler)
                .SetPartitionsAssignedHandler(PartitionsAssignedHandler)
                .Build();

            consumer.Subscribe(Common.Common.TopicMultiSchema);

            return consumer;
        }

        private async Task<ISpecificRecord> Deserialize(ConsumeResult<string, byte[]> result)
        {
            Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>> converter = result is {Message: {Value: { }}} ? await GetSpecificConverter(result.Message.Value) : null;
            if (converter == null)
            {
                return await Task.FromResult<ISpecificRecord>(null);
            }

            return await converter(result);
        }

        private void ErrorHandler(IConsumer<string, byte[]> consumer, Confluent.Kafka.Error error)
        {
            Debug.WriteLine($"Error: {error.Reason}");
        }

        private void StatisticsHandler(IConsumer<string, byte[]> consumer, string json)
        {
            Debug.WriteLine(json);
        }

        private void PartitionsAssignedHandler(IConsumer<string, byte[]> consumer, List<TopicPartition> partitions)
        {
            Debug.WriteLine(partitions.Count);
        }

        private IDictionary<Avro.Schema, Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>>> GetSpecificConverters(IEnumerable<Type> types)
        {
            return types
                .Select(t => new { type = t, schema = KafkaUtils.GetAvroSchema(t) })
                .ToDictionary(t => t.schema, t => KafkaUtils.CreateSpecificConverter(t.type, _schemaRegistryClient));
        }

        private async Task<Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>>> GetSpecificConverter(byte[] data)
        {
            Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>> converter;

            try
            {
                int schemaId = KafkaUtils.GetSchemaId(data);

                if (_convertersBySchemaId.TryGetValue(schemaId, out converter))
                {
                    return converter;
                }

                Schema schema = await _schemaRegistryClient.GetSchemaAsync(schemaId);
                Avro.Schema avroSchema = (Avro.RecordSchema)Avro.Schema.Parse(schema.SchemaString);
                converter = _convertersBySchema.ContainsKey(avroSchema) ? _convertersBySchema[avroSchema] : null;

                if (converter != null)
                {
                    _ = _convertersBySchemaId.TryAdd(schemaId, converter);
                }
            }
            catch (SchemaRegistryException e)
            {
                Debug.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            
            return converter ?? await Task.FromResult<Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>>>(null);
        }
    }
}
