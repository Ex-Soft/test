#define TEST_LIST
//#define TEST_DICTIONARY

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

using static System.Console;

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
            public bool FB { get; set; }
            public bool FC { get; set; }

            public A(A obj) : this(obj.FA, obj.FB, obj.FC)
            {}

            public A(int fA = default, bool fB = default, bool fC = default)
            {
                FA = fA;
                FB = fB;
                FC = fC;
            }

            #region IEquatable<A> Members

            public bool Equals(A other)
            {
                if(ReferenceEquals(this, other))
                    return true;

                if (ReferenceEquals(other, null))
                    return false;

                return FA == other.FA && FB == other.FB && FC == other.FC;
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

        class C
        {
            public int FI { get; set; }
            public List<A> LA { get; set; }

            public C() : this(default(int), new List<A>())
            {}

            public C(C obj) : this(obj.FI, obj.LA)
            {}

            public C(int fi, List<A> la)
            {
                FI = fi;
                LA = la;
            }
        }

        class SmthClassWithListOfString
        {
            public List<string> ListOfString { get; set; }
        }
    #endif

    class Program
    {
        static void Main(string[] args)
        {
            bool tmpBool;
            object tmpObject;

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
                catch (InvalidOperationException eInvalidOperationException)
                {
                    WriteLine(eInvalidOperationException.Message);
                }

                Dictionary<string, string>
                    dic = null;

                try
                {
                    foreach (var kvp in dic)
                        WriteLine("\"{0}\" = \"{1}\"", kvp.Key, kvp.Value);
                }
                catch(NullReferenceException eNullReferenceException)
                {
                    WriteLine(eNullReferenceException.Message);
                }

                dic = new Dictionary<string, string>();

                foreach (var kvp in dic)
                    WriteLine("\"{0}\" = \"{1}\"", kvp.Key, kvp.Value);

                dic.Add("3rd", "3rd");
                dic.Add("2nd", "2nd");
                dic.Add("1st", "1st");

                dic["4th"] = "4th";
                dic["5th"] = "5th";

                try
                {
                    if (dic["6th"] != "6th")
                        WriteLine("Tampax");
                }
                catch (KeyNotFoundException eKeyNotFoundException)
                {
                    WriteLine(eKeyNotFoundException.Message);
                }

                foreach (KeyValuePair<string, string> v in dic)
                    WriteLine("{0} {1}", v.Key, v.Value);
                WriteLine();

                foreach(string k in dic.Keys)
                    WriteLine("{0} {1}", k, dic[k]);
                WriteLine();

                try
                {
                    foreach (string k in dic.Keys)
                        dic[k] = dic[k] + dic[k];
                }
                catch (InvalidOperationException eInvalidOperationException)
                {
                    WriteLine(eInvalidOperationException.Message);
                }

                Dictionary<string, string>.Enumerator e = dic.GetEnumerator();
                while(e.MoveNext())
                { 
                    WriteLine("{0} {1}", e.Current.Key, e.Current.Value);

                    //e.Current.Value += "3rd"; // Error CS0200  Property or indexer 'KeyValuePair<string, string>.Value' cannot be assigned to --it is read only

                }
                e.Dispose();
                WriteLine();
                
                Dictionary<string, string>.KeyCollection.Enumerator ek = dic.Keys.GetEnumerator();
                try
                {
                    while(ek.MoveNext())
                    { 
                        WriteLine("{0} {1}", ek.Current, dic[ek.Current]);

                        if (ek.Current == "3rd")
                            dic[ek.Current] = dic[ek.Current] + dic[ek.Current];
                    }
                }
                catch (InvalidOperationException eInvalidOperationException)
                {
                    WriteLine(eInvalidOperationException.Message);
                }
                finally
                { 
                    ek.Dispose();
                }
                WriteLine();

                #region ReadOnlyDictionary

                ReadOnlyDictionary<string, string> roDic = new ReadOnlyDictionary<string, string>(dic);

                foreach (var kvp in roDic)
                    WriteLine($"[\"{kvp.Key}\"] = \"{kvp.Value}\"");
                WriteLine();

                //roDic["3rd"] = "3rd"; // Error CS0200  Property or indexer 'ReadOnlyDictionary<string, string>.this[string]' cannot be assigned to --it is read only
                
                dic["6th"] = "6th";
                dic["7th"] = "7th";
                dic["3rd"] = "3rd";

                foreach (var kvp in roDic)
                    WriteLine($"[\"{kvp.Key}\"] = \"{kvp.Value}\"");
                WriteLine();

                #endregion

                #region OrderedDictionary

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

                #endregion

            #endif

            #if TEST_LIST
                var classWithListOfString = new SmthClassWithListOfString();
                try
                { 
                    tmpBool = (bool)(classWithListOfString.ListOfString?.Contains("blah-blah-blah")); // mscorlib.dll!bool?.Value.get()
                }
                catch (InvalidOperationException e)
                {
                    WriteLine(e.Message);
                }

                tmpObject = classWithListOfString.ListOfString?.Contains("blah-blah-blah");
                tmpBool = classWithListOfString.ListOfString?.Contains("blah-blah-blah") == true;
                
                classWithListOfString.ListOfString = new List<string> { "1st", "2nd", "3rd" };
                tmpBool = (bool)(classWithListOfString.ListOfString?.Contains("3rd"));
                tmpObject = classWithListOfString.ListOfString?.Contains("2nd");
                tmpBool = classWithListOfString.ListOfString?.Contains("1st") == true;

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

                listOfAI = new List<A>(new[]
		        {
		            new A {FA = 1, FB = true, FC = false},
                    new A {FA = 2, FB = true, FC = true},
		            new A {FA = 3, FB = true, FC = false},
                    new A {FA = 4, FB = true, FC = false}
		        });

                var listOfC = new List<C>
                {
                    new C(1, listOfAI),
                    new C(2, listOfAI),
                    new C(3, listOfAI),
                    new C(4, listOfAI),
                    new C(5,
                        new List<A>
                        {
                            new A {FA = 1, FB = true, FC = true},
                            new A {FA = 2, FB = true, FC = true},
                            new A {FA = 3, FB = true, FC = true},
                            new A {FA = 4, FB = true, FC = true}
                        })
                };

                var listOfC2 = listOfC.FindAll(c => c.LA.All(_a_ => _a_.FC));

            #endif
        }
    }
}
