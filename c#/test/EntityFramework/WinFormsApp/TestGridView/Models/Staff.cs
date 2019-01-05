using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGridView.Models
{
    public partial class Staff
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }
        public int? Dep { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? NullField { get; set; }
    }
}
