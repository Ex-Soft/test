using System;
using System.Collections;
using System.Collections.Concurrent;
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
            ConcurrentDictionary<string, string> concurrentDictionaryStringString = new ConcurrentDictionary<string, string>();
            HashSet<string> hashSet = new HashSet<string>();
            SortedSet<string> sortedSet = new SortedSet<string>();
            ConcurrentBag<string> concurrentBag = new ConcurrentBag<string>();

            dictionaryStringString = new Dictionary<string, string>
            {
                { "1st", "1st" },
                { "2nd", "2nd" },
                { "3rd", "3rd" },
            };

            foreach (var item in dictionaryStringString)
            {
                dictionaryStringString["4th"] = "blah";
            }

            bool result = hashSet.Add("1st");
            result = hashSet.Add("1st");

            result = sortedSet.Add("1st");
            result = sortedSet.Add("1st");

            concurrentBag.Add("1st");
            concurrentBag.Add("1st");

            listOfInt.Add(1);
            
            dictionaryStringString.Add("1st", "first");
            string tmpString = dictionaryStringString["1st"];

            IDictionary<string, string> iDictionaryStringString = dictionaryStringString;
            tmpString = iDictionaryStringString.Keys.First();
            tmpString = iDictionaryStringString[tmpString];
            
            sortedDictionaryStringString.Add("1st", "first");
            tmpString = sortedDictionaryStringString["1st"];

            concurrentDictionaryStringString.TryAdd("1st", "first");
            tmpString = concurrentDictionaryStringString.GetOrAdd("1st", "first");

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
