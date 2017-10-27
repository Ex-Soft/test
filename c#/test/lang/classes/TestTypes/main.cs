using System;

namespace TestTypes
{
	class Base
	{
		int
			FIntBase;
	}

	class A : Base
	{
		int
			FIntA;
	}

	class B : Base
	{
		int
			FIntB;
	}

	class C : Base
	{
		int
			FIntC;
	}

	class Program
	{
		static void Main(string[] args)
		{
			Base
				a = new A(),
				b = new B(),
				c = new C();

			Type
				ta = a.GetType(),
				tb = b.GetType(),
				tc = c.GetType();

			Base
				na = (Base)Activator.CreateInstance(ta),
				nb = (Base)Activator.CreateInstance(tb),
				nc = (Base)Activator.CreateInstance(tc);

			TypeCode
				tca = Type.GetTypeCode(a.GetType()),
				tcb = Type.GetTypeCode(b.GetType()),
				tcc = Type.GetTypeCode(c.GetType());
		}
	}
}
