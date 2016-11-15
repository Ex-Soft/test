using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Threading;

namespace TestServiceWithThreads
{
	/// <summary>
	/// Summary description for ServiceWithThreads
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class ServiceWithThreads : System.Web.Services.WebService
	{
		const string
			ListThreadsSignature = "ServiceWithThreadsListThreads";

		[WebMethod]
		public string Start()
		{
			ThreadWithLogger
				ThreadWithLogger = null;

			List<ThreadWithLogger>
				ListThreadsWithLoggers;

			if ((ListThreadsWithLoggers = (List<ThreadWithLogger>)Application[ListThreadsSignature]) == null)
				Application[ListThreadsSignature] = ListThreadsWithLoggers = new List<ThreadWithLogger>();

			for (int i = 0; i < 5; ++i)
			{
				ThreadWithLogger = new ThreadWithLogger(i, (i + 1) * 10, (i + 1) * 1000);
				ListThreadsWithLoggers.Add(ThreadWithLogger);
			}

			return DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fffffff tt");
		}

		[WebMethod]
		public string Show()
		{
			string
				result="List is empty";

			List<ThreadWithLogger>
				ListThreadsWithLoggers;

			if ((ListThreadsWithLoggers = (List<ThreadWithLogger>)Application[ListThreadsSignature]) != null)
			{

				result = string.Empty;
				ListThreadsWithLoggers.ForEach((item) =>
				{
					if (result != string.Empty)
						result += " ";

					result += item.Thread.Name + "(IsAlive=" + item.Thread.IsAlive.ToString().ToLower() + ")";
				});
			}

			return result;
		}

		[WebMethod]
		public string Stop()
		{
			string
				result = "List is empty";

			List<ThreadWithLogger>
				ListThreadsWithLoggers;

			if ((ListThreadsWithLoggers = (List<ThreadWithLogger>)Application[ListThreadsSignature]) != null)
			{

				result = string.Empty;
				ListThreadsWithLoggers.ForEach((item) =>
				{
					if (!item.Thread.IsAlive)
						return;

					item.Logger.SetShouldStop();

					if (result != string.Empty)
						result += " ";

					result += item.Thread.Name + "(Stopped)";
				});
			}

			return result;
		}
	}
}