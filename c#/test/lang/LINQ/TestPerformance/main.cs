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

            //Debug.WriteLine("sort");
            //var sort = arr.OrderByDescending(item => item).ToArray();
            Debug.WriteLine("sort -> distinct");
            var sortDistinct = arr.OrderByDescending(item => item).Distinct().ToArray();
/*
sort -> distinct

int CompareTo(object {FiledInt: 5})
int CompareTo(object {FiledInt: -1})
int CompareTo(object {FiledInt: 2})
int CompareTo(object {FiledInt: 5})
int CompareTo(object {FiledInt: 3})
int CompareTo(object {FiledInt: 3})
int CompareTo(object {FiledInt: -1})
int CompareTo(object {FiledInt: 5})
int CompareTo(object {FiledInt: 3})
int CompareTo(object {FiledInt: 5})
int CompareTo(object {FiledInt: 5})
int CompareTo(object {FiledInt: 5})
int CompareTo(object {FiledInt: 5})
int CompareTo(object {FiledInt: 5})

override int GetHashCode(5)
override int GetHashCode(5)
override bool Equals(object {FiledInt: 5})
operator == (TestClassIComparableFull {FiledInt: 5}, TestClassIComparableFull {FiledInt: 5})
override int GetHashCode(3)
override int GetHashCode(2)
override int GetHashCode(0)
override int GetHashCode(-1)

*/

            //Debug.WriteLine("distinct");
            //var distinct = arr.Distinct().ToArray();
            Debug.WriteLine("distinct -> sort");
            var distinctSort = arr.Distinct().OrderByDescending(item => item).ToArray();
/*
distinct -> sort

override int GetHashCode(5)
override int GetHashCode(-1)
override int GetHashCode(0)
override int GetHashCode(3)
override int GetHashCode(5)
override bool Equals(object {FiledInt: 5})
operator == (TestClassIComparableFull {FiledInt: 5}, TestClassIComparableFull {FiledInt: 5})
override int GetHashCode(2)

int CompareTo(object {FiledInt: 5})
int CompareTo(object {FiledInt: -1})
int CompareTo(object {FiledInt: 2})
int CompareTo(object {FiledInt: 3})
int CompareTo(object {FiledInt: -1})
int CompareTo(object {FiledInt: 5})
int CompareTo(object {FiledInt: 3})
int CompareTo(object {FiledInt: 3})

*/
        }
    }
}
