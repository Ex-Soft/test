using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace TestMasterDetail.Models
{
    public partial class Master
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [XmlIgnore]
        public int Id { get; set; }
    }
}