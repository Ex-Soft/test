using System.Collections.Generic;

namespace TestUOW.Models
{
    public class TestMaster
    {
        public TestMaster()
        {
            this.TestDetails = new List<TestDetail>();
        }

        public int Id { get; set; }
        public string Val { get; set; }

        public virtual ICollection<TestDetail> TestDetails { get; set; }
    }
}
