using System;
using System.Data.Linq.Mapping;

namespace TestLINQ2SQLII
{
    [Table(Name = "Staff")]
    public class Staff
    {
        [Column(IsPrimaryKey = true, CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public long ID { get; set; }
        
        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public string Name { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public decimal? Salary { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public int? Dep { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public DateTime? BirthDate { get; set; }

        [Column(CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public decimal? NullField { get; set; }
    }
}
