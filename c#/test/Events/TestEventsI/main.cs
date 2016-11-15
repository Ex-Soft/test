using System;

namespace TestEventsI
{
	class Program
	{
		static void Main(string[] args)
		{
			EventManagerClass
				EventManager = new EventManagerClass();

			ClassWithEventI
				c1 = new ClassWithEventI(EventManager);

			ClassWithEventII
				c2 = new ClassWithEventII(EventManager);

			ClassWithEventIII
				c3 = new ClassWithEventIII(null);

			EventManager.Test();

			c3.Attach(EventManager);
			c2.Detach(EventManager);

			EventManager.Test();
		}
	}
}
