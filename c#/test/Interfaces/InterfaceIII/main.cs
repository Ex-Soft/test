using System;

namespace InterfaceIII
{
    public interface IA
    {
        void FooA();
    }

    public interface IB
    {
        void FooB();
    }

    public class A : IA
    {
        public void FooA()
        {
            Console.WriteLine("A:FooA()");
        }
    }

    public class B : IB
    {
        public void FooB()
        {
            Console.WriteLine("B:FooB()");
        }
    }

    public class AB : IA, IB
    {
        public void FooA()
        {
            Console.WriteLine("AB:FooA()");
        }

        public void FooB()
        {
            Console.WriteLine("AB:FooB()");
        }
    }

	public interface ITestInterface
	{
		void Foo();
	}

    public class TestClassA : ITestInterface
    {
        public void Foo()
        {
            Console.WriteLine("TestClassA:Foo()");
        }
    }

    public class TestClassB : ITestInterface
    {
        public void Foo()
        {
            Console.WriteLine("TestClassB:Foo()");
        }
    }

	public class TestClass : ITestInterface
	{
		public void Foo()
		{
			Console.WriteLine("Foo()");
		}

		public void FooFoo()
		{
			Console.WriteLine("FooFoo()");
		}
	}

    public interface IBase
    {
        int A { get; set; }

        void F1();
    }

    public class CBase : IBase
    {
        public int A { get; set; }

        public void F1() { Console.WriteLine("CBase.F1()"); }
    }

    public interface IDerivered : IBase
    {
        int B { get; set; }

        void F2();
    }

    public class CDerived : CBase
    {
        public int B { get; set; }

        public void F2() { Console.WriteLine("CDerived.F2()"); }
    }

	class Program
	{
		static void Main(string[] args)
		{
            TestClassA
                testClassA = new TestClassA();

            TestClassB
                testClassB = new TestClassB();

		    ITestInterface
		        testInterface;

		    testInterface = testClassA;
            if(testInterface is TestClassA)
                Console.WriteLine("TestClassA");
            if (testInterface is TestClassB)
                Console.WriteLine("TestClassB");

            testInterface = testClassB;
            if (testInterface is TestClassA)
                Console.WriteLine("TestClassA");
            if (testInterface is TestClassB)
                Console.WriteLine("TestClassB");

			TestClass
				t = new TestClass();

			t.Foo();
			t.FooFoo();

            A
                a=new A();

            B
                b=new B();

            AB
                ab=new AB();

		    IA
		        ia;

		    IB
		        ib;

            if((ia=a as IA)!=null)
                ia.FooA();
            if ((ia = ab as IA) != null)
                ia.FooA();
            if ((ib = b as IB) != null)
                ib.FooB();
            if ((ib = ab as IB) != null)
                ib.FooB();

		    CDerived
		        derived = new CDerived { A = 1, B = 2 };

		    IDerivered
		        iDerivered = derived as IDerivered;

            if(iDerivered != null)
                iDerivered.F2();
		}
	}
}
