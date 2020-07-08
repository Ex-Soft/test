using System;
using System.Globalization;
using System.Linq;
using TestModel.Models;

namespace TestModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestModelDbContext())
            {
                var tmpProduct = db.TestTable4TestPivotProducts.Find(1);

                if (tmpProduct != null)
                {
                    if(tmpProduct.TestTable4TestPivotLists != null)
                        foreach (var list in tmpProduct.TestTable4TestPivotLists)
                            Console.WriteLine("{0} \"{1}\" -> {2} \"{3}\" ({4})", tmpProduct.Id, tmpProduct.Name, list.Store != null ? list.Store.Id.ToString(CultureInfo.InvariantCulture) : "null", list.Store != null && !string.IsNullOrWhiteSpace(list.Store.Name) ? list.Store.Name : "null", list.Cnt.HasValue ? list.Cnt.Value.ToString(CultureInfo.InvariantCulture) : "null");
                }
                Console.WriteLine();

                foreach (var product in db.TestTable4TestPivotProducts.OrderBy(p => p.Name))
                {
                    if (product.TestTable4TestPivotLists != null)
                        foreach (var list in product.TestTable4TestPivotLists)
                            Console.WriteLine("{0} \"{1}\" -> {2} \"{3}\" ({4})", product.Id, product.Name, list.Store != null ? list.Store.Id.ToString(CultureInfo.InvariantCulture) : "null", list.Store != null && !string.IsNullOrWhiteSpace(list.Store.Name) ? list.Store.Name : "null", list.Cnt.HasValue ? list.Cnt.Value.ToString(CultureInfo.InvariantCulture) : "null");
                    else
                        Console.WriteLine("{0} \"{1}\"", product.Id, product.Name);
                }
                Console.WriteLine();

                var tmpStore = db.TestTable4TestPivotStores.Find(1);

                if (tmpStore != null)
                {
                    if (tmpStore.TestTable4TestPivotLists != null)
                        foreach (var list in tmpStore.TestTable4TestPivotLists)
                            Console.WriteLine("{0} \"{1}\" -> {2} \"{3}\" ({4})", tmpStore.Id, tmpStore.Name, list.Product != null ? list.Product.Id.ToString(CultureInfo.InvariantCulture) : "null", list.Product != null && !string.IsNullOrWhiteSpace(list.Product.Name) ? list.Product.Name : "null", list.Cnt.HasValue ? list.Cnt.Value.ToString(CultureInfo.InvariantCulture) : "null");
                }
                Console.WriteLine();

                foreach (var store in db.TestTable4TestPivotStores.OrderBy(s => s.Name))
                {
                    if (store.TestTable4TestPivotLists != null)
                        foreach (var list in store.TestTable4TestPivotLists)
                            Console.WriteLine("{0} \"{1}\" -> {2} \"{3}\" ({4})", store.Id, store.Name, list.Product != null ? list.Product.Id.ToString(CultureInfo.InvariantCulture) : "null", list.Product != null && !string.IsNullOrWhiteSpace(list.Product.Name) ? list.Product.Name : "null", list.Cnt.HasValue ? list.Cnt.Value.ToString(CultureInfo.InvariantCulture) : "null");
                    else
                        Console.WriteLine("{0} \"{1}\"", store.Id, store.Name);
                }
                Console.WriteLine();

                foreach (var list in db.TestTable4TestPivotList)
                    Console.WriteLine("{0} \"{1}\" -> {2} \"{3}\" ({4})", list.Product != null ? list.Product.Id.ToString(CultureInfo.InvariantCulture) : "null", list.Product != null && !string.IsNullOrWhiteSpace(list.Product.Name) ? list.Product.Name : "null", list.Store != null ? list.Store.Id.ToString(CultureInfo.InvariantCulture) : "null", list.Store != null && !string.IsNullOrWhiteSpace(list.Store.Name) ? list.Store.Name : "null", list.Cnt.HasValue ? list.Cnt.Value.ToString(CultureInfo.InvariantCulture) : "null");
                Console.WriteLine();
            }
        }
    }
}
