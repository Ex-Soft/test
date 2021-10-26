//#define TEST_SIMPLE
//#define TEST_CUSTOMER_BY_SPECIFIC_RECORD
//#define TEST_CUSTOMER_BY_GENERIC_RECORD
//#define TEST_TYPES_BY_SPECIFIC_RECORD
//#define TEST_TYPES_BY_GENERIC_RECORD
//#define TEST_TYPES_BY_BYTE_ARRAY
//#define TEST_MULTI_SCHEMA
//#define USE_AVRO_DESERIALIZER_WRAPPER
//#define MANUAL_COMMIT
//#define DO_COMMIT
#define TEST_SCHEMA_REGISTRY_CLIENT

using System;
using System.Buffers.Binary;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Avro;
using Avro.Generic;
using Avro.Specific;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using ConfluentKafkaDotnet.Common;
using org.example;

using static System.Console;
using Schema = Avro.Schema;

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
            #if TEST_SCHEMA_REGISTRY_CLIENT
                TestSchemaRegistryClient();
            #endif

            #if TEST_MULTI_SCHEMA
                ConsumeSpecificRecord<TestTypes>(Common.TopicMultiSchema);
                ConsumeSpecificRecord<Customer>(Common.TopicMultiSchema);
            #endif

            #if TEST_TYPES_BY_GENERIC_RECORD
                ConsumeGenericRecord(Common.TopicTestTypes);
            #endif

            #if TEST_TYPES_BY_SPECIFIC_RECORD
                ConsumeSpecificRecord<TestTypes>(Common.TopicTestTypes);
            #endif

            #if TEST_TYPES_BY_BYTE_ARRAY
                ConsumeByteArray(Common.TopicTestTypes);
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

        public static void TestSchemaRegistryClient()
        {
            var schemaRegistryConfig = new SchemaRegistryConfig
            {
                Url = Common.SchemaRegistryUrl,
                /*SslCaLocation = "/certs/ProtonCert.pem",
                BasicAuthCredentialsSource = AuthCredentialsSource.UserInfo,
                BasicAuthUserInfo = $"{Common.UserName}:{Common.Password}"*/
            };

            using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);

            Confluent.SchemaRegistry.Schema schema = schemaRegistry.GetSchemaAsync(1).Result;
            int schemaId = schemaRegistry.GetSchemaIdAsync("TestTypes-value",
                    @"{""type"":""record"",""name"":""sampleRecord"",""namespace"":""com.mycorp.mynamespace"",""fields"":[{""name"":""my_field1"",""type"":""int"",""doc"":""The int type is a 32-bit signed integer.""},{""name"":""my_field2"",""type"":""double"",""doc"":""The double type is a double precision (64-bit) IEEE 754 floating-point number.""},{""name"":""my_field3"",""type"":""string""}],""doc"":""Sample schema to help you get started.""}")
                .Result;

            List<string> allSubjects = schemaRegistry.GetAllSubjectsAsync().Result;
            int idx = allSubjects.FindIndex(item => item.Contains("order-events-avro-com.nordstrom.care.communications.EmailCommunicationRequested"));
            List<int> versions = schemaRegistry.GetSubjectVersionsAsync(allSubjects[idx]).Result;
            schema = schemaRegistry.GetSchemaAsync(5519/*9617*/).Result;
            schema = schemaRegistry.GetSchemaAsync(9617).Result;
            string schemaStr1 = schemaRegistry.GetSchemaAsync("order-events-avro-com.nordstrom.care.communications.EmailCommunicationRequested", 1).Result;
            schemaId = schemaRegistry.GetSchemaIdAsync("order-events-avro-com.nordstrom.care.communications.EmailCommunicationRequested", schemaStr1).Result;
            string schemaStr11 = schemaRegistry.GetSchemaAsync("order-events-avro-com.nordstrom.care.communications.EmailCommunicationRequested", 11).Result;
            schemaId = schemaRegistry.GetSchemaIdAsync("order-events-avro-com.nordstrom.care.communications.EmailCommunicationRequested", schemaStr11).Result;
            bool isCompatibleAsync = schemaRegistry.IsCompatibleAsync("order-events-avro-com.nordstrom.care.communications.EmailCommunicationRequested", schemaStr1).Result;
            isCompatibleAsync = schemaRegistry.IsCompatibleAsync("order-events-avro-com.nordstrom.care.communications.EmailCommunicationRequested", schemaStr11).Result;
            Avro.Schema avroSchema1 = Avro.Schema.Parse(schema.SchemaString);
            Avro.Schema avroSchema2 = Avro.Schema.Parse("{\"type\":\"string\"}");
            WriteLine($"{(avroSchema1 == avroSchema2 ? "=" : "!")}=");
            WriteLine($"{(avroSchema1.ToString() == avroSchema2.ToString() ? "=" : "!")}=");
            Dictionary<Avro.Schema, byte> dictionary = new Dictionary<Schema, byte>();
            dictionary.Add(avroSchema1, 1);
            if (!dictionary.ContainsKey(avroSchema2))
            {
                dictionary.Add(avroSchema2, 1);
            }

            ConcurrentDictionary<Avro.Schema, byte> concurrentDictionary = new ConcurrentDictionary<Schema, byte>();
            bool result = concurrentDictionary.TryAdd(avroSchema1, 1);
            result = concurrentDictionary.TryAdd(avroSchema2, 1);
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
                AutoOffsetReset = AutoOffsetReset.Earliest,
                #if MANUAL_COMMIT
                    EnableAutoCommit = false,
                #endif
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

                #if MANUAL_COMMIT && DO_COMMIT
                    consumer.Commit();
                    //consumer.Commit(result);
                    //consumer.Commit(new List<TopicPartitionOffset> { new(topic, result.Partition, result.Offset + 1) });
                #endif
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                WriteLine(e.Message);
            }

            consumer.Close();
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
                WriteLine($"Topic: {result.Topic}{Environment.NewLine}Partition: {result.Partition} Offset: {result.Offset}{Environment.NewLine}TopicPartition: {result.TopicPartition} TopicPartitionOffset: {result.TopicPartitionOffset}{Environment.NewLine}IsPartitionEOF: {result.IsPartitionEOF}{Environment.NewLine}Key: {result.Message.Key}{Environment.NewLine}Value: {result.Message.Value}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                WriteLine(e.Message);
            }

            consumer.Close();
        }

        public static void ConsumeByteArray(string topic)
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
                new ConsumerBuilder<string, byte[]>(consumerConfig)
                    .SetKeyDeserializer(new AvroDeserializer<string>(schemaRegistry).AsSyncOverAsync())
                    .SetErrorHandler((_, e) => WriteLine($"Error: {e.Reason}"))
                    .Build();

            try
            {
                consumer.Subscribe(topic);
                ConsumeResult<string, byte[]> result = consumer.Consume();

                var schemaId = BitConverter.ToInt32(result.Message.Value, 1);
                schemaId = !BitConverter.IsLittleEndian ? schemaId : BinaryPrimitives.ReverseEndianness(schemaId);

                var schema = schemaRegistry.GetSchemaAsync(schemaId).GetAwaiter().GetResult();
                var recordSchema = (RecordSchema)Avro.Schema.Parse(schema.SchemaString);
                //var specificRecord1 = GetSpecificRecord1(recordSchema, schemaRegistry, result).GetAwaiter().GetResult();
                var specificRecord2 = GetSpecificRecord2(recordSchema, schemaRegistry, result).GetAwaiter().GetResult();

                WriteLine($"Topic: {result.Topic}{Environment.NewLine}Partition: {result.Partition} Offset: {result.Offset}{Environment.NewLine}TopicPartition: {result.TopicPartition} TopicPartitionOffset: {result.TopicPartitionOffset}{Environment.NewLine}IsPartitionEOF: {result.IsPartitionEOF}{Environment.NewLine}Key: {result.Message.Key}{Environment.NewLine}Value: {result.Message.Value}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                WriteLine(e.Message);
            }

            consumer.Close();
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

        public static async Task<ISpecificRecord> GetSpecificRecord1(Avro.Schema schema, ISchemaRegistryClient schemaRegistryClient, ConsumeResult<string, byte[]> source)
        {
            Dictionary<Avro.Schema, Type> schemaToType;

            (_, schemaToType) = GetSpecificRecordTypesAndSchemas();

            if (!schemaToType.ContainsKey(schema))
                return null;

            var specificType = schemaToType[schema];
            var constructedAvroDeserializer = typeof(AvroDeserializer<>).MakeGenericType(specificType);
            object avroDeserializer = Activator.CreateInstance(constructedAvroDeserializer, schemaRegistryClient, null);
            if (avroDeserializer == null)
                return null;

            var methodsInfo = avroDeserializer.GetType().GetMethods();
            var methodInfo = avroDeserializer.GetType().GetMethod("DeserializeAsync");
            if (methodInfo == null)
                return null;

            var serializationContext = new SerializationContext(MessageComponentType.Value, source.Topic, source.Message.Headers);
            var task = (Task)methodInfo.Invoke(avroDeserializer, BindingFlags.InvokeMethod, null, new object[] {new ReadOnlyMemory<byte>(source.Message.Value), source.Message.Value.Length == 0, serializationContext}, null);
            if (task == null)
                return null;

            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");
            if (resultProperty == null)
                return null;

            ISpecificRecord result = (ISpecificRecord) resultProperty.GetValue(task);

            return result;
        }

        public static async Task<ISpecificRecord> GetSpecificRecord2(Avro.Schema schema, ISchemaRegistryClient schemaRegistryClient, ConsumeResult<string, byte[]> source)
        {
            Dictionary<Avro.Schema, Type> schemaToType;

            (_, schemaToType) = GetSpecificRecordTypesAndSchemas();

            if (!schemaToType.ContainsKey(schema))
                return null;

            Type specificType = schemaToType[schema];
            Type constructedAvroDeserializer = typeof(AvroDeserializer<>).MakeGenericType(specificType);
            object avroDeserializer = Activator.CreateInstance(constructedAvroDeserializer, schemaRegistryClient, null);
            if (avroDeserializer == null)
                return null;

            MethodInfo openGenericMethod = typeof(Program).GetMethod(nameof(Deserialize), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (openGenericMethod == null)
                return null;

            MethodInfo constructedGenericMethod = openGenericMethod.MakeGenericMethod(specificType);

            Expression[] parameters = constructedGenericMethod.GetParameters().Select(x =>
            {
                if (x.ParameterType.IsGenericType && x.ParameterType.GetGenericTypeDefinition().IsAssignableFrom(typeof(IAsyncDeserializer<>)))
                {
                    return Expression.Constant(avroDeserializer);
                }

                return (Expression)Expression.Parameter(x.ParameterType, x.Name);

            }).ToArray();

            MethodCallExpression callExpression = Expression.Call(null, constructedGenericMethod, parameters);

            Expression<Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>>> lambda
                = Expression.Lambda<Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>>>
                (
                    callExpression,
                    parameters.OfType<ParameterExpression>()
                );

            AvroDeserializer<TestTypes> realAvroDeserializer = new AvroDeserializer<TestTypes>(schemaRegistryClient);
            Expression<Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>>> realLambda = src => Deserialize(source, realAvroDeserializer);
            
            WriteLine(lambda.ToString());
            WriteLine(realLambda.ToString());

            Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>> f = lambda.Compile();

            return await f(source);
        }

        public static async Task<ISpecificRecord> Deserialize<T>(ConsumeResult<string, byte[]> source, IAsyncDeserializer<T> deserializer) where T : ISpecificRecord
        {
            return await deserializer.DeserializeAsync(source.Message.Value, source.Message.Value.Length == 0, new SerializationContext(MessageComponentType.Value, source.Topic, source.Message.Headers));
        }
    }
}
