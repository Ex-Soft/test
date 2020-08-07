using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TestTable4Types
    {
        public long Id { get; set; }
        public string FVarChar { get; set; }
        public string FNVarChar { get; set; }
        public Nullable<bool> FBit { get; set; }
    }
}
