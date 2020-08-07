using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class Staff
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<int> Dep { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<decimal> NullField { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
        public Nullable<int> GCRecord { get; set; }
    }
}
