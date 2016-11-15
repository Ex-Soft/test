using System;
using System.IO;

namespace TestFinalizeIII
{
	class Program
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

			void IDisposable.Dispose()
			{
				if (file != null && file.BaseStream!=null && file.BaseStream.CanWrite)
					file.Close();
			}

			~ClassWithFinalize()
			{
				((IDisposable)this).Dispose();
			}
		}

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
