using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TableWithHierarchy
    {
        public TableWithHierarchy()
        {
            this.TableWithHierarchy1 = new List<TableWithHierarchy>();
        }

        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Val { get; set; }
        public virtual ICollection<TableWithHierarchy> TableWithHierarchy1 { get; set; }
        public virtual TableWithHierarchy TableWithHierarchy2 { get; set; }
    }
}
