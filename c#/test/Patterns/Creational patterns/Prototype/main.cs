using System;

namespace Prototype
{
	class Program
	{
		// "Prototype"
		abstract class Prototype
		{
			private string
				_id;

			public Prototype(string id)
			{
				_id = id;
			}

			public string Id
			{
				get { return _id; }
			}

			public abstract Prototype Clone();
		}

		// "ConcretePrototype"
		class ConcretePrototype1 : Prototype
		{
			public ConcretePrototype1(string id):base(id)
			{}

			public override Prototype Clone()
			{
				return (Prototype)MemberwiseClone();
			}
		}

		// "ConcretePrototype"
		class ConcretePrototype2 : Prototype
		{
			public ConcretePrototype2(string id):base(id)
			{}

			public override Prototype Clone()
			{
				return (Prototype)MemberwiseClone();
			}
		}

		static void Main()
		{
			ConcretePrototype1
				p1 = new ConcretePrototype1("I"),
				c1 = (ConcretePrototype1)p1.Clone();

			Console.WriteLine("Cloned: {0}", c1.Id);

			ConcretePrototype2
				p2 = new ConcretePrototype2("II"),
				c2 = (ConcretePrototype2)p2.Clone();

			Console.WriteLine("Cloned: {0}", c2.Id);
		}
	}
}
