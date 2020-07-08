// https://msdn.microsoft.com/en-us/data/jj591620.aspx?f=255&MSPPError=-2147217396
// https://www.safaribooksonline.com/library/view/programming-entity-framework/9781449317867/ch04s07.html
// http://www.entityframeworktutorial.net/code-first/configure-one-to-one-relationship-in-code-first.aspx

using System;
using System.Globalization;
using OneToOne.Models;

namespace OneToOne
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new OneToOneDbContext())
            {
                TestTable4TestPIVOTProduct
                    tmpProduct;

                if ((tmpProduct = db.TestTable4TestPIVOTProducts.Find(new object[] {1})) != null)
                    Console.WriteLine("\"{0}\" -> \"{1}\": {2}", tmpProduct.Name, tmpProduct.TestTable4TestPIVOTList != null && tmpProduct.TestTable4TestPIVOTList.Store != null ? tmpProduct.TestTable4TestPIVOTList.Store.Name : "null", tmpProduct.TestTable4TestPIVOTList != null && tmpProduct.TestTable4TestPIVOTList.Cnt.HasValue ? tmpProduct.TestTable4TestPIVOTList.Cnt.Value.ToString(CultureInfo.InvariantCulture) : "null");
                Console.WriteLine();

                foreach(var product in db.TestTable4TestPIVOTProducts)
                    Console.WriteLine("{0} \"{1}\" -> \"{2}\": {3}", product.Id, product.Name, product.TestTable4TestPIVOTList != null && product.TestTable4TestPIVOTList.Store != null ? product.TestTable4TestPIVOTList.Store.Name : "null", product.TestTable4TestPIVOTList != null && product.TestTable4TestPIVOTList.Cnt.HasValue ? product.TestTable4TestPIVOTList.Cnt.Value.ToString(CultureInfo.InvariantCulture) : "null");
                Console.WriteLine();
            }
        }
    }
}
