using System;
using System.Globalization;
using System.Threading;

namespace TestConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] patterns = Thread.CurrentThread.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns();
                string str;
                DateTime dt;
                object oDt;

                //str = "04";
                //dt = DateTime.Parse(str, Thread.CurrentThread.CurrentCulture); // System.FormatException "Строка не распознана как действительное значение DateTime."
                //oDt = Convert.ChangeType(str, TypeCode.DateTime); // System.FormatException "Строка не распознана как действительное значение DateTime."

                str = "19.08.201";
                dt = DateTime.Parse(str, Thread.CurrentThread.CurrentCulture);
                
                str = "10.04";
                dt = DateTime.Parse(str, Thread.CurrentThread.CurrentCulture);
                oDt = Convert.ChangeType(str, TypeCode.DateTime);

                //str = "15.08.";
                //dt = DateTime.Parse(str, Thread.CurrentThread.CurrentCulture); // System.FormatException "Строка не распознана как действительное значение DateTime."
                //oDt = Convert.ChangeType(str, TypeCode.DateTime); // System.FormatException "Строка не распознана как действительное значение DateTime."

                str = "20.11";
                CultureInfo ci = new CultureInfo("ru-RU");
                ci.DateTimeFormat.MonthDayPattern = "d MMMM";
                dt = DateTime.Parse(str, ci /*Thread.CurrentThread.CurrentCulture*/);
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
