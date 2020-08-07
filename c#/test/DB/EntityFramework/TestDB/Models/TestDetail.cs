using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TestDetail
    {
        public int Id { get; set; }
        public int IdMaster { get; set; }
        public string Val { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
        public Nullable<int> GCRecord { get; set; }
        public virtual TestMaster TestMaster { get; set; }
    }
}
