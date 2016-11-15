using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TestReflection
{
    [DataContract]
    [Serializable]
    public class TestClass
    {
        [DataMember(Order = 3)]
        public string Property2 { get; set; }

        [DataMember(Order = 1)]
        public string Field3;

        [XmlAttribute("Field1")]
        public string Field1;

        [XmlAttribute("Field2")]
        public string Field2;

        [DataMember(Order = 0)]
        public string Field4;

        [DataMember(Order = 2)]
        public string Property1 { get; set; }

        public TestClass() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {}

        public TestClass(TestClass obj) : this(obj.Field1, obj.Field2, obj.Field3, obj.Field4, obj.Property1, obj.Property2)
        {}

        public TestClass(string field1, string field2, string field3, string field4, string property1, string property2)
        {
            Field1 = field1;
            Field2 = field2;
            Field3 = field3;
            Field4 = field4;
            Property1 = property1;
            Property2 = property2;
        }
    }
}
