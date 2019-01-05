using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMasterDetail.Models
{
    [Serializable]
    public partial class Detail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Val { get; set; }

        [ForeignKey("Master")]
        public int IdMaster { get; set; }
        public virtual Master Master { get; set; }
    }
}
