// http://www.c-sharpcorner.com/article/c-sharp-7-2-new-features-with-visual-studio-2017/

using System;

using static System.Console;

namespace cs72
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = default;
            int binaryValue = 0b_0101_0101;

            PrintOrderDetails("Gift Shop", 31, "Red Mug");

            // Named arguments can be supplied for the parameters in any order.
            PrintOrderDetails(orderNum: 31, productName: "Red Mug", sellerName: "Gift Shop");
            PrintOrderDetails(productName: "Red Mug", sellerName: "Gift Shop", orderNum: 31);

            // Named arguments mixed with positional arguments are valid
            // as long as they are used in their correct position.
            PrintOrderDetails("Gift Shop", 31, productName: "Red Mug");
            PrintOrderDetails(sellerName: "Gift Shop", 31, productName: "Red Mug");    // C# 7.2 onwards
            PrintOrderDetails("Gift Shop", orderNum: 31, "Red Mug");                   // C# 7.2 onwards

            // However, mixed arguments are invalid if used out-of-order.
            // The following statements will cause a compiler error.
            // PrintOrderDetails(productName: "Red Mug", 31, "Gift Shop");
            // PrintOrderDetails(31, sellerName: "Gift Shop", "Red Mug");
            // PrintOrderDetails(31, "Red Mug", sellerName: "Gift Shop");

            int a = 20, b = 30, c = 0;
            Write($"Sum of {a} and {b} is: ");
            Add(a, b, ref c);
            WriteLine($"{c}");
        }

        static void PrintOrderDetails(string sellerName, int orderNum, string productName)
        {
            if (string.IsNullOrWhiteSpace(sellerName))
            {
                throw new ArgumentException(message: "Seller name cannot be null or empty.", paramName: nameof(sellerName));
            }

            WriteLine($"Seller: {sellerName}, Order #: {orderNum}, Product: {productName}");
        }

        public static void Add(ref readonly int x, ref readonly int y, ref int z)
        {
            z = x + y + z;
        }
    }
}
