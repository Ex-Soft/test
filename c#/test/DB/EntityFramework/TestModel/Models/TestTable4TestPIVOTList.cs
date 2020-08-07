using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestModel.Models
{
    public class TestTable4TestPivotList
    {
        [Key]
        public int Id { get; set; }
        public int? Cnt { get; set; }

        [ForeignKey("Store")]
        public int? IdStore { get; set; }
        public virtual TestTable4TestPivotStore Store { get; set; }

        [ForeignKey("Product")]
        public int? IdProduct { get; set; }
        public virtual TestTable4TestPivotProduct Product { get; set; }
    }
}