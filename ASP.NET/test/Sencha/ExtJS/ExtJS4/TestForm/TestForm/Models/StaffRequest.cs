namespace TestForm.Models
{
    public class StaffRequest
    {
        public ulong _dc { get; set; }
        public int page { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
    }
}