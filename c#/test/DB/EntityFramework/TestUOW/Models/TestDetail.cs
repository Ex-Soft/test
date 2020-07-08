namespace TestUOW.Models
{
    public class TestDetail
    {
        public int Id { get; set; }
        public int TestMasterId { get; set; }
        public string Val { get; set; }

        public virtual TestMaster TestMaster { get; set; }
    }
}
