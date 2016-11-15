//#define GO_BY_DELEGATE
#define GO_BY_PARAMETERIZED_THREAD_START

using System;
using System.Threading;

namespace TestThreadsII
{
	class Program
	{
		static void Main(string[] args)
		{
			Thread.CurrentThread.Name = "main";
			Console.WriteLine(Thread.CurrentThread.Name+" start...");

			#if GO_BY_DELEGATE
				string
					text = "B4";

				Thread
					t = new Thread(delegate() { GoByDelegate(true, text); });
			#elif GO_BY_PARAMETERIZED_THREAD_START
				Thread
					t = new Thread(Go);
			#endif
			t.Name = "thread";

			#if GO_BY_DELEGATE
				text = "After";
				t.Start();
			#elif GO_BY_PARAMETERIZED_THREAD_START
				t.Start(true);
			#endif

			t.Join();
			//t.Join(Timeout.Infinite);

			#if GO_BY_DELEGATE
				GoByDelegate();
			#elif GO_BY_PARAMETERIZED_THREAD_START
				Go(false);
			#endif

			Console.WriteLine(Thread.CurrentThread.Name + " finish");
		}

		static void GoByDelegate(bool IsSleep=false, string Text="")
		{
			for (int i = 0; i < 5; ++i)
			{
				Console.WriteLine("Hello from " + Thread.CurrentThread.Name + (!string.IsNullOrWhiteSpace(Text) ? " (" + Text + ")" : string.Empty));
				if (IsSleep)
					Thread.Sleep(1000);
			}
		}

		static void Go(object IsSleep)
		{
			for (int i = 0; i < 5; ++i)
			{
				Console.WriteLine("Hello from " + Thread.CurrentThread.Name);
				if ((bool)IsSleep)
					Thread.Sleep(1000);
			}
		}

	}
}
