using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestPivotGridWithServerMode.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        [Key]
        public int OID { get; set; }
        public string CustomerName { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
