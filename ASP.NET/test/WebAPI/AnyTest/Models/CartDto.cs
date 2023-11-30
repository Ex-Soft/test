namespace AnyTest.Models
{
    public class CartDto
    {
        public CartItemDto[]? Products { get; set; }
    }

    public class CartItemDto
    {
        public ulong Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
