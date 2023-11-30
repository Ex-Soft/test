namespace AnyTest.Models
{
    public class ProductDto
    {
        public ulong Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public required string Sku { get; set; }
    }
}
