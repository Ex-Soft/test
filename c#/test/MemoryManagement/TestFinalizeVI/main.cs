using System;
using System.IO;

namespace TestFinalizeVI
{
	class Program
	{
		static void Main(string[] args)
		{
			string
				FileName = "test.txt";

			if (File.Exists(FileName))
				File.Delete(FileName);

			StreamWriter
				file = new StreamWriter(FileName, true, System.Text.Encoding.GetEncoding(1251));

			try
			{
				file.WriteLine("1");
				file.WriteLine("2");
				file.WriteLine("3");
			}
			finally
			{
				if (file != null)
					((IDisposable)file).Dispose(); // oB!
			}
		}
	}
}
