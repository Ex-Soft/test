using System;

namespace Adapter
{
	// "Target"
	class Target
	{
		public virtual void Request()
		{
			Console.WriteLine("Called Target Request()");
		}
	}

	// "Adapter"
	class Adapter : Target
	{
		private Adaptee
			_adaptee = new Adaptee();

		public override void Request()
		{
			// Possibly do some other work
			//  and then call SpecificRequest
			_adaptee.SpecificRequest();
		}
	}

	// "Adaptee"
	class Adaptee
	{
		public void SpecificRequest()
		{
			Console.WriteLine("Called SpecificRequest()");
		}
	}

	class Program
	{
		static void Main()
		{
			Target
				target = new Adapter();

			target.Request();
		}
	}
}
