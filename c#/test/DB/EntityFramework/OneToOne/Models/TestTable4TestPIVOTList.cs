namespace OneToOne.Models
{
    public class TestTable4TestPIVOTList
    {
        public int Id { get; set; }
        public int? IdStore { get; set; }
        public int? IdProduct { get; set; }
        public int? Cnt { get; set; }

        public virtual TestTable4TestPIVOTStore Store { get; set; }
        public virtual TestTable4TestPIVOTProduct Product { get; set; }
    }
}