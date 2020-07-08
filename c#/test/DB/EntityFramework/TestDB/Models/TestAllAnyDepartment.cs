using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TestAllAnyDepartment
    {
        public TestAllAnyDepartment()
        {
            this.TestAllAnyEmployees = new List<TestAllAnyEmployee>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<TestAllAnyEmployee> TestAllAnyEmployees { get; set; }
    }
}
