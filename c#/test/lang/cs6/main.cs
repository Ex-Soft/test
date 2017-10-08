// http://sergeyteplyakov.blogspot.com/2015/08/c-60-overview.html?spref=fb
// https://github.com/dotnet/roslyn/wiki/New-Language-Features-in-C%23-6
// https://msdn.microsoft.com/en-us/magazine/dn802602.aspx

using System;
using System.Collections.Generic;

// Using static
using static System.Console;
using static System.Linq.Enumerable;

namespace cs6
{
    public class ClassWithListOfString
    {
        public List<string> ListOfString { get; set; }
    }

    // Auto-property enhancements
    class Customer
    {
        private int _fInt;

        public int FInt
        {
            get { return _fInt; }
            set { _fInt = value * 2; }
        }

        // Initializers for auto-properties
        public string First { get; set; } = "Jane";

        // Getter-only auto-properties
        public string Last { get; } = "Doe";

        // Expression bodies on property-like function members
        public string FullName => $"{First} {Last}";

        // Extension methods
        public void Print() => WriteLine(FullName);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var classWithListOfString = new ClassWithListOfString();
            foreach (var str in classWithListOfString?.ListOfString)
                System.Diagnostics.Debug.WriteLine(str);

            var range = Range(5, 17);
            //var odd = Where(range, i => i % 2 == 1); // Error, not in scope
            var even = range.Where(i => i % 2 == 0); // Ok

            // nameof expressions
            WriteLine(nameof(Customer.FullName));

            // Null-conditional operators
            string tmpString = null;
            int? tmpIntNullable = tmpString?.Length;
            int tmpInt = tmpString?.Length ?? -1;

            tmpString = "12345";
            tmpIntNullable = tmpString?.Length;
            tmpInt = tmpString?.Length ?? -1;

            // Index initializers
            var numbers = new Dictionary<int, string>
            {
                [7] = "seven",
                [9] = "nine",
                [13] = "thirteen"
            };

            // String interpolation
            var tmpCustomer = new Customer();
            tmpString = $"{tmpCustomer.First} {tmpCustomer.Last}"; // equ tmpString = string.Format("{1} {0}", tmpCustomer.First, tmpCustomer.Last);

            NameOf_UsingNameofExpressionInArgumentNullException();

            // Exception filters
            try
            {
                throw new Exception("Test Exception filters");
            }
            catch (Exception e) when (IsMyException(e))
            {
                WriteLine(e.Message);
            }

            // Await in catch and finally blocks
            /*Resource res = null;
            try
            {
                res = await Resource.OpenAsync(…);       // You could do this.

            }
            catch (ResourceException e)
            {
                await Resource.LogAsync(res, e);         // Now you can do this …
            }
            finally
            {
                if (res != null) await res.CloseAsync(); // … and this.
            }*/
        }

        private static bool IsMyException(Exception e)
        {
            return e.Message == "Test Exception filters";
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
