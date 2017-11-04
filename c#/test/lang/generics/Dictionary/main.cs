//#define TEST_DERIVED_CLASS

using System;
using System.Collections;
using System.Collections.Generic;

namespace Dictionary
{
	#if TEST_DERIVED_CLASS
		public class A
		{
			virtual public int FInt { get; set; }

			public A() : this(int.MinValue)
			{}

			public A(A obj) : this(obj.FInt)
			{}

			public A(int aInt)
			{
				FInt = aInt;
			}
		}

		public class B : A
		{
			virtual public string FString { get; set; }

			public B() : this(int.MinValue, string.Empty)
			{}

			public B(B obj) : this(obj.FInt, obj.FString)
			{}

			public B(int aInt, string aString) : base(aInt)
			{
				FString = aString;
			}
		}
	#endif

	class Program
	{
		static void Main(string[] args)
		{
			string
				tmpString;
			
			Dictionary<int, string>
				d = new Dictionary<int, string>();

			d[4] = "4th";

			d.Add(1, "1st");
			d.Add(2, "2nd");
			d.Add(3, "3rd");
			try
			{
				tmpString = d[5];
			}
            catch (KeyNotFoundException eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}

		    int?
		        tmpNullableInt = null;

		    try
		    {
                if (d.ContainsKey(tmpNullableInt.Value))
                    Console.WriteLine("blah-blah-blah");
		    }
            catch (InvalidOperationException eException)
		    {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
		    }

			Dictionary<int, string>
				dd = new Dictionary<int, string> { { 1, "1st" }, { 2, "2nd" }, { 3, "3rd" } },
				ddd = new Dictionary<int,string>(dd);

			dd[3] = "4th";

			if (dd[3] != ddd[3])
				Console.WriteLine("dd[3] != ddd[3]");

			tmpString = dd[2];

			foreach (KeyValuePair<int, string> kvp in dd)
				Console.WriteLine("dd[" + kvp.Key + "]=\"" + kvp.Value + "\"");

			Hashtable
				ht = new Hashtable() { { 1, "1st" }, { 2, "2nd" }, { 3, "3rd" } };

			IDictionaryEnumerator
				myEnumerator = ht.GetEnumerator();

			while (myEnumerator.MoveNext())
				Console.WriteLine("\tht[{0}]:\t\"{1}\"", myEnumerator.Key, myEnumerator.Value);

			foreach (DictionaryEntry de in ht)
				Console.WriteLine("\tht[{0}]:\t\"{1}\"", de.Key, de.Value);

			#if TEST_DERIVED_CLASS
				Dictionary<int, A>
					da = new Dictionary<int, A> { { 1, new B(1, "1") }, { 2, new B(2, "2") }, { 3, new B(3, "3") } };

				foreach (KeyValuePair<int, A> kvp in da)
					Console.WriteLine("da[" + kvp.Key + "] = {" + kvp.Value.FInt + ((kvp.Value is B) ? ", \""+(kvp.Value as B).FString+"\"" : string.Empty) + "}");
				
				Dictionary<int, B>
					db = new Dictionary<int, B> { { 1, new B(1, "1") }, { 2, new B(2, "2") }, { 3, new B(3, "3") } };

				foreach (KeyValuePair<int, B> kvp in db)
					Console.WriteLine("db[" + kvp.Key + "] = {" + kvp.Value.FInt + ", \"" + kvp.Value.FString + "\"}");
			#endif
		}
	}
}
