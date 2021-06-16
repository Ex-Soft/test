using System;
using System.Linq;
using System.Reflection;
using Avro;
using Avro.Generic;

namespace MultiTypesWinFormsApp.Common
{
    public class Common
    {
        public const string
            BootstrapServers = "localhost:9092",
            SchemaRegistryUrl = "localhost:8081",
            TopicTestTypes = "TestTypes",
            TopicCustomer = "Customer",
            TopicSimple = "Simple",
            TopicMultiSchema = "MultiSchema";

        public static GenericRecord SpecificRecordToGenericRecord(object specificRecord)
        {
            var type = specificRecord.GetType();
            var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (type.GetField("_SCHEMA", BindingFlags.Static | BindingFlags.Public)?.GetValue(null) is not RecordSchema schema)
            {
                return null;
            }

            var result = new GenericRecord(schema);

            foreach (var pi in propertyInfos)
            {
                if (pi.PropertyType == typeof(Schema)
                    || !result.Schema.Fields.Exists(field => field.Name.Equals(pi.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                if (pi.PropertyType.IsEnum)
                {
                    var enumField = schema.Fields.FirstOrDefault(field => field.Name == pi.Name);
                    if (enumField == null)
                    {
                        continue;
                    }

                    var value = pi.GetValue(specificRecord);
                    if (value == null)
                    {
                        continue;
                    }

                    var enumValue = new GenericEnum((EnumSchema)enumField.Schema, value.ToString());
                    result.Add(pi.Name, enumValue);
                }
                else
                {
                    result.Add(pi.Name, pi.GetValue(specificRecord));
                }
            }

            return result;
        }
    }
}
