using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestJsonNET
{
    [JsonConverter(typeof(StringEnumConverter))]
    enum TestEnum
    {
        Zero,
        First,
        Second,
        Third
    }

    [JsonConverter(typeof(GenderEnumConverter))]
    enum GenderEnum
    {
        Male,
        Female
    }

    class TestObject
    {
        public bool FBool { get; set; }
        public string FString { get; set; }
        public int FInt { get; set; }
        public float FFloat { get; set; }
        public double FDouble { get; set; }
        public decimal FDecimal { get; set; }
        public DateTime FDateTime { get; set; }
        public int[] FArrayInts { get; set; }
        public List<int> FListInts { get; set; }
        public TestObject[] FArrayTestObjects { get; set; }
        public List<TestObject> FListTestObjects { get; set; }
        public TestEnum FTestEnum { get; set; }
        public GenderEnum FGenderEnum { get; set; }
    }

    public class GenderEnumConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();

            if (string.Compare(value, "M", true) == 0)
            {
                return GenderEnum.Male;
            }

            if (string.Compare(value, "F", true) == 0)
            {
                return GenderEnum.Female;
            }
            
            return GenderEnum.Male;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = (GenderEnum)value;

            // Write associative array field name
            writer.WriteValue(value.ToString().Substring(0,1));
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
