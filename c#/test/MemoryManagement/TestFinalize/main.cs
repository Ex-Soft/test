using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace TestFinalize
{
	class Program
	{
		public class ClassWithFinalize : IDisposable
		{
			StreamWriter
				file;

			bool
				disposed = false;

			public ClassWithFinalize()
			{
                Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}");

                string
					FileName = "log.log";

				if (File.Exists(FileName))
					File.Delete(FileName);

				try
				{
					file = new StreamWriter(FileName, true, System.Text.Encoding.GetEncoding(1251));
				}
				catch
				{
					GC.SuppressFinalize(this);
					throw;
				}
			}

			public void Write(string str)
			{
				file.Write(str);
			}

			public void WriteLine(string str)
			{
				file.WriteLine(str);
			}
			
			~ClassWithFinalize()
			{
                Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}");

                Dispose(false);
			}
			
			public void Dispose()
			{
                Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");

                Dispose(true);
				GC.SuppressFinalize(this);
			}

			protected virtual void Dispose(bool disposing)
			{
                Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}({disposing})");

                if (!disposed)
				{
					if (disposing)
					{
						if(file!=null)
							file.Dispose();
					}
					disposed = true;
				}
			}
		}

		static void Main(string[] args)
		{
			ClassWithFinalize
				a = new ClassWithFinalize();

			a.WriteLine("Line# 1");
			a.WriteLine("Line# 2");
			a.WriteLine("Line# 3");

			a.Dispose(); // oB!
		}
	}
}
