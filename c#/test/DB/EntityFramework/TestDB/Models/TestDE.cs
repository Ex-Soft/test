using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TestDE
    {
        public long id { get; set; }
        public Nullable<int> f1 { get; set; }
        public Nullable<int> f2 { get; set; }
        public Nullable<int> f3 { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
        public Nullable<int> GCRecord { get; set; }
    }
}
