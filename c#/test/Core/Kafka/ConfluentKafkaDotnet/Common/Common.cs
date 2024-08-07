﻿using System;
using System.Linq;
using System.Reflection;
using Avro;
using Avro.Generic;

namespace ConfluentKafkaDotnet.Common
{
    public class Common
    {
        public const string
            BootstrapServers = "localhost:9092", // "brook.nonprod.us-west-2.aws.proton.nordstrom.com:9093",
            SchemaRegistryUrl = "localhost:8081", // "https://schema-registry.nonprod.us-west-2.aws.proton.nordstrom.com",
            TopicTestTypes = "TestTypes",
            TopicCustomer = "Customer",
            TopicSimple = "Simple",
            TopicMultiSchema = "MultiSchema",
            UserName = "resplendent-ermine.W76KGBB2UKOFM3N0W",
            Password = "HyQaeevpJ843lTGem08LDNa51vluVHsTf6SQOvmxiOgypkNMVUH4CZFQmehXiO8oSYAy1X-eVCCmkhOdVP_9j6b-tpGE5maALRxKXQtrSMHWq97t6yPsZfzERP8AmERZ";

        public static GenericRecord SpecificRecordToGenericRecord(object specificRecord)
        {
            var type = specificRecord.GetType();
            var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var schema = type.GetField("_SCHEMA", BindingFlags.Static | BindingFlags.Public)?.GetValue(null) as RecordSchema;
            var result = new GenericRecord(schema);

            foreach (var pi in propertyInfos)
            {
                if (pi.PropertyType == typeof(Schema)
                    || !result.Schema.Fields.Exists(field => field.Name.Equals(pi.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                result.Add(pi.Name, pi.GetValue(specificRecord));
            }

            return result;
        }

        public static T GenericRecordToSpecificRecord<T>(GenericRecord genericRecord) where T : new()
        {
            T result = new();
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var field in genericRecord.Schema.Fields)
            {
                PropertyInfo pi;
                if ((pi = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(field.Name, StringComparison.InvariantCultureIgnoreCase))) == null)
                    continue;

                pi.SetValue(result, genericRecord[field.Name]);
            }

            return result;
        }
    }
}
