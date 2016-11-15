using System;

namespace Decorator
{
	// "Component"
	abstract class Component
	{
		public abstract void Operation();
	}

	// "ConcreteComponent"
	class ConcreteComponent:Component
	{
		public override void Operation()
		{
			Console.WriteLine("ConcreteComponent.Operation()");
		}
	}

	// "Decorator"
	abstract class Decorator:Component
	{
		protected Component component;

		public void SetComponent(Component aComponent)
		{
			component = aComponent;
		}

		public override void Operation()
		{
			if (component != null)
			{
				component.Operation();
			}
		}
	}

	// "ConcreteDecoratorA"
	class ConcreteDecoratorA:Decorator
	{
		private string addedState;

		public override void Operation()
		{
			base.Operation();
			addedState = "New State";
			Console.WriteLine("ConcreteDecoratorA.Operation()");
		}
	}

	// "ConcreteDecoratorB"
	class ConcreteDecoratorB:Decorator
	{
		public override void Operation()
		{
			base.Operation();
			AddedBehavior();
			Console.WriteLine("ConcreteDecoratorB.Operation()");
		}

		void AddedBehavior()
		{
		}
	}

	class Program
	{
		static void Main()
		{
			ConcreteComponent
				c = new ConcreteComponent();

			ConcreteDecoratorA
				d1 = new ConcreteDecoratorA();

			ConcreteDecoratorB
				d2 = new ConcreteDecoratorB();

			// Link decorators
			d1.SetComponent(c);
			d2.SetComponent(d1);

			d2.Operation();
		}
	}
}
