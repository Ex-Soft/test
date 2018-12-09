using Equality;
using System.Diagnostics;
using System.Linq;

namespace TestPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new [] {
                new TestClassIComparableFull(5),
                new TestClassIComparableFull(-1),
                new TestClassIComparableFull(0),
                new TestClassIComparableFull(3),
                new TestClassIComparableFull(5),
                new TestClassIComparableFull(2)
            };

            Debug.WriteLine("sort");
            var sort = arr.OrderByDescending(item => item).ToArray();
            Debug.WriteLine("sort -> distinct");
            var sortDistinct = arr.OrderByDescending(item => item).Distinct().ToArray();

            Debug.WriteLine("distinct");
            var distinct = arr.Distinct().ToArray();
            Debug.WriteLine("distinct -> sort");
            var distinctSort = arr.Distinct().OrderByDescending(item => item).ToArray();
        }
    }
}
