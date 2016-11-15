using System;
using System.Collections.Generic;

namespace GenericsII
{
	class A
	{
		int
			_ValueInt;

		public virtual int ValueInt
		{
			get
			{
				return _ValueInt;
			}
			set
			{
				if (_ValueInt != value)
					_ValueInt = value;
			}
		}
	}

	class B : A
	{
	}

	class Program
	{
		static void Main(string[] args)
		{
			B
				b = new B();

			List<B>
				listB = new List<B>();

			listB.Add(b);

			List<A>
				listA = new List<A>();

			listB.ForEach((item) => { listA.Add(item); });
		}
	}
}
