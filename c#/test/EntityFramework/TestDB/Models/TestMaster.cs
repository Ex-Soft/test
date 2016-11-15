using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TestMaster
    {
        public TestMaster()
        {
            this.TestDetails = new List<TestDetail>();
        }

        public int Id { get; set; }
        public string Val { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
        public Nullable<int> GCRecord { get; set; }
        public virtual ICollection<TestDetail> TestDetails { get; set; }
    }
}
