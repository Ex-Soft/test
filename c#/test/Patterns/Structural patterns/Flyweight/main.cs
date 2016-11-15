using System;
using System.Collections;

namespace Flyweight
{
	// "FlyweightFactory'
	class FlyweightFactory
	{
		private Hashtable
			flyweights = new Hashtable();

		public FlyweightFactory()
		{
			flyweights.Add("X", new ConcreteFlyweight());
			flyweights.Add("Y", new ConcreteFlyweight());
			flyweights.Add("Z", new ConcreteFlyweight());
		}

		public Flyweight GetFlyweight(string key)
		{
			return ((Flyweight)flyweights[key]);
		}
	}

	// "Flyweight"
	abstract class Flyweight
	{
		public abstract void Operation(int extrinsicstate);
	}

	// "ConcreteFlyweight"
	class ConcreteFlyweight : Flyweight
	{
		public override void Operation(int extrinsicstate)
		{
			Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
		}
	}

	// "UnsharedConcreteFlyweight"
	class UnsharedConcreteFlyweight : Flyweight
	{
		public override void Operation(int extrinsicstate)
		{
			Console.WriteLine("UnsharedConcreteFlyweight: " + extrinsicstate);
		}
	}

	class Program
	{
		static void Main()
		{
			int
				extrinsicstate = 22;

			FlyweightFactory
				factory = new FlyweightFactory();

			Flyweight
				fx = factory.GetFlyweight("X");

			fx.Operation(--extrinsicstate);

			Flyweight
				fy = factory.GetFlyweight("Y");

			fy.Operation(--extrinsicstate);

			Flyweight
				fz = factory.GetFlyweight("Z");

			fz.Operation(--extrinsicstate);

			UnsharedConcreteFlyweight
				fu = new UnsharedConcreteFlyweight();

			fu.Operation(--extrinsicstate);
		}
	}
}
