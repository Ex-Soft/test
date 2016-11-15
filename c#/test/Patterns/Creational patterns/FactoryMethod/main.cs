using System;

namespace FactoryMethod
{
	// "Product"
	abstract class Product
	{}

	// "ConcreteProduct"
	class ConcreteProductA : Product
	{}

	// "ConcreteProduct"
	class ConcreteProductB : Product
	{}

	// "Creator"
	abstract class Creator
	{
		public abstract Product FactoryMethod();
	}

	// "ConcreteCreator"
	class ConcreteCreatorA : Creator
	{
		public override Product FactoryMethod()
		{
			return new ConcreteProductA();
		}
	}

	// "ConcreteCreator"
	class ConcreteCreatorB : Creator
	{
		public override Product FactoryMethod()
		{
			return new ConcreteProductB();
		}
	}

	class Program
	{
		static void Main()
		{
			Creator[]
				creators = new Creator[2];

			creators[0] = new ConcreteCreatorA();
			creators[1] = new ConcreteCreatorB();

			foreach (Creator creator in creators)
			{
				Product
					product = creator.FactoryMethod();

				Console.WriteLine("Created {0}",product.GetType().Name);
			}
		}
	}
}
