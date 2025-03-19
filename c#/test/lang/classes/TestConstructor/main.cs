#define TEST_REQUIRED_PROPERTIES
#define TEST_CLASS_INITIALIZATION // http://www.interface.ru/home.asp?artId=7747
//#define TEST_OVERLOADING

using System;
using System.Diagnostics;

namespace TestConstructor
{
	/*
	public class Base
	{
	    private int
	        int1,
	        int2;

	    public Base(int i1, int i2)
	    {
	        int1 = i1;
	        int2 = i2;
	    }

	    public void Base(int i1, int i2) // Error CS0542 'base': member names cannot be the same as their enclosing type
	    {
	        int1 = i1;
	        int2 = i2;
	    }
	}
	*/

#if TEST_REQUIRED_PROPERTIES
	public class Order(string orderIdentifier = "")
	{
		public int OrderId { get; set; }
		public required string OrderIdentifier { get; init; } = orderIdentifier;
		public int? DealerId { get; set; }
	}
	
	public class Dealer
	{
		public int DealerId { get; set; }
		public string? DealerIdentifier { get; set; }
	}

	public class OrderWithDealer : Order
	{
		public string? DealerIdentifier { get; set; }

		public OrderWithDealer(Order order, Dealer? dealer = null) : base(order.OrderIdentifier)
		{
			OrderId = order.OrderId;
			OrderIdentifier = order.OrderIdentifier;
			DealerId = dealer?.DealerId;
			DealerIdentifier = dealer?.DealerIdentifier;
		}
	}
#endif

#if TEST_OVERLOADING
        public class TestClassWithConstructorOverloading
        {
            public string Message = "";

            public TestClassWithConstructorOverloading()
            {
                Message = "TestClassWithConstructorOverloading()";
            }

            public TestClassWithConstructorOverloading(string message)
            {
                Message = message + " TestClassWithConstructorOverloading(string)";
            }
        }
#endif

#if TEST_CLASS_INITIALIZATION
	public class MyClass1
	{
		public MyClass1() : this("DefaultValue1", "DefaultValue2", "DefaultValue3")
		{
		}

		public MyClass1(string str1) : this(str1, "DefaultValue2", "DefaultValue3")
		{
		}

		public MyClass1(string str1, string str2) : this(str1, str2, "DefaultValue3")
		{
		}

		public MyClass1(string str1, string str2, string str3)
		{
			this.str1 = str1;
			this.str2 = str2;
			this.str3 = str3;
		}

		string str1;
		string str2;
		string str3;
	}

	public class MyClass2
	{
		public MyClass2() : this("DefaultValue1")
		{
		}

		public MyClass2(string str1) : this(str1, "DefaultValue2")
		{
		}

		public MyClass2(string str1, string str2) : this(str1, str2, "DefaultValue3")
		{
		}

		public MyClass2(string str1, string str2, string str3)
		{
			this.str1 = str1;
			this.str2 = str2;
			this.str3 = str3;
		}

		string str1;
		string str2;
		string str3;
	}

#endif

	class Program
	{
		static void Main(string[] args)
		{
#if TEST_REQUIRED_PROPERTIES
			var order = new Order() { OrderId = 1, OrderIdentifier = "A", DealerId = 1 };
			var dealer = new Dealer() { DealerId = 1, DealerIdentifier = "B" };
			var orderWithDealer = new OrderWithDealer(order, dealer)
			{
				OrderIdentifier = "A"
			};
			Console.WriteLine(orderWithDealer);
#endif

#if TEST_OVERLOADING
		        var tmp = new TestClassWithConstructorOverloading();
                Console.WriteLine(tmp.Message);

                tmp = new TestClassWithConstructorOverloading("blah-blah-blah");
                Console.WriteLine(tmp.Message);
#endif

#if TEST_CLASS_INITIALIZATION

			test1();
			test2();

#endif

			Console.ReadLine();
		}

#if TEST_CLASS_INITIALIZATION

		static int count = 10000000;

		static void test1()
		{
			Stopwatch
				sw = Stopwatch.StartNew();

			MyClass1
				m;

			for (int i = 0; i < count; ++i)
			{
				m = new MyClass1();
			}

			sw.Stop();
			Console.WriteLine(sw.ElapsedMilliseconds);
		}

		static void test2()
		{
			Stopwatch
				sw = Stopwatch.StartNew();

			MyClass2
				m;

			for (int i = 0; i < count; ++i)
			{
				m = new MyClass2();
			}

			sw.Stop();
			Console.WriteLine(sw.ElapsedMilliseconds);
		}

#endif
	}
}
