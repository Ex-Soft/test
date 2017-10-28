using System;

namespace AnyTest
{
	class Program
	{
		static void Main(string[] args)
		{
			decimal
				decimalVictim = 1.123456789010000m;

			string
				decimalVictimStr = decimalVictim.ToString();

			Console.WriteLine(decimalVictimStr);
			ShowScale(decimalVictim);
			Console.WriteLine(decimalVictim.ToString("G29"));
			decimalVictimStr = string.Format("{0:G29}", decimalVictim);
			Console.WriteLine(decimalVictimStr);
			decimalVictimStr = string.Format("{0:g29}", decimalVictim);
			Console.WriteLine(decimalVictimStr);

			decimalVictim = 1m;
			Console.WriteLine(decimalVictim.ToString("G29"));
			decimalVictimStr = string.Format("{0:G29}", decimalVictim);
			Console.WriteLine(decimalVictimStr);
			decimalVictimStr = string.Format("{0:g29}", decimalVictim);
			Console.WriteLine(decimalVictimStr);

			decimalVictim = 1.10m;
			Console.WriteLine(decimalVictim.ToString("G29"));
			decimalVictimStr = string.Format("{0:G29}", decimalVictim);
			Console.WriteLine(decimalVictimStr);
			decimalVictimStr = string.Format("{0:g29}", decimalVictim);
			Console.WriteLine(decimalVictimStr);
		}

		static void ShowScale(decimal value)
		{
			int[] parts = decimal.GetBits(value);
			byte scale = (byte)((parts[3] >> 16) & 0x7F);

			Console.WriteLine("{0} {1}", value, scale);
		}
	}
}
