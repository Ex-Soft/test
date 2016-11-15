using System;
using System.Threading;

public static class Program
{
	public static void Main()
	{
		Timer
			t = new Timer(TimerCallback, null, 0, 2000);

		Console.ReadLine();

		t=null;
	}

	private static void TimerCallback(Object o)
	{
		Console.WriteLine("In TimerCallback: " + DateTime.Now);
		GC.Collect();
	}
}
