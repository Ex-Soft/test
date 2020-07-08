using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TestTableWithNullField
    {
        public int id { get; set; }
        public Nullable<int> val { get; set; }
    }
}
