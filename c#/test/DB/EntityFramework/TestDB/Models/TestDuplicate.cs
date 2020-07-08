using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TestDuplicate
    {
        public int id { get; set; }
        public Nullable<int> F1 { get; set; }
        public Nullable<int> F2 { get; set; }
        public Nullable<int> F3 { get; set; }
    }
}
