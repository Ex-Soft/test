using EssentialTools.Models;

namespace EssentialTools.Controllers
{
    public class HomeController
    {
        IValueCalculator calc;

        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public decimal GetTotalValue()
        {
            ShoppingCart cart = new ShoppingCart(calc)
            {
                Products = products
            };

            return cart.CalculateProductTotal();
        }
    }
}
