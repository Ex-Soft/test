using System.Xml.Serialization;

namespace TestMasterDetail
{
    public partial class Detail
    {
        [XmlIgnore]
        public int Id { get; set; }

        [XmlIgnore]
        public int IdMaster { get; set; }

        [XmlIgnore]
        public int? OptimisticLockField { get; set; }

        [XmlIgnore]
        public int? GCRecord { get; set; }

        [XmlIgnore]
        public Master Master { get; set; }
    }
}
