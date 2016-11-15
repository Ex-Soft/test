using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestClassWithTask
{
    public class ClassWithTask
    {
        DateTime _p2;
        Task _task;

        public DateTime P1 { get; private set; }

        public DateTime P2
        {
            get
            {
                if (!_task.IsCompleted)
                    _task.Wait();

                return _p2;
            }
        }

        public ClassWithTask(DateTime p1)
        {
            System.Diagnostics.Debug.WriteLine("ClassWithTask.ClassWithTask(DateTime p1) starting... (thread ID = {0})", Thread.CurrentThread.ManagedThreadId);

            P1 = p1;

            System.Diagnostics.Debug.WriteLine("ClassWithTask.ClassWithTask(DateTime p1) b4 Task.Run((Action)SetP2)");
            _task = Task.Factory.StartNew(SetP2);
            System.Diagnostics.Debug.WriteLine("ClassWithTask.ClassWithTask(DateTime p1) after Task.Run((Action)SetP2)");

            System.Diagnostics.Debug.WriteLine("ClassWithTask.ClassWithTask(DateTime p1) finished");
        }

        public ClassWithTask(ClassWithTask obj)
        {
            System.Diagnostics.Debug.WriteLine("ClassWithTask.ClassWithTask(ClassWithTask obj) starting... (thread ID = {0})", Thread.CurrentThread.ManagedThreadId);

            P1 = obj.P1;
            _p2 = obj.P2;

            System.Diagnostics.Debug.WriteLine("ClassWithTask.ClassWithTask(ClassWithTask obj) finished");
        }

        void SetP2()
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine("ClassWithTask.SetP2() starting... (thread ID = {0})", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
                _p2 = DateTime.Now;
                //System.Diagnostics.Debug.WriteLine("ClassWithTask.SetP2() finished");
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("{0}: \"{1}\"", e.GetType().FullName, e.Message);
            }
        }

        public override string ToString()
        {
            return string.Format("{{P1: {0}, P2: {1}}}", P1.ToString("HH:mm:ss.fffffff"), P2.ToString("HH:mm:ss.fffffff"));
        }
    }
}
