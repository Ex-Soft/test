using System;
using System.Diagnostics;

namespace TestFinalizeVII
{
	class A
	{
		int
			intvariable;

		public A():this(int.MinValue)
		{}

		public A(A A):this(A.IntVariable)
		{}

		public A(int param)
		{
			intvariable = param;
		}

		~A()
		{
			EventLog
				tmpEventLog = new EventLog();

			tmpEventLog.Source = "TestFinalizeVII";
			tmpEventLog.WriteEntry("~A()", EventLogEntryType.Information);
		}

		public int IntVariable
		{
			get
			{
				return intvariable;
			}
			set
			{
				intvariable = value;
			}
		}
	}

	class B
	{
		public A
			a;

		public B()
		{
			a=new A();
		}

		~B()
		{
			EventLog
				tmpEventLog = new EventLog();

			tmpEventLog.Source = "TestFinalizeVII";
			tmpEventLog.WriteEntry("~B()", EventLogEntryType.Information);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			B
				b=new B();

			b.a.IntVariable = 999;
		}
	}
}
