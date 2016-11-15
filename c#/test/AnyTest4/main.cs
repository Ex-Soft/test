// http://msdn.microsoft.com/en-us/library/hh534540.aspx [CallerMemberName]/[CallerFilePath]/[CallerLineNumber] 4.5

//#define TEST_SORTER
//#define TEST_TUPLE
//#define TEST_ENUM
//#define TEST_CONVERT
//#define TEST_PARAMETERS
//#define TEST_NAMED_PARAMETERS
//#define TEST_DYNAMIC
//#define TEST_DYNAMIC_ATTRIBUTE
//#define TEST_COVARIANCE
#define TEST_STRING

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;

//using static Console; // WriteLine(Text) (wo Console.)

namespace AnyTest4
{
    #if TEST_DYNAMIC_ATTRIBUTE
        class ClassWithPropertyWithDynamicAttribute
        {
            //[Dynamic]
            public dynamic PropertyWithDynamicAttribute { get; set; }
        }
    #endif

    #if TEST_SORTER
        public class NullableLongComparer : IComparer<long?>
        {
            public int Compare(long? x, long? y)
            {
                if (!x.HasValue && !y.HasValue)
                    return 0;
                if (x.HasValue && !y.HasValue)
                    return -1;
                if (!x.HasValue && y.HasValue)
                    return 1;
                
                return x.Value > y.Value ? 1 : (x.Value == y.Value ? 0: -1);
            }
        }
    #endif

    #if TEST_SORTER || TEST_TUPLE
        class A
        {
            public int
                Order;

            public string
                Name,
                Str;

            public A(A obj) : this(obj.Order, obj.Str, obj.Name)
            {}

            public A(int order=0, string str="", string name="")
            {
                Order = order;
                Str = str;
                Name = name;
            }
        }

        class AA
        {
            public int?
                Order;

            public string
                Name,
                Str;

            public AA(AA obj) : this(obj.Order, obj.Str, obj.Name)
            { }

            public AA(int? order = null, string str = "", string name = "")
            {
                Order = order;
                Str = str;
                Name = name;
            }
        }
    #endif

    #if TEST_ENUM
        enum TestEnum
        {
            Zero = 0,
            First,
            Second,
            Third,
            Fourth,
            Fifth,
            Ten = 10,
            Thirteen = 13,
            Fifteen = 15
        }

        enum SmthEnum : long
        {
            First = 1L,
            Second,
            Third = 3L
        }
    #endif

    #if TEST_PARAMETERS
        public interface ITest
        {
            int F1(int a, int b);
            int F2(int a=3, int b=3);
        }

        public class A : ITest
        {
            public int F1(int a=1, int b=1)
            {
                Console.WriteLine("a = {0}, b = {1}", a, b);
                return a + b;
            }

            public int F2(int a = 13, int b = 13)
            {
                Console.WriteLine("a = {0}, b = {1}", a, b);
                return a + b;
            }
        }

        public class B : ITest
        {
            public int F1(int a=2, int b=2)
            {
                Console.WriteLine("a = {0}, b = {1}", a, b);
                return a + b;
            }

            public int F2(int a, int b)
            {
                Console.WriteLine("a = {0}, b = {1}", a, b);
                return a + b;
            }
        }

        public class AA
        {
            public virtual int F1(int a = 1, int b = 1)
            {
                Console.WriteLine("a = {0}, b = {1}", a, b);
                return a + b;
            }

            public virtual int F2(int a = 1, int b = 1)
            {
                Console.WriteLine("a = {0}, b = {1}", a, b);
                return a + b;
            }
        }

        public class BB : AA
        {
            public override int F1(int a = 1, int b = 1)
            {
                Console.WriteLine("a = {0}, b = {1}", a, b);
                return base.F1();
            }

            public override int F2(int a = 2, int b = 2)
            {
                Console.WriteLine("a = {0}, b = {1}", a, b);
                return base.F1();
            }
        }
    #endif

