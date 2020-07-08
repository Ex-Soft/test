using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TableWithTrigger2WD
    {
        public long id { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public bool deleted { get; set; }
    }
}
