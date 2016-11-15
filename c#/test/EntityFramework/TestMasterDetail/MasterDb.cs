using System.Xml.Serialization;

namespace TestMasterDetail
{
    public partial class Master
    {
        [XmlIgnore]
        public int Id { get; set; }

        [XmlIgnore]
        public int? OptimisticLockField { get; set; }

        [XmlIgnore]
        public int? GCRecord { get; set; }
    }
}