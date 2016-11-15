using System;
using System.Diagnostics;

namespace TestFinalizeVIII
{
	public class A : IDisposable
	{
		bool
			disposed = false;

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

			tmpEventLog.Source = "TestFinalizeVIII";
			tmpEventLog.WriteEntry("A::~A()", EventLogEntryType.Information);

			Dispose(false);
		}

		public void Dispose()
		{
			EventLog
				tmpEventLog = new EventLog();

			tmpEventLog.Source = "TestFinalizeVIII";
			tmpEventLog.WriteEntry("A::Dispose()", EventLogEntryType.Information);

			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			EventLog
				tmpEventLog = new EventLog();

			tmpEventLog.Source = "TestFinalizeVIII";
			tmpEventLog.WriteEntry("A::Dispose("+disposing.ToString().ToLower()+")", EventLogEntryType.Information);

			if (!disposed)
			{
				if (disposing)
				{
					;
				}
				disposed = true;
			}
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

	public class B : IDisposable
	{
		bool
			disposed = false;

		A
			a;

		public B():this(int.MinValue)
		{}

		public B(B obj):this(obj.a.IntVariable)
		{}

		public B(int param)
		{
			a = new A(param);
		}

		~B()
		{
			EventLog
				tmpEventLog = new EventLog();

			tmpEventLog.Source = "TestFinalizeVIII";
			tmpEventLog.WriteEntry("B::~B()", EventLogEntryType.Information);

			Dispose(false);
		}

		public void Dispose()
		{
			EventLog
				tmpEventLog = new EventLog();

			tmpEventLog.Source = "TestFinalizeVIII";
			tmpEventLog.WriteEntry("B::Dispose()", EventLogEntryType.Information);

			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			EventLog
				tmpEventLog = new EventLog();

			tmpEventLog.Source = "TestFinalizeVIII";
			tmpEventLog.WriteEntry("B::Dispose(" + disposing.ToString().ToLower() + ")", EventLogEntryType.Information);

			if (!disposed)
			{
				if (disposing)
				{
					if (a != null)
						a.Dispose();
				}
				disposed = true;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			B
				b=new B();

			b.Dispose();
		}
	}
}
