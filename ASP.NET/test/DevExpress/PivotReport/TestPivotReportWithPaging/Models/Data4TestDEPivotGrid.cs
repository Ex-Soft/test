using System.ComponentModel.DataAnnotations;

namespace TestPivotReportWithPaging.Models
{
    public class Data4TestDEPivotGrid
    {
        [Key]
        public long id { get; set; }
        public short year { get; set; }
        public byte quarter { get; set; }
        public byte month { get; set; }
        public byte day { get; set; }
        public string name { get; set; }
        public decimal value { get; set; }
    }
}