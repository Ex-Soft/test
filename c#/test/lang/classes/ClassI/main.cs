using System;

namespace ClassI
{
	public class A
	{
		public virtual void Show()
		{
			Console.WriteLine("A");
		}

		public void ShowCaller()
		{
			Show();
		}
	}

	public class B : A
	{
		public override void Show()
		{
			Console.WriteLine("B");
		}
	}

	class ClassI
	{
		static void Main(string[] args)
		{
			A
				a = new A(),
				_a_;

			a.Show(); // A
			a.ShowCaller(); // A

			B
				b = new B();

			b.Show(); // B
			b.ShowCaller(); // B

			_a_ = b;
			_a_.Show(); // B
			_a_.ShowCaller(); // B
		}
	}
}
