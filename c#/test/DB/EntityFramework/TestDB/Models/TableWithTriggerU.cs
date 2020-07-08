using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TableWithTriggerU
    {
        public int id { get; set; }
        public Nullable<int> value1 { get; set; }
        public Nullable<int> value2 { get; set; }
        public Nullable<int> value3 { get; set; }
        public Nullable<System.DateTime> recordModify { get; set; }
    }
}
