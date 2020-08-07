namespace OneToOne.Models
{
    public class TestTable4TestPIVOTProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual TestTable4TestPIVOTList TestTable4TestPIVOTList { get; set; }
    }
}