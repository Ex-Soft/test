using System;
using System.Collections.Generic;
using System.Linq;

namespace Inside
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfInt = new List<int>();
            Dictionary<string, string> dictionaryStringString = new Dictionary<string, string>();
            SortedDictionary<string, string> sortedDictionaryStringString = new SortedDictionary<string, string>();
            HashSet<string> hashSet = new HashSet<string>();

            IEnumerable<int> iEnumerableInt = listOfInt;
            IEnumerator<int> iEnumeratorInt = iEnumerableInt.GetEnumerator();
            iEnumeratorInt.Dispose();

            IQueryable<int> iQueryableInt = listOfInt.AsQueryable();
            iEnumeratorInt = iQueryableInt.GetEnumerator();
            iEnumeratorInt.Dispose();

            ICollection<int> iCollectionInt = listOfInt;
            iEnumeratorInt = iCollectionInt.GetEnumerator();
            iEnumeratorInt.Dispose();

            IList<int> iListInt = listOfInt;
            iEnumeratorInt = iListInt.GetEnumerator();
            iEnumeratorInt.Dispose();
        }
    }
}
