using System;
using System.Diagnostics;
using System.Threading.Tasks;
using com.mycorp.mynamespace;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

namespace TestSchema
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = "localhost:8081"
            };
            using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
            var subjectName = schemaRegistry.ConstructValueSubjectName("TestTypes", typeof(sampleRecord).FullName);
            var str = @"{""doc"": ""Sample schema to help you get started."",""type"":""record"",""name"":""sampleRecord"",""namespace"":""com.mycorp.mynamespace"",""fields"":[{""name"":""my_field1"",""doc"":""The int type is a 32-bit signed integer."",""type"":""int""},{""name"":""my_field2"",""doc"":""The double type is a double precision (64-bit) IEEE 754 floating-point number."",""type"":""double""},{""name"":""my_field3"",""doc"":""The string is a unicode character sequence."",""type"":""string""}]}";
            try
            {
                var schema = schemaRegistry.GetLatestSchemaAsync(subjectName).Result;
                var schema1 = schemaRegistry.GetSchemaAsync(1).Result;
                var schemaId0 = await schemaRegistry.GetSchemaIdAsync(subjectName, /*sampleRecord._SCHEMA.ToString()*/str/*schema.SchemaString*/);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
            };

            var avroSerializerConfigValue = new AvroSerializerConfig();

            using var producer = new ProducerBuilder<string, sampleRecord>(producerConfig)
                .SetValueSerializer(new AvroSerializer<sampleRecord>(schemaRegistry, avroSerializerConfigValue))
                .Build();

            var obj = new sampleRecord
            {
                my_field1 = 1,
                my_field2 = 2,
                my_field3 = "3"
            };

            var result = await producer.ProduceAsync("TestTypes", new Message<string, sampleRecord> { Key = Guid.NewGuid().ToString(), Value = obj })
                .ContinueWith(task => task.IsFaulted
                    ? $"error producing message: {task.Exception?.Message}"
                    : $"produced to: {task.Result.TopicPartitionOffset}");

            producer.Flush(TimeSpan.FromSeconds(30));

            Debug.WriteLine(result);
        }
    }
}
