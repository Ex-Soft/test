using System;

namespace Proxy
{
	#region Sample1
	// "Subject"
	abstract class Subject
	{
		public abstract void Request();
	}

	// "RealSubject"
	class RealSubject : Subject
	{
		public override void Request()
		{
			Console.WriteLine("Called RealSubject.Request()");
		}
	}

	// "Proxy"
	class Proxy : Subject
	{
		private RealSubject _realSubject;
		
		public override void Request()
		{
			// Use 'lazy initialization'
			if (_realSubject == null)
			{
				_realSubject = new RealSubject();
			}

			_realSubject.Request();
		}
	}
	#endregion

	#region Sample2
	// "Subject"
	public interface IMath
	{
		double Add(double x, double y);
		double Sub(double x, double y);
		double Mul(double x, double y);
		double Div(double x, double y);
	}

	// "RealSubject"
	class Math : IMath
	{
		public double Add(double x, double y) { return x + y; }
		public double Sub(double x, double y) { return x - y; }
		public double Mul(double x, double y) { return x * y; }
		public double Div(double x, double y) { return x / y; }
	}

	// "Proxy Object"
	class MathProxy : IMath
	{
		Math math;

		public MathProxy()
		{
			math = new Math();
		}

		public double Add(double x, double y)
		{
			return math.Add(x, y);
		}

		public double Sub(double x, double y)
		{
			return math.Sub(x, y);
		}

		public double Mul(double x, double y)
		{
			return math.Mul(x, y);
		}

		public double Div(double x, double y)
		{
			return math.Div(x, y);
		}
	}
	#endregion

	class Program
	{
		static void Main()
		{
			#region Sample1
			Proxy proxy = new Proxy();

			proxy.Request();
			#endregion

			#region Sample2
			// Create math proxy
			MathProxy p = new MathProxy();

			// Do the math
			Console.WriteLine("4 + 2 = " + p.Add(4, 2));
			Console.WriteLine("4 - 2 = " + p.Sub(4, 2));
			Console.WriteLine("4 * 2 = " + p.Mul(4, 2));
			Console.WriteLine("4 / 2 = " + p.Div(4, 2));
			#endregion
		}
	}
}
