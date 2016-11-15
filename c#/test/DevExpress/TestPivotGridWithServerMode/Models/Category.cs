using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestPivotGridWithServerMode.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        [Key]
        public int OID { get; set; }
        public string CategoryName { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
