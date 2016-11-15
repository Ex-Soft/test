using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TableWithTriggerIUDHistory
    {
        public decimal Id { get; set; }
        public string Value { get; set; }
        public System.DateTime RecordModify { get; set; }
    }
}
