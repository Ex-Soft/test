using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsIII
{
	public class A
	{
		public virtual int Id {get; set;}
		public virtual string Name { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<A>
				tmpList = new List<A>(new A[] { new A { Id=1, Name="Иванов"},
												new A { Id=2, Name="Петров"},
												new A { Id=3, Name="Сидоров"}});

			var
				Ids = from l in tmpList select l.Id;

			List<int>
				IdsIntI = Ids.ToList<int>();

			IdsIntI.ForEach((item) => { Console.WriteLine(item); });

			List<int>
				IdsIntII = (from l in tmpList select l.Id).OfType<int>().ToList();

			IdsIntII.ForEach((item) => { Console.WriteLine(item); });

			Console.ReadLine();
		}
	}
}
