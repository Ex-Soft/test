using System;
using System.Collections.Generic;

namespace TestDelegateII
{
	class Program
	{
		delegate void VoidDelegateInt(int arg);
		delegate string StringDelegateIntInt(int arg1, int arg2);

		static void Main(string[] args)
		{
			const int
				max = 5;

			int
				i;

			List<VoidDelegateInt>
				VoidDelegatesInt = new List<VoidDelegateInt>();

			List<StringDelegateIntInt>
				StringDelegatesIntInt = new List<StringDelegateIntInt>();

			for (i = 0; i < max; ++i)
			{
				VoidDelegatesInt.Add(delegate(int arg) { Console.WriteLine("i={0}\targ={1}", i, arg); });
				StringDelegatesIntInt.Add(delegate(int arg1, int arg2) { return string.Format("i={0}\targ1={1}\targ2={2}", i, arg1, arg2); });
			}

			VoidDelegatesInt.ForEach((item) =>
			{
				item(13);
			});
			Console.WriteLine();

			StringDelegatesIntInt.ForEach(item =>
			{
				Console.WriteLine(item(9, 13));
			});
			Console.WriteLine();

			for (i = 0; i < VoidDelegatesInt.Count; ++i)
				VoidDelegatesInt[i](13);
			Console.WriteLine();

			for (i = 0; i < StringDelegatesIntInt.Count; ++i)
				Console.WriteLine(StringDelegatesIntInt[i](9, 13));
			Console.WriteLine();

			i = 3;
			VoidDelegatesInt[0](13);
			Console.WriteLine(StringDelegatesIntInt[0](9, 13));
		}
	}
}
