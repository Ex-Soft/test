using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ABC.Models
{
    public class TestTable4TestPivotProduct
    {
        public TestTable4TestPivotProduct()
        {
            TestTable4TestPivotLists = new List<TestTable4TestPivotList>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<TestTable4TestPivotList> TestTable4TestPivotLists { get; set; }
    }
}