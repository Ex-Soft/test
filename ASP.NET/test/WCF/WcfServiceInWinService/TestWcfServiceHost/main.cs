using System;
using TestWcfServiceHost.WcfServiceHostReference;

namespace TestWcfServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new WcfServiceHostClient();

                var result = client.GetData(1);
                Console.WriteLine(result);

                CompositeType
                    compositeTypeIn = new CompositeType { BoolValue = true, StringValue = "StringValue" },
                    compositeTypeOut = client.GetDataUsingDataContract(compositeTypeIn);

                Console.WriteLine("{{ BoolValue = \"{0}\", StringValue =\"{1}\" }}", compositeTypeOut.BoolValue, compositeTypeOut.StringValue);
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
