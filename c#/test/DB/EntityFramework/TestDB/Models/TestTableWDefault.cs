using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TestTableWDefault
    {
        public int Id { get; set; }
        public Nullable<int> Val { get; set; }
        public string UsrName { get; set; }
        public System.DateTime DtTm { get; set; }
    }
}
