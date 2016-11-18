using System.ComponentModel.DataAnnotations;

namespace TestGridWithServerMode.Models.EF
{
    class TableWithHugeData
    {
        [Key]
        public long Id { get; set; }
        public string FString { get; set; }
    }
}
