using System;
using System.Diagnostics;

namespace Singleton
{
	class Program
	{
		public sealed class Singleton : IDisposable
		{
			static volatile Singleton _instance;
            static readonly object SyncRoot = new Object();
            bool _disposed = false;

			Singleton()
			{}

			public static Singleton Instance
			{
			    get
			    {
			        if (_instance == null)
			        {
			            lock (SyncRoot)
			            {
			                if (_instance == null)
			                    _instance = new Singleton();
			            }
			        }

			        return _instance;
			    }
			}

            public void Dispose()
            {
                Debug.WriteLine("public void Dispose()");

                Dispose(true);
                GC.SuppressFinalize(this);
            }

            void Dispose(bool disposing)
            {
                Debug.WriteLine(string.Format("void Dispose({0})", disposing));

                if (_disposed)
                    return;

                if (disposing)
                {
                    // Free any other managed objects here. 
                    //
                }

                // Free any unmanaged objects here. 
                //
                _disposed = true;
            }

            ~Singleton()
            {
                Debug.WriteLine("~Singleton()");

                Dispose(false);
            }
        }

		static void Main()
		{
			Singleton
				s1 = Singleton.Instance,
				s2 = Singleton.Instance;

			if (s1 == s2)
			{
				Console.WriteLine("Objects are the same instance");
			}

            if (ReferenceEquals(s1, s2))
            {
                Console.WriteLine("Objects are the same instance");
            }

		    //s1.Dispose();
            s1 = s2 = null;

            GC.Collect();
		}
	}
}
