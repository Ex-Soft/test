using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestPivotGridWithServerMode.Models
{
    public class Product
    {
        public Product()
        {
            Sales = new List<Sale>();
        }

        [Key]
        public int OID { get; set; }
	    public string ProductName { get; set; }
	    public int? IdCategory { get; set; }
	    public int? OptimisticLockField { get; set; }
	    public int? GCRecord { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
