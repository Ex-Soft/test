using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace TestWindowsServiceWithWebServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(ToDouble("123,45"));

                Console.WriteLine(RunMethod("Add", 3, 2));
                Console.WriteLine(RunMethod("Subtract", 3, 2));
                Console.WriteLine(RunMethod("Multiply", 3, 2));
                Console.WriteLine(RunMethod("Divide", 3, 2));
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        static double RunMethod(string methodName, double n1, double n2)
        {
            var retValue = 0.0;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://localhost/Calculator/{0}", methodName));
            var json = string.Format("{{\"n1\":{0},\"n2\":{1}}}", n1, n2);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            httpWebRequest.Timeout = 1000000;

            string result;
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var stream = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                result = stream.ReadToEnd();
            }

            var regex = new Regex(string.Format("(?<=\"{0}Result\":).*(?=\\}})", methodName));
            var match = regex.Match(result);

            if (match.Success)
                double.TryParse(match.Value, out retValue);

            return retValue;
        }

        static double ToDouble(string str)
        {
            var retValue = 0.0;
            var methodName = "ToDouble";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("http://localhost/Calculator/{0}", methodName));
            var json = string.Format("{{\"str\":\"{0}\"}}", str);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            httpWebRequest.Timeout = 1000000;

            string result;
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var stream = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                result = stream.ReadToEnd();
            }

            var regex = new Regex(string.Format("(?:\\{{\"{0}Result\":)(.*)(?:,\"success\":)(.*)(?:\\}})", methodName));
            var match = regex.Match(result);

            if (!match.Success || match.Groups.Count <= 2)
                return retValue;

            bool success;
            success = bool.TryParse(match.Groups[2].Value, out success);

            if(success)
                double.TryParse(match.Groups[1].Value, out retValue);

            return retValue;
        }
    }
}
