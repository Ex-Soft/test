using System.Xml.Serialization;

namespace TestSerializationI
{
    public class Reports
    {
        [XmlElement("Report")]
        public Report[] Report;
    }

    public class Report
    {
        [XmlAttributeAttribute]
        public long id;

        [XmlAttributeAttribute]
        public string outercode;

        [XmlAttributeAttribute("ProcessedIn1CFacing")]
        public string Status;
    }
}
