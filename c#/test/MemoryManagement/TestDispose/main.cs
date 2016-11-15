using System;
using System.Diagnostics;

namespace TestDispose
{
    class DisposableA : IDisposable
    {
        string
            sLog = "Application",
            sSource = "TestDispose";

        int
            eventID = 234;

        bool disposed = false;
    
        public DisposableA()
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, "DisposableA::DisposableA()", EventLogEntryType.Information, eventID);
        }

        ~DisposableA()
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, "DisposableA::~DisposableA()", EventLogEntryType.Information, eventID);

            Dispose(false);
        }

        public void Dispose()
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, "DisposableA::Dispose()", EventLogEntryType.Information, eventID);

            Dispose(true);
            GC.SuppressFinalize(this);
        }

         protected virtual void Dispose(bool disposing)
         {
             if (!EventLog.SourceExists(sSource))
                 EventLog.CreateEventSource(sSource, sLog);

             EventLog.WriteEntry(sSource, string.Format("DisposableA::Dispose({0})", disposing), EventLogEntryType.Information, eventID);

             if(!disposed)
             {
                 if(disposing)
                 {
                     
                 }

                 disposed = true;
             }
         }
    }

    class DisposableB : IDisposable
    {
        string
            sLog = "Application",
            sSource = "TestDispose";

        int
            eventID = 234;

        bool disposed = false;

        DisposableA
            disposableA;

        public DisposableB()
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, "DisposableB::DisposableB()", EventLogEntryType.Information, eventID);

            disposableA = new DisposableA();

            throw new Exception("OOPS!");
        }

        ~DisposableB()
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, "DisposableB::~DisposableB()", EventLogEntryType.Information, eventID);

            Dispose(false);
        }

        public void Dispose()
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, "DisposableB::Dispose()", EventLogEntryType.Information, eventID);

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, string.Format("DisposableB::Dispose({0})", disposing), EventLogEntryType.Information, eventID);

            if (!disposed)
            {
                if (disposing)
                {
                    if(disposableA!=null)
                        disposableA.Dispose();
                }

                disposed = true;
            }
        }
    }

    class DisposableC : IDisposable
    {
        bool disposed = false;

        public DisposableC()
        {
            Debug.WriteLine("DisposableC::DisposableC()");
        }

        ~DisposableC()
        {
            Debug.WriteLine("DisposableC::~DisposableC()");

            Dispose(false);
        }

        public void Dispose()
        {
            Debug.WriteLine("DisposableC::Dispose()");

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine(string.Format("DisposableC::Dispose({0})", disposing));

            if (!disposed)
            {
                if (disposing)
                {

                }

                disposed = true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
			var c = new DisposableC();
			c.Dispose();
			Debug.WriteLine(string.Format("c {0}= null", c != null ? "!" : "="));

            Foo(1);
            Foo(2);

            using (var disposable = new DisposableB())
            {
                // Упс! Метод Dispose не будет вызван ни для
                // DisposableB, ни для DisposableA
            }

            try
            {
                using (var disposable = new DisposableB())
                {
                }
            }
            catch (Exception eException)
            {
                ;
            }
        }

        static int Foo(int param = 0)
        {
            using (var disposable = new DisposableC())
            {
                if (param%2 == 0)
                    return 0;
            }

            return 1;
        }
    }
}
