using System;

namespace TestFinalizeIV
{
	class Program
	{
		public class ClassWithFinalize : IDisposable
		{
			#region IDisposable Members

			public void Dispose()
			{
				throw new NotImplementedException();
			}

			#endregion

			#region IDisposable Members

			void IDisposable.Dispose()
			{
				throw new NotImplementedException();
			}

			#endregion
		}

		static void Main(string[] args)
		{
		}
	}
}
