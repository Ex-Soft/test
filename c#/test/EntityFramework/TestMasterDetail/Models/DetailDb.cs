using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMasterDetail.Models
{
    public partial class Detail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [XmlIgnore]
        public int Id { get; set; }

        [ForeignKey("Master")]
        [XmlIgnore]
        public int IdMaster { get; set; }

        [XmlIgnore]
        public Master Master { get; set; }
    }
}
