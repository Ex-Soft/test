using System;

namespace TestExceptionIII
{
	class UserTestException:ApplicationException
	{
		public int
			ErrorCode;

		public UserTestException(int aErrorCode):base()
		{
			ErrorCode=aErrorCode;
		}

		public UserTestException(int aErrorCode, string aMessage):base(aMessage)
		{
			ErrorCode=aErrorCode;
		}

		public override string ToString()
		{
			return("ErrorCode: "+ErrorCode+" Message: "+Message);
		}
	}

	class ExceptA:ApplicationException
	{
		public ExceptA():base()
		{}

		public ExceptA(string aMessage):base(aMessage)
		{}

		public override string ToString()
		{
			return(Message);
		}
	}

	class ExceptB:ExceptA
	{
		public ExceptB():base()
		{}

		public ExceptB(string aMessage):base(aMessage)
		{}

		public override string ToString()
		{
			return(Message);
		}
	}

	class C
	{
		private int
			Fi;

		public C():this(int.MinValue)
		{}

		public C(C obj):this(obj.i)
		{}

		public C(int ai)
		{
			i=ai;
		}

		public int i
		{
			set
			{
				if(Fi!=value)
					Fi=value;
			}
			get
			{
				return(Fi);
			}
		}
	}

	class TestException
	{
		[STAThread]
		public static void Main()
		{
			C
				tmpC=new C(123);

			Console.WriteLine(TestFinally(tmpC));
			Console.WriteLine(tmpC.i);

			long
				tmpLong;

			string
				tmpString="qwerty";

			try
			{
				tmpLong=Convert.ToInt64(tmpString);
			}
			catch(FormatException eException)
			{
				Console.WriteLine("Exception.GetType().Name: \""+eException.GetType().Name+"\""+Environment.NewLine
					+"Exception.GetType().FullName: \""+eException.GetType().FullName+"\""+Environment.NewLine
					+"Exception.Message: \""+eException.Message+"\""+Environment.NewLine
					+"Exception.Source: \""+eException.Source+"\""+Environment.NewLine
					+"Exception.StackTrace:"+Environment.NewLine+eException.StackTrace+Environment.NewLine
					+"Exception.TargetSite: \""+eException.TargetSite+"\""+Environment.NewLine
					+"Exception.ToString(): \""+eException.ToString()+"\"");
			}
			finally
			{
				tmpLong=long.MinValue;
			}

			try
			{
				tmpLong=Convert.ToInt64(tmpString);
			}
			catch(FormatException eException)
			{
				Console.WriteLine("Exception.GetType().Name: \""+eException.GetType().Name+"\""+Environment.NewLine
									+"Exception.GetType().FullName: \""+eException.GetType().FullName+"\""+Environment.NewLine
									+"Exception.Message: \""+eException.Message+"\""+Environment.NewLine
									+"Exception.Source: \""+eException.Source+"\""+Environment.NewLine
									+"Exception.StackTrace:"+Environment.NewLine+eException.StackTrace+Environment.NewLine
									+"Exception.TargetSite: \""+eException.TargetSite+"\""+Environment.NewLine
									+"Exception.ToString(): \""+eException.ToString()+"\"");
			}
			catch(OverflowException eException)
			{
				Console.WriteLine("Exception.Message: \""+eException.Message+"\"");
			}
			catch(Exception eException)
			{
				Console.WriteLine("Exception.GetType().Name: \""+eException.GetType().Name+"\""+Environment.NewLine
					+"Exception.GetType().FullName: \""+eException.GetType().FullName+"\""+Environment.NewLine
					+"Exception.Message: \""+eException.Message+"\""+Environment.NewLine
					+"Exception.Source: \""+eException.Source+"\""+Environment.NewLine
					+"Exception.StackTrace:"+Environment.NewLine+eException.StackTrace+Environment.NewLine
					+"Exception.TargetSite: \""+eException.TargetSite+"\""+Environment.NewLine
					+"Exception.ToString(): \""+eException.ToString()+"\"");
			}

			int[]
				nums=new int[4];

			int
				i;

			try
			{
				for(i=0; i<10; ++i)
				{
					nums[i]=i;
					Console.WriteLine("nums[{0}]={1}",i,nums[i]);
				}
				Console.WriteLine("Этот текст не отображается.");
			}
			catch(IndexOutOfRangeException eException)
			{
				Console.WriteLine(eException.Message);
			}
			Console.WriteLine("После catch-инструкции.");

			for(i=0; i<5; ++i)
			{
				try
				{
					if(i==0)
						throw(new ExceptA("Перехват исключения типа ExceptA."));
					else if(i==1)
						throw(new ExceptB("Перехват исключения типа ExceptB."));
					else if(i==2)
						throw(new UserTestException(10));
					else if(i==3)
						throw(new UserTestException(100,"KARAUL!!!"));
					else
						throw new Exception();
				}
				catch(UserTestException eException)
				{
					Console.WriteLine("ErrorCode: "+eException.ErrorCode+" Message: "+eException.Message);
				}
				catch(ExceptB eException)
				{
					Console.WriteLine(eException);
				}
				catch(ExceptA eException)
				{
					Console.WriteLine(eException);
				}
				catch(Exception eException)
				{
					Console.WriteLine(eException);
				}
			}

			try
			{
				int
					a=1,
					b=0,
					c;

				c=a/b;
			}
			catch(DivideByZeroException eException)
			{
				Console.WriteLine(eException);
				throw;
			}
			catch(Exception eException)
			{
				Console.WriteLine(eException);
			}
		}

		static int TestFinally(C ac)
		{
			int
				a=1,
				b=0,
				c;

			try
			{
				try
				{
					Console.WriteLine(Environment.NewLine+Environment.StackTrace+Environment.NewLine);
					c=a/b;
				}
				catch
				{
					a=2;
					ac.i=456;
					return(a);
				}
			}
			finally
			{
				a=3;
				ac.i=789;
			}

			return(a);
		}
	}
}
