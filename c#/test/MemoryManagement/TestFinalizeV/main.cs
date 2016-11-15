using System;
using System.IO;

namespace TestFinalizeV
{
	class Program
	{
		static void Main(string[] args)
		{
			string
				FileName = "test.txt";

			if (File.Exists(FileName))
				File.Delete(FileName);

			using (StreamWriter file = new StreamWriter(FileName, true, System.Text.Encoding.GetEncoding(1251))) // oB!
			{
				file.WriteLine("1");
				file.WriteLine("2");
				file.WriteLine("3");
			}
		}
	}
}
