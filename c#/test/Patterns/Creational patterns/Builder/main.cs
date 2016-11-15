using System;
using System.Collections.Generic;

namespace Builder
{
	class Program
	{
		// "Director"
		class Director
		{
			public void Construct(Builder builder)
			{
				builder.BuildPartA();
				builder.BuildPartB();
			}
		}

		// "Builder"
		abstract class Builder
		{
			public abstract void BuildPartA();
			public abstract void BuildPartB();
			public abstract Product GetResult();
		}

		// "ConcreteBuilder1"
		class ConcreteBuilder1 : Builder
		{
			private Product
				_product = new Product();

			public override void BuildPartA()
			{
				_product.Add("PartA");
			}

			public override void BuildPartB()
			{
				_product.Add("PartB");
			}

			public override Product GetResult()
			{
				return _product;
			}
		}

		// "ConcreteBuilder2"
		class ConcreteBuilder2 : Builder
		{
			private Product
				_product = new Product();

			public override void BuildPartA()
			{
				_product.Add("PartX");
			}

			public override void BuildPartB()
			{
				_product.Add("PartY");
			}

			public override Product GetResult()
			{
				return _product;
			}
		}

		// "Product"
		class Product
		{
			private List<string>
				_parts = new List<string>();

			public void Add(string part)
			{
				_parts.Add(part);
			}

			public void Show()
			{
				Console.WriteLine("\nProduct Parts -------");

				foreach (string part in _parts)
					Console.WriteLine(part);
			}
		}

		static void Main()
		{
			Director
				director = new Director();

			Builder
				b1 = new ConcreteBuilder1(),
				b2 = new ConcreteBuilder2();

			director.Construct(b1);

			Product
				p1 = b1.GetResult();

			p1.Show();

			director.Construct(b2);

			Product
				p2 = b2.GetResult();

			p2.Show();
		}
	}
}
