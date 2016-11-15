using System;

namespace ClassIII
{
	class Critter
	{
		public virtual string Eats { get { return "Air"; } }

		public override string ToString()
		{
			return this.GetType().Name + " eats " + Eats;
		}
	}

	class Dog : Critter
	{
		public override string Eats { get { return "Cat"; } }
	}

	class Lion : Critter
	{
		public override string Eats { get { return "Dog"; } }
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(System.Environment.Version);
			Console.WriteLine(new Critter());
			Console.WriteLine(new Dog());
			Console.WriteLine(new Lion());
		}
	}
}
