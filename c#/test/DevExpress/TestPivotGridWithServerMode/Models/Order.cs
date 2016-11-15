using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestPivotGridWithServerMode.Models
{
    public class Order
    {
        public Order()
        {
            Sales = new List<Sale>();
        }

        [Key]
        public int OID { get; set; }
        public int? IdSalesPerson { get; set; }
	    public int? IdCustomer { get; set; }
	    public DateTime? OrderDate { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }

        public virtual SalesPeople SalesPeople { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
