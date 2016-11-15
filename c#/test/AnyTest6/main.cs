// http://sergeyteplyakov.blogspot.com/2015/08/c-60-overview.html?spref=fb
// https://github.com/dotnet/roslyn/wiki/New-Language-Features-in-C%23-6
// https://msdn.microsoft.com/en-us/magazine/dn802602.aspx

using System;
using System.Collections.Generic;

namespace AnyTest6
{
    class Customer
    {
        public string First { get; set; } = "Jane";
        public string Last { get; } = "Doe";
    }

    class Program
    {
        static void Main(string[] args)
        {
            string tmpString = null;
            int? tmpIntNullable = tmpString?.Length;
            int tmpInt = tmpString?.Length ?? -1;

            tmpString = "12345";
            tmpIntNullable = tmpString?.Length;
            tmpInt = tmpString?.Length ?? -1;

            var numbers = new Dictionary<int, string>
            {
                [7] = "seven",
                [9] = "nine",
                [13] = "thirteen"
            };

            var tmpCustomer = new Customer();
            tmpString = $"{tmpCustomer.First} {tmpCustomer.Last}"; // equ tmpString = string.Format("{1} {0}", tmpCustomer.First, tmpCustomer.Last);

            NameOf_UsingNameofExpressionInArgumentNullException();
        }

        /*public static string Truncate(string value, int length)
        {
            string result = value;
            if (value != null) // Skip empty string check for elucidation
            {
                result = value.Substring(0, Math.Min(value.Length, length));
            }
            return result;
        }
        */

        public static string Truncate(string value, int length)
        {
            return value?.Substring(0, Math.Min(value.Length, length));
        }

        //[TestMethod]
        //public void Truncate_WithNull_ReturnsNull()
        //{
        //    Assert.AreEqual<string>(null, Truncate(null, 42));
        //}

        public static void ThrowArgumentNullExceptionUsingNameOf(string param1)
        {
            throw new ArgumentNullException(nameof(param1));
        }

        //[TestMethod]
        public static void NameOf_UsingNameofExpressionInArgumentNullException()
        {
            try
            {
                ThrowArgumentNullExceptionUsingNameOf("data");
                //Assert.Fail("This code should not be reached");
            }
            catch (ArgumentNullException exception)
            {
                //Assert.AreEqual<string>("param1", exception.ParamName);
            }
        }
    }
}
