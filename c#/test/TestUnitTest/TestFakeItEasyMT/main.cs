using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using FakeItEasy;

using static System.Console;

namespace TestFakeItEasyMT
{
    public interface II
    {
        NameValueCollection QueryString { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fake = A.Fake<II>();

            Action<object> action = ToDictionary;

            const int
                threadsMax = 100,
                mSec = 100;

            var tasks = new Task[threadsMax];

            for (var i = 0; i < threadsMax; ++i)
            {
                var param = new TaskParam { i = i, mSec = mSec, fake = fake };
                tasks[i] = Task.Factory.StartNew(action, param);
            }

            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException e)
            {
                WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
                for (var i = 0; i < e.InnerExceptions.Count; i++)
                {
                    WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[i]);
                }
            }

            ReadLine();
        }

        static void ToDictionary(object o)
        {
            if (!(o is TaskParam param))
                return;

            WriteLine("{0}\t{1} started...", DateTime.Now.ToString("HH:mm:ss.fffffff"), param.i);

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            for (var c = 'a'; c <= 'z'; ++c)
                queryString[new string(c, 1)] = new string(c, 2);

            A.CallTo(() => param.fake.QueryString).Returns(queryString);

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(param.mSec * rnd.Next(10));

            var result = ToDictionaryReal(param.fake);

            WriteLine("{0}\t{1} finished", DateTime.Now.ToString("HH:mm:ss.fffffff"), param.i);
        }

        static Dictionary<string, string> ToDictionaryReal(II smth)
        {
            var result = smth.QueryString.AllKeys.AsEnumerable()
                .Select(k => new { key = k, value = smth.QueryString[k] })
                .ToDictionary(item => item.key, item => item.value);

            return result;
        }
    }

    public class TaskParam
    {
        public int i { get; set; }
        public int mSec { get; set; }
        public II fake { get; set; }
    }
}
