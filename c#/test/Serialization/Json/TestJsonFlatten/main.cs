using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonFlatten;

namespace TestJsonFlatten
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = "{\"Inner.B\": \"B value\", \"Inner.C\": \"C value\", \"Inner.A\": \"A value\"}";
            IDictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            JObject unflatten = dict.Unflatten();
            Outer obj = unflatten.ToObject<Outer>();

            JObject jObj = JObject.FromObject(obj);
            dict = jObj.Flatten();
            jsonString = JsonConvert.SerializeObject(dict);
        }
    }

    public class Outer
    {
        public Inner Inner { get; set; } = new Inner();
    }

    public class Inner
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    }
}
