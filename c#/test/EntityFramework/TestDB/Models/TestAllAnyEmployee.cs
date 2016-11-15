using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TestAllAnyEmployee
    {
        public TestAllAnyEmployee()
        {
            this.TestAllAnyEmployee1 = new List<TestAllAnyEmployee>();
        }

        public int id { get; set; }
        public Nullable<int> department_id { get; set; }
        public Nullable<int> chief_id { get; set; }
        public string name { get; set; }
        public Nullable<decimal> salary { get; set; }
        public virtual TestAllAnyDepartment TestAllAnyDepartment { get; set; }
        public virtual ICollection<TestAllAnyEmployee> TestAllAnyEmployee1 { get; set; }
        public virtual TestAllAnyEmployee TestAllAnyEmployee2 { get; set; }
    }
}