	class Program
	{
		static void Main(string[] args)
		{
		    string
		        tmpString=string.Empty;

		    bool
		        tmpBool;

            DateTime
                tmpDateTime;

			try
			{
				#if TEST_STRING
					tmpBool = string.IsNullOrEmpty(tmpString);
					tmpBool = string.IsNullOrWhiteSpace(tmpString);
				#endif

                #if TEST_SORTER || TEST_TUPLE
                    var srcI = new List<A>(new[] { new A(5, "5", "5"), new A(0, "01", "01"),  new A(3, "3", "3"), new A(0, "02", "02"),  new A(1, "1", "1") });
                    var destI = Sort(srcI, a => a.Order);
                    var srcII = new List<AA>(new[] { new AA(5, "5", "5"), new AA(0, "01", "01"), new AA(null, "null1", "null1"),  new AA(3, "3", "3"), new AA(null, "null2", "null2"), new AA(0, "02", "02"), new AA(1, "1", "1") });
                    var destII = Sort(srcII, a => a.Order);
                #endif

                #if TEST_TUPLE
                    tmpDateTime = DateTime.Now;

                    var tmpTupleI = Tuple.Create(1, "2nd", tmpDateTime);
                    var tmpTupleII = new Tuple<int, string, DateTime>(1, "2nd", tmpDateTime);

                    Console.WriteLine(tmpTupleI.Item1==tmpTupleII.Item1 && tmpTupleI.Item2==tmpTupleII.Item2 && tmpTupleI.Item3==tmpTupleII.Item3 ? "oB!" : "Tampax");

                    var src = new List<A>(new A[] { new A(str:"0 0", name:"Zero"), new A(3, "3 1", "1st"), new A(1, "1 2", "2nd"), new A(str:"0 3", name:"3rd"), new A(0, "0 4", "4th") });
                    var dic = new Dictionary<int, ICollection<Tuple<string, A>>>();
                    var dest = new OrderedDictionary();

                    foreach (var a in src)
                    {
                        var key = a.Order;

                        if(!dic.ContainsKey(key))
                            dic.Add(key, new List<Tuple<string, A>>());

                        dic[key].Add(new Tuple<string, A>(a.Name, a));
                    }

                    var keys = dic.Keys.ToList();

                    keys.Sort();

                    foreach (var key in keys)
                    {
                        var items = dic[key];

                        foreach (var tuple in items)
                        {
                            if(key>0 && key<=dest.Count)
                                dest.Insert(key-1, tuple.Item1, tuple.Item2);
                            else
                                dest.Add(tuple.Item1, tuple.Item2);
                        }
                    }

                    foreach (DictionaryEntry a in dest)
                        Console.WriteLine("{0} \"{1}\" \"{2}\"", ((A)a.Value).Order, ((A)a.Value).Str, ((A)a.Value).Name);
                #endif

                #if TEST_ENUM
                    TestEnum
                        testEnum;

                    SmthEnum
                        smthEnum;

                    Console.WriteLine("{0}", Enum.TryParse("1", out testEnum) ? testEnum.ToString() : "Tampax");
                    Console.WriteLine("{0}", Enum.TryParse("Third", out testEnum) ? testEnum.ToString() : "Tampax");
                    Console.WriteLine("{0}", Enum.TryParse("3", out smthEnum) ? testEnum.ToString() : "Tampax");
                    Console.WriteLine("{0}", Enum.TryParse("Second", out smthEnum) ? testEnum.ToString() : "Tampax");
                #endif

                #if TEST_CONVERT
				    try
				    {
					    tmpBool = Convert.ToBoolean(tmpString = "0");
				    }
				    catch (FormatException)
				    {
					    Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
				    }

                    try
                    {
                        tmpBool = Convert.ToBoolean(tmpString = "1");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
                    }

                    try
                    {
                        tmpBool = Convert.ToBoolean(tmpString = "true");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
                    }

                    try
                    {
                        tmpBool = Convert.ToBoolean(tmpString = "false");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
                    }

                    try
                    {
                        tmpBool = Convert.ToBoolean(tmpString = "TrUe");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
                    }

                    try
                    {
                        tmpBool = Convert.ToBoolean(tmpString = "FaLsE");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
                    }
                #endif

				#if TEST_PARAMETERS
					Console.WriteLine(F1());

                    A
                        a = new A();

                    B
                        b = new B();

                    a.F1();
                    a.F2();
                    b.F1();
                    //b.F2(); // Error	1	No overload for method 'F2' takes 0 arguments
                    b.F2(23, 23);

                    BB
                        bb = new BB();

                    bb.F1();
                    bb.F2();
				#endif

                #if TEST_NAMED_PARAMETERS
			        Console.WriteLine(F1(b:10, a:1));
                    Console.WriteLine(F1(b:10));
                    Console.WriteLine(F1(a:1));
                #endif

                #if TEST_DYNAMIC
			        dynamic
			            a = 1;

			        a++;

			        Console.WriteLine(a);

			        a = DateTime.Now;
                    a.
			        a = a.AddYears(1);
                    Console.WriteLine(a);
                #endif

                #if TEST_DYNAMIC_ATTRIBUTE
                    ClassWithPropertyWithDynamicAttribute obj = new ClassWithPropertyWithDynamicAttribute();

                    obj.PropertyWithDynamicAttribute.PString = "string";
                    obj.PropertyWithDynamicAttribute.PDateTime = new DateTime();
                    obj.PropertyWithDynamicAttribute.PDouble = 123.45;

                    System.Diagnostics.Debug.WriteLine(obj.ToString());
                #endif

                #if TEST_COVARIANCE
                    IEnumerable<string>
                        listString = new List<string>();

			        IEnumerable<object>
			            listObject = listString;

                    object[]
                        array = new string[10];
                #endif
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
		}

        #if TEST_PARAMETERS ||TEST_NAMED_PARAMETERS
            static int F1(int a = 3, int b = 4)
		    {
                Console.WriteLine(string.Format("a = {0}, b = {1}", a, b));
			    return a + b;
		    }
		#endif

        #if TEST_SORTER
            static IEnumerable<T> Sort<T>(IEnumerable<T> collection, Func<T, long?> orderPropertyGetter)
            {
                var tmpCollection = new List<Tuple<long?, T>>();

                collection.ToList().ForEach(item => tmpCollection.Add(new Tuple<long?, T>(orderPropertyGetter(item), item)));

                return tmpCollection.OrderBy(item => item.Item1, new NullableLongComparer()).Select(item => item.Item2).ToList();
            }
        #endif
	}
}
