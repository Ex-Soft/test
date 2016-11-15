#define TEST_INNER

using System;

namespace TestScope
{
	class Program
	{
		static void Main(string[] args)
		{
			#if TEST_INNER
				for (int i = 0; i < 5; ++i)
				{
					string
						FormatString = "i={0}";

					Console.WriteLine(string.Format(FormatString, i));
				}
			#else
				string
					FormatString = "i={0}";

				for (int i = 0; i < 5; ++i)
					Console.WriteLine(string.Format(FormatString, i));
			#endif
		}
	}
}
