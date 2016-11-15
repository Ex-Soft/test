using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace TestConnectionPool
{
    class TaskParam
    {
        public int
            id,
            mSec;

        public string connectionString;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string
                connectionString;

            int
                threadsMax,
                mSec;

            if (args.Length < 3
                || string.IsNullOrWhiteSpace(connectionString = args[0])
                || !int.TryParse(args[1], out threadsMax)
                || !int.TryParse(args[2], out mSec))
                return;

            Console.WriteLine("{0}\tMain thread started...", DateTime.Now.ToString("HH:mm:ss.fffffff"));

            Action<object> action = Run;
            Task[] tasks = new Task[threadsMax];

            for (int i = 0; i < threadsMax; ++i)
            {
                TaskParam param = new TaskParam { id = i, connectionString = connectionString, mSec = mSec };
                tasks[i] = Task.Factory.StartNew(action, param);
            }

            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException e)
            {
                Console.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
                }
            }

            Console.WriteLine("{0}\tMain thread finished", DateTime.Now.ToString("HH:mm:ss.fffffff"));

            OnEnd();
        }

        static void Run(object param)
        {
            TaskParam taskParam;

            if ((taskParam = param as TaskParam) == null)
                return;

            Console.WriteLine("{0}\t{1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), taskParam.id);

            Random
                rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine("{0}\t{1} i={2}", DateTime.Now.ToString("HH:mm:ss.fffffff"), taskParam.id, i);
                Thread.Sleep(taskParam.mSec * rnd.Next(10));

                SqlConnection
                    conn = null;

                try
                {
                    conn = new SqlConnection(taskParam.connectionString);
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();
                    Object tmpObject;

                    long?
                        spid = null;

                    string
                        systemUser = null;

                    cmd.CommandText = "select @@spid";
                    if ((tmpObject  = cmd.ExecuteScalar()) != null && !Convert.IsDBNull(tmpObject))
                        spid = Convert.ToInt64(tmpObject);

                    cmd.CommandText = "select system_user";
                    if ((tmpObject = cmd.ExecuteScalar()) != null && !Convert.IsDBNull(tmpObject))
                        systemUser = Convert.ToString(tmpObject);

                    Console.WriteLine("{0}\t{1} i={2} @@spid = {3} system_user = \"{4}\"", DateTime.Now.ToString("HH:mm:ss.fffffff"), taskParam.id, i, spid.HasValue ? spid.Value.ToString() : "null", !string.IsNullOrWhiteSpace(systemUser) ? systemUser : "null");

                    conn.Close();
                    conn = null;
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        conn = null;
                    }
                }
            }

            Console.WriteLine("{0}\t{1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), taskParam.id);
        }

        static void OnEnd()
        {
            Console.WriteLine("{0}\tOnEnd()", DateTime.Now.ToString("HH:mm:ss.fffffff"));
        }
    }
}
