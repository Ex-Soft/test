using System;
using System.Buffers.Binary;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Avro.Specific;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;

namespace MultiTypesWinFormsApp.Helpers
{
    public class KafkaUtils
    {
        public static Avro.Schema GetAvroSchema(Type type)
        {
            return typeof(ISpecificRecord).IsAssignableFrom(type) ? (Avro.Schema)type.GetField("_SCHEMA", BindingFlags.Static | BindingFlags.Public)?.GetValue(null) : null;
        }

        public static Func<ConsumeResult<string, byte[]>, Task<ISpecificRecord>> CreateSpecificConverter(Type specificType, ISchemaRegistryClient schemaRegistryClient)
        {
            Type constructedAvroDeserializer = typeof(AvroDeserializer<>).MakeGenericType(specificType);
            object avroDeserializer = Activator.CreateInstance(constructedAvroDeserializer, schemaRegistryClient, null);
            if (avroDeserializer == null)
                return null;

            MethodInfo openGenericMethod = typeof(KafkaUtils).GetMethod(nameof(Deserialize), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
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

            return lambda.Compile();
        }

        public static async Task<ISpecificRecord> Deserialize<T>(ConsumeResult<string, byte[]> source, IAsyncDeserializer<T> deserializer) where T : ISpecificRecord
        {
            return await deserializer.DeserializeAsync(source.Message.Value, source.Message.Value.Length == 0, new SerializationContext(MessageComponentType.Value, source.Topic, source.Message.Headers));
        }

        public static int GetSchemaId(byte[] array)
        {
            if (array[0] != 0)
            {
                throw new InvalidDataException($"Expecting data with Confluent Schema Registry framing. Magic byte was {array[0]}, expecting 0");
            }

            int schemaId = BitConverter.ToInt32(array, 1);
            return !BitConverter.IsLittleEndian ? schemaId : BinaryPrimitives.ReverseEndianness(schemaId);
        }
    }
}
