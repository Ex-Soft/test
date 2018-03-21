// http://www.codeproject.com/Articles/1117462/TFS-API-TFS-Work-Item-All-Changes-History

using System;
using System.Net;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace TestTFS
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WorkItemStore service;

                var projectCollection = new TfsTeamProjectCollection(new Uri("http://tfssrv.systtech.ru:8080/tfs/DefaultCollection"), new NetworkCredential("i.nozhenko@systtech.ru", "ruo581LTpSGc"));
                var workItemStore = projectCollection.GetService<WorkItemStore>();

                if (workItemStore != null)
                {
                    Console.WriteLine("TFS connected successfully");

                    var workItem = workItemStore.GetWorkItem(57502);
                    if (workItem != null)
                        Console.WriteLine(workItem.Title);
                }
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
