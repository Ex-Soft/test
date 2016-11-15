using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace TestVictimService
{
    class Program
    {
        static void Main(string[] args)
        {
            var endPointAddr = ConfigurationManager.AppSettings["endPointAddr"];

            if (string.IsNullOrEmpty(endPointAddr))
                return;

            const int maxThread = 30;

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < maxThread; ++i)
            {
                Thread thread = new Thread(RunVicimMethod);
                thread.Name = string.Format("Thread#{0}", i);
                threads.Add(thread);
                thread.Start(i);
            }

            Console.ReadLine();
        }

        static void RunVicimMethod(object data)
        {
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            int paramCount = (int)data * rnd.Next(10);
            string paramStr = string.Empty;

            if (paramCount <= 0)
                paramCount = 1;

            for (int i = 0; i < paramCount; ++i)
            {
                if (!string.IsNullOrWhiteSpace(paramStr))
                    paramStr += ";";

                paramStr += ((int)data * rnd.Next(10)).ToString();
            }

            try
            {
                int
                    result = 0;

                string
                    methodName = "VictimMethod",
                    resultStr = RunMethod(methodName, string.Format("{{\"paramString\":\"{0}\"}}", EscapeJson(paramStr)));

                Regex regex = new Regex(String.Format("(?:\\{{\"{0}Result\":)(.*)(?:\\}})", methodName));
                Match match = regex.Match(resultStr);

                if (match.Success && match.Groups.Count > 1)
                    result = int.Parse(match.Groups[1].Value);

                System.Diagnostics.Debug.WriteLine("result = {0} {1}", result, result == paramCount ? "oB!" : "Tampax");
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        static string RunMethod(string methodName, string @params)
        {
            string retValue = string.Empty;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", PatchEndPointAddress(GetEndPointAddress("endPointAddr")), methodName));

                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(@params);
                }

                using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var stream = new StreamReader(httpWebResponse.GetResponseStream()))
                        {
                            retValue = stream.ReadToEnd();
                        }
                    }
                    else
                        retValue = httpWebResponse.StatusCode.ToString();
                }
            }
            catch (Exception e)
            {
                retValue = e.Message;
            }

            return retValue;
        }

        static string GetEndPointAddress(string key)
        {
            string endPointAddress;

            try
            {
                endPointAddress = ConfigurationManager.AppSettings[key];

                if (string.IsNullOrWhiteSpace(endPointAddress))
                    endPointAddress = "http://localhost/VictimService/";
            }
            catch (Exception e)
            {
                endPointAddress = "";
            }

            return endPointAddress;
        }

        static string PatchEndPointAddress(string endPointAddress)
        {
            if (string.IsNullOrWhiteSpace(endPointAddress))
                return endPointAddress;

            if (!endPointAddress.EndsWith("/"))
                endPointAddress += "/";

            return endPointAddress;
        }

        static string EscapeJson(string str)
        {
            return !string.IsNullOrEmpty(str) ? str.Replace("\\", "\\\\").Replace("/", "\\/").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r") : str;
        }
    }
}
