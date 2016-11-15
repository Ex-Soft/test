using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestSerializationII
{
    [Serializable]
    public class SmthObject
    {
        public int Field1;
        public int Field2;
        [XmlElement(ElementName = "Field_Nullable_Decimal", IsNullable = true)]
        public decimal? FieldNullableDecimal;

        [XmlAttribute("Attribute1")]
        public int Attribute1;
    }

    [Serializable]
    public class Container
    {
        public int ContainerField;

        [XmlElement("SmthObject")] // without this overnest is generated
        public List<SmthObject> SmthObjects;
    }
}
