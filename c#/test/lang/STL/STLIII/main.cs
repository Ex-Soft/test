//#define TEST_LIST
#define TEST_DICTIONARY

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace STLIII
{
    #if TEST_DICTIONARY
        class Victim
        {
            public string FString { get; set; }
        }
    #endif

    #if TEST_LIST
        class A : IEquatable<A>
        {
            public int FA { get; set; }

            public A(A obj) : this(obj.FA)
            {}

            public A(int fA = default(int))
            {
                FA = fA;
            }

            #region IEquatable<A> Members

            public bool Equals(A other)
            {
                if(ReferenceEquals(this, other))
                    return true;

                if (ReferenceEquals(other, null))
                    return false;

                return FA == other.FA;
            }

            #endregion
        }

        public class StringStringPair : IEquatable<StringStringPair>
        {
            public string Left { get; set; }
            public string Right { get; set; }

            public StringStringPair(string left = "", string rigth="")
            {
                Left = left;
                Right = rigth;
            }

            public StringStringPair(StringStringPair obj) : this(obj.Left, obj.Right)
            {}

            #region IEquatable<StringStringPair> Members

            public bool Equals(StringStringPair other)
            {
                if(ReferenceEquals(this, other))
                    return true;

                if (ReferenceEquals(other, null))
                    return false;

                return (Left == other.Left && Right == other.Right) || (Left == other.Right && Right == other.Left);
            }

            #endregion
        }

        class StringStringPairComparer : IEqualityComparer<StringStringPair>
        {
            public bool Equals(StringStringPair x, StringStringPair y)
            {
                if (ReferenceEquals(x, y))
                    return true;

                if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                    return false;

                return (x.Left == y.Left && x.Right == y.Right) || (x.Left == y.Right && x.Right == y.Left);
            }

            public int GetHashCode(StringStringPair s)
            {
                return 0;
            }
        }
    #endif

    class Program
    {
        static void Main(string[] args)
        {
            #if TEST_DICTIONARY
                var dicLongLong = new Dictionary<long, long>
                {
                    { 1L, 1L },
                    { 2L, 2L },
                    { 3L, 3L }
                };

                //lock (dicLongLong[2L]) // Error CS0185  'long' is not a reference type as required by the lock statement
                //{}

                var dicIntVictim = new Dictionary<int, Victim>
                    {
                        { 0, new Victim { FString = "0" }},
                        { 1, new Victim { FString = "1" }},
                        { 2, new Victim { FString = "2" }}
                    };

                foreach (var k in dicIntVictim.Keys)
                    dicIntVictim[k].FString = dicIntVictim[k].FString + dicIntVictim[k].FString;

                var dicIntInt = new Dictionary<int, int>
                    {
                        { 0, 0 },
                        { 1, 1 },
                        { 2, 2 }
                    };

                try
                {
                    foreach (var k in dicIntInt.Keys)
                        dicIntInt[k] = dicIntInt[k] + dicIntInt[k];
                }
                catch (InvalidOperationException eInvalidOperationException0)
                {
                    Console.WriteLine(eInvalidOperationException0.Message);
                }

                Dictionary<string, string>
                    dic = null;

                try
                {
                    foreach (var kvp in dic)
                        Console.WriteLine("\"{0}\" = \"{1}\"", kvp.Key, kvp.Value);
                }
                catch(NullReferenceException)
                {

                }

                dic = new Dictionary<string, string>();

                foreach (var kvp in dic)
                    Console.WriteLine("\"{0}\" = \"{1}\"", kvp.Key, kvp.Value);

                dic.Add("3rd", "3rd");
                dic.Add("2nd", "2nd");
                dic.Add("1st", "1st");

                dic["4th"] = "4th";
                dic["5th"] = "5th";

                try
                {
                    if (dic["6th"] != "6th")
                        Console.WriteLine("Tampax");
                }
                catch (KeyNotFoundException)
                {
                    
                }

                foreach (KeyValuePair<string, string> v in dic)
                    Console.WriteLine("{0} {1}", v.Key, v.Value);
                Console.WriteLine();

                foreach(string k in dic.Keys)
                    Console.WriteLine("{0} {1}", k, dic[k]);
                Console.WriteLine();

                try
                {
                    foreach (string k in dic.Keys)
                        dic[k] = dic[k] + dic[k];
                }
                catch (InvalidOperationException eInvalidOperationException)
                {
                    Console.WriteLine(eInvalidOperationException.Message);
                }

                Dictionary<string, string>.Enumerator e = dic.GetEnumerator();
                while(e.MoveNext())
                    Console.WriteLine("{0} {1}", e.Current.Key, e.Current.Value);
                Console.WriteLine();

                Dictionary<string, string>.KeyCollection.Enumerator ek = dic.Keys.GetEnumerator();
                while(ek.MoveNext())
                    Console.WriteLine("{0} {1}", ek.Current, dic[ek.Current]);
                Console.WriteLine();

                OrderedDictionary
                    oDic = new OrderedDictionary();

                oDic.Add("3rd", "3rd");
                oDic.Add("2nd", "2nd");
                oDic.Add("1st", "1st");

                oDic["4th"] = "4th";
                oDic["5th"] = "5th";

                foreach (DictionaryEntry v in oDic)
                    Console.WriteLine("{0} {1}", v.Key, v.Value);
                Console.WriteLine();

                IDictionaryEnumerator oe = oDic.GetEnumerator();
                while (oe.MoveNext())
                    Console.WriteLine("{0} {1}", oe.Key, oe.Value);
                Console.WriteLine();

                IEnumerator oek = oDic.Keys.GetEnumerator();
                while(oek.MoveNext())
                    Console.WriteLine("{0} {1}", oek.Current, oDic[oek.Current]);
                Console.WriteLine();

                oDic = new OrderedDictionary();
                oDic.Add("3rd", "3rd (value)");
                oDic.Add("2nd", "2nd (value)");
                oDic.Insert(0, "1st", "1st (value)");

                for(var i = 0; i < oDic.Count; ++i)
                    Console.WriteLine("{0}", oDic[i]);
                Console.WriteLine();

                foreach (DictionaryEntry v in oDic)
                    Console.WriteLine("{0} {1}", v.Key, v.Value);
                Console.WriteLine();

                oe = oDic.GetEnumerator();
                while (oe.MoveNext())
                    Console.WriteLine("{0} {1}", oe.Key, oe.Value);
                Console.WriteLine();

                oek = oDic.Keys.GetEnumerator();
                while (oek.MoveNext())
                    Console.WriteLine("{0} {1}", oek.Current, oDic[oek.Current]);
                Console.WriteLine();

                IList a = oDic.Cast<DictionaryEntry>().Select(de => de.Value).ToList();
                IList aa = oDic.Keys.Cast<string>().ToList();
                Console.WriteLine();
            #endif

            #if TEST_LIST
                List<StringStringPair>
                    listOfStringStringPair = new List<StringStringPair>(new StringStringPair[] { new StringStringPair("aa", "bb") });

                StringStringPair
                    stringStringPair = new StringStringPair("aa", "bb");

                if (listOfStringStringPair.Contains(stringStringPair))
                    Console.WriteLine("Already exists!");

                stringStringPair = new StringStringPair("bb", "aa");
                if (listOfStringStringPair.Contains(stringStringPair))
                    Console.WriteLine("Already exists!");

                stringStringPair = new StringStringPair("bb", "cc");
                if (listOfStringStringPair.Contains(stringStringPair))
                    Console.WriteLine("Already exists!");

                listOfStringStringPair.Add(new StringStringPair("bb", "aa"));
                listOfStringStringPair.Add(new StringStringPair("bb", "cc"));

                var tmp = listOfStringStringPair.Distinct().ToArray();
                tmp = listOfStringStringPair.Distinct(new StringStringPairComparer()).ToArray();

                List<int>
                    listOfIntI = new List<int>(new int[] { 1, 2, 3, 4, 5 }),
                    listOfIntII = new List<int>(new int[] { 1, 3, 5 });

                listOfIntI.RemoveAll(listOfIntII.Contains);

                A
                    a = new A(13);

                List<A>
                    listOfAI = new List<A>(new A[] { a, new A(1), new A(2), new A(3), new A(4), new A(5), null }),
                    listOfAII = new List<A>(new A[] { a, new A(1), new A(3), new A(5) });

                listOfAI.RemoveAll(listOfAII.Contains);

                listOfIntI = new List<int>(new int[] { 1, 2, 3, 4, 5 });
                foreach (var i in listOfIntI.ToArray())
                {
                    if (i%2 == 0)
                        listOfIntI.Remove(i);
                }
            #endif
        }
    }
}
