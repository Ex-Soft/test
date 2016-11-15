using System;
using System.IO;

namespace TestFinalizeII
{
	public class ClassWithFinalize : IDisposable
	{
		StreamWriter
			file;

		public ClassWithFinalize()
		{
			string
				FileName = "log.log";

			if (File.Exists(FileName))
				File.Delete(FileName);

			file = new StreamWriter(FileName, true, System.Text.Encoding.GetEncoding(1251));
		}

		public void Write(string str)
		{
			file.Write(str);
		}

		public void WriteLine(string str)
		{
			file.WriteLine(str);
		}

		public void Dispose()
		{
			if (file == null)
				return;

			file.Flush();
			file.Close();
			file.Dispose();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			ClassWithFinalize
				a = new ClassWithFinalize();

			a.WriteLine("Line# 1");
			a.WriteLine("Line# 2");
			a.WriteLine("Line# 3");

			// Log is empty!!!
		}
	}
}
