using System.ComponentModel.DataAnnotations;

namespace TestPivotGridWithServerMode.Models
{
    public class Sale
    {
        [Key]
        public int OID { get; set; }
	    public int? IdOrder { get; set; }
	    public int? IdProduct { get; set; }
	    public int? Quantity { get; set; }
	    public decimal? UnitPrice { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
