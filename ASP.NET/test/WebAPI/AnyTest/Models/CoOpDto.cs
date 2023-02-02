namespace AnyTest.Models
{
    public class CoOpDto
    {
        public decimal? TotalAmount { get; set; }
        public CoOpItemDto[]? Items { get; set; }
    }

    public class CoOpItemDto
    {
        public DateOnly? Date { get; set; }
        public string? Description { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public decimal? Amount { get; set; }
    }
}