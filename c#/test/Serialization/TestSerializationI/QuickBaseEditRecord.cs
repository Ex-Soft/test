using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TestSerializationI
{
    [DataContract]
    [Serializable]
    public class QuickBaseEditRecord
    {
        [XmlElement]
        public string udata;

        [XmlElement]
        public string ticket;

        [XmlElement]
        public string apptoken;

        [XmlElement]
        public int rid;

        [XmlElement("field")]
        public QuickBaseEditRecordField[] fields;
    }

    [DataContract]
    [Serializable]
    public class QuickBaseEditRecordField
    {
        [XmlAttribute]
        public string name;

        [XmlText]
        public string Value;
    }
}
